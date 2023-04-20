using consultationProjet.views.Iviews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace consultationProjet.views
{
    public partial class ConnexionForm : Form, IconnexionView
    {
        //definitir tous les composants,evenss
        public ConnexionForm()
        {
            InitializeComponent();
            btnconnexion.Click += delegate
            {
                ConnexionEvent.Invoke(this, new EventArgs());
                if (!IsLoggedIn)
                {
                    MessageBox.Show(Message);
                }
            };


        }

        public string Login { get => txtLogin.Text.Trim(); set => throw new NotImplementedException(); }
        public string Password { get => txtPass.Text.Trim(); set => throw new NotImplementedException(); }
        public string Message { get; set; }
        public bool IsLoggedIn { get; set; } 

        public event EventHandler ConnexionEvent;




































        private void ConnexionForm_Load(object sender, EventArgs e)
        {

        }

        private void ConnexionForm_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
