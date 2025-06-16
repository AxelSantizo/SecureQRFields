using QRCoder;
using System.Drawing;

namespace SecureQRFields.Services
{
    public static class QRService
    {
        public static Bitmap GenerarQRDesdeTexto(string contenido)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrData = qrGenerator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrData))
                {
                    return qrCode.GetGraphic(5); // 5 = resolución
                }
            }
        }
    }
}
