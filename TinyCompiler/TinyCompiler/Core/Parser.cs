using System;
using System.Collections.Generic;
using System.Linq;
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

        #region STARTING POINT
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
            if (tokensIndex < TokenStream.Count())
                program.Children.Add(MainFunction());
            else
                MessageBox.Show("The Program Must have The Entry Point (Main Function)", "Missing Main Function", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            return program;
        }
        #endregion

        #region TINY LANGUAGE FUNCTIONS ARCHITECTURE
        private Node FunctionStatements()
        {
            Node functionStatements = new Node("Function Statements");
            if (tokensIndex < TokenStream.Count() && isStartWithDatatype() && TokenType.Main != TokenStream[tokensIndex+1].tokenType)
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

        
        private Node Parameter()
        {
            Node parameter = new Node("Parameter");
            parameter.Children.Add(Datatype());
            parameter.Children.Add(match(TokenType.Idenifier));

            return parameter;
        }

        private Node MultiParameters()
        {
            Node multiParameter = new Node("Multi Parameter");
            if (tokensIndex < TokenStream.Count() && TokenType.Comma == TokenStream[tokensIndex].tokenType)
            {
                multiParameter.Children.Add(match(TokenType.Comma));
                multiParameter.Children.Add(Parameter());
                multiParameter.Children.Add(MultiParameters());
                return multiParameter;
            }

            return null;
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
        #endregion

        #region TINY LANGUAGE FUNCTIONS STATEMENT (BODY)
        private Node Statements()
        {
            Node statements = new Node("Statements");
            if (tokensIndex < TokenStream.Count() && (TokenType.Comment == TokenStream[tokensIndex].tokenType
                || TokenType.Idenifier == TokenStream[tokensIndex].tokenType
                || isStartWithDatatype() || TokenType.Write == TokenStream[tokensIndex].tokenType || TokenType.Read == TokenStream[tokensIndex].tokenType
                || TokenType.If == TokenStream[tokensIndex].tokenType || TokenType.Repeat == TokenStream[tokensIndex].tokenType))
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
            if (tokensIndex < TokenStream.Count())
            {
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
                else tokensIndex++;
            }
            return statement;
        }
        
        private Node Datatype()
        {
            Node datatype = new Node("Datatype");
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.Integer == TokenStream[tokensIndex].tokenType)
                    datatype.Children.Add(match(TokenType.Integer));
                else if (TokenType.Float == TokenStream[tokensIndex].tokenType)
                    datatype.Children.Add(match(TokenType.Float));
                else if (TokenType.String == TokenStream[tokensIndex].tokenType)
                    datatype.Children.Add(match(TokenType.String));
            }
            return datatype;
        }

        private Node FunctionName()
        {
            Node functionName = new Node("Function Name");  
            functionName.Children.Add(match(TokenType.Idenifier));

            return functionName;
        }


        private Node AssignmentStatement()
        {
            Node assignmentStatement = new Node("Assignment Statement");
            assignmentStatement.Children.Add(match(TokenType.Idenifier));
            assignmentStatement.Children.Add(match(TokenType.Assignment));
            assignmentStatement.Children.Add(Expression());

            return assignmentStatement;
        }

        private Node DeclarationStatement()
        {
            Node declarationStatement = new Node("Declaration Statement");
            declarationStatement.Children.Add(Datatype());
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.Assignment == TokenStream[tokensIndex + 1].tokenType)
                    declarationStatement.Children.Add(AssignmentStatement());
                else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                    declarationStatement.Children.Add(match(TokenType.Idenifier));
            }
            declarationStatement.Children.Add(MultipleDeclarations());
            declarationStatement.Children.Add(match(TokenType.Semicolon));

            return declarationStatement;
        }

        private Node MultipleDeclarations()
        {
            Node multipleDeclarations = new Node("Multiple Declarations");
            if (tokensIndex < TokenStream.Count() && TokenType.Comma == TokenStream[tokensIndex].tokenType)
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

        private Node ReadStatement()
        {
            Node readStatement = new Node("Read Statement");
            readStatement.Children.Add(match(TokenType.Read));
            readStatement.Children.Add(match(TokenType.Idenifier));
            readStatement.Children.Add(match(TokenType.Semicolon));

            return readStatement;
        }

        private Node WriteStatement()
        {
            Node writeStatement = new Node("Write Statement");
            writeStatement.Children.Add(match(TokenType.Write));
            if (tokensIndex < TokenStream.Count() && TokenType.Endl == TokenStream[tokensIndex].tokenType)
                writeStatement.Children.Add(match(TokenType.Endl));
            else
                writeStatement.Children.Add(Expression());

            writeStatement.Children.Add(match(TokenType.Semicolon));

            return writeStatement;
        }
        
        private Node FunctionCall()
        {
            Node functionCall = new Node("Function Call");
            functionCall.Children.Add(match(TokenType.Idenifier));
            functionCall.Children.Add(match(TokenType.LParanthesis));
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                    functionCall.Children.Add(match(TokenType.Idenifier));
                else if (TokenType.Constant == TokenStream[tokensIndex].tokenType)
                    functionCall.Children.Add(match(TokenType.Constant));
            }
            functionCall.Children.Add(MultipleIdentifiers());
            functionCall.Children.Add(match(TokenType.RParanthesis));

            return functionCall;
        }

        private Node MultipleIdentifiers()
        {
            Node multiIdentifiers = new Node("Multi Identifiers");
            if (tokensIndex < TokenStream.Count() && TokenType.Comma == TokenStream[tokensIndex].tokenType)
            {
                multiIdentifiers.Children.Add(match(TokenType.Comma));
                if (tokensIndex < TokenStream.Count())
                {
                    if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                        multiIdentifiers.Children.Add(match(TokenType.Idenifier));
                    else
                        multiIdentifiers.Children.Add(match(TokenType.Constant));
                }
                multiIdentifiers.Children.Add(MultipleIdentifiers());
                return multiIdentifiers;
            }

            return null;
        }

        private Node IfStatement()
        {
            Node ifStatement = new Node("If Statement");
            ifStatement.Children.Add(match(TokenType.If));
            ifStatement.Children.Add(ConditionStatement());
            ifStatement.Children.Add(match(TokenType.Then));
            ifStatement.Children.Add(MultipleStatements());
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.Elseif == TokenStream[tokensIndex].tokenType)
                    ifStatement.Children.Add(ElseIfStatement());
                else if (TokenType.Else == TokenStream[tokensIndex].tokenType)
                    ifStatement.Children.Add(ElseStatement());
                else
                    ifStatement.Children.Add(match(TokenType.End));
            }

            return ifStatement;
        }
        
        private Node ElseIfStatement()
        {
            Node elseIfStatement = new Node("ElseIf Statement");
            elseIfStatement.Children.Add(match(TokenType.Elseif));
            elseIfStatement.Children.Add(ConditionStatement());
            elseIfStatement.Children.Add(match(TokenType.Then));
            elseIfStatement.Children.Add(MultipleStatements());
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.Elseif == TokenStream[tokensIndex].tokenType)
                    elseIfStatement.Children.Add(ElseIfStatement());
                else if (TokenType.Else == TokenStream[tokensIndex].tokenType)
                    elseIfStatement.Children.Add(ElseStatement());
                else
                    elseIfStatement.Children.Add(match(TokenType.End));
            }

            return elseIfStatement;
        }

        private Node ElseStatement()
        {
            Node elseStatement = new Node("Else Statement");
            elseStatement.Children.Add(match(TokenType.Else));
            elseStatement.Children.Add(MultipleStatements());
            elseStatement.Children.Add(match(TokenType.End));

            return elseStatement;
        }

        private Node MultipleStatements()
        {
            Node multipleStatements = new Node("Multiple Statements");
            multipleStatements.Children.Add(Statement());
            multipleStatements.Children.Add(MultipleStatement());

            return multipleStatements;
        }

        private Node MultipleStatement()
        {
            Node multipleStatement = new Node("Multiple Statement");
            if (tokensIndex < TokenStream.Count() && (TokenType.Comment == TokenStream[tokensIndex].tokenType || TokenType.Idenifier == TokenStream[tokensIndex].tokenType
                || isStartWithDatatype() || TokenType.Write == TokenStream[tokensIndex].tokenType || TokenType.Read == TokenStream[tokensIndex].tokenType
                || TokenType.If == TokenStream[tokensIndex].tokenType || TokenType.Repeat == TokenStream[tokensIndex].tokenType))
            {
                multipleStatement.Children.Add(Statement());
                multipleStatement.Children.Add(MultipleStatement());
                return multipleStatement;
            }

            return null;
        }

        private Node RepeatStatement()
        {
            Node repeatStatement = new Node("Repeat Statement");
            repeatStatement.Children.Add(match(TokenType.Repeat));
            repeatStatement.Children.Add(MultipleStatements());
            repeatStatement.Children.Add(match(TokenType.Until));
            repeatStatement.Children.Add(ConditionStatement());

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
        #endregion

        #region HELPING TERMINAL & NON TERMINAL METHODS
        private Node Expression() 
        {
            Node expression = new Node("Expression");
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.StringText == TokenStream[tokensIndex].tokenType)
                    expression.Children.Add(match(TokenType.StringText));
                else if ((isStartWithTerm() && isStartWithOperation(tokensIndex + 1))
                        || (TokenType.LParanthesis == TokenStream[tokensIndex].tokenType))
                    expression.Children.Add(Equation());
                else if (isStartWithTerm())
                    expression.Children.Add(Term());
            }
            return expression;
        }
        
        private Node Term()
        {
            Node term = new Node("Term");
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.Constant == TokenStream[tokensIndex].tokenType)
                    term.Children.Add(match(TokenType.Constant));
                else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType && TokenType.LParanthesis == TokenStream[tokensIndex + 1].tokenType)
                    term.Children.Add(FunctionCall());
                else if (TokenType.Idenifier == TokenStream[tokensIndex].tokenType)
                    term.Children.Add(match(TokenType.Idenifier));
            }
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
                if (tokensIndex < TokenStream.Count() && TokenType.LParanthesis == TokenStream[tokensIndex + 1].tokenType)
                {
                    equation.Children.Add(Operation());
                    equation.Children.Add(Br_Op());
                }
                else
                {
                    equation.Children.Add(Operation());
                    equation.Children.Add(Expression());
                }
            }

            return equation;
        }

        private Node MultipleTerms()
        {
            Node multipleTerms = new Node("Multiple Terms");
            multipleTerms.Children.Add(Operation());
            multipleTerms.Children.Add(Expression());
            multipleTerms.Children.Add(MultipleTerm());

            return multipleTerms;
        }

        private Node MultipleTerm()
        {
            Node multipleTerm = new Node("Multiple Term");
            if (isStartWithOperation(tokensIndex))
            {
                multipleTerm.Children.Add(Operation());
                multipleTerm.Children.Add(Expression());
                multipleTerm.Children.Add(MultipleTerm());
                return multipleTerm;
            }

            return null;
        }

        private Node Operation()
        {
            Node operation = new Node("Operation");
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.PlusOp == TokenStream[tokensIndex].tokenType)
                    operation.Children.Add(match(TokenType.PlusOp));
                else if (TokenType.MinusOp == TokenStream[tokensIndex].tokenType)
                    operation.Children.Add(match(TokenType.MinusOp));
                else if (TokenType.MultiplyOp == TokenStream[tokensIndex].tokenType)
                    operation.Children.Add(match(TokenType.MultiplyOp));
                else if (TokenType.DivideOp == TokenStream[tokensIndex].tokenType)
                    operation.Children.Add(match(TokenType.DivideOp));
            }
            return operation;
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
        
        private Node ConditionStatement()
        {
            Node conditionStatement = new Node("Condition Statements");
            conditionStatement.Children.Add(Condition());
            conditionStatement.Children.Add(MultipleCondition());

            return conditionStatement;
        }

        private Node MultipleCondition()
        {
            Node multipleCondition = new Node("Multiple Condition");
            if (tokensIndex < TokenStream.Count() && (TokenType.AndOp == TokenStream[tokensIndex].tokenType || TokenType.OrOp == TokenStream[tokensIndex].tokenType))
            {
                multipleCondition.Children.Add(BooleanOperator());
                multipleCondition.Children.Add(Condition());
                multipleCondition.Children.Add(MultipleCondition());
                return multipleCondition;
            }

            return null;
        }

        private Node Condition()
        {
            Node condition = new Node("Condition");
            condition.Children.Add(match(TokenType.Idenifier));
            condition.Children.Add(ConditionOperator());
            condition.Children.Add(Expression());
            
            return condition;
        }

        private Node BooleanOperator()
        {
            Node booleanOperator = new Node("Boolean Operator");
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.AndOp == TokenStream[tokensIndex].tokenType)
                    booleanOperator.Children.Add(match(TokenType.AndOp));
                else if (TokenType.OrOp == TokenStream[tokensIndex].tokenType)
                    booleanOperator.Children.Add(match(TokenType.OrOp));
            }
            return booleanOperator;
        }

        private Node ConditionOperator()
        {
            Node conditionOperator = new Node("Condition Operator");
            if (tokensIndex < TokenStream.Count())
            {
                if (TokenType.LessThanOp == TokenStream[tokensIndex].tokenType)
                    conditionOperator.Children.Add(match(TokenType.LessThanOp));
                else if (TokenType.GreaterThanOp == TokenStream[tokensIndex].tokenType)
                    conditionOperator.Children.Add(match(TokenType.GreaterThanOp));
                else if (TokenType.EqualOp == TokenStream[tokensIndex].tokenType)
                    conditionOperator.Children.Add(match(TokenType.EqualOp));
                else if (TokenType.NotEqualOp == TokenStream[tokensIndex].tokenType)
                    conditionOperator.Children.Add(match(TokenType.NotEqualOp));
            }

            return conditionOperator;
        }
        #endregion

        #region CHECKING FUNCTIONS
        private bool isStartWithDatatype()
        {
            if (tokensIndex < TokenStream.Count() && (TokenType.Integer == TokenStream[tokensIndex].tokenType || TokenType.Float == TokenStream[tokensIndex].tokenType
                || TokenType.String == TokenStream[tokensIndex].tokenType))
                return true;
            
            return false;
        }

        private bool isStartWithTerm()
        {
            if (tokensIndex < TokenStream.Count() && (TokenType.Constant == TokenStream[tokensIndex].tokenType 
                || TokenType.Idenifier == TokenStream[tokensIndex].tokenType))
                 return true;
            
            return false;
        }


        private bool isStartWithOperation(int tokens_Index)
        {
            if (tokensIndex < TokenStream.Count() && (TokenType.PlusOp == TokenStream[tokens_Index].tokenType || TokenType.MinusOp == TokenStream[tokens_Index].tokenType
                || TokenType.MultiplyOp == TokenStream[tokens_Index].tokenType || TokenType.DivideOp == TokenStream[tokens_Index].tokenType))
                return true;
           
            return false;
        }
        #endregion

        #region TERMINALS MATCH  
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
                    Errors.parserErrors.Add((Errors.parserErrors.Count() +1) 
                        +") Parsing Error: Expected "
                        + ExpectedToken.ToString() + " and " +
                        TokenStream[tokensIndex].tokenType.ToString() +
                        "  found\r\n");
                    tokensIndex++;
                    return null;
                }
            }
            else
            {
                Errors.parserErrors.Add((Errors.parserErrors.Count() + 1)
                    + ") Parsing Error: Expected "
                        + ExpectedToken.ToString() + "\r\n");
                tokensIndex++;
                return null;
            }
        }
        #endregion

        #region PRINTING PARSE TREE
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
        #endregion

    }
}
