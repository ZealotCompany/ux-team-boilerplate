using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.QRCode;

namespace TaxiApp.QRCode
{
    public class QRCodeHandler : TaxiAppAppServiceBase, IQRCodeHandler
    {
        private static Dictionary<string, Nullable<bool>> requestMap = new Dictionary<string, Nullable<bool>>();

        public GetQRImageOutput GetQRImage(GetQRImageInput input)
        {
            return new GetQRImageOutput()
            {
                ImageUrl = "hello.google.com"
            };
        }

        public IsAuthenticatedOutput IsAuthenticated(IsAuthenticatedInput input)
        {
            if (requestMap.ContainsKey(input.RequestID) 
                && requestMap[input.RequestID].HasValue
                && requestMap[input.RequestID].Value == true)
            {
                requestMap.Remove(input.RequestID);
                return new IsAuthenticatedOutput()
                {
                    IsAuthenticated = true
                };
            }
            else
            {
                return new IsAuthenticatedOutput()
                {
                    IsAuthenticated = false
                };
            }
        }


        public AuthenticateOutput Authenticate(AuthenticateInput input)
        {
            if (input.EncryptedRequestData == null || input.AuthCertificateData == null)
            {
                Logger.Warn("Input arguments are invalid. They are null");
                return new AuthenticateOutput()
                {
                    IsAuthenticated = false
                };
            }

            string decryptedRequestID = string.Empty;
            
            try
            {
                X509Certificate2 authCertificate = new X509Certificate2(Convert.FromBase64String(input.AuthCertificateData));
                // validate certificate
                bool isCertificateValid = true;
                if (!isCertificateValid)
                {
                    Logger.Warn("Certificate is invalid. X509Certificate: " + authCertificate.SerialNumber);
                    return  new AuthenticateOutput()
                    {
                        IsAuthenticated = false
                    };
                }

                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)authCertificate.PublicKey.Key;

                bool verify = rsa.VerifyData(System.Text.Encoding.UTF8.GetBytes(input.RequestID), CryptoConfig.MapNameToOID("SHA1"), Convert.FromBase64String(input.EncryptedRequestData));
                //byte[] plainbytes = rsa.Decrypt(Convert.FromBase64String(input.EncryptedRequestData), false);
                Logger.Debug("Decrypted request id: " + verify);

                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                //decryptedRequestID = enc.GetString(plainbytes);
                Logger.Debug("Decrypted Request ID: " + input.RequestID);

                
                if (requestMap.ContainsKey(input.RequestID))
                {
                    Logger.Error("Successfully logged in");
                    requestMap[input.RequestID] = true;
                    return new AuthenticateOutput()
                    {
                        IsAuthenticated = true,
                        CertificateSerialNumber = authCertificate.SerialNumber,
                        SubjectName = authCertificate.Subject
                    };
                }
                else
                {
                    return new AuthenticateOutput()
                    {
                        IsAuthenticated = false
                    };
                }

            }
            catch (CryptographicException ce) 
            {
                Logger.Error(ce.ToString());
                return new AuthenticateOutput()
                {
                    IsAuthenticated = false
                };
            }
            catch (Exception e)
            {
                Logger.Error("Failed to decrypt request ID ", e);
                return new AuthenticateOutput()
                {
                    IsAuthenticated = false
                };
            }

            
        }


        public void AddRequest(string guid)
        {
            requestMap.Add(guid, null);
        }
    }
}
