using System;
using System.Collections.Generic;
using System.Collections;

namespace Rokt
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = correctness(new List<string>()
            {
                "]}{]](]}{))}",
                "{}()[()]",
                "()",
                "([]({}{})){}()",
                "[){}(]}]}]))](())(",
                "({{)"
            });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static List<string> correctness(List<string> roktx)
        {
            var result = new List<string>();

            foreach (string eachRoktx in roktx)
            {
                result.Add(checkSyntax(eachRoktx));
            }
            return result;

        }

        static string checkSyntax(string braces)
        {
            Stack<char> stack = new Stack<char>();
            int openBracesCount = 0, closeBracesCount = 0;

            for (int i = 0; i < braces.Length; i++)
            {
                if (braces[i] == '[' || braces[i] == '{' || braces[i] == '(')
                {
                    stack.Push(braces[i]);
                    openBracesCount++;
                }
                else if (braces[i] == ']' || braces[i] == '}' || braces[i] == ')')
                {
                    closeBracesCount++;
                    if (stack.Count == 0 || !ComapareThe2ClosestBraces(stack.Pop(), braces[i]))
                    {
                        return "NO";
                    }
                }
            }

            if (openBracesCount != closeBracesCount)
            {
                return "NO";
            }

            return "YES";
        }

        private static bool ComapareThe2ClosestBraces(char openBrace, char closeBrace)
        {
            return (openBrace == '[' && closeBrace ==']')
                || (openBrace == '{' && closeBrace == '}')
                || (openBrace == '(' && closeBrace == ')');
        }
    }
}
