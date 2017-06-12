using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    static class StringWordsReverser
    {
        public static string ReverseWords(string originalStr)
        {
            var words = originalStr.Split(new[] { '.', ',', '_', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var reversedWords = new List<string>();
            foreach (var word in words)
            {
                reversedWords.Add(new string(word.Reverse().ToArray()));
            }
            var newStr = originalStr;
            for (int i = 0; i < words.Length; i++)
            {
                newStr = newStr.Replace(words[i], reversedWords[i]);
            }
            return newStr;
        }

        public static string ReverseWords2(string srcStr)
        {
            var dstStr = new StringBuilder();
            for (int srcIndx = 0, wordLen = 0; srcIndx < srcStr.Length; srcIndx++)
            {
                if (!char.IsLetter(srcStr[srcIndx]))
                {
                    ReverseWord(srcStr, srcIndx - 1, wordLen, dstStr);    // Перевернуть слово, если не буква
                    dstStr.Append(srcStr[srcIndx]);                       // Сохранить символ не букву
                    wordLen = 0;
                }
                else
                {
                    wordLen++;
                }
            }
            return dstStr.ToString();
        }

        /// <summary>
        /// Перевернуть слово в указанной строке и сохранить в указанную строку
        /// </summary>
        /// <param name="srcStr"> Строка источник </param>
        /// <param name="srcStrIndx"> Индекс конца переворачиваемого слова </param>
        /// <param name="wordLen"> Длина слова </param>
        /// <param name="dstStr"> Строка приемник </param>
        private static void ReverseWord(string srcStr, int srcStrIndx, int wordLen, StringBuilder dstStr)
        {
            for (int i = srcStrIndx; wordLen > 0; i--, wordLen--)
            {
                dstStr.Append(srcStr[i]);
            }
        }
    }
}
