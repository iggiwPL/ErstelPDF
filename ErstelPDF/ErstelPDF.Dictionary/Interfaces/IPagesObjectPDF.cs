using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Dictionary
{
    public interface IPagesObjectPDF
    {
        public void CountObjects();
        public void SyncMainCounter(ref int MainCounter);
        public string GetObject();

    }
}
