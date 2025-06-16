using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureQRFields.Models
{
    public enum FieldEncodingType
    {
        PlainText,
        Encrypted,
        Hashed
    }

    public class FieldEntry
    {
        public string FieldName { get; set; }
        public string OriginalValue { get; set; }
        public FieldEncodingType EncodingType { get; set; }
        public string EncodedValue { get; set; }  // Se genera luego según EncodingType
    }
}

