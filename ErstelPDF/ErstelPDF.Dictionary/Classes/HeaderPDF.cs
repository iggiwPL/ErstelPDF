using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class HeaderPDF : IHeaderPDF
    {
        public enum VersionPDF
        {
            PDF_1_0
        }
        
        public string GetVersion(VersionPDF version)
        {
            return version switch 
            {
                VersionPDF.PDF_1_0 => "1.0",
                _ => throw new NotSupportedException()
            };
        }

        public string GetHeader(VersionPDF version)
        {
            return $"%PDF-{GetVersion(version)}\n";
        }
    }
}
