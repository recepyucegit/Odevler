using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils
{
    public class IpAddressFinder
    {
        public static string GetHostName()
        {
            string ip = "";

            var hostName = Dns.GetHostName();

            var ipAddresses = Dns.GetHostAddresses(hostName);

            foreach (var item in ipAddresses)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = item.ToString();
                    break;
                }
            }

            return ip;
        }
    }
}
