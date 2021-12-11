
namespace cbu
{
    partial class InsertLesson
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
            this.insertBtn = new System.Windows.Forms.Button();
            this.shortNameBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lesNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.periodCombo = new System.Windows.Forms.ComboBox();
            this.depCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.aktsCombo = new System.Windows.Forms.ComboBox();
            this.lecturerCombo = new System.Windows.Forms.ComboBox();
            this.lectrurerMailCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(213, 246);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(75, 23);
            this.insertBtn.TabIndex = 34;
            this.insertBtn.Text = "Ekle";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // shortNameBox
            // 
            this.shortNameBox.Enabled = false;
            this.shortNameBox.FormattingEnabled = true;
            this.shortNameBox.Location = new System.Drawing.Point(140, 129);
            this.shortNameBox.Name = "shortNameBox";
            this.shortNameBox.Size = new System.Drawing.Size(86, 21);
            this.shortNameBox.TabIndex = 28;
            this.shortNameBox.Text = "Bölüm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ders Dönemi:";
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(232, 130);
            this.codeBox.MaxLength = 30;
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(56, 20);
            this.codeBox.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ders Kodu:";
            // 
            // lesNameTxt
            // 
            this.lesNameTxt.Location = new System.Drawing.Point(140, 27);
            this.lesNameTxt.MaxLength = 50;
            this.lesNameTxt.Name = "lesNameTxt";
            this.lesNameTxt.Size = new System.Drawing.Size(148, 20);
            this.lesNameTxt.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ders Adı:";
            // 
            // periodCombo
            // 
            this.periodCombo.FormattingEnabled = true;
            this.periodCombo.Location = new System.Drawing.Point(140, 94);
            this.periodCombo.Name = "periodCombo";
            this.periodCombo.Size = new System.Drawing.Size(86, 21);
            this.periodCombo.TabIndex = 36;
            // 
            // depCombo
            // 
            this.depCombo.FormattingEnabled = true;
            this.depCombo.Location = new System.Drawing.Point(140, 60);
            this.depCombo.Name = "depCombo";
            this.depCombo.Size = new System.Drawing.Size(148, 21);
            this.depCombo.TabIndex = 37;
            this.depCombo.SelectedIndexChanged += new System.EventHandler(this.depCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Bölüm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Öğretim Görevlisi:";
            // 
            // aktsCombo
            // 
            this.aktsCombo.FormattingEnabled = true;
            this.aktsCombo.Location = new System.Drawing.Point(232, 94);
            this.aktsCombo.Name = "aktsCombo";
            this.aktsCombo.Size = new System.Drawing.Size(56, 21);
            this.aktsCombo.TabIndex = 39;
            this.aktsCombo.Text = "AKTS";
            // 
            // lecturerCombo
            // 
            this.lecturerCombo.FormattingEnabled = true;
            this.lecturerCombo.Location = new System.Drawing.Point(140, 166);
            this.lecturerCombo.Name = "lecturerCombo";
            this.lecturerCombo.Size = new System.Drawing.Size(148, 21);
            this.lecturerCombo.TabIndex = 41;
            this.lecturerCombo.SelectedIndexChanged += new System.EventHandler(this.lecturerCombo_SelectedIndexChanged);
            // 
            // lectrurerMailCombo
            // 
            this.lectrurerMailCombo.FormattingEnabled = true;
            this.lectrurerMailCombo.Location = new System.Drawing.Point(140, 203);
            this.lectrurerMailCombo.Name = "lectrurerMailCombo";
            this.lectrurerMailCombo.Size = new System.Drawing.Size(148, 21);
            this.lectrurerMailCombo.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Öğretim Görevlisi Mail:";
            // 
            // InsertLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 291);
            this.Controls.Add(this.lectrurerMailCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lecturerCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aktsCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.depCombo);
            this.Controls.Add(this.periodCombo);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.shortNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lesNameTxt);
            this.Controls.Add(this.label1);
            this.Name = "InsertLesson";
            this.Text = "Ders Ekle";
            this.Load += new System.EventHandler(this.InsertLesson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.ComboBox shortNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lesNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox periodCombo;
        private System.Windows.Forms.ComboBox depCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox aktsCombo;
        private System.Windows.Forms.ComboBox lecturerCombo;
        private System.Windows.Forms.ComboBox lectrurerMailCombo;
        private System.Windows.Forms.Label label6;
    }
}