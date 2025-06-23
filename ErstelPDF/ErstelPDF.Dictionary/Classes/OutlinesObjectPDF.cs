using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class OutlinesObjectPDF : IOutlinesObjectPDF
    {
        // Arguments
        public int ObjectCounter { get; set; }

        // Active processed counts
        public int OutlinesObject { get; set; }

        // Cache 
        public int SyncCounterTransition { get; set; }

        public OutlinesObjectPDF(int CurrentObject)
        {
            this.ObjectCounter = CurrentObject;
        }

        public void CountObjects()
        {
            this.OutlinesObject = this.ObjectCounter;
        }

        public void SyncMainCounter(ref int MainCounter)
        {
            this.SyncCounterTransition = this.ObjectCounter + 1;
            MainCounter = this.SyncCounterTransition;
        }

        public string GetObject()
        {
            string template = $"{this.OutlinesObject} 0 obj\n" +
                    "<<\n" +
                    "/Type /Outlines\n" +
                    "/Count 0\n" +
                    ">>\n" +
                    "endobj\n";

            return template;
        }
    }
}