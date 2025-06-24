using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class PageObjectPDF : IPageObjectPDF
    {
        // Arguments
        public int ObjectCounter { get; set; }

        // Active processed
        public int PagesObject { get; set; }
        public int PageObject { get; set; }

        // Cache
        public int SyncCounterTransition { get; set; }

        public PageObjectPDF(int CurrentObject)
        {
            this.ObjectCounter = CurrentObject;
        }
        public void CountObjects()
        {
            this.PagesObject = this.ObjectCounter - 1;
            this.PageObject = this.ObjectCounter;
        }
        public void SyncMainCounter(ref int MainCounter)
        {
            this.SyncCounterTransition = this.ObjectCounter + 1;
            MainCounter = this.SyncCounterTransition;
        }
        // Datatype custom is requied for format
        public string GetObject()
        {
            string template = $"{this.PageObject} 0 obj\n" +
                              "<<\n" +
                              $"/Type /Page /Parent {this.PagesObject} 0 R /MediaBox [0 0 612 792]\n" +
                              ">>\n" +
                             "endobj\n";
            return template;
        }
    }
}
