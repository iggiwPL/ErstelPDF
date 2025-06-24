using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.DataTypes
{
    public class PageFormatType
    {
        public int x_lower { get; set; }
        public int y_lower { get; set; }
        public int x_upper { get; set; }
        public int y_upper { get; set; }
       


        public PageFormatType() { }

        public PageFormatType(int x_lower, int y_lower, int x_upper, int y_upper)
        {
            this.x_lower = x_lower;
            this.y_lower = y_lower;

            this.x_upper = x_upper;
            this.y_upper = y_upper;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PageFormatType))
            {
                return false;
            }
            PageFormatType other = (PageFormatType)obj;
            return this.x_lower == other.x_lower && this.y_lower == other.y_lower && this.x_upper == other.x_upper && this.y_upper == other.y_upper;
        }
        public override int GetHashCode()
        {
            return x_lower.GetHashCode() ^ y_lower.GetHashCode() ^ x_upper.GetHashCode() ^ y_upper.GetHashCode();
        }
    }
}
