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
            try
            {
                program.Children.Add(MainFunction());
            }
            catch (Exception e)
            {
                MessageBox.Show("The Program Must have The Entry Point (Main Function)", "Missing Main Function", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
            //MessageBox.Show("Success");
            return program;
        }

        private Node FunctionStatements()
        {
            Node functionStatements = new Node("Function Statements");
            if ( tokensIndex < TokenStream.Count() && isStartWithDatatype() && TokenType.Main != TokenStream[tokensIndex+1].tokenType)
            {
                functionStatements.Children.Add(FunctionStatement());
                functionStatements.Children.Add(FunctionStatements());
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
                || TokenType.If == TokenStream[tokensIndex].tokenType || TokenType.Repeat == TokenStream[tokensIndex].tokenType)
            {
                statements.Children.Add(Statement());
                statements.Children.Add(Statements());
                return statements;
            }

            return null;
        }

        private Node Statement()
        {
            Node statement = new Node("Statement");
            if (TokenType.Comment == TokenStream[tokensIndex].tokenType)
                statement.Children.Add(match(TokenType.Comment));
            else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.Assignment == TokenStream[tokensIndex + 1].tokenType)
            {
                statement.Children.Add(AssignmentStatement());
                statement.Children.Add(match(TokenType.Semicolon));
            }
            else if (isStartWithDatatype())
                statement.Children.Add(DeclarationStatement());
            else if (TokenType.Write == TokenStream[tokensIndex].tokenType)
                statement.Children.Add(WriteStatement());
            else if (TokenType.Read == TokenStream[tokensIndex].tokenType)
                statement.Children.Add(ReadStatement());
            else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.LParanthesis == TokenStream[tokensIndex + 1].tokenType)
            {
                statement.Children.Add(FunctionCall());
                statement.Children.Add(match(TokenType.Semicolon));
            }
            else if (TokenType.If == TokenStream[tokensIndex].tokenType)
                statement.Children.Add(IfStatement());
            else if (TokenType.Repeat == TokenStream[tokensIndex].tokenType)
                statement.Children.Add(RepeatStatement());
            
            
            return statement;
        }

        private Node AssignmentStatement()
        {
            Node assignmentStatement = new Node("Assignment Statement");
            assignmentStatement.Children.Add(match(TokenType.Idenifier));
            assignmentStatement.Children.Add(match(TokenType.Assignment));
            assignmentStatement.Children.Add(Expression());

            return assignmentStatement;
        }

        private Node Expression()
        {
            Node expression = new Node("Expression");
            if(TokenType.StringText == TokenStream[tokensIndex].tokenType)
                expression.Children.Add(match(TokenType.StringText));
            else if ((isStartWithTerm() && isStartWithOperation(tokensIndex + 1)) 
                    || (TokenType.LParanthesis == TokenStream[tokensIndex].tokenType))
                expression.Children.Add(Equation());
            else if (isStartWithTerm())
                expression.Children.Add(Term());
            
            return expression;
        }
        
        private Node Term()
        {
            Node term = new Node("Term");
            if (TokenType.Constant == TokenStream[tokensIndex].tokenType)
                term.Children.Add(match(TokenType.Constant));
            else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.LParanthesis == TokenStream[tokensIndex + 1].tokenType)
                term.Children.Add(FunctionCall());
            else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                term.Children.Add(match(TokenType.Idenifier));
            
            return term;
        }
        
        private Node Equation()
        {
            Node equation = new Node("Equation");
            if (isStartWithTerm())
            {
                equation.Children.Add(Term());
                equation.Children.Add(MultipleTerms());
            }
            else 
            {
                equation.Children.Add(Br_Op());
                if (TokenType.LParanthesis == TokenStream[tokensIndex + 1].tokenType)
                {
                    equation.Children.Add(Operation());
                    equation.Children.Add(Br_Op());
                }
                else
                {
                    equation.Children.Add(Operation());
                    equation.Children.Add(Term());
                }
            }

            return equation;
        }

        private Node Operation()
        {
            Node operation = new Node("Operation");
            if (TokenType.PlusOp == TokenStream[tokensIndex].tokenType)
                operation.Children.Add(match(TokenType.PlusOp));
            else if (TokenType.MinusOp == TokenStream[tokensIndex].tokenType)
                operation.Children.Add(match(TokenType.MinusOp));
            else if (TokenType.MultiplyOp == TokenStream[tokensIndex].tokenType)
                operation.Children.Add(match(TokenType.MultiplyOp));
            else if (TokenType.DivideOp == TokenStream[tokensIndex].tokenType)
                operation.Children.Add(match(TokenType.DivideOp));

            return operation;
        }

        private Node MultipleTerms()
        {
            Node multipleTerms = new Node("Multiple Terms");
            multipleTerms.Children.Add(Operation());
            multipleTerms.Children.Add(Term());
            multipleTerms.Children.Add(MultipleTerm());

            return multipleTerms;
        }

        private Node MultipleTerm()
        {
            Node multipleTerm = new Node("Multiple Term");
            if (isStartWithOperation(tokensIndex))
            {
                multipleTerm.Children.Add(Operation());
                multipleTerm.Children.Add(Term());
                multipleTerm.Children.Add(MultipleTerm());
                return multipleTerm;
            }

            return null;
        }

        private Node Br_Op()
        {
            Node br_Op = new Node("Br_Op");
            br_Op.Children.Add(match(TokenType.LParanthesis));
            br_Op.Children.Add(Term());
            br_Op.Children.Add(MultipleTerms());
            br_Op.Children.Add(match(TokenType.RParanthesis));

            return br_Op;
        }

        private Node DeclarationStatement()
        {
            Node declarationStatement = new Node("Declaration Statement");
            declarationStatement.Children.Add(Datatype());
            if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.Assignment == TokenStream[tokensIndex + 1].tokenType)
                declarationStatement.Children.Add(AssignmentStatement());
            else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                declarationStatement.Children.Add(match(TokenType.Idenifier));
            
            declarationStatement.Children.Add(MultipleDeclarations());
            declarationStatement.Children.Add(match(TokenType.Semicolon));

            return declarationStatement;
        }

        private Node MultipleDeclarations()
        {
            Node multipleDeclarations = new Node("Multiple Declarations");
            if(TokenType.Comma == TokenStream[tokensIndex].tokenType)
            {
                multipleDeclarations.Children.Add(match(TokenType.Comma));
                if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.Assignment == TokenStream[tokensIndex + 1].tokenType)
                    multipleDeclarations.Children.Add(AssignmentStatement());
                else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                    multipleDeclarations.Children.Add(match(TokenType.Idenifier));

                multipleDeclarations.Children.Add(MultipleDeclarations());


                return multipleDeclarations;
            }

            return null;
        }

        private Node WriteStatement()
        {
            Node writeStatement = new Node("Write Statement");
            writeStatement.Children.Add(match(TokenType.Write));
            if (TokenType.Endl == TokenStream[tokensIndex].tokenType)
                writeStatement.Children.Add(match(TokenType.Endl));
            else
                writeStatement.Children.Add(Expression());

            writeStatement.Children.Add(match(TokenType.Semicolon));

            return writeStatement;
        }

        private Node ReadStatement()
        {
            Node readStatement = new Node("Read Statement");
            readStatement.Children.Add(match(TokenType.Read));
            readStatement.Children.Add(match(TokenType.Idenifier));
            readStatement.Children.Add(match(TokenType.Semicolon));

            return readStatement;
        }

        
        private Node FunctionCall()
        {
            Node functionCall = new Node("Function Call");
            functionCall.Children.Add(match(TokenType.Idenifier));
            functionCall.Children.Add(match(TokenType.LParanthesis));
            if(TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                functionCall.Children.Add(match(TokenType.Idenifier));
            else if (TokenType.Constant == TokenStream[tokensIndex].tokenType)
                functionCall.Children.Add(match(TokenType.Constant));   
            
            functionCall.Children.Add(MultiIdentifiers());
            functionCall.Children.Add(match(TokenType.RParanthesis));

            return functionCall;
        }
        
        private Node MultiIdentifiers()
        {
            Node multiIdentifiers = new Node("Multi Identifiers");
            if (TokenType.Comma == TokenStream[tokensIndex].tokenType)
            {
                multiIdentifiers.Children.Add(match(TokenType.Comma));
                if(TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                    multiIdentifiers.Children.Add(match(TokenType.Idenifier));
                else
                    multiIdentifiers.Children.Add(match(TokenType.Constant));
                multiIdentifiers.Children.Add(MultiIdentifiers());

                return multiIdentifiers;
            }
            
            return null;
        }

      
        private Node IfStatement()
        {
            Node ifStatement = new Node("If Statement");

            return ifStatement;
        }

        private Node RepeatStatement()
        {
            Node repeatStatement = new Node("Repeat Statement");

            return repeatStatement;
        }

        private Node ReturnStatement()
        {
            Node returnStatement = new Node("Return Statement");
            returnStatement.Children.Add(match(TokenType.Return));
            returnStatement.Children.Add(Expression());
            returnStatement.Children.Add(match(TokenType.Semicolon));

            return returnStatement;
        }










        private bool isStartWithDatatype()
        {
            if (TokenType.Integer == TokenStream[tokensIndex].tokenType || TokenType.Float == TokenStream[tokensIndex].tokenType
                || TokenType.String == TokenStream[tokensIndex].tokenType)
                return true;
            
            return false;
        }

        private bool isStartWithTerm()
        {
            if (TokenType.Constant == TokenStream[tokensIndex].tokenType || TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                 return true;
            
            return false;
        }


        private bool isStartWithOperation(int tokens_Index)
        {
            if (TokenType.PlusOp == TokenStream[tokens_Index].tokenType || TokenType.MinusOp == TokenStream[tokens_Index].tokenType
                || TokenType.MultiplyOp == TokenStream[tokens_Index].tokenType || TokenType.DivideOp == TokenStream[tokens_Index].tokenType)
                return true;
           
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
