using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyCompiler.Core
{

    public class Node
    {
        public List<Node> Children = new List<Node>();

        public string Name;
        public Node(string N)
        {
            this.Name = N;
        }
    }

    public class Parser
    {
        int tokensIndex;
        List<Token> TokenStream;
        public Node root;
        
        public Node StartParsing(List<Token> TokenStream)
        {
            this.tokensIndex = 0;
            this.TokenStream = TokenStream;
            root = new Node("Root");
            root.Children.Add(Program());
            return root;
        }

        private Node Program()
        {
            Node program = new Node("Program");
            program.Children.Add(FunctionStatements());
            //program.Children.Add(MainFunction());
            //MessageBox.Show("Success");

            return program;
        }

        private Node FunctionStatements()
        {
            Node functionStatements = new Node("Function Statements");
            if (isStartWithDatatype())
            {
                
                functionStatements.Children.Add(FunctionStatement());
                tokensIndex++;
                functionStatements.Children.Add(FunctionStatements());
                tokensIndex--;
                return functionStatements;
            }

            return null;
        }


        private Node FunctionStatement()
        {
            Node functionStatement = new Node("Function Statement");
            functionStatement.Children.Add(FunctionDeclaration());
            functionStatement.Children.Add(FunctionBody());

            return functionStatement;
        }


        private Node MainFunction()
        {
            Node mainFunction = new Node("Main Function");
            mainFunction.Children.Add(Datatype());
            mainFunction.Children.Add(match(TokenType.Main));
            mainFunction.Children.Add(match(TokenType.LParanthesis));
            mainFunction.Children.Add(match(TokenType.RParanthesis));
            mainFunction.Children.Add(FunctionBody());

            return mainFunction;
        }

        private Node Datatype()
        {
            Node datatype = new Node("Datatype");
            if (TokenType.Integer == TokenStream[tokensIndex].tokenType)
                datatype.Children.Add(match(TokenType.Integer));
            else if (TokenType.Float == TokenStream[tokensIndex].tokenType)
                datatype.Children.Add(match(TokenType.Float));
            else if (TokenType.String == TokenStream[tokensIndex].tokenType)
                datatype.Children.Add(match(TokenType.String));

            return datatype;
        }

        private Node FunctionDeclaration()
        {
            Node functionDeclaration = new Node("Function Declaration");
            functionDeclaration.Children.Add(Datatype());
            functionDeclaration.Children.Add(FunctionName());
            functionDeclaration.Children.Add(match(TokenType.LParanthesis));
            if (isStartWithDatatype())
            {
                functionDeclaration.Children.Add(Parameter());
                functionDeclaration.Children.Add(MultiParameters());
            }
            functionDeclaration.Children.Add(match(TokenType.RParanthesis));

            return functionDeclaration;
        }

        private Node MultiParameters()
        {
            Node multiParameter = new Node("Multi Parameter");
            if (TokenType.Comma == TokenStream[tokensIndex].tokenType)
            {
                multiParameter.Children.Add(match(TokenType.Comma));
                multiParameter.Children.Add(Parameter());
                multiParameter.Children.Add(MultiParameters());
                return multiParameter;
            }

            return null;
        }

        private Node Parameter()
        {
            Node parameter = new Node("Parameter");
            parameter.Children.Add(Datatype());
            parameter.Children.Add(match(TokenType.Idenifier));

            return parameter;
        }

        private Node FunctionName()
        {
            Node functionName = new Node("Function Name");
            functionName.Children.Add(match(TokenType.Idenifier));

            return functionName;
        }

        private Node FunctionBody()
        {
            Node functionBody = new Node("Function Body");
            functionBody.Children.Add(match(TokenType.LBraces));
            functionBody.Children.Add(Statements());
            functionBody.Children.Add(ReturnStatement());
            functionBody.Children.Add(match(TokenType.RBraces));

            return functionBody;
        }

        
        private Node Statements()
        {
            Node statements = new Node("Statements");
            if (TokenType.Comment == TokenStream[tokensIndex].tokenType || TokenType.Idenifier == TokenStream[tokensIndex].tokenType
                || isStartWithDatatype() || TokenType.Write == TokenStream[tokensIndex].tokenType || TokenType.Read == TokenStream[tokensIndex].tokenType
                || TokenType.If == TokenStream[tokensIndex].tokenType || TokenType.Repeat == TokenStream[tokensIndex].tokenType
                || TokenType.Return == TokenStream[tokensIndex].tokenType)
            {
                statements.Children.Add(Statement());
                tokensIndex++;
                statements.Children.Add(Statements());
                tokensIndex--;
                return statements;
            }

            return null;
        }

        private Node Statement()
        {
            Node statement = new Node("Statement");

            return statement;
        }

        private Node ReturnStatement()
        {
            Node returnStatement = new Node("Return Statement");

            return returnStatement;
        }










        private bool isStartWithDatatype()
        {
            if (TokenType.Integer == TokenStream[tokensIndex].tokenType || TokenType.Float == TokenStream[tokensIndex].tokenType
                || TokenType.String == TokenStream[tokensIndex].tokenType)
            {
                return true;
            }
            return false;
        }




        public Node match(TokenType ExpectedToken)
        {
            if (tokensIndex < TokenStream.Count)
            {
                if (ExpectedToken == TokenStream[tokensIndex].tokenType)
                {
                    tokensIndex++;
                    Node newNode = new Node(ExpectedToken.ToString());

                    return newNode;

                }

                else
                {
                    Errors.parserErrors.Add("Parsing Error: Expected "
                        + ExpectedToken.ToString() + " and " +
                        TokenStream[tokensIndex].tokenType.ToString() +
                        "  found\r\n");
                    tokensIndex++;
                    return null;
                }
            }
            else
            {
                Errors.parserErrors.Add("Parsing Error: Expected "
                        + ExpectedToken.ToString() + "\r\n");
                tokensIndex++;
                return null;
            }
        }


        public static TreeNode PrintParseTree(Node root)
        {
            TreeNode tree = new TreeNode("Parse Tree");
            TreeNode treeRoot = PrintTree(root);
            if (treeRoot != null)
                tree.Nodes.Add(treeRoot);
            return tree;
        }
        private static TreeNode PrintTree(Node root)
        {
            if (root == null || root.Name == null)
                return null;
            TreeNode tree = new TreeNode(root.Name);
            if (root.Children.Count == 0)
                return tree;
            foreach (Node child in root.Children)
            {
                if (child == null)
                    continue;
                tree.Nodes.Add(PrintTree(child));
            }
            return tree;
        }

    }
}
