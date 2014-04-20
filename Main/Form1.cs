using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initialize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string profile = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            Hashtable profileLang = new Hashtable();

            profileLang.Add("profile.options.name.name", lang.getLang("profile.options.name.name"));
            profileLang.Add("profile.options.name", lang.getLang("profile.options.name"));

            ProfileOptions po = new ProfileOptions(profile, profileLang, pm.getProfileOptions(profile));

            if (po.ShowDialog() == po.DialogResult)
            {

                //string nombre = po.getUser(); //lee la propiedad

                //username = nombre;

                //opts.writeOpt("user", formLogin.getUser(), true);
                //opts.writeOpt("user2", username, false);

            }
        }
    }
}
