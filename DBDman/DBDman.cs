using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Fiddler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using DBDman.Classes;

#pragma warning disable CS0618

namespace DBDman
{
    public partial class DBDman : Form
    {
        [DllImport(@"qrypt0r.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern void readData(byte[] jsonBytes, byte[] buffer);
        [DllImport(@"qrypt0r.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern void writeData(byte[] jsonBytes, byte[] buffer);

        Process DBD;
        static Proxy oSecureEndpoint;
        const string sSecureEndpointHostname = "localhost";
        const ushort iPort = 1337;

        public static string[] MessageBoxTitles = {"Error", "Success", "Warning"};

        const string uriScheme = "https";
        const string host = "latest.live.dbd.bhvronline.com";
        const string httpVersion = "HTTP/1.1";
        const string accept = "*/*";
        const string acceptEncoding = "deflate, gzip";
        const string contentTypeJson = "application/json";
        const string userAgent = "DeadByDaylight/++DeadByDaylight+Live-CL-99847 Windows/6.2.9200.1.768.64bit";

        static string cloudsave = AppDomain.CurrentDomain.BaseDirectory + "cloudsave.json";
        static string inventory_dump = AppDomain.CurrentDomain.BaseDirectory + "inventory_dumped.txt";
        static string inventory_redirect = AppDomain.CurrentDomain.BaseDirectory + "inventory.txt";
        static string cert = AppDomain.CurrentDomain.BaseDirectory + "root.cer";

        FiddlerCoreStartupSettings startupSettings = new FiddlerCoreStartupSettingsBuilder()
            .ListenOnPort(iPort)
            .RegisterAsSystemProxy()
            .DecryptSSL()
            .MonitorAllConnections()
            .OptimizeThreadPool()
            .Build();

        HTTPRequestHeaders getPlayerLevelHeader = new HTTPRequestHeaders();
        HTTPRequestHeaders getRankHeader = new HTTPRequestHeaders();
        HTTPRequestHeaders getActiveNodeHeader = new HTTPRequestHeaders();

        int totalXp = -1;
        int levelVersion = -1;
        int survivorPips = -1;
        int killerPips = -1;

        public DBDman()
        {
            //generate random window title
            string randChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[32];
            Random random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = randChars[random.Next(randChars.Length)];
            }
            Text = new string(stringChars);

            InitializeComponent();

            //clean up fiddler defaults
            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.echoservice.enabled", false);
            FiddlerApplication.Prefs.SetBoolPref("fiddler.certmaker.PreferCertEnroll", true);
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);

            //initialise request headers (so we don't have to reconstruct the full request each time)
            getPlayerLevelHeader.UriScheme = uriScheme;
            getPlayerLevelHeader.HTTPMethod = "POST";
            getPlayerLevelHeader.RequestPath = "/api/v1/extensions/playerLevels/getPlayerLevel";
            getPlayerLevelHeader.HTTPVersion = httpVersion;
            getPlayerLevelHeader.Add("Host", host);
            getPlayerLevelHeader.Add("Accept", accept);
            getPlayerLevelHeader.Add("Accept-Encoding", acceptEncoding);
            getPlayerLevelHeader.Add("Content-Type", contentTypeJson);
            getPlayerLevelHeader.Add("User-Agent", userAgent);

            getRankHeader.UriScheme = uriScheme;
            getRankHeader.HTTPMethod = "GET";
            getRankHeader.RequestPath = "/api/v1/ranks/pips";
            getRankHeader.HTTPVersion = httpVersion;
            getRankHeader.Add("Host", host);
            getRankHeader.Add("Accept", accept);
            getRankHeader.Add("Accept-Encoding", acceptEncoding);
            getRankHeader.Add("Content-Type", contentTypeJson);
            getRankHeader.Add("User-Agent", userAgent);
            getRankHeader.Add("Content-Length", "0");

            getActiveNodeHeader.UriScheme = uriScheme;
            getActiveNodeHeader.HTTPMethod = "GET";
            getActiveNodeHeader.RequestPath = "/api/v1/archives/stories/get/activeNode";
            getActiveNodeHeader.HTTPVersion = httpVersion;
            getActiveNodeHeader.Add("Host", host);
            getActiveNodeHeader.Add("Accept", accept);
            getActiveNodeHeader.Add("Accept-Encoding", acceptEncoding);
            getActiveNodeHeader.Add("Content-Type", contentTypeJson);
            getActiveNodeHeader.Add("User-Agent", userAgent);
        }

        private void updateCertMenuStatus()
        {
            if (!CertMaker.rootCertExists())
            {
                menuInstallCert.Enabled = true;
                menuUninstallCert.Enabled = false;
                menuExportCert.Enabled = false;
            }
            else
            {
                menuInstallCert.Enabled = false;
                menuUninstallCert.Enabled = true;
                menuExportCert.Enabled = true;
            }
        }

        private void addLogString(string logString)
        {
            log.Text += logString + "\r\n";
        }

        private bool isGameRunning()
        {
            DBD = Process.GetProcessesByName("DeadByDaylight-Win64-Shipping").FirstOrDefault();
            if(DBD != null)
            {
                return true;
            }

            return false;
        }

        private void startServer()
        {
            if (!CertMaker.rootCertExists())
            {
                MessageBox.Show("Certificate not found, please go to the menu and install the certificate before starting the server", MessageBoxTitles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FiddlerApplication.BeforeRequest += new SessionStateHandler(FiddlerApplication_BeforeRequest);
            FiddlerApplication.BeforeResponse += new SessionStateHandler(FiddlerApplication_BeforeResponse);

            FiddlerApplication.Startup(startupSettings);
            oSecureEndpoint = FiddlerApplication.CreateProxyEndpoint(8888, true, sSecureEndpointHostname);

            addLogString(string.Format("Created server listening on port {0}", iPort));
            
            buttonServer.Text = "Stop Server";
        }

        private void stopServer()
        {
            if (oSecureEndpoint != null)
            {
                oSecureEndpoint.Dispose();
            }

            FiddlerApplication.Shutdown();

            FiddlerApplication.BeforeRequest -= new SessionStateHandler(FiddlerApplication_BeforeRequest);
            FiddlerApplication.BeforeResponse -= new SessionStateHandler(FiddlerApplication_BeforeResponse);

            addLogString("Server terminated");
            buttonServer.Text = "Start Server";
        }

        private void FiddlerApplication_BeforeRequest(Session oSession)
        {
            oSession.bBufferResponse = true; //we gotta buffer every response, otherwise we break traffic for other apps :/
        }

        private void FiddlerApplication_BeforeResponse(Session oSession)
        {
            if(isGameRunning()) //don't bother checking requests if dbd process doesn't exist (needed to update dbd id for next check)
            {
                if(oSession.LocalProcessID == DBD.Id) //skip checks if the requests aren't coming from dbd process
                {
                    //get cookie to use in requests
                    if (oSession.uriContains("https://latest.live.dbd.bhvronline.com/api/v1/auth/provider/steam/login"))
                    {
                        string str = oSession.ResponseHeaders.FindAll("Set-Cookie")[0].Value;
                        textBoxCookie.Text = str.Substring(12, str.IndexOf(';') - 12); //start reading from after 'bhvrSession=' and stop at the semicolon
                        addLogString("Logged into game");
                    }

                    //save mods
                    if (oSession.fullUrl == "https://latest.live.dbd.bhvronline.com/api/v1/players/me/states/FullProfile/binary")
                    {
                        if(checkBoxSave.Checked)
                        {
                            if(radioButtonSaveDump.Checked) //dump save
                            {
                                byte[] buf = new byte[0x2000000];
                                byte[] json = oSession.responseBodyBytes;
                                buf[0] = 0;
                                readData(json, buf);
                                string json_dat = Encoding.ASCII.GetString(buf);
                                json_dat = json_dat.TrimEnd('\x00');
                                File.WriteAllText(cloudsave, json_dat);
                                DBD.Kill(); //kill dbd process after dumping (to remain consistent on server)
                                addLogString("Save dumped to " + cloudsave);
                            }
                            checkBoxSave.Checked = false;
                        }
                    }

                    //inventory mods
                    if(oSession.fullUrl == "https://latest.live.dbd.bhvronline.com/api/v1/inventories")
                    {
                        if(checkBoxInventory.Checked)
                        {
                            if(radioButtonInventoryDump.Checked)
                            {
                                oSession.utilDecodeResponse();
                                File.WriteAllText(inventory_dump, oSession.GetResponseBodyAsString());
                                addLogString("Inventory dumped");
                                checkBoxInventory.Checked = false;
                            }
                            if(radioButtonInventoryRedirect.Checked)
                            {
                                if(File.Exists(inventory_redirect))
                                {
                                    oSession.utilSetResponseBody(File.ReadAllText(inventory_redirect));
                                    addLogString("Local inventory used");
                                }
                                else
                                {
                                    addLogString("ERROR: inventory.txt could not be found");
                                }
                            }
                        }
                    }

                    //bypass temp ban
                    if(oSession.fullUrl == "https://latest.live.dbd.bhvronline.com/api/v1/players/ban/status")
                    {
                        oSession.utilSetResponseBody("{\"isBanned\":false}");
                    }
                }
            }
        }

        private void menuInstallCert_Click(object sender, EventArgs e)
        {
            CertMaker.createRootCert();
            CertMaker.trustRootCert();
            updateCertMenuStatus();
        }

        private void menuUninstallCert_Click(object sender, EventArgs e)
        {
            CertMaker.removeFiddlerGeneratedCerts(true);
            updateCertMenuStatus();
        }

        private void menuExportCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 rootCertificate = CertMaker.GetRootCertificate();
            if (rootCertificate == null)
            {
                MessageBox.Show("Unable to export certificate", MessageBoxTitles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            File.WriteAllBytes(cert, rootCertificate.Export(X509ContentType.Cert));
            MessageBox.Show(string.Format("Certificate exported to {0}", cert), MessageBoxTitles[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxSave_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxSave.Checked)
            {
                groupBoxSave.Enabled = true;
            }
            else
            {
                groupBoxSave.Enabled = false;
            }
        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            if (!FiddlerApplication.IsStarted())
            {
                startServer();
            }
            else
            {
                stopServer();
            }
        }

        private void checkBoxInventory_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxInventory.Checked)
            {
                groupBoxInventory.Enabled = true;
            }
            else
            {
                groupBoxInventory.Enabled = false;
            }
        }

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            InventoryManager inventoryManager = new InventoryManager();
            inventoryManager.Show();
        }

        private bool checkCookie()
        {
            if (textBoxCookie.Text != "")
            {
                return true;
            }
            MessageBox.Show("Cookie data not found", MessageBoxTitles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void buttonGetCurrentXp_Click(object sender, EventArgs e)
        {
            if (!checkCookie())
            {
                return;
            }

            string responseBody = "{\"data\":{}}";

            getPlayerLevelHeader.Add("Cookie", string.Format("bhvrSession={0}", textBoxCookie.Text));
            getPlayerLevelHeader.Add("Content-Length", responseBody.Length.ToString());

            Session oGetPlayerLevel = FiddlerApplication.oProxy.SendRequest(getPlayerLevelHeader, Encoding.ASCII.GetBytes(responseBody), null);

            getPlayerLevelHeader.Remove("Cookie");
            getPlayerLevelHeader.Remove("Content-Length");

            using (ManualResetEvent oWaitForDone = new ManualResetEvent(false))
            {
                oGetPlayerLevel.OnStateChanged += (messager, eA) =>
                {
                    if (eA.newState == SessionStates.Aborted)
                    {
                        addLogString("Request aborted");
                    }
                    else if (eA.newState == SessionStates.Done)
                    {
                        if (oGetPlayerLevel.responseCode != 200)
                        {
                            addLogString(string.Format("Request failed: {0}", oGetPlayerLevel.GetResponseBodyAsString()));
                        }
                        else
                        {
                            JObject playerLevelObj = JObject.Parse(oGetPlayerLevel.GetResponseBodyAsString());
                            labelLevel.Text = (string)playerLevelObj["level"];
                            labelDevotion.Text = (string)playerLevelObj["prestigeLevel"];
                            totalXp = (int)playerLevelObj["totalXp"];
                            labelTotalXp.Text = totalXp.ToString();
                            levelVersion = (int)playerLevelObj["levelVersion"];
                        }
                    }
                    oWaitForDone.Set();
                };
                if (!oWaitForDone.WaitOne(5000, false))
                {
                    addLogString("Request timed out");
                }
            }
        }

        private void buttonGetRank_Click(object sender, EventArgs e)
        {
            if (!checkCookie())
            {
                return;
            }

            getRankHeader.Add("Cookie", string.Format("bhvrSession={0}", textBoxCookie.Text));
            Session oGetRank = FiddlerApplication.oProxy.SendRequest(getRankHeader, null, null);
            getRankHeader.Remove("Cookie");

            using (ManualResetEvent oWaitForDone = new ManualResetEvent(false))
            {
                oGetRank.OnStateChanged += (messager, eA) =>
                {
                    if (eA.newState == SessionStates.Aborted)
                    {
                        addLogString("Request aborted");
                    }
                    else if (eA.newState == SessionStates.Done)
                    {
                        if (oGetRank.responseCode != 200)
                        {
                            addLogString(string.Format("Request failed: {0}", oGetRank.GetResponseBodyAsString()));
                        }
                        else
                        {
                            JObject rankObj = JObject.Parse(oGetRank.GetResponseBodyAsString());
                            survivorPips = (int)rankObj["survivorPips"];
                            killerPips = (int)rankObj["killerPips"];
                            numericUpDownSurvivorPips.Value = survivorPips;
                            numericUpDownKillerPips.Value = killerPips;
                        }
                    }
                    oWaitForDone.Set();
                };
                if (!oWaitForDone.WaitOne(5000, false))
                {
                    addLogString("Request timed out");
                    return;
                }
            }
        }

        private void DBDman_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FiddlerApplication.IsStarted())
            {
                stopServer();
                Thread.Sleep(500);
            }
        }
    }
}