
namespace cbu
{
    partial class UpdateDepartmentForm
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
            this.depNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shortNameTxt = new System.Windows.Forms.TextBox();
            this.insertBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // depNameTxt
            // 
            this.depNameTxt.Location = new System.Drawing.Point(119, 38);
            this.depNameTxt.Name = "depNameTxt";
            this.depNameTxt.Size = new System.Drawing.Size(163, 20);
            this.depNameTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Departman Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Departman Kısa Adı:";
            // 
            // shortNameTxt
            // 
            this.shortNameTxt.Location = new System.Drawing.Point(119, 79);
            this.shortNameTxt.Name = "shortNameTxt";
            this.shortNameTxt.Size = new System.Drawing.Size(163, 20);
            this.shortNameTxt.TabIndex = 2;
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(207, 128);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(75, 23);
            this.insertBtn.TabIndex = 4;
            this.insertBtn.Text = "Güncelle";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // UpdateDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 179);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortNameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depNameTxt);
            this.Name = "UpdateDepartmentForm";
            this.Text = "UpdateDepartmentForm";
            this.Load += new System.EventHandler(this.UpdateDepartmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox depNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shortNameTxt;
        private System.Windows.Forms.Button insertBtn;
    }
}