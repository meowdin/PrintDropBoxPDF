using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropBoxPrint
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            DropboxCertHelper.InitializeCertPinning();
            Common.LoadSetting();
            if (Common.settings.AccessToken.Length > 0)
            {
                Common.LoadDropBoxClient();
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void administrativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPassword frmPassword = new frmPassword();
           if (DialogResult.OK  == frmPassword.ShowDialog())
            {

                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(frmPassword.txtPWD.Text);
                string base64Encoded = System.Convert.ToBase64String(data);
                if (base64Encoded == Common.settings.SettingPassword)
                {

                    DropBoxSetting settngform = new DropBoxSetting(this);
                    settngform.ShowDialog();

                }
                else
                {

                    MessageBox.Show("Wrong System Password");
                }
            }

        }

        private void settingPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPassword frmPassword = new frmPassword();

            if (DialogResult.OK == frmPassword.ShowDialog())
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(frmPassword.txtPWD.Text);
                string base64Encoded = System.Convert.ToBase64String(data);
                if (base64Encoded == Common.settings.SettingPassword)
                {

                    ChangePassword changePassword = new ChangePassword();

                    changePassword.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Wrong System Password");
                }

            }
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
         

            GetCurrentAccount(Common.client);

            var list =  Common.client.Files.ListFolderAsync(Common.settings.DropBoxFolder).Result;


            List<Metadata> files = list.Entries.Where(i => i.IsFile).ToList();
            dataFileViews.DataSource = files;



        }

        private void Main_Load(object sender, EventArgs e)
        {
            Common.LoadSetting();
            lblFolder.Text = Common.settings.DropBoxFolder;
        }
        void GetCurrentAccount(DropboxClient client)
        {

            var full =  client.Users.GetCurrentAccountAsync().Result;

            Console.WriteLine("Account id    : {0}", full.AccountId);
            Console.WriteLine("Country       : {0}", full.Country);
            Console.WriteLine("Email         : {0}", full.Email);
            Console.WriteLine("Is paired     : {0}", full.IsPaired ? "Yes" : "No");
            Console.WriteLine("Locale        : {0}", full.Locale);
            Console.WriteLine("Name");
            Console.WriteLine("  Display  : {0}", full.Name.DisplayName);
            Console.WriteLine("  Familiar : {0}", full.Name.FamiliarName);
            Console.WriteLine("  Given    : {0}", full.Name.GivenName);
            Console.WriteLine("  Surname  : {0}", full.Name.Surname);
            Console.WriteLine("Referral link : {0}", full.ReferralLink);

            if (full.Team != null)
            {
                Console.WriteLine("Team");
                Console.WriteLine("  Id   : {0}", full.Team.Id);
                Console.WriteLine("  Name : {0}", full.Team.Name);
            }
            else
            {
                Console.WriteLine("Team - None");
            }
        }

        private void selectPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            printer.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataFileViews.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select row to print");
                return;
            }
            Metadata selected = (Metadata)dataFileViews.SelectedRows[0].DataBoundItem;
            PrntFile print = new PrntFile(selected);
            print.ShowDialog();
        }
    }
}
