using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NewsBlogProject.Infrastructure.Utilities
{
  public static  class RemoteIpAdress
    {
        public static string GetIpAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            return "Ip adress not found";
        }
        public static string IpAddress => GetIpAdress();
    }
}
