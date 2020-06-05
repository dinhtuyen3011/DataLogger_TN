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
            this.Operate1_combobox = new System.Windows.Forms.ComboBox();
            this.Operand_combobox = new System.Windows.Forms.ComboBox();
            this.Operate2_combobox = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Operate1_combobox
            // 
            this.Operate1_combobox.FormattingEnabled = true;
            this.Operate1_combobox.Location = new System.Drawing.Point(12, 26);
            this.Operate1_combobox.Name = "Operate1_combobox";
            this.Operate1_combobox.Size = new System.Drawing.Size(101, 21);
            this.Operate1_combobox.TabIndex = 0;
            this.Operate1_combobox.SelectedIndexChanged += new System.EventHandler(this.Operate1_SelectedIndexChanged);
            // 
            // Operand_combobox
            // 
            this.Operand_combobox.FormattingEnabled = true;
            this.Operand_combobox.Location = new System.Drawing.Point(128, 26);
            this.Operand_combobox.Name = "Operand_combobox";
            this.Operand_combobox.Size = new System.Drawing.Size(51, 21);
            this.Operand_combobox.TabIndex = 1;
            this.Operand_combobox.SelectedIndexChanged += new System.EventHandler(this.Operand_SelectedIndexChanged);
            // 
            // Operate2_combobox
            // 
            this.Operate2_combobox.FormattingEnabled = true;
            this.Operate2_combobox.Location = new System.Drawing.Point(199, 26);
            this.Operate2_combobox.Name = "Operate2_combobox";
            this.Operate2_combobox.Size = new System.Drawing.Size(101, 21);
            this.Operate2_combobox.TabIndex = 0;
            this.Operate2_combobox.SelectedIndexChanged += new System.EventHandler(this.Operate2_combobox_SelectedIndexChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(331, 24);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // InterativeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 72);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Operand_combobox);
            this.Controls.Add(this.Operate2_combobox);
            this.Controls.Add(this.Operate1_combobox);
            this.Name = "InterativeForm";
            this.Text = "InterativeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InterativeForm_FormClosed);
            this.Load += new System.EventHandler(this.InterativeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Operate1_combobox;
        private System.Windows.Forms.ComboBox Operand_combobox;
        private System.Windows.Forms.ComboBox Operate2_combobox;
        private System.Windows.Forms.Button OK;
    }
}