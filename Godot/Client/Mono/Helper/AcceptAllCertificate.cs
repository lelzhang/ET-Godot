

namespace ET
{
    public class AcceptAllCertificate 
    {
        protected bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}