using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFromCleverenceSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            RLE_Work();

            SingleFormat_Work();
        }
        static void RLE_Work()
        {
            RLE Rle = new RLE();
            Console.WriteLine(Rle.Сoding());
            Console.WriteLine(Rle.Decoding());
            Console.ReadLine();
        }
        static void SingleFormat_Work()
        {
            SingleFormat singleFormat = new SingleFormat();
            singleFormat.Work(@"..\..\Files\FirstFormat.txt");
            singleFormat.Work(@"..\..\Files\SecondFormat.txt");
            singleFormat.Work(@"..\..\Files\IncorrectFormat.txt");
        }
    }
}
