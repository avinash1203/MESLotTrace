namespace Printing
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radUnPrinted = new System.Windows.Forms.RadioButton();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestLabel = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 150);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 150);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 36);
            this.button3.TabIndex = 6;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 266);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 184);
            this.listBox1.TabIndex = 7;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(155, 57);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(194, 26);
            this.txtCode.TabIndex = 9;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(18, 63);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(103, 20);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Vendor Code";
            this.lblCode.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLotNumber.Location = new System.Drawing.Point(155, 14);
            this.txtLotNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(194, 26);
            this.txtLotNumber.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Vendor Lot No";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(155, 105);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(55, 24);
            this.radAll.TabIndex = 14;
            this.radAll.TabStop = true;
            this.radAll.Text = "All ";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radUnPrinted
            // 
            this.radUnPrinted.AutoSize = true;
            this.radUnPrinted.Checked = true;
            this.radUnPrinted.Location = new System.Drawing.Point(258, 105);
            this.radUnPrinted.Name = "radUnPrinted";
            this.radUnPrinted.Size = new System.Drawing.Size(105, 24);
            this.radUnPrinted.TabIndex = 15;
            this.radUnPrinted.TabStop = true;
            this.radUnPrinted.Text = "UnPrinted";
            this.radUnPrinted.UseVisualStyleBackColor = true;
            // 
            // txtIp
            // 
            this.txtIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIp.Location = new System.Drawing.Point(514, 57);
            this.txtIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(194, 26);
            this.txtIp.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP";
            // 
            // btnTestLabel
            // 
            this.btnTestLabel.Location = new System.Drawing.Point(514, 136);
            this.btnTestLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTestLabel.Name = "btnTestLabel";
            this.btnTestLabel.Size = new System.Drawing.Size(91, 36);
            this.btnTestLabel.TabIndex = 18;
            this.btnTestLabel.Text = "Test";
            this.btnTestLabel.UseVisualStyleBackColor = true;
            this.btnTestLabel.Click += new System.EventHandler(this.btnTestLabel_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(639, 136);
            this.btnTest2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(91, 36);
            this.btnTest2.TabIndex = 19;
            this.btnTest2.Text = "Test 2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 471);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnTestLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.radUnPrinted);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLotNumber);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radUnPrinted;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestLabel;
        private System.Windows.Forms.Button btnTest2;
    }
}