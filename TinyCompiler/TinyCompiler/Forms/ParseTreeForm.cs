using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyCompiler.Core;

namespace TinyCompiler.Forms
{
    public partial class ParseTreeForm : Form
    {
        public ParseTreeForm()
        {
            InitializeComponent();
            fillParserTree();
        }

        private void fillParserTree()
        {
            parserTreeView.Nodes.Clear();
            parserTreeView.Nodes.Add(Parser.PrintParseTree(Compiler.treeroot));
        }
    }
}
