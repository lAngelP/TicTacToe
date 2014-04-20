using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        public string getUser(){
            return user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = false;

            /* HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(loginValues["login.url.validate"].ToString());

            httpRequest.Timeout = 10000;     // 10 secs
            httpRequest.UserAgent = Form1.getVersion();

            HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

            string content = responseStream.ReadToEnd();*/

            string sURL;
            sURL = loginValues["login.url.validate"].ToString() + "?user=" + textBox1.Text + "&pass=" + textBox2.Text;
            
            /*WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            //wrGETURL.Headers.Add("user-agent", loginValues["main.version"].ToString());
            //wrGETURL.Headers["user-agent"] = loginValues["main.version"].ToString();
            //wrGETURL.Headers.Add("User-Agent: " + loginValues["main.version"].ToString());
            //wrGETURL.Headers.Set(HttpRequestHeader.UserAgent, loginValues["main.version"].ToString());

            WebHeaderCollection whc = new WebHeaderCollection();
            
            whc.Set(HttpRequestHeader.UserAgent, loginValues["main.version"].ToString());

            wrGETURL.Headers = whc;

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);*/

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.UserAgent = loginValues["main.version"].ToString();

            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

            string content = responseStream.ReadToEnd();


            if (content == "1")
            {
                
                user = textBox1.Text;
                label3.Text = loginValues["login.success.name"].ToString();
                DialogResult = DialogResult.OK;
                this.Close();
                

            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                label3.Text = loginValues["login.error.name"].ToString();
            }
            pictureBox1.Visible = false;
            responseStream.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

    }
}
