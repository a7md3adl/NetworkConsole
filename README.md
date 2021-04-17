# NetworkConsole
Network Console Application For Catching Android releases Exceptions





add the next static  class to your code


using MyRetailer.Customers.Global;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AlexandrinaSoftware.NetworkConsole
{

    public class NetworkConsole
    {
        public static UdpClient UDPsender = new UdpClient();
        public static void Write(string ConsoleMessage)
        {
            try
            {
                IPEndPoint IpEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 48762);
                UDPsender.Send(Encoding.UTF8.GetBytes("<AppName>^" + ConsoleMessage), Encoding.UTF8.GetBytes("<AppName>^" + ConsoleMessage).Length, IpEndPoint);
            }
            catch
            {
            throw;
            }
         
        }
        

    }
}




Use :

namespace YourNameSpace
{
    class
    {
        try
        {
                //.... (do somthing)
        }
        catch(Exception Ex)
        {
                NetworkConsole.Write(Ex.Message);
                NetworkConsole.Write(Ex.StackTrace);
                NetworkConsole.Write(Ex.InnerException.Message);
                //....(or cutome exception message)
        }
    }
}
