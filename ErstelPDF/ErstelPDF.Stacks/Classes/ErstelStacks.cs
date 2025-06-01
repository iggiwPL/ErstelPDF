using ErstelPDF.DataTypes;

namespace ErstelPDF.Stacks
{
    
    public class ErstelStacks
    {
        public Queue<LinkedDocumentType> DocumentTextContent = new Queue<LinkedDocumentType>();
        
        public Queue<XReferenceType> XreferenceTable = new Queue<XReferenceType>();

    }
}
