using Microsoft.Extensions.Options;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthurium.API.Helpers {
  public class QRCodeEnrpytion {
    private static readonly string _secretKey =
        "LcpbD6yV34ckuXGdqcs4HL52w6c9npWDZUhz4GmvRjCsr8AjVqcX4";

    public static string GenerateQRCode(string stringToQrCode) {

      var encrpytionString =
          EncrpytionMechanism.EncryptString(stringToQrCode, _secretKey);

      QRCodeGenerator qrGenerator = new QRCodeGenerator();
      QRCodeData qrCodeData = qrGenerator.CreateQrCode(
          encrpytionString, QRCodeGenerator.ECCLevel.Q);
      Base64QRCode qrCode = new Base64QRCode(qrCodeData);
      string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

      return qrCodeImageAsBase64;

      //
      //   var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    }
  }
}
