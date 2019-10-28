using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropBoxPrint
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtPWD.PasswordChar = '\0';
            }
            else
            {
                txtPWD.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(txtPWD.Text);
            string base64Encoded = System.Convert.ToBase64String(data);
            Common.settings.SettingPassword = base64Encoded;
            Common.SaveSetting();
            this.Close();
        }
    }
}
