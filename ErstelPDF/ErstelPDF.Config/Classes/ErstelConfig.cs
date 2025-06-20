using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Config
{
    public class ErstelConfig : IErstelConfig
    {
        public bool EnableOutlines { get; set; } = true;
    }
}
