using System.Collections.Generic;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Stacks
{
    
    internal class ErstelStacks
    {
        public static Queue<String> DocumentTextContent = new Queue<String>();
        
        public static Queue<XReferenceType> XreferenceTable = new Queue<XReferenceType>();

    }
}
