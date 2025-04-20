namespace ErstelPDF.DataTypes
{
    internal class XReferenceType
    {
        public string ByteOffset { get; set; }
        public string GenerationNumber { get; set; }
        public char AttributeObject { get; set; }

        public XReferenceType(string ByteOffset, string GenerationNumber, char AttributeObject) 
        { 
            this.ByteOffset = ByteOffset;
            this.GenerationNumber = GenerationNumber;
            this.AttributeObject = AttributeObject;
        }
        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is XReferenceType))
            {
                 return false;
            }
            XReferenceType other = (XReferenceType)obj;
            return this.ByteOffset == other.ByteOffset && this.GenerationNumber == other.GenerationNumber && this.AttributeObject == other.AttributeObject;
        }
        public override int GetHashCode()
        {
            return ByteOffset.GetHashCode() ^ GenerationNumber.GetHashCode() ^ AttributeObject.GetHashCode();
        }
    }
}
