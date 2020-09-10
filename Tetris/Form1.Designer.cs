namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GridBox = new System.Windows.Forms.TableLayoutPanel();
            this.NextGridBox = new System.Windows.Forms.TableLayoutPanel();
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LevelBox = new System.Windows.Forms.TextBox();
            this.PointsBox = new System.Windows.Forms.Label();
            this.ScoreBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LinesLabel = new System.Windows.Forms.Label();
            this.LinesBox = new System.Windows.Forms.TextBox();
            this.PauseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GridBox
            // 
            this.GridBox.AutoSize = true;
            this.GridBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GridBox.ColumnCount = 12;
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.GridBox.Location = new System.Drawing.Point(33, 31);
            this.GridBox.Name = "GridBox";
            this.GridBox.RowCount = 22;
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.GridBox.Size = new System.Drawing.Size(361, 660);
            this.GridBox.TabIndex = 0;
            this.GridBox.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // NextGridBox
            // 
            this.NextGridBox.AutoSize = true;
            this.NextGridBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextGridBox.ColumnCount = 4;
            this.NextGridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NextGridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NextGridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NextGridBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NextGridBox.Location = new System.Drawing.Point(421, 58);
            this.NextGridBox.Name = "NextGridBox";
            this.NextGridBox.RowCount = 2;
            this.NextGridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NextGridBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.NextGridBox.Size = new System.Drawing.Size(120, 60);
            this.NextGridBox.TabIndex = 1;
            this.NextGridBox.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.NextGridBox_CellPaint);
            // 
            // GameLoop
            // 
            this.GameLoop.Interval = 600;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(421, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Next:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(421, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Level:";
            // 
            // LevelBox
            // 
            this.LevelBox.CausesValidation = false;
            this.LevelBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LevelBox.Location = new System.Drawing.Point(421, 175);
            this.LevelBox.Name = "LevelBox";
            this.LevelBox.ReadOnly = true;
            this.LevelBox.Size = new System.Drawing.Size(120, 23);
            this.LevelBox.TabIndex = 3;
            this.LevelBox.TabStop = false;
            this.LevelBox.Enter += new System.EventHandler(this.Textbox_Enter);
            // 
            // PointsBox
            // 
            this.PointsBox.AutoSize = true;
            this.PointsBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PointsBox.Location = new System.Drawing.Point(421, 220);
            this.PointsBox.Name = "PointsBox";
            this.PointsBox.Size = new System.Drawing.Size(56, 21);
            this.PointsBox.TabIndex = 2;
            this.PointsBox.Text = "Score:";
            // 
            // ScoreBox
            // 
            this.ScoreBox.CausesValidation = false;
            this.ScoreBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ScoreBox.Location = new System.Drawing.Point(421, 244);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.ReadOnly = true;
            this.ScoreBox.Size = new System.Drawing.Size(120, 23);
            this.ScoreBox.TabIndex = 3;
            this.ScoreBox.TabStop = false;
            this.ScoreBox.Enter += new System.EventHandler(this.Textbox_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(231, 360);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(120, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            // 
            // LinesLabel
            // 
            this.LinesLabel.AutoSize = true;
            this.LinesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LinesLabel.Location = new System.Drawing.Point(421, 282);
            this.LinesLabel.Name = "LinesLabel";
            this.LinesLabel.Size = new System.Drawing.Size(53, 21);
            this.LinesLabel.TabIndex = 2;
            this.LinesLabel.Text = "Lines:";
            // 
            // LinesBox
            // 
            this.LinesBox.CausesValidation = false;
            this.LinesBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LinesBox.Location = new System.Drawing.Point(421, 306);
            this.LinesBox.Name = "LinesBox";
            this.LinesBox.ReadOnly = true;
            this.LinesBox.Size = new System.Drawing.Size(120, 23);
            this.LinesBox.TabIndex = 3;
            this.LinesBox.TabStop = false;
            this.LinesBox.Enter += new System.EventHandler(this.Textbox_Enter);
            // 
            // PauseButton
            // 
            this.PauseButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PauseButton.Location = new System.Drawing.Point(421, 662);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(120, 29);
            this.PauseButton.TabIndex = 4;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 719);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.LinesBox);
            this.Controls.Add(this.LinesLabel);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.PointsBox);
            this.Controls.Add(this.LevelBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NextGridBox);
            this.Controls.Add(this.GridBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel GridBox;
        private System.Windows.Forms.TableLayoutPanel NextGridBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LevelBox;
        private System.Windows.Forms.Label PointsBox;
        private System.Windows.Forms.TextBox ScoreBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LinesLabel;
        private System.Windows.Forms.TextBox LinesBox;
        private System.Windows.Forms.Button PauseButton;
    }
}

