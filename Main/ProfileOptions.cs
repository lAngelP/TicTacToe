using System;
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
    public partial class ProfileOptions : Form
    {
        private string profile;

        private System.Collections.Hashtable profileLang = new System.Collections.Hashtable();

        private System.Collections.Hashtable profileOpts = new System.Collections.Hashtable();

        public ProfileOptions(string selected, System.Collections.Hashtable hs, System.Collections.Hashtable hs2)
        {
            profile = selected;
            profileLang = hs;
            profileOpts = hs2;

            this.Text = profileLang["profile.options.name"].ToString();

            this.label1.Text = profileLang["profile.options.name.name"].ToString();



            InitializeComponent();
        }
    }
}
