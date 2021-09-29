using System;
using System.Drawing;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using StringUtilsClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Case Reversing:");
            Console.WriteLine("* Hello World!".ReverseCase());
            Console.WriteLine("* THIS USED TO BE UPPER CASE!".ReverseCase());
            Console.WriteLine("* 'this used to be all lower case'".ReverseCase());
            Console.WriteLine("* @#*@$@&#_+~<?:\"{}\\".ReverseCase());
            Console.WriteLine("* Тест с кирилица".ReverseCase());

            Console.WriteLine();
            Console.WriteLine("String Width:");
            Console.WriteLine($"* Text: 'Hello World!', 'Consolas', 16; Length: {"Hello World!".GetWidth(new Font("Consolas", 16))}px");
            Console.WriteLine($"* Text: 'Hello World!', 'Arial', 20; Length: {"Hello World!".GetWidth(new Font("Arial", 20))}px");

            Console.WriteLine("String Word Wrap:");
            string longText = "Hello! This will be a very long text that will be word wrapped so it fits in a set width. This will happen by splitting it in new lines";
            Console.WriteLine($"* Long text with 60 word wrap:\n{longText.SetWordWrap(60)}");
            Console.WriteLine($"* Long text with 30 word wrap:\n{longText.SetWordWrap(30)}");
            Console.WriteLine($"* Long text with 10 word wrap:\n{longText.SetWordWrap(11)}");

            Console.WriteLine("Performance diagnostics:");
            BenchmarkRunner.Run<StringUtilsBenchmarkDemo>();
        }
    }
}
