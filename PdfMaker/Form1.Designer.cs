namespace PdfMaker
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
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(138, 152);
            button2.Name = "button2";
            button2.Size = new Size(192, 52);
            button2.TabIndex = 1;
            button2.Text = "Make it bitch!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(451, 60);
            label1.TabIndex = 2;
            label1.Text = "Görselleri sürükle bırak yaptıktan sonra \r\n\"Oluştur\"a basarsanız PDF dosyanız oluşacaktır.\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 216);
            Controls.Add(label1);
            Controls.Add(button2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pdf Maker";
            Load += Form1_Load;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Label label1;
    }
}