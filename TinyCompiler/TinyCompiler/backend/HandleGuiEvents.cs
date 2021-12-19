using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TinyCompiler.Core;

namespace TinyCompiler.backend
{
    class HandleGuiEvents
    {
        public static string loadFileEvent()
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*", Multiselect = false })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        return (File.ReadAllText(dialog.FileName));
                    }
                    catch
                    {
                        MessageBox.Show("Error loading file !", "DIALOG RESULT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return "";
        }

        public static string getLinesNumbers(string sourceCode)
        {
            string linesNumbers = "";
            int k = 1; 
            linesNumbers += (k++) + System.Environment.NewLine;
            for (int i = 0; i < sourceCode.Length; ++i)
                if (sourceCode[i] == '\n')
                    linesNumbers += (k++) + System.Environment.NewLine;
            return linesNumbers;
        }

        public static void compileEvent(string sourceCode)
        {
            Compiler.Lines.Clear();
            Compiler.Lexemes.Clear();
            Compiler.TokenStream.Clear();
            Errors.errorsList.Clear();
            Errors.parserErrors.Clear();
            Compiler.StartCompiling(sourceCode);
        }

        public static List<KeyValuePair<int, KeyValuePair<string, string>>> getTokensData()
        {
            List<KeyValuePair<int, KeyValuePair<string, string>>> tokens =
                new List<KeyValuePair<int, KeyValuePair<string, string>>>();
            for (int i = 0; i < Compiler.TokenStream.Count; ++i)
            {
                int line = Compiler.Lines[i];
                string lexeme = Compiler.Lexemes[i];
                string tokenDesc = Compiler.TokenStream[i].description;
                tokens.Add(new KeyValuePair<int, KeyValuePair<string, string>>(line, 
                           new KeyValuePair<string, string>(lexeme, tokenDesc)));
            }
            return tokens;
        }

        public static List<KeyValuePair<int, KeyValuePair<string, string>>> getErrorsList()
        {
            List<KeyValuePair<int, KeyValuePair<string, string>>> errors = 
                new List<KeyValuePair<int, KeyValuePair<string, string>>>();
            foreach (var item in Errors.errorsList)
            {
                int line = item.Key;
                string token = item.Value;
                string errorDesc = "Unrecognized token !";
                errors.Add(new KeyValuePair<int, KeyValuePair<string, string>>(line, 
                           new KeyValuePair<string, string> (token, errorDesc)));
            }
            return errors;
        }
    }
}
