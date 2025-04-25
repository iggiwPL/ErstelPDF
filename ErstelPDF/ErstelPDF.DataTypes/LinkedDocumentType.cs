using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.DataTypes
{
    // Mask the queue string of DocumentTextContent
    public class LinkedDocumentType
    {
        public string Content { get; set; }

        public LinkedDocumentType(string Content)
        {
            this.Content = Content;
        }

        public override bool Equals(object obj)
        {
            if( (obj == null) || !(obj is LinkedDocumentType))
            {
                return false;
            }
            LinkedDocumentType other = (LinkedDocumentType)obj;
            return other.Content == Content;
        }

        public override int GetHashCode() 
        { 
            return Content.GetHashCode();
        } 
    }
}
