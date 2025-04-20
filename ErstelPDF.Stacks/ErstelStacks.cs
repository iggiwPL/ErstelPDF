using ErstelPDF.DataTypes;

namespace ErstelPDF.Stacks
{
    
    internal class ErstelStacks
    {
        public static Queue<LinkedDocumentType> DocumentTextContent = new Queue<LinkedDocumentType>();
        
        public static Queue<XReferenceType> XreferenceTable = new Queue<XReferenceType>();

    }
}
