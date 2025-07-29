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

        /// <summary>
        /// Remember to use the constructor after other object synchronisation.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="CurrentObject">The main counter.</param>
        public OutlinesObjectPDF(int CurrentObject)
        {
            this.ObjectCounter = CurrentObject;
        }
        /// <summary>
        /// Counts the IDs of the objects.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        public void CountObjects()
        {
            this.OutlinesObject = this.ObjectCounter;
        }
        /// <summary>
        /// Synchronises with main counter.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="MainCounter">The main counter that is pointed to main counter to synchronise.</param>
        public void SyncMainCounter(ref int MainCounter)
        {
            this.SyncCounterTransition = this.ObjectCounter + 1;
            MainCounter = this.SyncCounterTransition;
        }

        // Unit testing for the function GetObject() not requied.
        /// <summary>
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <returns>Gets the object of PDF.</returns>
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