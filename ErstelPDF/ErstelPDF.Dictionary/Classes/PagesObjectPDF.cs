using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class PagesObjectPDF : IPagesObjectPDF
    {
        // Arguments
        public int ObjectCounter { get; set; }
        public int CountPages { get; set; }

        // Active processed objects
        public int PagesObject { get; set; }
        public int PageObject { get; set; }
        
        // Cache
        public int SyncCounterTransition { get; set; }

        public PagesObjectPDF(int CurrentObject, int CountPages)
        {
            this.ObjectCounter = CurrentObject;
            this.CountPages = CountPages;
        }
        public void CountObjects()
        {
            this.PagesObject = this.ObjectCounter;
            this.PageObject = this.ObjectCounter + 1;
        }
        public void SyncMainCounter(ref int MainCounter)
        {
            this.SyncCounterTransition = this.ObjectCounter + 1;
            MainCounter = this.SyncCounterTransition;
        }
        // Make transformer for multipage if in specs it's available and possible
        public string GetObject()
        {
            string template = $"{this.PagesObject} 0 obj\n" +
                            "<<\n" +
                            $"/Type /Pages /Kids [{this.PageObject} 0 R] /Count {this.CountPages}\n" +
                            ">>\n" +
                            "endobj\n";
            
            return template;
        }
    }
}
