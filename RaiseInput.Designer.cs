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
            this.labelText = new System.Windows.Forms.Label();
            this.numUDRaise = new System.Windows.Forms.NumericUpDown();
            this.btnRaise = new System.Windows.Forms.Button();
            this.buttonAllIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUDRaise)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(137, 51);
            this.labelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(110, 16);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Raise the stakes!";
            // 
            // numUDRaise
            // 
            this.numUDRaise.Location = new System.Drawing.Point(115, 86);
            this.numUDRaise.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numUDRaise.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUDRaise.Name = "numUDRaise";
            this.numUDRaise.Size = new System.Drawing.Size(160, 22);
            this.numUDRaise.TabIndex = 1;
            // 
            // btnRaise
            // 
            this.btnRaise.Location = new System.Drawing.Point(140, 116);
            this.btnRaise.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(100, 28);
            this.btnRaise.TabIndex = 2;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = true;
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // buttonAllIn
            // 
            this.buttonAllIn.Location = new System.Drawing.Point(7, 86);
            this.buttonAllIn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAllIn.Name = "buttonAllIn";
            this.buttonAllIn.Size = new System.Drawing.Size(100, 22);
            this.buttonAllIn.TabIndex = 3;
            this.buttonAllIn.Text = "All-In";
            this.buttonAllIn.UseVisualStyleBackColor = true;
            this.buttonAllIn.Click += new System.EventHandler(this.buttonAllIn_Click);
            // 
            // RaiseInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 165);
            this.Controls.Add(this.buttonAllIn);
            this.Controls.Add(this.btnRaise);
            this.Controls.Add(this.numUDRaise);
            this.Controls.Add(this.labelText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(401, 212);
            this.MinimumSize = new System.Drawing.Size(401, 212);
            this.Name = "RaiseInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaiseInput";
            ((System.ComponentModel.ISupportInitialize)(this.numUDRaise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.NumericUpDown numUDRaise;
        private System.Windows.Forms.Button btnRaise;
        private System.Windows.Forms.Button buttonAllIn;
    }
}