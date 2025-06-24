using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public interface IOutlinesObjectPDF
    {
        public void CountObjects();
        public void SyncMainCounter(ref int MainCounter);
        public string GetObject();
    }
}
