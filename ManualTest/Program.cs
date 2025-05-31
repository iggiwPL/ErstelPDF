using ErstelPDF.Core;

namespace ManualTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ErstelCore core = new ErstelCore();
            await core.CompileToPDFAsync(Directory.GetCurrentDirectory() + "/example.pdf");
            await core.CompileToPDFAsync(Directory.GetCurrentDirectory() + "/example1.pdf");
            await core.CompileToPDFAsync(Directory.GetCurrentDirectory() + "/example2.pdf");
        }
    }
}
