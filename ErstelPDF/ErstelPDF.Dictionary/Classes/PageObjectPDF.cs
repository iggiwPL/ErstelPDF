using ErstelPDF.DataTypes;
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
        public PageFormatType pageFormat { get; set; }

        // Active processed
        public int PagesObject { get; set; }
        public int PageObject { get; set; }

        // Cache
        public int SyncCounterTransition { get; set; }

        /// <summary>
        /// Remember to use the constructor after other object synchronisation.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="CurrentObject">The main counter.</param>
        /// <param name="PageFormat">The datatype that specifies the format of a PDF.
        /// Applicable for using.</param>
        public PageObjectPDF(int CurrentObject, PageFormatType PageFormat)
        {
            this.ObjectCounter = CurrentObject;
            this.pageFormat = PageFormat;
        }
        /// <summary>
        /// Counts the IDs of the objects.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        public void CountObjects()
        {
            this.PagesObject = this.ObjectCounter - 1;
            this.PageObject = this.ObjectCounter;
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
        // Datatype custom is requied for format
        // Unit testing for the function GetObject() not requied.
        /// <summary>
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <returns>Gets the object of PDF.</returns>
        public string GetObject()
        {
            string template = $"{this.PageObject} 0 obj\n" +
                              "<<\n" +
                              $"/Type /Page /Parent {this.PagesObject} 0 R /MediaBox [{this.pageFormat.x_lower} {this.pageFormat.y_lower} {this.pageFormat.x_upper} {this.pageFormat.y_upper}]\n" +
                              ">>\n" +
                             "endobj\n";
            return template;
        }
    }
}
