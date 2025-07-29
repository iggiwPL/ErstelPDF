using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class HeaderPDF : IHeaderPDF
    {
        /// <summary>
        /// The enum that is base of header and it's version.
        /// Applicable to use directly in end-user program.
        /// </summary>
        public enum VersionPDF
        {
            PDF_1_0
        }
        /// <summary>
        /// Used to get a version of a PDF used in header.
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="version">Version is an enum for choosing a version of a PDF file.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public string GetVersion(VersionPDF version)
        {
            return version switch 
            {
                VersionPDF.PDF_1_0 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
        /// <summary>
        /// Used for get header of the PDF and it's version. 
        /// Not applicable to use directly in end-user program.
        /// </summary>
        /// <param name="version">Version is an enum for choosing a version of a PDF file.</param>
        /// <returns>Full header of the PDF.</returns>
        public string GetHeader(VersionPDF version)
        {
            return $"%PDF-{GetVersion(version)}\n";
        }
    }
}
