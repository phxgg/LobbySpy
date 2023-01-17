using Ekko;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LobbySpy
{

    public partial class frmMain : Form
    {
        private static List<LobbyHandler> _handlers = new List<LobbyHandler>();
        private static bool _update = true;

        public frmMain()
        {
            InitializeComponent();
        }

        // Update form from inside different threads
        delegate void EnableFormCallback(bool enable);
        private void EnableForm(bool enable)
        {
            if (this.btnMultiOpgg.InvokeRequired
                || this.lbLobby.InvokeRequired)
            {
                EnableFormCallback d = new EnableFormCallback(EnableForm);
                this.Invoke(d, new object[] { enable });
            }
            else
            {
                this.lbLobby.Items.Clear();
                this.lbLobby.Enabled = enable;
                this.btnMultiOpgg.Enabled = enable;
            }
        }

        delegate void AddToLobbyCallback(string summonerName);
        private void AddToLobby(string summonerName)
        {
            if (this.lbLobby.InvokeRequired)
            {
                AddToLobbyCallback d = new AddToLobbyCallback(AddToLobby);
                this.Invoke(d, new object[] { summonerName });
            }
            else
            {
                this.lbLobby.Items.Add(summonerName);
            }
        }

        delegate void SetStatusCallback(string status);
        private void SetStatus(string status)
        {
            if (this.lblStatus.InvokeRequired)
            {
                SetStatusCallback d = new SetStatusCallback(SetStatus);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                this.lblStatus.Text = status;
            }
        }

        delegate void WriteHistoryCallback(string text);
        private void WriteHistory(string text)
        {
            if (this.rtbHistory.InvokeRequired)
            {
                WriteHistoryCallback d = new WriteHistoryCallback(WriteHistory);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.rtbHistory.Text += text + "\n";
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            ConsoleHelper.CreateConsole();
            Console.WriteLine("frmMain Loaded.");
#endif
            var watcher = new LeagueClientWatcher();
            watcher.OnLeagueClient += (clientWatcher, client) =>
            {
                // Currently only 1 client is supported.
                // Kill process if clients are more than 1
                if (clientWatcher.Clients.Count > 1)
                {
                    Process.GetProcessById(client.Pid).Kill();
                }
#if DEBUG
                Console.WriteLine("Client ID: " + client.Pid);
#endif
                SetStatus("Connected to client PID: " + client.Pid.ToString());

                var handler = new LobbyHandler(new LeagueApi(client.ClientAuthInfo.RiotClientAuthToken,
                    client.ClientAuthInfo.RiotClientPort));

                _handlers.Add(handler);

                handler.OnUpdate += (lobbyHandler, names) => { _update = true; };
                handler.Start();

                _update = true;
            };

            // Observe for new clients
            new Thread(async () => { await watcher.Observe(); })
            {
                IsBackground = true
            }.Start();

            // Update lobby
            new Thread(() => { UpdateLobby(); })
            {
                IsBackground = true
            }.Start();

            btnMultiOpgg.Click += BtnMultiOpgg_Click;
        }

        private void BtnMultiOpgg_Click(object sender, EventArgs e)
        {
            try
            {
                var region = _handlers[0].GetRegion();
                Process.Start($"https://www.op.gg/multisearch/{region ?? LobbySpy.Region.EUW}?summoners={string.Join(",", _handlers[0].GetSummoners())}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLobby()
        {
            while (true)
            {
                if (_update)
                {
                    for (int i = 0; i < _handlers.Count; i++)
                    {
                        if (_handlers[i].GetSummoners().Length != 0)
                        {
                            WriteHistory("* New lobby");
                            //WriteHistory(string.Join(",", _handlers[0].GetSummoners()));
                            EnableForm(true);
                        }
                        else
                        {
                            EnableForm(false);
                        }

                        for (int j = 0; j < _handlers[i].GetSummoners().Length; j++)
                        {
#if DEBUG
                            Console.WriteLine(_handlers[i].GetSummoners()[j]);
#endif
                            WriteHistory(_handlers[i].GetSummoners()[j]);
                            WriteHistory("");

                            AddToLobby(_handlers[i].GetSummoners()[j]);
                        }
                    }

                    _update = false;
                }

                Thread.Sleep(2000);
            }
        }

        private void lbLobby_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbLobby.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string summonerName = this.lbLobby.Items[index].ToString();
                var region = _handlers[0].GetRegion();
                Process.Start($"https://www.op.gg/summoners/{region ?? LobbySpy.Region.EUW}/{summonerName}");                
            }
        }

        private void toolStripMenuQuit_Click(object sender, EventArgs e)
        {
            // Quit application
            System.Windows.Forms.Application.Exit();
        }

        private void toolStripMenuItemCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Built by phxgg\n\nThis is actually Riotphobia's LobbyReveal but with a UI.\nCheck out their work at https://github.com/Riotphobia",
                "Credits",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        private void rtbHistory_TextChanged(object sender, EventArgs e)
        {
            rtbHistory.SelectionStart = rtbHistory.Text.Length;
            rtbHistory.ScrollToCaret();
        }
    }
}
