using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Compiler
{
    class Scanner
    {
        public static bool scannerError;
        string variable = "";
        string special = "";

        public void startScanning(string input, Form1 obj, 
            Dictionary<string, string> reservedWords, Dictionary<string, string> specialSymbols)
        {
            scannerError = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]) || Char.IsLetter(input[i]))
                {
                    variable += input[i];
                    if (special != "/*")
                        checkSpecialCharacters(special, specialSymbols, obj);
                    else
                    {
                        i = checkComments(i - 2, input, obj);
                        variable = "";
                        special = "";
                        continue;
                    }
                    special = "";
                }
                else if (input[i] != ' ' && input[i] != '\n' && input[i] != '\r' && input[i] != '\t')
                {
                    special += input[i];
                    checkVariable(variable, reservedWords, obj);
                    variable = "";
                }
                if (i == input.Length - 1 || input[i] == ' ' || input[i] == '\n' || input[i] == '\r' || input[i] == '\t')
                {
                    if (special != "/*")
                        checkSpecialCharacters(special, specialSymbols, obj);
                    else
                    {
                        i = checkComments(i - 2, input, obj);
                        variable = "";
                        special = "";
                        continue;
                    }
                    checkVariable(variable, reservedWords, obj);
                    variable = "";
                    special = "";
                }
            }
        }

        static void checkVariable(string variable, Dictionary<string, string> reservedWords, Form1 obj)
        {
            int tmp;
            if (variable.Length > 0)
            {
                bool Isexp = true;
                bool found = false;
                for (int i = 0; i < variable.Length; i++)
                {
                    if (variable[i] == 'E')
                    {
                        if (found == true || i == variable.Length - 1)
                            Isexp = false;
                        found = true;

                    }
                    else if (!Char.IsDigit(variable[i]))
                        Isexp = false;
                }

                if (Char.IsLetter(variable[0]))
                {
                    if (reservedWords.ContainsKey(variable))
                    {
                        obj.printOnGrid(false, variable, reservedWords[variable]);
                    }
                    else
                        obj.printOnGrid(false, variable, "ID");

                }
                else if (Isexp && found)
                    obj.printOnGrid(false, variable, "Exponent number");
                else if (int.TryParse(variable, out tmp))
                {
                    obj.printOnGrid(false, variable, "Number");
                }
                else
                {
                    obj.printOnGrid(true, variable, "Error!");
                    scannerError = true;
                }
            }
        }


        static void checkSpecialCharacters(string special, Dictionary<string, string> specialSymbols, Form1 obj)
        {
            if (special.Length > 0)
            {
                if (specialSymbols.ContainsKey(special))
                {
                    obj.printOnGrid(false, special, specialSymbols[special]);
                }
                else
                {
                    for (int i = 0; i < special.Length; i++)
                    {
                        if (i < special.Length - 1)
                        {
                            string tmp = special[i].ToString() + special[i + 1];
                            if (specialSymbols.ContainsKey(tmp))
                            {
                                obj.printOnGrid(false, tmp, specialSymbols[tmp]);
                                i++;
                                continue;
                            }

                        }
                        if (specialSymbols.ContainsKey(special[i].ToString()))
                            obj.printOnGrid(false, special[i].ToString(), specialSymbols[special[i].ToString()]);
                        else
                        {
                            obj.printOnGrid(true, special[i].ToString(), "Error! underfined character");
                            scannerError = true;
                        }
                    }

                }
            }
        }

        static int checkComments(int i, string input, Form1 obj)
        {
            string comment = "";
            for (int j = i; ; j++)
            {
                comment += input[j];
                if (input[j] == '*')
                {
                    if (input[j + 1] == '/')
                    {
                        i = j + 1;
                        comment += input[j + 1];
                        break;
                    }
                }
            }
            obj.printOnGrid(false, comment, "Comment");
            return i;
        }
    }
}
