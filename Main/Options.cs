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
    class Options
    {
        
        public static bool loaded { get; set; }

        private string optsURL = Form1.getUrl("local") + @"\options.dat";

        private string defOpts = Form1.getUrl("base") + @"/options.php";

        private static Hashtable opts = new Hashtable();

        private string[] opts2;

        private static Hashtable defaultOpts = new Hashtable();

        /// <summary>
        /// Initializes the class.
        /// </summary>
        public Options()
        {
            
        }

        private void writeDefaults()
        {
            /*StreamWriter sw = new StreamWriter(optsURL);
            sw.WriteLine("lang=es_es");
            sw.WriteLine("user=");

            
            //writeOpt("user", "");
            
            
            sw.Close();*/
            writeOpt("lang", "es_es");
            writeOpt("user", "");
        }


        public void load()
        {
            if (loaded == false)
            {
                if (File.Exists(optsURL))
                {
                    StreamReader sr = new StreamReader(optsURL);

                    string linea = sr.ReadLine();

                    while (linea != null)
                    {
                        opts2 = linea.Split(new char[] { '=' });
                        opts.Add(opts2[0], opts2[1]);
                        linea = sr.ReadLine();
                    }
                    sr.Close();

                    loaded = true;
                }
                else
                {
                    
                    //File.Create(optsURL).Close();
                    //File.SetAttributes(optsURL, FileAttributes.Normal);
                    
                    
                    

                    /*StreamWriter sw = new StreamWriter(optsURL);

                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(defOpts);

                    httpRequest.Timeout = 10000;     // 10 secs
                    httpRequest.UserAgent = Form1.getVersion();

                    HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
                    StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

                    string content = responseStream.ReadToEnd();

                    sw.Write(content);
                    

                    responseStream.Close();
                    sw.Close();*/

                    this.writeDefaults();

                    this.load();
                }
            }
            else
            {
                throw new Exception("Ya se ha cargado el archivo de lenguaje, intenta acceder a él.");
            }
        }

        public void writeOpt(string key, string value, bool exists = false)
        {
            
            if (exists == false)
            {
               StreamWriter sw = new StreamWriter(optsURL, true);
               sw.WriteLine("{0}={1}", key, value);
               sw.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(optsURL);
                string linea = sr.ReadLine();
                string writer = "";
                while (linea != null)
                {

                    string[] temp = linea.Split(new char[] { '=' });

                    if (temp[0] == key)
                    {

                        linea = key + "=";
                        linea += value;
                        //Form1.writeinLabel2(linea);

                        writer += key + "=" + value + "\r\n";
                    }
                    else
                    {
                        writer += linea + "\r\n";
                    }


                    

                    linea = sr.ReadLine();
                }
                sr.Close();

                StreamWriter sw = new StreamWriter(optsURL);
                sw.Write(writer);
                sw.Close();
            }

            
        }


        public string getOpt(string s)
        {
            if (loaded == false)
            {
                throw new Exception("No se ha cargado el archivo de lenguaje.");
            }
            else
            {
                if (opts[s].ToString() != null && opts[s].ToString() != "")
                {
                    return opts[s].ToString();
                }
                else
                {
                    return s;
                }
            }


        }
    }
}
