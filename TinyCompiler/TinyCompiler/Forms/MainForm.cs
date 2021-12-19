using System;
using System.Windows.Forms;
using TinyCompiler.backend;
using TinyCompiler.Core;

namespace TinyCompiler
{
    public partial class CompileForm : Form
    {
        public CompileForm()
        {
            InitializeComponent();
        }

        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            sourceCodeTxt.Text = HandleGuiEvents.loadFileEvent();
        }

        private void compileBtn_Click(object sender, EventArgs e)
        {
            HandleGuiEvents.compileEvent(sourceCodeTxt.Text);
            fillDataGridView();
            fillParserTree();
        }

        private void fillDataGridView()
        {
            tokensDgv.Rows.Clear(); tokensDgv.Refresh();
            errorsDgv.Rows.Clear(); errorsDgv.Refresh();

            foreach (var item in HandleGuiEvents.getTokensData())
                tokensDgv.Rows.Add(item.Value.Key,    // Lexeme
                                   item.Key,          // line #
                                   item.Value.Value); // Token

            foreach (var item in HandleGuiEvents.getErrorsList())
                errorsDgv.Rows.Add(item.Value.Key,      // Error Token
                                   item.Key,            // Line #
                                   item.Value.Value);   // Description
        }
        

        private void fillParserTree()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(Parser.PrintParseTree(Compiler.treeroot));
        }

    }
}
