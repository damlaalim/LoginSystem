
namespace cbu
{
    partial class UpdateLessonsForm
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
            this.updateBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.periodCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.depCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.codeCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.codeTxt = new System.Windows.Forms.TextBox();
            this.aktsCombo = new System.Windows.Forms.ComboBox();
            this.lecturerCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(267, 220);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 55;
            this.updateBtn.Text = "GÜNCELLE";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "DÖNEM";
            // 
            // periodCombo
            // 
            this.periodCombo.FormattingEnabled = true;
            this.periodCombo.Location = new System.Drawing.Point(199, 177);
            this.periodCombo.Name = "periodCombo";
            this.periodCombo.Size = new System.Drawing.Size(143, 21);
            this.periodCombo.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "DEPARTMAN";
            // 
            // depCombo
            // 
            this.depCombo.FormattingEnabled = true;
            this.depCombo.Location = new System.Drawing.Point(196, 126);
            this.depCombo.Name = "depCombo";
            this.depCombo.Size = new System.Drawing.Size(146, 21);
            this.depCombo.TabIndex = 51;
            this.depCombo.SelectedIndexChanged += new System.EventHandler(this.depCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "DERS KODU";
            // 
            // codeCombo
            // 
            this.codeCombo.Enabled = false;
            this.codeCombo.FormattingEnabled = true;
            this.codeCombo.Location = new System.Drawing.Point(15, 177);
            this.codeCombo.Name = "codeCombo";
            this.codeCombo.Size = new System.Drawing.Size(68, 21);
            this.codeCombo.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "ÖĞRETİM GÖREVLİSİ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "AKTS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "DERS ADI";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(15, 77);
            this.nameTxt.MaxLength = 30;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(146, 20);
            this.nameTxt.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "DERS BİLGİLERİ";
            // 
            // codeTxt
            // 
            this.codeTxt.Location = new System.Drawing.Point(89, 178);
            this.codeTxt.MaxLength = 11;
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(72, 20);
            this.codeTxt.TabIndex = 56;
            // 
            // aktsCombo
            // 
            this.aktsCombo.FormattingEnabled = true;
            this.aktsCombo.Location = new System.Drawing.Point(15, 126);
            this.aktsCombo.Name = "aktsCombo";
            this.aktsCombo.Size = new System.Drawing.Size(146, 21);
            this.aktsCombo.TabIndex = 57;
            // 
            // lecturerCombo
            // 
            this.lecturerCombo.FormattingEnabled = true;
            this.lecturerCombo.Location = new System.Drawing.Point(196, 77);
            this.lecturerCombo.Name = "lecturerCombo";
            this.lecturerCombo.Size = new System.Drawing.Size(146, 21);
            this.lecturerCombo.TabIndex = 58;
            // 
            // UpdateLessonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 263);
            this.Controls.Add(this.lecturerCombo);
            this.Controls.Add(this.aktsCombo);
            this.Controls.Add(this.codeTxt);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.periodCombo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.depCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codeCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label1);
            this.Name = "UpdateLessonsForm";
            this.Text = "UpdateLessonsForm";
            this.Load += new System.EventHandler(this.UpdateLessonsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox periodCombo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox depCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox codeCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeTxt;
        private System.Windows.Forms.ComboBox aktsCombo;
        private System.Windows.Forms.ComboBox lecturerCombo;
    }
}