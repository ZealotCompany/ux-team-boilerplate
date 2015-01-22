using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.QRCode;

namespace TaxiApp.QRCode
{
    public interface IQRCodeHandler : IApplicationService
    {
        GetQRImageOutput GetQRImage(GetQRImageInput input);

        IsAuthenticatedOutput IsAuthenticated(IsAuthenticatedInput input);

        AuthenticateOutput Authenticate(AuthenticateInput input);

        void AddRequest(string guid);
    }
}
