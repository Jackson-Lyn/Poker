namespace PokerGame
{
    partial class RaiseInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.numUDRaise = new System.Windows.Forms.NumericUpDown();
            this.btnRaise = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUDRaise)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "-----";
            // 
            // numUDRaise
            // 
            this.numUDRaise.Location = new System.Drawing.Point(86, 70);
            this.numUDRaise.Name = "numUDRaise";
            this.numUDRaise.Size = new System.Drawing.Size(120, 20);
            this.numUDRaise.TabIndex = 1;
            // 
            // btnRaise
            // 
            this.btnRaise.Location = new System.Drawing.Point(110, 107);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(75, 23);
            this.btnRaise.TabIndex = 2;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = true;
            // 
            // RaiseInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 142);
            this.Controls.Add(this.btnRaise);
            this.Controls.Add(this.numUDRaise);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(305, 181);
            this.MinimumSize = new System.Drawing.Size(305, 181);
            this.Name = "RaiseInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaiseInput";
            ((System.ComponentModel.ISupportInitialize)(this.numUDRaise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUDRaise;
        private System.Windows.Forms.Button btnRaise;
    }
}