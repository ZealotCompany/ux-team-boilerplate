using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.QRCode
{
    public class AuthenticateInput
    {
        public string RequestID { get; set; }

        public string EncryptedRequestData { get; set; }

        public string AuthCertificateData { get; set; }

    }
}
