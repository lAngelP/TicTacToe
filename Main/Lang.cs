using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Lang
    {
        private bool loaded = false;

        private string langURL;

        private string defLang;

        private Hashtable lang = new Hashtable();

        

        private string[] langs;

        /// <summary>
        /// Initializes the class.
        /// </summary>
        public Lang(string lang)
        {
            langURL = @Form1.getUrl("local") + @"\lang\" + lang + ".dat";
            defLang = @Form1.getUrl("local") + @"\lang\" + lang + ".php";
        }

        public void load()
        {
            if (loaded == false)
            {
                if (File.Exists(langURL))
                {
                    StreamReader sr = new StreamReader(langURL);

                    string linea = sr.ReadLine();

                    while (linea != null)
                    {
                        langs = linea.Split(new char[] { '=' });
                        lang.Add(langs[0], langs[1]);
                        linea = sr.ReadLine();
                    }
                    sr.Close();

                    loaded = true;
                }
                else
                {
                    File.Create(langURL);

                    StreamWriter sw = new StreamWriter(langURL);

                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(defLang);

                    httpRequest.Timeout = 10000;     // 10 secs
                    httpRequest.UserAgent = Form1.getVersion();

                    HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
                    StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

                    string content = responseStream.ReadToEnd();

                    sw.Write(content);


                    responseStream.Close();
                    sw.Close();

                    this.load();
                }
            }
            else
            {
                throw new Exception("Ya se ha cargado el archivo de lenguaje, intenta acceder a él.");
            }


        }

        public string getLang(string s)
        {
            if (loaded == false)
            {
                throw new Exception("No se ha cargado el archivo de lenguaje.");
            }
            else
            {
                if (lang[s].ToString() != null && lang[s].ToString() != "")
                {
                    return lang[s].ToString();
                }
                else
                {
                    return s;
                }
            }

            
        }
    }
}
