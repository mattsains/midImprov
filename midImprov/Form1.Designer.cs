namespace midImprov
{
    partial class Form1
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
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.scaleList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmbNote
            // 
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Items.AddRange(new object[] {
            "A",
            "A#",
            "B",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"});
            this.cmbNote.Location = new System.Drawing.Point(35, 12);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(121, 21);
            this.cmbNote.TabIndex = 0;
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Major",
            "Minor",
            "Diminished"});
            this.cmbMode.Location = new System.Drawing.Point(35, 39);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(121, 21);
            this.cmbMode.TabIndex = 1;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // scaleList
            // 
            this.scaleList.FormattingEnabled = true;
            this.scaleList.Location = new System.Drawing.Point(35, 95);
            this.scaleList.Name = "scaleList";
            this.scaleList.Size = new System.Drawing.Size(121, 147);
            this.scaleList.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 443);
            this.Controls.Add(this.scaleList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.cmbNote);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNote;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox scaleList;
    }
}

