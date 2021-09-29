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
        public float GetWidth()
        {
            return StringUtils.GetWidth("Sample text", new Font("Consolas", 16));
        }

        [Benchmark]
        public string SetWordWrap()
        {
            return StringUtils.SetWordWrap("New long sample text to be split in word wrap", 20);
        }
    }
}
