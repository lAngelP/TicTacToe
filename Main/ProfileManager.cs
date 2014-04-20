using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class ProfileManager
    {
        string[] Profiles;

        //Hashtable profileSelected = new Hashtable();

        public ProfileManager()
        {
            StreamReader sr = new StreamReader(Form1.getUrl("local") + @"\profile\manager.dat");

            string linea = sr.ReadLine();

            Profiles = linea.Split(new char[] { ',' });

            /*while (linea != null)
            {


                linea = sr.ReadLine();
            }*/

            sr.Close();

            
            
        }

        public string[] getProfiles()
        {
            return Profiles;
        }

        public void deleteProfile()
        {
            
        }

        public Hashtable getProfileOptions(string profile)
        {
            if (File.Exists(Form1.getUrl("local") + @"\profile\" + profile + @".dat"))
            {
                Hashtable ht = new Hashtable();
                StreamReader sr = new StreamReader(Form1.getUrl("local") + @"\profile\" + profile + @".dat");
                string linea = sr.ReadLine();

                while (linea != null)
                {
                    ht[linea.Split(new char[] { '=' })[0]] = linea.Split(new char[] { '=' })[1];
                    linea = sr.ReadLine();
                }

                sr.Close();

                return ht;
            }
            else
            {
                throw new Exception("Los datos del perfil no se han encontrado, selecciona otro.");
            }
            
        }

        public void addProfile(string name, Hashtable values)
        {
            Profiles[Profiles.Length] = name;
        }

        private void saveProfiles()
        {
            
        }


    }
}
