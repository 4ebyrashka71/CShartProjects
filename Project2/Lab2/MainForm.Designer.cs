
namespace Lab2
{
    partial class MainForm
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
            this.matrix1Grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.task1Button = new System.Windows.Forms.Button();
            this.chartButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFirstButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.matrix1Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // matrix1Grid
            // 
            this.matrix1Grid.AllowUserToAddRows = false;
            this.matrix1Grid.AllowUserToDeleteRows = false;
            this.matrix1Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrix1Grid.Location = new System.Drawing.Point(55, 148);
            this.matrix1Grid.Margin = new System.Windows.Forms.Padding(6);
            this.matrix1Grid.Name = "matrix1Grid";
            this.matrix1Grid.Size = new System.Drawing.Size(711, 522);
            this.matrix1Grid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrix";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(842, 148);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(165, 42);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Matrix";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // task1Button
            // 
            this.task1Button.Enabled = false;
            this.task1Button.Location = new System.Drawing.Point(842, 466);
            this.task1Button.Margin = new System.Windows.Forms.Padding(4);
            this.task1Button.Name = "task1Button";
            this.task1Button.Size = new System.Drawing.Size(165, 42);
            this.task1Button.TabIndex = 5;
            this.task1Button.Text = "Task 1";
            this.task1Button.UseVisualStyleBackColor = true;
            this.task1Button.Click += new System.EventHandler(this.task1Button_Click);
            // 
            // chartButton
            // 
            this.chartButton.Enabled = false;
            this.chartButton.Location = new System.Drawing.Point(842, 626);
            this.chartButton.Margin = new System.Windows.Forms.Padding(4);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(165, 42);
            this.chartButton.TabIndex = 6;
            this.chartButton.Text = "Show Chart";
            this.chartButton.UseVisualStyleBackColor = true;
            this.chartButton.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // saveFirstButton
            // 
            this.saveFirstButton.Enabled = false;
            this.saveFirstButton.Location = new System.Drawing.Point(842, 308);
            this.saveFirstButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveFirstButton.Name = "saveFirstButton";
            this.saveFirstButton.Size = new System.Drawing.Size(165, 42);
            this.saveFirstButton.TabIndex = 7;
            this.saveFirstButton.Text = "Save Matrix";
            this.saveFirstButton.UseVisualStyleBackColor = true;
            this.saveFirstButton.Click += new System.EventHandler(this.saveFirstButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.loadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 831);
            this.Controls.Add(this.saveFirstButton);
            this.Controls.Add(this.chartButton);
            this.Controls.Add(this.task1Button);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matrix1Grid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab2";
            ((System.ComponentModel.ISupportInitialize)(this.matrix1Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView matrix1Grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button task1Button;
        private System.Windows.Forms.Button chartButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button saveFirstButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

