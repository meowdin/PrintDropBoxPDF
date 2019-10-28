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
    public partial class Printer : Form
    {
        public Printer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Printer_Load(object sender, EventArgs e)
        {
            List<string> printers = new List<string>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }

            cboPrint.DataSource = printers;

            if (Common.settings.PrinterName.Length > 0)
            {

                cboPrint.SelectedIndex = cboPrint.FindStringExact(Common.settings.PrinterName);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Common.settings.PrinterName = cboPrint.Items[cboPrint.SelectedIndex].ToString();
            Common.SaveSetting();
            MessageBox.Show("Saved!");
            this.Close();
        }
    }
}
