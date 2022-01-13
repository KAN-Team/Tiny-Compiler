
namespace TinyCompiler
{
    partial class CompileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompileForm));
            this.loadFileBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maximizeParseTreeBtn = new System.Windows.Forms.Button();
            this.compileBtnHolderPanel = new System.Windows.Forms.Panel();
            this.compileBtn = new System.Windows.Forms.Button();
            this.loadFileBtnHolderPanel = new System.Windows.Forms.Panel();
            this.tokensDgv = new System.Windows.Forms.DataGridView();
            this.lexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceCodeHolderPanel = new System.Windows.Forms.Panel();
            this.linesNumTxt = new System.Windows.Forms.TextBox();
            this.sourceCodeTxt = new System.Windows.Forms.TextBox();
            this.parserTreeView = new System.Windows.Forms.TreeView();
            this.errorsHolder = new System.Windows.Forms.Panel();
            this.errorsListLbl = new System.Windows.Forms.Label();
            this.errorsDgv = new System.Windows.Forms.DataGridView();
            this.errorLexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.parserErrorsTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.compileBtnHolderPanel.SuspendLayout();
            this.loadFileBtnHolderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokensDgv)).BeginInit();
            this.sourceCodeHolderPanel.SuspendLayout();
            this.errorsHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsDgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(189)))), ((int)(((byte)(151)))));
            this.loadFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadFileBtn.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFileBtn.Location = new System.Drawing.Point(0, 0);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(394, 50);
            this.loadFileBtn.TabIndex = 9;
            this.loadFileBtn.Text = "Load file";
            this.loadFileBtn.UseVisualStyleBackColor = false;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.625F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.375F));
            this.tableLayoutPanel.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.compileBtnHolderPanel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.loadFileBtnHolderPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tokensDgv, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.sourceCodeHolderPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.parserTreeView, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.errorsHolder, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.panel2, 2, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1200, 478);
            this.tableLayoutPanel.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maximizeParseTreeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(824, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 50);
            this.panel1.TabIndex = 20;
            // 
            // maximizeParseTreeBtn
            // 
            this.maximizeParseTreeBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.maximizeParseTreeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximizeParseTreeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maximizeParseTreeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeParseTreeBtn.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximizeParseTreeBtn.ForeColor = System.Drawing.Color.White;
            this.maximizeParseTreeBtn.Location = new System.Drawing.Point(0, 0);
            this.maximizeParseTreeBtn.Name = "maximizeParseTreeBtn";
            this.maximizeParseTreeBtn.Size = new System.Drawing.Size(373, 50);
            this.maximizeParseTreeBtn.TabIndex = 13;
            this.maximizeParseTreeBtn.Text = "Maximize Parse Tree";
            this.maximizeParseTreeBtn.UseVisualStyleBackColor = false;
            this.maximizeParseTreeBtn.Click += new System.EventHandler(this.maximizeParseTreeBtn_Click);
            // 
            // compileBtnHolderPanel
            // 
            this.compileBtnHolderPanel.Controls.Add(this.compileBtn);
            this.compileBtnHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compileBtnHolderPanel.Location = new System.Drawing.Point(403, 3);
            this.compileBtnHolderPanel.Name = "compileBtnHolderPanel";
            this.compileBtnHolderPanel.Size = new System.Drawing.Size(415, 50);
            this.compileBtnHolderPanel.TabIndex = 19;
            // 
            // compileBtn
            // 
            this.compileBtn.BackColor = System.Drawing.Color.Crimson;
            this.compileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compileBtn.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compileBtn.ForeColor = System.Drawing.Color.White;
            this.compileBtn.Location = new System.Drawing.Point(0, 0);
            this.compileBtn.Name = "compileBtn";
            this.compileBtn.Size = new System.Drawing.Size(415, 50);
            this.compileBtn.TabIndex = 12;
            this.compileBtn.Text = "Compile";
            this.compileBtn.UseVisualStyleBackColor = false;
            this.compileBtn.Click += new System.EventHandler(this.compileBtn_Click);
            // 
            // loadFileBtnHolderPanel
            // 
            this.loadFileBtnHolderPanel.Controls.Add(this.loadFileBtn);
            this.loadFileBtnHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadFileBtnHolderPanel.Location = new System.Drawing.Point(3, 3);
            this.loadFileBtnHolderPanel.Name = "loadFileBtnHolderPanel";
            this.loadFileBtnHolderPanel.Size = new System.Drawing.Size(394, 50);
            this.loadFileBtnHolderPanel.TabIndex = 18;
            // 
            // tokensDgv
            // 
            this.tokensDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tokensDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tokensDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tokensDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tokensDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tokensDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lexeme,
            this.lineNum,
            this.token});
            this.tokensDgv.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tokensDgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.tokensDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokensDgv.Location = new System.Drawing.Point(403, 59);
            this.tokensDgv.Name = "tokensDgv";
            this.tokensDgv.ReadOnly = true;
            this.tokensDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tokensDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tokensDgv.RowHeadersVisible = false;
            this.tokensDgv.Size = new System.Drawing.Size(415, 205);
            this.tokensDgv.TabIndex = 15;
            // 
            // lexeme
            // 
            this.lexeme.HeaderText = "Lexeme";
            this.lexeme.Name = "lexeme";
            this.lexeme.ReadOnly = true;
            // 
            // lineNum
            // 
            this.lineNum.FillWeight = 20F;
            this.lineNum.HeaderText = "Line";
            this.lineNum.Name = "lineNum";
            this.lineNum.ReadOnly = true;
            // 
            // token
            // 
            this.token.HeaderText = "Token";
            this.token.Name = "token";
            this.token.ReadOnly = true;
            // 
            // sourceCodeHolderPanel
            // 
            this.sourceCodeHolderPanel.Controls.Add(this.linesNumTxt);
            this.sourceCodeHolderPanel.Controls.Add(this.sourceCodeTxt);
            this.sourceCodeHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceCodeHolderPanel.Location = new System.Drawing.Point(3, 59);
            this.sourceCodeHolderPanel.Name = "sourceCodeHolderPanel";
            this.tableLayoutPanel.SetRowSpan(this.sourceCodeHolderPanel, 2);
            this.sourceCodeHolderPanel.Size = new System.Drawing.Size(394, 407);
            this.sourceCodeHolderPanel.TabIndex = 20;
            // 
            // linesNumTxt
            // 
            this.linesNumTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.linesNumTxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.linesNumTxt.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.linesNumTxt.ForeColor = System.Drawing.Color.Gray;
            this.linesNumTxt.Location = new System.Drawing.Point(0, 0);
            this.linesNumTxt.Multiline = true;
            this.linesNumTxt.Name = "linesNumTxt";
            this.linesNumTxt.Size = new System.Drawing.Size(25, 407);
            this.linesNumTxt.TabIndex = 12;
            this.linesNumTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sourceCodeTxt
            // 
            this.sourceCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceCodeTxt.BackColor = System.Drawing.Color.Silver;
            this.sourceCodeTxt.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.sourceCodeTxt.Location = new System.Drawing.Point(26, 0);
            this.sourceCodeTxt.Multiline = true;
            this.sourceCodeTxt.Name = "sourceCodeTxt";
            this.sourceCodeTxt.Size = new System.Drawing.Size(371, 407);
            this.sourceCodeTxt.TabIndex = 11;
            this.sourceCodeTxt.TextChanged += new System.EventHandler(this.sourceCodeTxt_TextChanged_1);
            // 
            // parserTreeView
            // 
            this.parserTreeView.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.parserTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parserTreeView.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parserTreeView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.parserTreeView.Location = new System.Drawing.Point(824, 59);
            this.parserTreeView.Name = "parserTreeView";
            this.parserTreeView.Size = new System.Drawing.Size(373, 205);
            this.parserTreeView.TabIndex = 21;
            // 
            // errorsHolder
            // 
            this.errorsHolder.Controls.Add(this.errorsListLbl);
            this.errorsHolder.Controls.Add(this.errorsDgv);
            this.errorsHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorsHolder.Location = new System.Drawing.Point(403, 270);
            this.errorsHolder.Name = "errorsHolder";
            this.errorsHolder.Size = new System.Drawing.Size(415, 196);
            this.errorsHolder.TabIndex = 18;
            // 
            // errorsListLbl
            // 
            this.errorsListLbl.AutoSize = true;
            this.errorsListLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorsListLbl.ForeColor = System.Drawing.Color.Red;
            this.errorsListLbl.Location = new System.Drawing.Point(-2, -3);
            this.errorsListLbl.Name = "errorsListLbl";
            this.errorsListLbl.Size = new System.Drawing.Size(66, 15);
            this.errorsListLbl.TabIndex = 13;
            this.errorsListLbl.Text = "Error List";
            // 
            // errorsDgv
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.errorsDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.errorsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.errorsDgv.BackgroundColor = System.Drawing.Color.DimGray;
            this.errorsDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.errorsDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.errorsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorLexeme,
            this.line,
            this.error});
            this.errorsDgv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorsDgv.EnableHeadersVisualStyles = false;
            this.errorsDgv.GridColor = System.Drawing.Color.Silver;
            this.errorsDgv.Location = new System.Drawing.Point(0, 16);
            this.errorsDgv.Margin = new System.Windows.Forms.Padding(4);
            this.errorsDgv.Name = "errorsDgv";
            this.errorsDgv.ReadOnly = true;
            this.errorsDgv.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.errorsDgv.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.errorsDgv.RowTemplate.Height = 30;
            this.errorsDgv.Size = new System.Drawing.Size(415, 180);
            this.errorsDgv.TabIndex = 16;
            // 
            // errorLexeme
            // 
            this.errorLexeme.HeaderText = "Lexeme";
            this.errorLexeme.Name = "errorLexeme";
            this.errorLexeme.ReadOnly = true;
            // 
            // line
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray;
            this.line.DefaultCellStyle = dataGridViewCellStyle6;
            this.line.FillWeight = 20F;
            this.line.HeaderText = "Line";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            // 
            // error
            // 
            this.error.HeaderText = "Error";
            this.error.Name = "error";
            this.error.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.parserErrorsTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(824, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 196);
            this.panel2.TabIndex = 22;
            // 
            // parserErrorsTextBox
            // 
            this.parserErrorsTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.parserErrorsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parserErrorsTextBox.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parserErrorsTextBox.Location = new System.Drawing.Point(0, 0);
            this.parserErrorsTextBox.Multiline = true;
            this.parserErrorsTextBox.Name = "parserErrorsTextBox";
            this.parserErrorsTextBox.Size = new System.Drawing.Size(373, 196);
            this.parserErrorsTextBox.TabIndex = 11;
            // 
            // CompileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(1200, 478);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compile Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.compileBtnHolderPanel.ResumeLayout(false);
            this.loadFileBtnHolderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tokensDgv)).EndInit();
            this.sourceCodeHolderPanel.ResumeLayout(false);
            this.sourceCodeHolderPanel.PerformLayout();
            this.errorsHolder.ResumeLayout(false);
            this.errorsHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsDgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button loadFileBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel compileBtnHolderPanel;
        private System.Windows.Forms.Button compileBtn;
        private System.Windows.Forms.Panel loadFileBtnHolderPanel;
        private System.Windows.Forms.DataGridView tokensDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn token;
        private System.Windows.Forms.Panel sourceCodeHolderPanel;
        private System.Windows.Forms.TextBox linesNumTxt;
        private System.Windows.Forms.TextBox sourceCodeTxt;
        private System.Windows.Forms.TreeView parserTreeView;
        private System.Windows.Forms.Panel errorsHolder;
        private System.Windows.Forms.Label errorsListLbl;
        private System.Windows.Forms.DataGridView errorsDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorLexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox parserErrorsTextBox;
        private System.Windows.Forms.Button maximizeParseTreeBtn;
    }
}

