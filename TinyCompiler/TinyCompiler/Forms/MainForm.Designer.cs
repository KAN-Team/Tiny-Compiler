
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompileForm));
            this.loadFileBtn = new System.Windows.Forms.Button();
            this.errorsListLbl = new System.Windows.Forms.Label();
            this.compileBtn = new System.Windows.Forms.Button();
            this.tokensDgv = new System.Windows.Forms.DataGridView();
            this.lexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorsDgv = new System.Windows.Forms.DataGridView();
            this.errorLexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.compileBtnHolderPanel = new System.Windows.Forms.Panel();
            this.errorsHolder = new System.Windows.Forms.Panel();
            this.loadFileBtnHolderPanel = new System.Windows.Forms.Panel();
            this.sourceCodeHolderPanel = new System.Windows.Forms.Panel();
            this.linesNumTxt = new System.Windows.Forms.TextBox();
            this.sourceCodeTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tokensDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsDgv)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.compileBtnHolderPanel.SuspendLayout();
            this.errorsHolder.SuspendLayout();
            this.loadFileBtnHolderPanel.SuspendLayout();
            this.sourceCodeHolderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(189)))), ((int)(((byte)(151)))));
            this.loadFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadFileBtn.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFileBtn.Location = new System.Drawing.Point(118, 6);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(132, 38);
            this.loadFileBtn.TabIndex = 9;
            this.loadFileBtn.Text = "Load file";
            this.loadFileBtn.UseVisualStyleBackColor = false;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // errorsListLbl
            // 
            this.errorsListLbl.AutoSize = true;
            this.errorsListLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorsListLbl.ForeColor = System.Drawing.Color.Red;
            this.errorsListLbl.Location = new System.Drawing.Point(-1, 2);
            this.errorsListLbl.Name = "errorsListLbl";
            this.errorsListLbl.Size = new System.Drawing.Size(66, 15);
            this.errorsListLbl.TabIndex = 13;
            this.errorsListLbl.Text = "Error List";
            // 
            // compileBtn
            // 
            this.compileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compileBtn.BackColor = System.Drawing.Color.Crimson;
            this.compileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compileBtn.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compileBtn.ForeColor = System.Drawing.Color.White;
            this.compileBtn.Location = new System.Drawing.Point(148, 6);
            this.compileBtn.Name = "compileBtn";
            this.compileBtn.Size = new System.Drawing.Size(116, 38);
            this.compileBtn.TabIndex = 12;
            this.compileBtn.Text = "Compile";
            this.compileBtn.UseVisualStyleBackColor = false;
            this.compileBtn.Click += new System.EventHandler(this.compileBtn_Click);
            // 
            // tokensDgv
            // 
            this.tokensDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokensDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tokensDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tokensDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tokensDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.tokensDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tokensDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lexeme,
            this.lineNum,
            this.token});
            this.tokensDgv.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tokensDgv.DefaultCellStyle = dataGridViewCellStyle9;
            this.tokensDgv.Location = new System.Drawing.Point(403, 57);
            this.tokensDgv.Name = "tokensDgv";
            this.tokensDgv.ReadOnly = true;
            this.tokensDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tokensDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.tokensDgv.RowHeadersVisible = false;
            this.tokensDgv.Size = new System.Drawing.Size(394, 196);
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
            // errorsDgv
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.errorsDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.errorsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.errorsDgv.BackgroundColor = System.Drawing.Color.DimGray;
            this.errorsDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.errorsDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.errorsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorLexeme,
            this.line,
            this.error});
            this.errorsDgv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorsDgv.EnableHeadersVisualStyles = false;
            this.errorsDgv.GridColor = System.Drawing.Color.Silver;
            this.errorsDgv.Location = new System.Drawing.Point(2, 21);
            this.errorsDgv.Margin = new System.Windows.Forms.Padding(4);
            this.errorsDgv.Name = "errorsDgv";
            this.errorsDgv.ReadOnly = true;
            this.errorsDgv.RowHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.errorsDgv.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.errorsDgv.RowTemplate.Height = 30;
            this.errorsDgv.Size = new System.Drawing.Size(392, 167);
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
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Gray;
            this.line.DefaultCellStyle = dataGridViewCellStyle13;
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
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.compileBtnHolderPanel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.errorsHolder, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.loadFileBtnHolderPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tokensDgv, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.sourceCodeHolderPanel, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 17;
            // 
            // compileBtnHolderPanel
            // 
            this.compileBtnHolderPanel.Controls.Add(this.compileBtn);
            this.compileBtnHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compileBtnHolderPanel.Location = new System.Drawing.Point(403, 3);
            this.compileBtnHolderPanel.Name = "compileBtnHolderPanel";
            this.compileBtnHolderPanel.Size = new System.Drawing.Size(394, 48);
            this.compileBtnHolderPanel.TabIndex = 19;
            // 
            // errorsHolder
            // 
            this.errorsHolder.Controls.Add(this.errorsListLbl);
            this.errorsHolder.Controls.Add(this.errorsDgv);
            this.errorsHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorsHolder.Location = new System.Drawing.Point(403, 259);
            this.errorsHolder.Name = "errorsHolder";
            this.errorsHolder.Size = new System.Drawing.Size(394, 188);
            this.errorsHolder.TabIndex = 18;
            // 
            // loadFileBtnHolderPanel
            // 
            this.loadFileBtnHolderPanel.Controls.Add(this.loadFileBtn);
            this.loadFileBtnHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadFileBtnHolderPanel.Location = new System.Drawing.Point(3, 3);
            this.loadFileBtnHolderPanel.Name = "loadFileBtnHolderPanel";
            this.loadFileBtnHolderPanel.Size = new System.Drawing.Size(394, 48);
            this.loadFileBtnHolderPanel.TabIndex = 18;
            // 
            // sourceCodeHolderPanel
            // 
            this.sourceCodeHolderPanel.Controls.Add(this.linesNumTxt);
            this.sourceCodeHolderPanel.Controls.Add(this.sourceCodeTxt);
            this.sourceCodeHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceCodeHolderPanel.Location = new System.Drawing.Point(3, 57);
            this.sourceCodeHolderPanel.Name = "sourceCodeHolderPanel";
            this.tableLayoutPanel.SetRowSpan(this.sourceCodeHolderPanel, 2);
            this.sourceCodeHolderPanel.Size = new System.Drawing.Size(394, 390);
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
            this.linesNumTxt.Size = new System.Drawing.Size(25, 390);
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
            this.sourceCodeTxt.Size = new System.Drawing.Size(368, 390);
            this.sourceCodeTxt.TabIndex = 11;
            this.sourceCodeTxt.TextChanged += new System.EventHandler(this.sourceCodeTxt_TextChanged);
            // 
            // CompileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compile Form";
            ((System.ComponentModel.ISupportInitialize)(this.tokensDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsDgv)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.compileBtnHolderPanel.ResumeLayout(false);
            this.errorsHolder.ResumeLayout(false);
            this.errorsHolder.PerformLayout();
            this.loadFileBtnHolderPanel.ResumeLayout(false);
            this.sourceCodeHolderPanel.ResumeLayout(false);
            this.sourceCodeHolderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button loadFileBtn;
        private System.Windows.Forms.Label errorsListLbl;
        private System.Windows.Forms.Button compileBtn;
        private System.Windows.Forms.DataGridView tokensDgv;
        private System.Windows.Forms.DataGridView errorsDgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel errorsHolder;
        private System.Windows.Forms.Panel compileBtnHolderPanel;
        private System.Windows.Forms.Panel loadFileBtnHolderPanel;
        private System.Windows.Forms.Panel sourceCodeHolderPanel;
        private System.Windows.Forms.TextBox sourceCodeTxt;
        private System.Windows.Forms.TextBox linesNumTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorLexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn token;
    }
}

