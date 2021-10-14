using System;
using System.Collections;
using System.Drawing;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using StringUtilsClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        public static bool Benchmark { get; set; }

        static void Main(string[] args)
        {
            Benchmark = false;
            //Console.WriteLine(StringUtils.TranslateByteString2("01101000011101000111010001110000001110100010111100101111011101110111011101110111001011100110010101100101011011000111001101101100011000010111000000101110011000110110111101101101"));
            StartStringUtils();
        }

        private static void StartStringUtils()
        {
            Console.WriteLine("String Case Reversing:");
            Console.WriteLine("* Hello World!".ReverseCase());
            Console.WriteLine("* THIS USED TO BE UPPER CASE!".ReverseCase());
            Console.WriteLine("* 'this used to be all lower case'".ReverseCase());
            Console.WriteLine("* @#*@$@&#_+~<?:\"{}\\".ReverseCase());
            Console.WriteLine("* Тест с кирилица".ReverseCase());

            //Console.WriteLine();
            //Console.WriteLine("String Width Old:");
            //Console.WriteLine($"* Text: 'Hello World!', 'Consolas', 16; Length: {"Hello World!".GetWidthOld(new Font("Consolas", 16))}px");
            //Console.WriteLine($"* Text: 'Hello World!', 'Arial', 20; Length: {"Hello World!".GetWidthOld(new Font("Arial", 20))}px");

            Console.WriteLine();
            Console.WriteLine("String Case Capitalize:");
            Console.WriteLine($"* {"hello world.".Capitalize()}");
            Console.WriteLine($"* {"THIS USED TO BE UPPER CASE!".Capitalize()}");
            Console.WriteLine($"* {"this used to be all lower case".Capitalize()}");
            Console.WriteLine($"* {"@#*@$@&#_+~<?:\"{}\\".Capitalize()}");
            Console.WriteLine($"* {"тест с кирилица".Capitalize()}");

            Console.WriteLine();
            Console.WriteLine("String Title Case:");
            Console.WriteLine($"* {"hello world.".ToTitleCase()}");
            Console.WriteLine($"* {"THIS USED TO BE UPPER CASE!".ToTitleCase()}");
            Console.WriteLine($"* {"this used to be all lower case".ToTitleCase()}");
            Console.WriteLine($"* {"@#*@$@&#_+~<?:\"{}\\".ToTitleCase()}");
            Console.WriteLine($"* {"тест с кирилица".ToTitleCase()}");

            Console.WriteLine();
            Console.WriteLine("String Word Wrap:");
            string longText = "Hello! This will be a very long text that will be word wrapped so it fits in a set width. This will happen by splitting it in new lines";
            Console.WriteLine($"* Long text with 60 word wrap:\n{longText.SetWordWrap(60)}");
            Console.WriteLine($"* Long text with 30 word wrap:\n{longText.SetWordWrap(30)}");
            Console.WriteLine($"* Long text with 10 word wrap:\n{longText.SetWordWrap(11)}");

            Console.WriteLine();
            string[] websites = {
                "01101000011101000111010001110000001110100010111100101111011101110111011101110111001011100110010101100101011011000111001101101100011000010111000000101110011000110110111101101101",
                "011010000111010001110100011100000011101000101111001011110110001101101111011100100110011101101001011011110111001001100111011110010010111001100011011011110110110100101111",
                "01101000011101000111010001110000001110100010111100101111011011100110111101101111011011110110111101101111011011110110111101101111011011110110111101101111011011110110111101101111011011110010111001100011011011110110110100101111",
                "011010000111010001110100011100000011101000101111001011110110100001100001011011100110010101101011011001010010111001101110011001010111010000101111"
            };
            foreach (string site in websites)
            {
                Console.WriteLine($"Translating byte string: {site}...");
                Console.WriteLine($"* {StringUtils.TranslateByteString(site)}");
            }

            if(Benchmark)
            {
                Console.WriteLine();
                Console.WriteLine("Performance diagnostics:");
                BenchmarkRunner.Run<StringUtilsBenchmarkDemo>();
            }
        }
    }
}
