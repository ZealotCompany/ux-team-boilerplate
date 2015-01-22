using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using TaxiApp.QRCode;

namespace TaxiApp.Web.Controllers
{
    public class QRCodeController : ApiController
    {
        private IQRCodeHandler _qrHandler;

        public QRCodeController (IQRCodeHandler qrHandler)
        {
            this._qrHandler = qrHandler;
        }

        [HttpGet]
        [Route("api/qrcode/qrImage")]
        public GetQRImageOutput GetQRImage(GetQRImageInput input)
        {
            string guid = Guid.NewGuid().ToString();
            Bitmap bmp = GenerateQR(200, 200, guid);

            //3
            var Fs = new FileStream(HostingEnvironment.MapPath("~/QRImages") + @"\" + guid + ".png", FileMode.Create);
            bmp.Save(Fs, ImageFormat.Png);
            bmp.Dispose();


            //4
            Image img = Image.FromStream(Fs);
            Fs.Close();
            Fs.Dispose();


            //5
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);


            //6
            ms.Close();
            ms.Dispose();

            _qrHandler.AddRequest(guid);
            return new GetQRImageOutput()
            {
                ImageUrl = guid
            };
        }

        [HttpGet]
        public IsAuthenticatedOutput IsAuthenticated(string id)
        {
            return _qrHandler.IsAuthenticated(new IsAuthenticatedInput() { RequestID = id });
        }

        public async Task<JToken> Post(HttpRequestMessage request)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            AuthenticateInput input = JsonConvert.DeserializeObject<AuthenticateInput>(jsonString);
            var retValue = _qrHandler.Authenticate(input);
            JToken json = JObject.Parse("{ 'isAuthenticated' : '" + (retValue.IsAuthenticated == true ? "true" : "false") + "'}");
            return json;
        }

        //[HttpPost]
        //public AuthenticateOutput Authenticate([FromBody] AuthenticateInput input)
        //{

        //    return _qrHandler.Authenticate(input);
        //}

        private Bitmap GenerateQR(int width, int height, string text)
        {
            var bw = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(bw.Write(text));

            return result;
        }

    }
}
