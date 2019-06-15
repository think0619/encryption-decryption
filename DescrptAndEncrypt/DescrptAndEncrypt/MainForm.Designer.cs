namespace DescrptAndEncrypt
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
            this.StartEncrypt = new System.Windows.Forms.Button();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.encryFilePathTxt = new System.Windows.Forms.TextBox();
            this.CipherModeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TargetDirectoryTxt = new System.Windows.Forms.TextBox();
            this.DesDireBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.ResultTxt = new System.Windows.Forms.TextBox();
            this.resultlabel = new System.Windows.Forms.Label();
            this.descpasswordTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.decSelectDirectoryBtn = new System.Windows.Forms.Button();
            this.descTargetDirectoryTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.desSourceFile = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.descCipherModeComboBox = new System.Windows.Forms.ComboBox();
            this.descryFilePathTxt = new System.Windows.Forms.TextBox();
            this.decSelectFileBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartEncrypt
            // 
            this.StartEncrypt.Location = new System.Drawing.Point(286, 179);
            this.StartEncrypt.Name = "StartEncrypt";
            this.StartEncrypt.Size = new System.Drawing.Size(98, 25);
            this.StartEncrypt.TabIndex = 0;
            this.StartEncrypt.Text = "Start";
            this.StartEncrypt.UseVisualStyleBackColor = true;
            this.StartEncrypt.Click += new System.EventHandler(this.Button1_Click);
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Location = new System.Drawing.Point(513, 56);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(121, 22);
            this.selectFileBtn.TabIndex = 1;
            this.selectFileBtn.Text = "Select File";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // encryFilePathTxt
            // 
            this.encryFilePathTxt.Location = new System.Drawing.Point(138, 58);
            this.encryFilePathTxt.Name = "encryFilePathTxt";
            this.encryFilePathTxt.Size = new System.Drawing.Size(355, 20);
            this.encryFilePathTxt.TabIndex = 2;
            // 
            // CipherModeComboBox
            // 
            this.CipherModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CipherModeComboBox.FormattingEnabled = true;
            this.CipherModeComboBox.Location = new System.Drawing.Point(138, 179);
            this.CipherModeComboBox.Name = "CipherModeComboBox";
            this.CipherModeComboBox.Size = new System.Drawing.Size(108, 21);
            this.CipherModeComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encrypt File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "CipherMode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source File:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Target Directory:";
            // 
            // TargetDirectoryTxt
            // 
            this.TargetDirectoryTxt.Location = new System.Drawing.Point(138, 96);
            this.TargetDirectoryTxt.Name = "TargetDirectoryTxt";
            this.TargetDirectoryTxt.Size = new System.Drawing.Size(355, 20);
            this.TargetDirectoryTxt.TabIndex = 8;
            this.TargetDirectoryTxt.Text = "D:\\OutputFile";
            // 
            // DesDireBtn
            // 
            this.DesDireBtn.Location = new System.Drawing.Point(513, 93);
            this.DesDireBtn.Name = "DesDireBtn";
            this.DesDireBtn.Size = new System.Drawing.Size(121, 23);
            this.DesDireBtn.TabIndex = 9;
            this.DesDireBtn.Text = "Select Directory";
            this.DesDireBtn.UseVisualStyleBackColor = true;
            this.DesDireBtn.Click += new System.EventHandler(this.DesDireBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password:";
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(138, 139);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(355, 20);
            this.passwordTxt.TabIndex = 11;
            // 
            // ResultTxt
            // 
            this.ResultTxt.Location = new System.Drawing.Point(719, 74);
            this.ResultTxt.Multiline = true;
            this.ResultTxt.Name = "ResultTxt";
            this.ResultTxt.ReadOnly = true;
            this.ResultTxt.Size = new System.Drawing.Size(446, 446);
            this.ResultTxt.TabIndex = 12;
            // 
            // resultlabel
            // 
            this.resultlabel.AutoSize = true;
            this.resultlabel.Location = new System.Drawing.Point(716, 47);
            this.resultlabel.Name = "resultlabel";
            this.resultlabel.Size = new System.Drawing.Size(40, 13);
            this.resultlabel.TabIndex = 13;
            this.resultlabel.Text = "Result:";
            // 
            // descpasswordTxt
            // 
            this.descpasswordTxt.Location = new System.Drawing.Point(138, 395);
            this.descpasswordTxt.Name = "descpasswordTxt";
            this.descpasswordTxt.Size = new System.Drawing.Size(355, 20);
            this.descpasswordTxt.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Password:";
            // 
            // decSelectDirectoryBtn
            // 
            this.decSelectDirectoryBtn.Location = new System.Drawing.Point(513, 349);
            this.decSelectDirectoryBtn.Name = "decSelectDirectoryBtn";
            this.decSelectDirectoryBtn.Size = new System.Drawing.Size(121, 23);
            this.decSelectDirectoryBtn.TabIndex = 23;
            this.decSelectDirectoryBtn.Text = "Select Directory";
            this.decSelectDirectoryBtn.UseVisualStyleBackColor = true;
            this.decSelectDirectoryBtn.Click += new System.EventHandler(this.decSelectDirectoryBtn_Click);
            // 
            // descTargetDirectoryTxt
            // 
            this.descTargetDirectoryTxt.Location = new System.Drawing.Point(138, 352);
            this.descTargetDirectoryTxt.Name = "descTargetDirectoryTxt";
            this.descTargetDirectoryTxt.Size = new System.Drawing.Size(355, 20);
            this.descTargetDirectoryTxt.TabIndex = 22;
            this.descTargetDirectoryTxt.Text = "D:\\OutputFile";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Target Directory:";
            // 
            // desSourceFile
            // 
            this.desSourceFile.AutoSize = true;
            this.desSourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desSourceFile.Location = new System.Drawing.Point(15, 318);
            this.desSourceFile.Name = "desSourceFile";
            this.desSourceFile.Size = new System.Drawing.Size(79, 16);
            this.desSourceFile.TabIndex = 20;
            this.desSourceFile.Text = "Source File:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "CipherMode:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Decrypt File";
            // 
            // descCipherModeComboBox
            // 
            this.descCipherModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.descCipherModeComboBox.FormattingEnabled = true;
            this.descCipherModeComboBox.Location = new System.Drawing.Point(138, 435);
            this.descCipherModeComboBox.Name = "descCipherModeComboBox";
            this.descCipherModeComboBox.Size = new System.Drawing.Size(108, 21);
            this.descCipherModeComboBox.TabIndex = 17;
            // 
            // descryFilePathTxt
            // 
            this.descryFilePathTxt.Location = new System.Drawing.Point(138, 314);
            this.descryFilePathTxt.Name = "descryFilePathTxt";
            this.descryFilePathTxt.Size = new System.Drawing.Size(355, 20);
            this.descryFilePathTxt.TabIndex = 16;
            // 
            // decSelectFileBtn
            // 
            this.decSelectFileBtn.Location = new System.Drawing.Point(513, 312);
            this.decSelectFileBtn.Name = "decSelectFileBtn";
            this.decSelectFileBtn.Size = new System.Drawing.Size(121, 22);
            this.decSelectFileBtn.TabIndex = 15;
            this.decSelectFileBtn.Text = "Select File";
            this.decSelectFileBtn.UseVisualStyleBackColor = true;
            this.decSelectFileBtn.Click += new System.EventHandler(this.decSelectFileBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(286, 435);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 25);
            this.button3.TabIndex = 14;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 589);
            this.Controls.Add(this.descpasswordTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.decSelectDirectoryBtn);
            this.Controls.Add(this.descTargetDirectoryTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.desSourceFile);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.descCipherModeComboBox);
            this.Controls.Add(this.descryFilePathTxt);
            this.Controls.Add(this.decSelectFileBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.resultlabel);
            this.Controls.Add(this.ResultTxt);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DesDireBtn);
            this.Controls.Add(this.TargetDirectoryTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CipherModeComboBox);
            this.Controls.Add(this.encryFilePathTxt);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.StartEncrypt);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartEncrypt;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.TextBox encryFilePathTxt;
        private System.Windows.Forms.ComboBox CipherModeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TargetDirectoryTxt;
        private System.Windows.Forms.Button DesDireBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox ResultTxt;
        private System.Windows.Forms.Label resultlabel;
        private System.Windows.Forms.TextBox descpasswordTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button decSelectDirectoryBtn;
        private System.Windows.Forms.TextBox descTargetDirectoryTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label desSourceFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox descCipherModeComboBox;
        private System.Windows.Forms.TextBox descryFilePathTxt;
        private System.Windows.Forms.Button decSelectFileBtn;
        private System.Windows.Forms.Button button3;
    }
}

