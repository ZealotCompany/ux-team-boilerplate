using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.QRCode
{
    public class AuthenticateOutput
    {
        public bool IsAuthenticated { get; set; }

        public string CertificateSerialNumber { get; set; }

        public string SubjectName { get; set; }
    }
}
