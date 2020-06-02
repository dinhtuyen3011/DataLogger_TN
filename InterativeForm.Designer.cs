namespace DataLogger
{
    partial class InterativeForm
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
            this.Operate1 = new System.Windows.Forms.ComboBox();
            this.Operand = new System.Windows.Forms.ComboBox();
            this.Operate2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Operate1
            // 
            this.Operate1.FormattingEnabled = true;
            this.Operate1.Location = new System.Drawing.Point(12, 144);
            this.Operate1.Name = "Operate1";
            this.Operate1.Size = new System.Drawing.Size(121, 21);
            this.Operate1.TabIndex = 0;
            // 
            // Operand
            // 
            this.Operand.FormattingEnabled = true;
            this.Operand.Location = new System.Drawing.Point(174, 144);
            this.Operand.Name = "Operand";
            this.Operand.Size = new System.Drawing.Size(145, 21);
            this.Operand.TabIndex = 1;
            // 
            // Operate2
            // 
            this.Operate2.FormattingEnabled = true;
            this.Operate2.Location = new System.Drawing.Point(358, 144);
            this.Operate2.Name = "Operate2";
            this.Operate2.Size = new System.Drawing.Size(121, 21);
            this.Operate2.TabIndex = 0;
            // 
            // InterativeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Operand);
            this.Controls.Add(this.Operate2);
            this.Controls.Add(this.Operate1);
            this.Name = "InterativeForm";
            this.Text = "InterativeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Operate1;
        private System.Windows.Forms.ComboBox Operand;
        private System.Windows.Forms.ComboBox Operate2;
    }
}