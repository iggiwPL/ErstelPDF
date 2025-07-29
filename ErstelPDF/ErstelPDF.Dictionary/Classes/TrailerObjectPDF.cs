using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class TrailerObjectPDF : ITrailerObjectPDF
    {
        // Arguments
        public int RootObject { get; set; }

        // Active processed objects
        public int Size { get; set; }
        public int BeginByteTrailer { get; set; }

        // Dependencies
        public ITrailerTransformer trailerTransformer { get; set; }
        public IXReferenceTransformer xReferenceTransformer { get; set; }
        public Queue<LinkedDocumentType> PDFObjects { get; set; }

        /// <summary>
        /// Remember to use the constructor after other object synchronisation.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="ItrailerTransformer">Interface of TrailerTransformer</param>
        /// <param name="IxReferenceTransformer">Interface of XReferenceTransformer</param>
        /// <param name="PDFObjects">The queue of PDF Objects.</param>
        /// <param name="rootObjectID">The root object of PDF.</param>
        public TrailerObjectPDF(ITrailerTransformer ItrailerTransformer, IXReferenceTransformer IxReferenceTransformer, Queue<LinkedDocumentType> PDFObjects, int rootObjectID)
        {
            this.trailerTransformer = ItrailerTransformer;
            this.xReferenceTransformer = IxReferenceTransformer;
            this.PDFObjects = PDFObjects;
            this.RootObject = rootObjectID;
        }
        // Unit testing for the function GetObject() not requied.
        /// <summary>
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <returns>Gets the object of PDF.</returns>
        public string GetObject()
        {
            IByteCounter byteCounter = new ByteCounter();

            this.trailerTransformer.Transform(byteCounter, PDFObjects);

            GetSize(this.xReferenceTransformer);
            GetBeginByteTrailer(this.trailerTransformer);

            string template = "trailer\n" +
                              "<<\n" +
                              $"/Size {this.Size}\n" +
                              $"/Root {this.RootObject} 0 R\n" +
                              ">>\n" +
                              "startxref\n" +
                              $"{this.BeginByteTrailer}\n" +
                              "%%EOF\n";
            return template;
        }
        /// <summary>
        /// 
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="transformer"></param>
        public void GetSize(IXReferenceTransformer transformer)
        {
            this.Size = transformer.RowsCountProperty;
        }
        // Already tested in ByteCounterTest.cs
        /// <summary>
        /// 
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="transformer"></param>
        public void GetBeginByteTrailer(ITrailerTransformer transformer)
        {
            this.BeginByteTrailer = transformer.XrefByteBeginProperty;
        }
    }
}
