using Newtonsoft.Json;
using SecureQRFields.Models;
using SecureQRFields.Services;
using System.Collections.Generic;
using System.Linq;

namespace SecureQRFields.Utils
{
    public static class JsonHelper
    {
        public static string GenerarJsonProtegido(List<FieldEntry> campos)
        {
            var resultado = new Dictionary<string, string>();

            foreach (var campo in campos)
            {
                string valorFinal = campo.OriginalValue;

                switch (campo.EncodingType)
                {
                    case FieldEncodingType.Encrypted:
                        valorFinal = EncryptionService.Encrypt(valorFinal);
                        break;

                    case FieldEncodingType.Hashed:
                        valorFinal = HashService.Hash(valorFinal);
                        break;

                    case FieldEncodingType.PlainText:
                    default:
                        break;
                }

                resultado[campo.FieldName] = valorFinal;
            }

            return JsonConvert.SerializeObject(resultado, Formatting.Indented);
        }
    }
}
