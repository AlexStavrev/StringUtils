using BenchmarkDotNet.Attributes;
using System.Drawing;

namespace StringUtilsClassLibrary
{
    [MemoryDiagnoser]
    public class StringUtilsBenchmarkDemo
    {
        [Benchmark]
        public string ReverseCase()
        {
            return StringUtils.ReverseCase("Sample text");
        }

        [Benchmark]
        public string Capitalize()
        {
            return StringUtils.Capitalize("sample text");
        }

        [Benchmark]
        public string ToTitleCase()
        {
            return StringUtils.ToTitleCase("sample text");
        }

        //[Benchmark]
        //public string ToTitleCaseOld()
        //{
        //    return StringUtils.ToTitleCaseOld("sample text");
        //}

        //[Benchmark]
        //public float GetWidthOld()
        //{
        //    return StringUtils.GetWidthOld("Sample text", new Font("Consolas", 16));
        //}

        [Benchmark]
        public string SetWordWrap()
        {
            return StringUtils.SetWordWrap("New long sample text to be split in word wrap", 20);
        }

        [Benchmark]
        public string TranslateByteString()
        {
            return StringUtils.TranslateByteString("01101000011101000111010001110000001110100010111100101111011101110111011101110111001011100110010101100101011011000111001101101100011000010111000000101110011000110110111101101101");
        }

        //[Benchmark]
        //public string TranslateByteString_Henrik()
        //{
        //    return StringUtils.TranslateByteString_Henrik("01101000011101000111010001110000001110100010111100101111011101110111011101110111001011100110010101100101011011000111001101101100011000010111000000101110011000110110111101101101");
        //}

        //[Benchmark]
        //public string TranslateByteString_Old()
        //{
        //    return StringUtils.TranslateByteString_Old("01101000011101000111010001110000001110100010111100101111011101110111011101110111001011100110010101100101011011000111001101101100011000010111000000101110011000110110111101101101");
        //}
    }
}
