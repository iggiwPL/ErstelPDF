using ErstelPDF.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{

    public class CatalogObjectPDF : ICatalogObjectPDF
    {
        // Arguments
        public int RootObject {  get; set; }
        public int ObjectCounter { get; set; }
        public string PageMode { get; set; } = "";

        // Properties
        /// <summary>
        /// The enum where outline mode is selected.
        /// Applicable to use directly in end-user program.
        /// </summary>
        public enum PageOutlineMode
        {
            Outlines,
            Thumbnails,
            None
        }

        // Active processed counts
        public int CatalogObject {  get; set; }
        public int PagesObject { get; set; }
        public int OutlinesObject { get; set; }

        
        // Cache 
        public int SyncCounterTransition { get; set; }


        // Download all arguments on construction of the instance
        /// <summary>
        /// Remember to use the constructor after other object synchronisation.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="CurrentObject"></param>
        /// <param name="RootObject"></param>
        /// <param name="PageMode"></param>
        public CatalogObjectPDF(int CurrentObject, int RootObject, PageOutlineMode PageMode) 
        {
             this.RootObject = RootObject;
             this.ObjectCounter = CurrentObject;
             this.PageMode = GetAttribObject(PageMode);
        }

        /// <summary>
        /// Counts the IDs of the objects.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        public void CountObjects()
        {
            this.CatalogObject = this.ObjectCounter; // Our object
            this.RootObject = this.ObjectCounter;

            this.OutlinesObject = this.ObjectCounter + 1; // Next object
            

            this.PagesObject = this.ObjectCounter + 2; // Next object
        }
        /// <summary>
        /// Used to synchronise with main counter.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="MainObjectCounter">The main counter that is pointed to main counter to synchronise.</param>
        /// <param name="RootObject">The root object that is base for PDF.</param>
        public void SyncMainCounter(ref int MainObjectCounter, ref int RootObject)
        {
            RootObject = this.RootObject;
          
            this.SyncCounterTransition = this.ObjectCounter + 1;
            MainObjectCounter = this.SyncCounterTransition;

        }
        /// <summary>
        /// Gets a attribute for mode of a catalog.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="PageMode">Mode of the page. Specified by enum called PageOutlineMode.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public string GetAttribObject(PageOutlineMode PageMode)
        {
            return PageMode switch
            {
                PageOutlineMode.Outlines => "/UseOutlines",
                PageOutlineMode.Thumbnails => "/UseThumbs",
                PageOutlineMode.None => "/UseNone",
                _ => throw new NotSupportedException()
            };
        }
        // Unit testing for the function GetObject() not requied.
        /// <summary>
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <returns>Gets the object of PDF.</returns>
        public string GetObject()
        {
            string template = $"{this.CatalogObject} 0 obj\n" +
                    "<<\n" +
                    "/Type /Catalog\n" +
                    $"/Pages {this.PagesObject} 0 R\n" +
                    $"/Outlines {this.OutlinesObject} 0 R\n" +
                    $"/PageMode {this.PageMode}\n" +
                    ">>\n" +
                    "endobj\n";

            return template;
        }

    }
}
