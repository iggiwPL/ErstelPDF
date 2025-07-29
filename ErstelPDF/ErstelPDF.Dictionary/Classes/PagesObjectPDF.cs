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

        /// <summary>
        /// Remember to use the constructor after other object synchronisation.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="CurrentObject">The main counter.</param>
        /// <param name="CountPages">Count of pages. Will be extended and removed from parameters.</param>
        public PagesObjectPDF(int CurrentObject, int CountPages)
        {
            this.ObjectCounter = CurrentObject;
            this.CountPages = CountPages;
        }
        /// <summary>
        /// Counts the IDs of the objects.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        public void CountObjects()
        {
            this.PagesObject = this.ObjectCounter;
            this.PageObject = this.ObjectCounter + 1;
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
        // Make transformer for multipage if in specs it's available and possible
        // Unit testing for the function GetObject() not requied.
        /// <summary>
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <returns>Gets the object of PDF.</returns>
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
