using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropBoxPrint
{
    public partial class DropBoxSetting : Form
    {
        Main parent;
        public DropBoxSetting(Main _parent)
        {
            parent = _parent;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Task.Run(() => Common.GetAccessToken());            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DropBoxSetting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Common.settings.DropBoxFolder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.settings.DropBoxFolder = textBox1.Text;
            parent.lblFolder.Text = Common.settings.DropBoxFolder;
            Common.SaveSetting();
            MessageBox.Show("Folder Saved");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!(Common.settings.AccessToken.Length>0))
            {
                MessageBox.Show("Please click start to initilize Authen first!");

            }


            if (!textBox1.Text.StartsWith("/"))
            {
                MessageBox.Show("Folder must strats with / ");

            }

            var folderArg = new CreateFolderArg(textBox1.Text);
            var folder = Common.client.Files.CreateFolderV2Async(folderArg).Result;

            MessageBox.Show("Folder Created!");
        }
    }
}
