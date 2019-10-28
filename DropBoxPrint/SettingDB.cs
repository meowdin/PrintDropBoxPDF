using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBoxPrint
{
    public class SettingDB
    {
        public string DropBoxFolder { get; set; } = "";
     
        public string DBFileName { get; set; } = "FileDBSource.xml";
        public string SettingPassword { get; set; } = "YWJjZDEyMzQ=";
        public string AccessToken { get; set; } = "";
        public string Uid { get; set; }  = "";

        public string PrinterName { get; set; } = "";
    }
}
