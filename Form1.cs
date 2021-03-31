using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkConsole
{
    public partial class Form1 : Form
    {
        UdpClient receiver = new UdpClient(48762);

        public Form1()
        {
            InitializeComponent();
            UDPsender.EnableBroadcast = true;
            UDPsender.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            UDPsender.ExclusiveAddressUse = false;
            receiver.BeginReceive(DataReceived, receiver);                //}
            MyIPLbl.Text = MyIPAddress;
            BroadcastBtn.PerformClick();
        }

        private void DataReceived(IAsyncResult ar)
        {
            UdpClient c = (UdpClient)ar.AsyncState;
            if (c == null) return;

            try
            {


                IPEndPoint receivedIpEndPoint = new IPEndPoint(IPAddress.Any, 48762);
                if (receivedIpEndPoint == null) return;
                Byte[] receivedBytes = c.EndReceive(ar, ref receivedIpEndPoint);

                // Convert data to ASCII and print in console
                string receivedText = Encoding.UTF8.GetString(receivedBytes);
                //Console.WriteLine(receivedText);
                if (receivedText.IndexOf("^") > 0)
                {
                    string[] arr = receivedText.Split('^');
                    if (arr.Length > 0)
                    {
                        //if (arr[0] == "MyRetailer Broadcast Server")
                        //{
                        //    System.Console.Beep();

                        //    var builer = new StringBuilder();
                        //    builer.Append(string.Format(DateTime.Now.ToString("hh:mm:ss ") + "\t{0}                            : {1}", arr[0], arr[1]));
                        //    builer.Append(Environment.NewLine);
                        //    Rt += builer.ToString(); this.Invoke(new EventHandler(datarecieved));

                        //}
                        //else
                        {
                            System.Console.Beep();

                            var builer = new StringBuilder();
                            builer.Append(string.Format(DateTime.Now.ToString("hh:mm:ss ") + "\t{0}                            : {1}", arr[0], arr[1]));
                            builer.Append(Environment.NewLine);
                            Rt += builer.ToString();
                            this.Invoke(new EventHandler(datarecieved));

                        }

                    }

                }
                c.BeginReceive(DataReceived, ar.AsyncState);
            }
            catch (Exception ex) { }

        }
        string Rt;
        private void datarecieved(object sender, EventArgs e)
        {
            
            
            ConsoleWindow.AppendText(Rt);
            Rt = "";
            ConsoleWindow.ScrollToCaret();
            //ConsoleWindow.SelectionLength = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            receiver.Close();
            receiver.Dispose();
        }
        public static UdpClient UDPsender = new UdpClient();

        private void BroadcastTimer_Tick(object sender, EventArgs e)
        {
            IPEndPoint broadcastAddress = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 48769);
            
            UDPsender.Send(Encoding.UTF8.GetBytes("MyRetailer Broadcast Server^" + MyIPAddress), Encoding.UTF8.GetBytes("MyRetailer Broadcast Server^" + MyIPAddress).Length, broadcastAddress);

        }
        private string _myIP = "";
        private string MyIPAddress
        {
            get
            {
                if (_myIP == "") _myIP = DisplayIPAddresses();
                return _myIP;
            }
        }
        public static string DisplayIPAddresses()
        {
            string returnAddress = String.Empty;

            // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                // Read the IP configuration for each network
                IPInterfaceProperties properties = network.GetIPProperties();

                if (network.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                       network.OperationalStatus == OperationalStatus.Up &&
                       !network.Description.ToLower().Contains("virtual") &&
                       !network.Description.ToLower().Contains("pseudo"))
                {
                    // Each network interface may have multiple IP addresses
                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        // We're only interested in IPv4 addresses for now
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                            continue;

                        // Ignore loopback addresses (e.g., 127.0.0.1)
                        if (IPAddress.IsLoopback(address.Address))
                            continue;

                        returnAddress = address.Address.ToString();
                        //Console.WriteLine(address.Address.ToString() + " (" + network.Name + " - " + network.Description + ")");
                    }
                }
                else
                {
                    if (network.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                       network.OperationalStatus == OperationalStatus.Up &&
                       !network.Description.ToLower().Contains("virtual") &&
                       !network.Description.ToLower().Contains("pseudo"))
                    {
                        // Each network interface may have multiple IP addresses
                        foreach (IPAddressInformation address in properties.UnicastAddresses)
                        {
                            // We're only interested in IPv4 addresses for now
                            if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                                continue;

                            // Ignore loopback addresses (e.g., 127.0.0.1)
                            if (IPAddress.IsLoopback(address.Address))
                                continue;

                            returnAddress = address.Address.ToString();
                            //Console.WriteLine(address.Address.ToString() + " (" + network.Name + " - " + network.Description + ")");
                        }
                    }
                }
            }

            return returnAddress;
        }

        private void BroadcastBtn_Click(object sender, EventArgs e)
        {
            BroadcastBtn.Checked = !BroadcastBtn.Checked;
            if(BroadcastBtn.Checked)
            {
                BroadcastTimer.Interval = 2000;
                BroadcastTimer.Enabled = true;
            }
            else
            {
                BroadcastTimer.Enabled = false;

            }
        }
    }
}
