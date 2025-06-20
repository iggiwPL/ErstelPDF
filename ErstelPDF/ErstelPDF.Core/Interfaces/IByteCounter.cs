using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Core
{
    public interface IByteCounter
    {
        public int CountBytesObject(string content);
    }
}
