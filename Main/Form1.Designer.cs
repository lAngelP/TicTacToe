using System;
using System.Collections;
using System.IO;
namespace Main
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// URL donde se almacenan las versiones
        /// </summary>
        private static string baseUrl = @"http://tictactoe.com.nu";

        private ProfileManager pm = new ProfileManager();


        private Options opts = new Options();

        private Lang lang;

        //private bool login;

        private string username;

        /// <summary>
        /// The version of the game
        /// </summary>
        private static string gameVersion = "alpha-0.1";

        /// <summary>
        /// Directorio de almacenamiento de archivos.
        /// </summary>
        private static string localDirectory = @"C:\Tictactoe";

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "main.welcome.text";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(67, 78);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1120, 365);
            this.webBrowser1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(409, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 82);
            this.button1.TabIndex = 3;
            this.button1.Text = "main.play.text";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(67, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "main.options.text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 492);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 598);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "window.name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void initialize()
        {
            opts.load();

            lang = new Lang(opts.getOpt("lang"));
            lang.load();

            this.Text = lang.getLang("window.name").Replace("{version}", getVersion());


            string s = opts.getOpt("user");

            if (s == null || s == "" || s == "user")
            {
                Login formLogin = new Login();
                
                Hashtable hs = new Hashtable();

                hs.Add("login.name", lang.getLang("login.name"));
                hs.Add("login.user.name", lang.getLang("login.user.name"));
                hs.Add("login.pass.name", lang.getLang("login.pass.name"));
                hs.Add("login.send.name", lang.getLang("login.send.name"));
                hs.Add("login.reset.name", lang.getLang("login.reset.name"));
                hs.Add("login.url.validate", baseUrl + @"/client/login.php");
                hs.Add("login.success.name", lang.getLang("login.success.name"));
                hs.Add("login.error.name", lang.getLang("login.error.name"));
                hs.Add("main.version", getVersion());

                formLogin.loadValues(hs);

                
                //formLogin.Show(this);

                

                if (formLogin.ShowDialog() == formLogin.DialogResult)
                {

                    string nombre = formLogin.getUser(); //lee la propiedad

                    username = nombre;

                    opts.writeOpt("user", formLogin.getUser(), true);
                    //opts.writeOpt("user2", username, false);

                }

                
            }
            label2.Text = lang.getLang("main.welcome.text");
            button1.Text = lang.getLang("main.play.text");
            button2.Text = lang.getLang("main.options.text");

                //Uri browser = new Uri(getUrl("base") + "/client/browser.html");
                    
            webBrowser1.Url = new Uri(getUrl("base") + "/client/browser.html");

            loadProfilesComboBox();

            

        }

        /// <summary>
        /// Carga de los perfiles al ComboBox.
        /// </summary>

        private void loadProfilesComboBox()
        {
            /*DirectoryInfo directory = new DirectoryInfo(getUrl("local"));

            FileInfo[] files = directory.GetFiles("*.dat");

            for (int i = 0; i < files.Length; i++)

            {

                //Console.WriteLine(((FileInfo)files[i]).FullName);
                //this.comboBox1.Items.Add(((FileInfo)files[i]).FullName);
                this.comboBox1.Items.Add(((FileInfo)files[i]).FullName);

            }*/

            //pm.addProfile("s", new Hashtable());

           // string[] profiles = pm.getProfiles();

            /*foreach (string item in profiles)
            {
                
            }*/

            

            System.Object[] toAdd = pm.getProfiles();
            
            comboBox1.Items.AddRange(toAdd);
            comboBox1.SelectedIndex = 0;



        }
        


        /// <summary>
        /// Devuelve el directorio/URL donde están alojados los archivos.
        /// </summary>
        /// <param name="b">base o local.</param>
        /// <returns>baseUrl o localDirectory</returns>
        public static string getUrl(string b)
        {
            if (b == "base")
            {
                return baseUrl;
            }
            else if (b == "local")
            {
                return localDirectory;
            }
            else
            {
                throw new Exception("No se declaró una URL válida");
            }
        }

        public static string getVersion()
        {
            return gameVersion;
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

