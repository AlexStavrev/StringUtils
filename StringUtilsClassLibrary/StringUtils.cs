using BenchmarkDotNet.Attributes;
using System;
using System.Drawing;
using System.Text;

namespace StringUtilsClassLibrary
{
    public static class StringUtils
    {
        private static readonly Graphics graphics = Graphics.FromImage(new Bitmap(1, 1));

        public static string ReverseCase(this string text)
        {
            StringBuilder reversedCaseString = new();
            foreach(char letter in text)
            {
                if (Char.IsLetter(letter))
                {
                    reversedCaseString.Append((Char.IsUpper(letter)) ? Char.ToLower(letter) : Char.ToUpper(letter));
                }
                else
                {
                    reversedCaseString.Append(letter);
                }
            }
            return reversedCaseString.ToString();
        }

        public static float GetWidth(this string text, Font font)
        {
            return graphics.MeasureString(text, font).Width;
        }

        public static string SetWordWrap(this string text, int maxCharactersPerLine)
        {
            StringBuilder wordWrappedText = new();
            int currentIndex;
            int lastWrap = 0;
            char[] whitespace = new[] { ' ', '\r', '\n', '\t' };
            do
            {
                currentIndex = (lastWrap + maxCharactersPerLine > text.Length)
                    ? text.Length
                    : (text.LastIndexOfAny(whitespace, Math.Min(text.Length - 1, lastWrap + maxCharactersPerLine)) + 1);
                if (currentIndex <= lastWrap)
                {
                    currentIndex = Math.Min(lastWrap + maxCharactersPerLine, text.Length);
                }
                wordWrappedText.AppendLine(text[lastWrap..currentIndex].Trim(whitespace));
                lastWrap = currentIndex;
            } while (currentIndex < text.Length);

            return wordWrappedText.ToString();
        }
    }
}
