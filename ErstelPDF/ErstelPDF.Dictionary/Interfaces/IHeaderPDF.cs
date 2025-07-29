using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ErstelPDF.Dictionary.HeaderPDF;

namespace ErstelPDF.Dictionary
{
    public interface IHeaderPDF
    {
        public string GetVersion(VersionPDF version);

        public string GetHeader(VersionPDF version);
    }
}
