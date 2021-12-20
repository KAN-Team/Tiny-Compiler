using System.Collections.Generic;

namespace TinyCompiler.Core
{
    public enum TokenType
    {
        Constant, String, Float, Integer, StringText, If, Return, Repeat, Read, Write, Until, Elseif,
        Else, End, Endl, Then, Main, Semicolon, Comma, LParanthesis, RParanthesis, 
        LBraces, RBraces, EqualOp, LessThanOp, GreaterThanOp, NotEqualOp, PlusOp, MinusOp, 
        MultiplyOp, DivideOp, AndOp, OrOp, Idenifier, Assignment, Comment
    }

    public class Token
    {
        public string lexeme;
        public TokenType tokenType;
        public string description;
        public static Dictionary<TokenType, string> tokenDescription 
                                = new Dictionary<TokenType, string>();
        public static void addDescription()
        {
            tokenDescription.Add(TokenType.Constant, "Constant Number");
            tokenDescription.Add(TokenType.String, "DataType(string)");
            tokenDescription.Add(TokenType.Float, "DataType(float)");
            tokenDescription.Add(TokenType.Integer, "DataType(int)");
            tokenDescription.Add(TokenType.StringText, "String Text");
            tokenDescription.Add(TokenType.If, "Reserved if");
            tokenDescription.Add(TokenType.Return, "Reserved return");
            tokenDescription.Add(TokenType.Repeat, "Reserved repeat");
            tokenDescription.Add(TokenType.Read, "Reserved read");
            tokenDescription.Add(TokenType.Write, "Reserved write");
            tokenDescription.Add(TokenType.Until, "Reserved until");
            tokenDescription.Add(TokenType.Elseif, "Reserved elseif");
            tokenDescription.Add(TokenType.Else, "Reserved else");
            tokenDescription.Add(TokenType.End, "Reserved end");
            tokenDescription.Add(TokenType.Endl, "Reserved endl");
            tokenDescription.Add(TokenType.Then, "Reserved then");
            tokenDescription.Add(TokenType.Main, "Identifier (Main)");
            tokenDescription.Add(TokenType.Semicolon, "Semicolon");
            tokenDescription.Add(TokenType.Comma, "Comma");
            tokenDescription.Add(TokenType.LParanthesis, "Left Parentheses");
            tokenDescription.Add(TokenType.RParanthesis, "Right Parentheses");
            tokenDescription.Add(TokenType.LBraces, "Left Braces");
            tokenDescription.Add(TokenType.RBraces, "Right Braces");
            tokenDescription.Add(TokenType.EqualOp, "Condition Operator (Equal)");
            tokenDescription.Add(TokenType.LessThanOp, "Condition Operator (Less Than)");
            tokenDescription.Add(TokenType.GreaterThanOp, "Condition Operator (Greater Than)");
            tokenDescription.Add(TokenType.NotEqualOp, "Condition Operator (Not Equal)");
            tokenDescription.Add(TokenType.PlusOp, "Arithmatic Operator (Plus)");
            tokenDescription.Add(TokenType.MinusOp, "Arithmatic Operator (Minus)");
            tokenDescription.Add(TokenType.MultiplyOp, "Arithmatic Operator (Multiply)");
            tokenDescription.Add(TokenType.DivideOp, "Arithmatic Operator (Divide)");
            tokenDescription.Add(TokenType.AndOp, "Boolean Operator (And)");
            tokenDescription.Add(TokenType.OrOp, "Boolean Operator (Or)");
            tokenDescription.Add(TokenType.Idenifier, "Identifier");
            tokenDescription.Add(TokenType.Assignment, "Assignment");
            tokenDescription.Add(TokenType.Comment, "Comment Statement");
        }
    }
}
