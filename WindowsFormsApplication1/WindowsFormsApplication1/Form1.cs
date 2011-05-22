using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        private Thread listenThread;
        private IDictionary<string, int> groups = new Dictionary<string, int>();
        private IList<User> UserList = new List<User>();
        private long UserCnt = 0;

        public Form1()
        {
            InitializeComponent();

            groups.Add("admin", 1);
            groups.Add("user", 2);
        }

        delegate void AddMessageCallback(string msg);

        private void AddMessage(string msg)
        {
            if (this.listBox1.InvokeRequired)
            {
                AddMessageCallback d = new AddMessageCallback(AddMessage);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                listBox1.Items.Add("[" + DateTime.Now.ToShortTimeString() + "] " + msg);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(IPAddress.Any, 8000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            AddMessage("Server started");
        }


        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                AddMessage("New Client");

                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                //System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));

                byte[] buffer = encoder.GetBytes(GetAnswer(encoder.GetString(message, 0, bytesRead)));
                clientStream.Write(buffer, 0, buffer.Length);
            }

            tcpClient.Close();
        }

        private int GetGroup(string txt)
        {
            int value;
            if (!groups.TryGetValue(txt, out value))
            {
                value = 2;
            }
            return value;
        }

        private string GetAnswer(string msg)
        {
            AddMessage("Qst: " + msg);
            string result = "failed";
            string[] part = msg.Split(new Char[] { ' ' });
            if (part.Length >= 1)
            {
                if (part[0].Equals("createuser", StringComparison.CurrentCultureIgnoreCase) && part.Length == 4){
                    int pwdhash;
                    
                    if(part[1].Length<32 && int.TryParse(part[2], out pwdhash)){
                        User u = new User { Username = part[1], PasswordHash = pwdhash, Group = GetGroup(part[3]), ID = UserCnt++ };
                        UserList.Add(u);
                        AddMessage("New User: " + u.ToString());
                        result = "succ";
                    }
                }
            }
            AddMessage("Ans: " + result);
            return result;
        }

    }
}
