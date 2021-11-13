using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Compiler
{
    class Initializer
    {
        Dictionary<string, string> reservedWords, specialSymbols;
        public Initializer()
        {
            reservedWords = new Dictionary<string, string>();
            specialSymbols = new Dictionary<string, string>();

            reservedWords.Add("If", "if-stmt");
            reservedWords.Add("Then", "then-stmt");
            reservedWords.Add("Else", "else-stmt");
            reservedWords.Add("End", "end-stmt");
            reservedWords.Add("Repeat", "repeat-stmt");
            reservedWords.Add("Until", "until-stmt");
            reservedWords.Add("Read", "Read-input-stmt");
            reservedWords.Add("Write", "Write-output-stmt");

            specialSymbols.Add("+", "Addition-symbol");
            specialSymbols.Add("-", "Subtraction-symbol");
            specialSymbols.Add("*", "Multiplication-symbol");
            specialSymbols.Add("=", "Equal-symbol");
            specialSymbols.Add(":=", "Assignment-symbol");
            specialSymbols.Add(">", "Greater-symbol");
            specialSymbols.Add("<", "Smaller-symbol");
            specialSymbols.Add(">=", "Greater or Equal-symbol");
            specialSymbols.Add("<=", "Smaller or Equal-symbol");
            specialSymbols.Add("!=", "Not equal-symbol");
            specialSymbols.Add(";", "Semicolon symbol");
            specialSymbols.Add("(", "Left Parenthesis");
            specialSymbols.Add(")", "Right Parenthesis");
        }
        public Dictionary<string, string> getReservedWords()
        {
            return reservedWords;
        }
        public Dictionary<string, string> getSpecialSymbols()
        {
            return specialSymbols;
        }
    }
}
