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
        public CatalogObjectPDF(int CurrentObj, int RootObj, PageOutlineMode PageMode) 
        {
             this.RootObject = RootObj;
             this.ObjectCounter = CurrentObj;
             this.PageMode = GetAttribObject(PageMode);
        }
        
        public void CountObjects()
        {
            this.CatalogObject = this.ObjectCounter; // Our object
            this.RootObject = this.ObjectCounter;

            this.OutlinesObject = this.ObjectCounter + 1; // Next object
            

            this.PagesObject = this.ObjectCounter + 2; // Next object
        }
        public void SyncMainCounter(ref int MainObjectCounter, ref int RootObject)
        {
            RootObject = this.RootObject;
          
            this.SyncCounterTransition = this.ObjectCounter + 1;
            MainObjectCounter = this.SyncCounterTransition;

        }
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
