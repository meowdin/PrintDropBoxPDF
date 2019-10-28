using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropBoxPrint
{

        // Structure and API declarions:
    
  

    public partial class PrntFile : Form
    {
      
        Metadata file;
        public PrntFile(Metadata _file)
        {
            InitializeComponent();
            txtPrinter.Text = Common.settings.PrinterName;
            file = _file;
            txtPrintFile.Text = file.Name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (numCopy.Value <= 0)
            {
                MessageBox.Show("Please input number of copied to print");
                return;
            }

            string Msg = $"Confirm to proint {file.Name} with {numCopy.Value} copies?";

            if (DialogResult.OK == MessageBox.Show(Msg, "Print File", MessageBoxButtons.OKCancel))
            {
                Task.Run(()=> PrintFile());

            }

        }
        async Task PrintFile()
        {
            string filename = System.IO.Path.GetTempFileName();
            using (var response = await Common.client.Files.DownloadAsync(Common.settings.DropBoxFolder + @"/" + file.Name))
            {
                Console.WriteLine("Downloaded {0} Rev {1}", response.Response.Name, response.Response.Rev);
                byte[] file =  await response.GetContentAsByteArrayAsync();        
                File.WriteAllBytes(filename, file);
              
            }
            string err = Common.Print(filename, Common.settings.PrinterName, (int)numCopy.Value);
            if (err.Length > 0)
            {
                MessageBox.Show(err);

            }

        }


      


    }
}
