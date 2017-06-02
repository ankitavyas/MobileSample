using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace MobileApp
{
    public class ConfigHelper
    {
        private string Retrieve(string key)
        {
            var type = this.GetType();
            var resource = type.Namespace + "." +
              Device.OnPlatform("iOS", "Droid", "WinPhone") + ".Config.xml";
            using (var stream = type.Assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());
                return doc?.Element("config")?.Element(key)?.Value;
            }
        }


        public string SmtpServer => Retrieve("smtp-server");

        public int Port
        {
            get
            {
                var p = Retrieve("port");
                int i;
                int.TryParse(p, out i);
                return i;
            }
        }
        public string EmailUser => Retrieve("email-user");
        public string EmailPassword => Retrieve("email-password");
        public string EmailFrom => Retrieve("email-from");
        public string EmailTo => Retrieve("email-to");

    }
}
