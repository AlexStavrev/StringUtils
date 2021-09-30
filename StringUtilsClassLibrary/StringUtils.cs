using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public static string TranslateByteString(string binaryString)
        {
            StringBuilder textBuilder = new StringBuilder();
            byte byteIncrement = 128;
            byte currentByte = 0;

            foreach (char bit in binaryString)
            {
                if (bit == '1')
                {
                    currentByte += byteIncrement;
                }
                byteIncrement /= 2;

                if (byteIncrement == 0)
                {
                    textBuilder.Append((char)currentByte);
                    byteIncrement = 128;
                    currentByte = 0;
                }
            }
            return textBuilder.ToString();
        }

        // My first attempt
        public static string TranslateByteString_Old(string bytes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string byteString in bytes.SplitAtParts(8))
            {
                byte value = 128;
                byte current = 0;
                foreach (char bit in byteString)
                {
                    if (bit == '1')
                    {
                        current += value;
                    }
                    value /= 2;
                }
                stringBuilder.Append((char)current);
            }
            return stringBuilder.ToString();
        }

        // Given example solution by Henrik
        public static string TranslateByteString_Henrik(string bytes)
        {
            int index = 7; // Start with MSB to the right of the 8 bits
            char result = (char)0;
            StringBuilder textBuilder = new StringBuilder();
            foreach (char t in bytes)
            {
                // Skip anything that is not '0' or '1'
                if ((t == '0') || (t == '1'))
                {
                    if (t == '1')
                    {
                        result += (char)(1 << index); // Using the left-shift operator
                    }
                    index--;
                    if (index == -1)
                    {
                        // Copy the new char to the output text, reset result and index
                        textBuilder.Append(result);
                        result = (char)0;
                        index = 7;
                    }
                }
            }
            return textBuilder.ToString();

        }

        private static IEnumerable<string> SplitAtParts(this string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
