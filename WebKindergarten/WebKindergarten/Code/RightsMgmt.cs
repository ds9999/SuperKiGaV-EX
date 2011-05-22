using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace WebKindergarten.Code
{
    public static class RightsMgmt
    {
        public bool CreateUser(String username, int pwdhash, String group, int dbID)
        {
            string send = username + " " + pwdhash.ToString() + " " + group + " " + dbID.ToString();
            string answer = DoQuestion(send);
            return answer != "succ";

        }

        public static string DoQuestion(string txt)
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            try
            {
                client.Connect(serverEndPoint);

                NetworkStream clientStream = client.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(txt);

                clientStream.ReadTimeout = 1000;
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                buffer = new Byte[128];
                int size = clientStream.Read(buffer, 0, buffer.Length);

                client.Close();
                return encoder.GetString(buffer, 0, buffer.Length);
            }
            catch
            {
                return "failed";
            }
        }
    }
}