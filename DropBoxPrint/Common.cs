using Dropbox.Api;
using Microsoft.Win32;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DropBoxPrint
{
    public static class Common
    {
        public static SettingDB settings = new SettingDB();
        public static DropboxClient client;
        public static string LoopbackHost = "http://127.0.0.1:52475/";

        // URL to receive OAuth 2 redirect from Dropbox server.
        // You also need to register  redirect and create apikey URL on https://www.dropbox.com/developers/apps.
        //public static string ApiKey = "";
       
        public static Uri RedirectUri = new Uri(LoopbackHost + "authorize");
        public static Uri JSRedirectUri = new Uri(LoopbackHost + "token");
        public static void LoadDropBoxClient()
        {
            var httpClient = new HttpClient()
            {
                // Specify request level timeout which decides maximum time that can be spent on
                // download/upload files.
                Timeout = TimeSpan.FromMinutes(20)
            };

            var config = new DropboxClientConfig("DropBoxPDFPrinter")
            {
                HttpClient = httpClient
            };

            client = new DropboxClient(settings.AccessToken, config);


        }
        public static void SaveSetting()
        {
           
            using (TextWriter txtWriter = new StreamWriter(@"Setting.xml"))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(settings.GetType());
                x.Serialize(txtWriter, settings);
                txtWriter.Close();
            }

        }
        public static void LoadSetting()
        {
            if (!File.Exists("Setting.xml"))
            {
                SaveSetting();

            }
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(settings.GetType());

            using (StringReader sr = new StringReader(File.ReadAllText("Setting.xml")))
            {
                settings = (SettingDB)ser.Deserialize(sr);
            }



        }


        public static async Task GetAccessToken()
        {
            var state = Guid.NewGuid().ToString("N");
            var authorizeUri = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, ApiKey, RedirectUri, state: state);
            var http = new HttpListener();
            http.Prefixes.Add("http://+:52475/");
            http.Start();


            System.Diagnostics.Process.Start(authorizeUri.ToString());
           await HandleOAuth2Redirect(http);
        }
        public static async Task HandleOAuth2Redirect(HttpListener http)
        {
            var context = await http.GetContextAsync();

            // We only care about request to RedirectUri endpoint.
            while (context.Request.Url.AbsolutePath != RedirectUri.AbsolutePath)
            {
                context = await http.GetContextAsync();
            }

            context.Response.ContentType = "text/html";

            // Respond with a page which runs JS and sends URL fragment as query string
            // to TokenRedirectUri.
            using (var file = File.OpenRead("index.html"))
            {
                file.CopyTo(context.Response.OutputStream);
            }

            context.Response.OutputStream.Close();

            var result = HandleJSRedirect(http);
            Console.WriteLine("and back...");
            settings.AccessToken = result.AccessToken;
            settings.Uid = result.Uid;
            SaveSetting();
            Common.LoadDropBoxClient();
        }
        public static OAuth2Response HandleJSRedirect(HttpListener http)
        {
            var context =  http.GetContextAsync().Result;

            // We only care about request to TokenRedirectUri endpoint.
            while (context.Request.Url.AbsolutePath != JSRedirectUri.AbsolutePath)
            {
                context =  http.GetContextAsync().Result;
            }

            var redirectUri = new Uri(context.Request.QueryString["url_with_fragment"]);

            var result = DropboxOAuth2Helper.ParseTokenFragment(redirectUri);

            return result;
        }
        public static string Print(string file, string printer,int copy)
        {
            try
            {
                var printerSettings = new PrinterSettings
                {
                    PrinterName = printer,
                    Copies = (short)copy,
                };

                // Create our page settings for the paper size selected
                var pageSettings = new PageSettings(printerSettings)
                {
                    Margins = new Margins(0, 0, 0, 0),
                };
                foreach (PaperSize paperSize in printerSettings.PaperSizes)
                {
                    if (paperSize.Kind == PaperKind.A4)
                    {
                        pageSettings.PaperSize = paperSize;
                        break;
                    }
                }

                // Now print the PDF document
                using (var document = PdfDocument.Load(file))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        printDocument.PrinterSettings = printerSettings;
                        printDocument.DefaultPageSettings = pageSettings;
                        printDocument.PrintController = new StandardPrintController();
                        printDocument.Print();
                    }
                }
                File.Delete(file);

                return "";

            }

            
            catch (Exception ex)
            {

                return ex.Message;

            }
       
        }
    }
}
