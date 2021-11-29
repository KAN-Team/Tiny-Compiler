using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TinyCompiler.Core
{
    class Scanner
    {
        private List<Token> Tokens;
        private readonly Dictionary<string, TokenType> ReservedWords;
        private readonly Dictionary<string, TokenType> Operators;
        private readonly Regex idRegex;
        private readonly Regex numRegex;
        private readonly Regex strRegex;
        private readonly Regex commRegex;
        private int line; // token line number in editor for visualization

        public Scanner()
        {
            Token.addDescription();
            Tokens = new List<Token>();
            Operators = new Dictionary<string, TokenType>();
            ReservedWords = new Dictionary<string, TokenType>();
            idRegex = new Regex("^[a-zA-Z][a-zA-Z0-9_]*|_[a-zA-Z0-9]+_*$");
            numRegex = new Regex("^[+|-]?[0-9]+(.[0-9]+)?$");
            strRegex = new Regex("^\"[^\"]*\"$");
            commRegex = new Regex("^/\\*(\\D|\\d|\\s)*\\*/$");
            initializer();
        }

        private void initializer()
        {
            ReservedWords.Add("if", TokenType.If);
            ReservedWords.Add("return", TokenType.Return);
            ReservedWords.Add("repeat", TokenType.Repeat);
            ReservedWords.Add("read", TokenType.Read);
            ReservedWords.Add("write", TokenType.Write);
            ReservedWords.Add("until", TokenType.Until);
            ReservedWords.Add("elseif", TokenType.Elseif);
            ReservedWords.Add("else", TokenType.Else);
            ReservedWords.Add("end", TokenType.End);
            ReservedWords.Add("endl", TokenType.Endl);
            ReservedWords.Add("then", TokenType.Then);
            ReservedWords.Add("main", TokenType.Main);
            ReservedWords.Add("string", TokenType.String);
            ReservedWords.Add("int", TokenType.Integer);
            ReservedWords.Add("float", TokenType.Float);

            Operators.Add(";", TokenType.Semicolon);
            Operators.Add(",", TokenType.Comma);
            Operators.Add("(", TokenType.LParanthesis);
            Operators.Add(")", TokenType.RParanthesis);
            Operators.Add("{", TokenType.LBraces);
            Operators.Add("}", TokenType.RBraces);
            Operators.Add("=", TokenType.EqualOp);
            Operators.Add("<", TokenType.LessThanOp);
            Operators.Add(">", TokenType.GreaterThanOp);
            Operators.Add("<>", TokenType.NotEqualOp);
            Operators.Add("+", TokenType.PlusOp);
            Operators.Add("-", TokenType.MinusOp);
            Operators.Add("*", TokenType.MultiplyOp);
            Operators.Add("/", TokenType.DivideOp);
            Operators.Add("&&", TokenType.AndOp);
            Operators.Add("||", TokenType.OrOp);
            Operators.Add(":=", TokenType.Assignment);
        }

        public void StartScanning(string sourceCode)
        {
            line = 1;
            int tempLines; // for comment statement and string text
            for (int i = 0; i < sourceCode.Length; ++i)
            {
                int j = i;
                char currentChar = sourceCode[i];
                string currentLexeme = currentChar.ToString();
                tempLines = 0;

                if (currentChar == '\n')
                    line++;
                if (currentChar == ' ' || currentChar == '\r' || currentChar == '\n' || currentChar == '\t')
                    continue;

                if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    j++;
                    while (j < sourceCode.Length)
                    {
                        currentChar = sourceCode[j];
                        if (!(char.IsLetter(currentChar) || char.IsDigit(currentChar) || currentChar == '_'))
                            break;

                        currentLexeme += currentChar;
                        j++;
                    }
                }

                else if (char.IsDigit(currentChar))
                {
                    j++;
                    while (j < sourceCode.Length)
                    {
                        currentChar = sourceCode[j];
                        if (!(char.IsDigit(currentChar) || currentChar == '.'))
                            break;

                        currentLexeme += currentChar;
                        j++;
                    }
                }

                else
                {
                    if (currentChar == '/'
                        && j + 1 < sourceCode.Length
                        && sourceCode[j + 1] == '*')
                    {
                        j += 2;
                        while (j < sourceCode.Length)
                        {
                            if (sourceCode[j] == '\n')
                                tempLines++;
                            if (j < sourceCode.Length - 1 && sourceCode[j] == '*'
                                && sourceCode[j + 1] == '/')
                            {
                                j += 2;
                                break;
                            }
                            j++;
                        }
                        currentLexeme = sourceCode.Substring(i, j - i);
                    }
                    else if (currentChar == '"')
                    {
                        j++;
                        while (j < sourceCode.Length)
                        {
                            if (sourceCode[j] == '\n')
                                tempLines++;
                            if (sourceCode[j] == '"')
                            {
                                j++;
                                break;
                            }
                            j++;
                        }
                        currentLexeme = sourceCode.Substring(i, j - i);
                    }
                    else if (currentChar == '.')
                    {
                        j++;
                        while (j < sourceCode.Length)
                        {
                            if (sourceCode[j] == '\n')
                                tempLines++;
                            if (sourceCode[j] == ' ' || sourceCode[j] == '\n')
                            {
                                j++;
                                break;
                            }
                            j++;
                        }
                        currentLexeme = sourceCode.Substring(i, j - i);
                    }
                    else if (currentChar == ':')
                    {
                        j++;
                        if (j < sourceCode.Length && sourceCode[j] == '=')
                        {
                            currentLexeme = ":=";
                            j++;
                        }
                    }
                    else if (currentChar == '<')
                    {
                        j++;
                        if (j < sourceCode.Length && sourceCode[j] == '>')
                        {
                            currentLexeme = "<>";
                            j++;
                        }
                    }
                    else if (currentChar == '&')
                    {
                        j++;
                        if (j < sourceCode.Length && sourceCode[j] == '&')
                        {
                            currentLexeme = "&&";
                            j++;
                        }
                    }
                    else if (currentChar == '|')
                    {
                        j++;
                        if (j < sourceCode.Length && sourceCode[j] == '|')
                        {
                            currentLexeme = "||";
                            j++;
                        }
                    }
                    else
                        j++;
                }

                findTokenType(currentLexeme);
                line += tempLines;
                i = j-1;
            }

            Compiler.TokenStream = Tokens;
        }

        void findTokenType(string Lexeme)
        {
            bool isError = false;
            Token Tok = new Token();
            Tok.lexeme = Lexeme;

            if (isReservedWord(Lexeme))
                Tok.tokenType = ReservedWords[Lexeme];
            else if (isIdentifier(Lexeme))
                Tok.tokenType = TokenType.Idenifier;
            else if (isConstant(Lexeme))
                Tok.tokenType = TokenType.Constant;
            else if (isString(Lexeme))
                Tok.tokenType = TokenType.StringText;
            else if (isOperator(Lexeme))
                Tok.tokenType = Operators[Lexeme];
            else if (isComment(Lexeme))
                Tok.tokenType = TokenType.Comment;
            else
            {
                isError = true;
                Errors.errorsList.Add(new KeyValuePair<int, string>(line, Lexeme));
            }
            
            if (!isError)
            {
                Compiler.Lexemes.Add(Lexeme);
                Compiler.Lines.Add(line);
                Tok.description = Token.tokenDescription[Tok.tokenType];
                Tokens.Add(Tok);
            }
        }

        private bool isReservedWord(string lexeme)
        {
            return ReservedWords.ContainsKey(lexeme);
        }

        private bool isIdentifier(string lexeme)
        {
            return idRegex.IsMatch(lexeme);
        }

        private bool isConstant(string lexeme)
        {
            return numRegex.IsMatch(lexeme);
        }

        private bool isString(string lexeme)
        {
            return strRegex.IsMatch(lexeme);
        }

        private bool isOperator(string lexeme)
        {
            return Operators.ContainsKey(lexeme);
        }

        private bool isComment(string lexeme)
        {
            return commRegex.IsMatch(lexeme);
        }

    }
}
