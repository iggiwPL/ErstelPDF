using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public interface ICatalogObjectPDF
    {
        public void CountObjects();

        public void SyncMainCounter(ref int MainObjectCounter, ref int RootObject);

        public string GetObject();
    }
}
