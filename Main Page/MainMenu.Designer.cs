namespace NFSColorRX
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            trackBarR = new TrackBar();
            trackBarG = new TrackBar();
            trackBarB = new TrackBar();
            trackBarA = new TrackBar();
            numR = new NumericUpDown();
            numG = new NumericUpDown();
            numB = new NumericUpDown();
            numA = new NumericUpDown();
            lblR = new Label();
            lblG = new Label();
            lblB = new Label();
            lblA = new Label();
            panelColor = new DoubleBufferedPanel();
            txtHEXFormat = new TextBox();
            txtDecimalFormat = new TextBox();
            labelHEX = new Label();
            labelDecimal = new Label();
            btnCopyHEX = new Button();
            btnCopyDecimal = new Button();
            btnSwapMode = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numA).BeginInit();
            SuspendLayout();
            // 
            // trackBarR
            // 
            trackBarR.Location = new Point(41, 20);
            trackBarR.Maximum = 255;
            trackBarR.Name = "trackBarR";
            trackBarR.Size = new Size(282, 45);
            trackBarR.TabIndex = 0;
            trackBarR.ValueChanged += trackBar_ValueChanged;
            // 
            // trackBarG
            // 
            trackBarG.Location = new Point(41, 60);
            trackBarG.Maximum = 255;
            trackBarG.Name = "trackBarG";
            trackBarG.Size = new Size(282, 45);
            trackBarG.TabIndex = 1;
            trackBarG.ValueChanged += trackBar_ValueChanged;
            // 
            // trackBarB
            // 
            trackBarB.Location = new Point(41, 100);
            trackBarB.Maximum = 255;
            trackBarB.Name = "trackBarB";
            trackBarB.Size = new Size(282, 45);
            trackBarB.TabIndex = 2;
            trackBarB.ValueChanged += trackBar_ValueChanged;
            // 
            // trackBarA
            // 
            trackBarA.Location = new Point(41, 145);
            trackBarA.Maximum = 255;
            trackBarA.Name = "trackBarA";
            trackBarA.Size = new Size(282, 45);
            trackBarA.TabIndex = 3;
            trackBarA.ValueChanged += trackBar_ValueChanged;
            // 
            // numR
            // 
            numR.Location = new Point(357, 20);
            numR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numR.Name = "numR";
            numR.Size = new Size(130, 23);
            numR.TabIndex = 4;
            numR.ValueChanged += numeric_ValueChanged;
            // 
            // numG
            // 
            numG.Location = new Point(357, 60);
            numG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numG.Name = "numG";
            numG.Size = new Size(130, 23);
            numG.TabIndex = 5;
            numG.ValueChanged += numeric_ValueChanged;
            // 
            // numB
            // 
            numB.Location = new Point(357, 105);
            numB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numB.Name = "numB";
            numB.Size = new Size(130, 23);
            numB.TabIndex = 6;
            numB.ValueChanged += numeric_ValueChanged;
            // 
            // numA
            // 
            numA.Location = new Point(357, 147);
            numA.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numA.Name = "numA";
            numA.Size = new Size(130, 23);
            numA.TabIndex = 7;
            numA.ValueChanged += numeric_ValueChanged;
            // 
            // lblR
            // 
            lblR.AutoSize = true;
            lblR.Location = new Point(20, 25);
            lblR.Name = "lblR";
            lblR.Size = new Size(14, 15);
            lblR.TabIndex = 8;
            lblR.Text = "R";
            // 
            // lblG
            // 
            lblG.AutoSize = true;
            lblG.Location = new Point(20, 65);
            lblG.Name = "lblG";
            lblG.Size = new Size(15, 15);
            lblG.TabIndex = 9;
            lblG.Text = "G";
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Location = new Point(20, 105);
            lblB.Name = "lblB";
            lblB.Size = new Size(14, 15);
            lblB.TabIndex = 10;
            lblB.Text = "B";
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Location = new Point(20, 145);
            lblA.Name = "lblA";
            lblA.Size = new Size(15, 15);
            lblA.TabIndex = 11;
            lblA.Text = "A";
            // 
            // panelColor
            // 
            panelColor.BorderStyle = BorderStyle.FixedSingle;
            panelColor.Location = new Point(511, 20);
            panelColor.Name = "panelColor";
            panelColor.Size = new Size(150, 150);
            panelColor.TabIndex = 12;
            // 
            // txtHEXFormat
            // 
            txtHEXFormat.Location = new Point(20, 200);
            txtHEXFormat.Name = "txtHEXFormat";
            txtHEXFormat.Size = new Size(303, 23);
            txtHEXFormat.TabIndex = 13;
            // 
            // txtDecimalFormat
            // 
            txtDecimalFormat.Location = new Point(20, 250);
            txtDecimalFormat.Name = "txtDecimalFormat";
            txtDecimalFormat.Size = new Size(303, 23);
            txtDecimalFormat.TabIndex = 14;
            // 
            // labelHEX
            // 
            labelHEX.AutoSize = true;
            labelHEX.Location = new Point(20, 180);
            labelHEX.Name = "labelHEX";
            labelHEX.Size = new Size(28, 15);
            labelHEX.TabIndex = 15;
            labelHEX.Text = "Hex";
            // 
            // labelDecimal
            // 
            labelDecimal.AutoSize = true;
            labelDecimal.Location = new Point(20, 230);
            labelDecimal.Name = "labelDecimal";
            labelDecimal.Size = new Size(50, 15);
            labelDecimal.TabIndex = 16;
            labelDecimal.Text = "Decimal";
            // 
            // btnCopyHEX
            // 
            btnCopyHEX.Location = new Point(357, 200);
            btnCopyHEX.Name = "btnCopyHEX";
            btnCopyHEX.Size = new Size(130, 24);
            btnCopyHEX.TabIndex = 17;
            btnCopyHEX.Text = "Copy Hex";
            btnCopyHEX.UseVisualStyleBackColor = true;
            btnCopyHEX.Click += btnCopyHEX_Click;
            // 
            // btnCopyDecimal
            // 
            btnCopyDecimal.Location = new Point(357, 250);
            btnCopyDecimal.Name = "btnCopyDecimal";
            btnCopyDecimal.Size = new Size(130, 24);
            btnCopyDecimal.TabIndex = 18;
            btnCopyDecimal.Text = "Copy Decimal";
            btnCopyDecimal.UseVisualStyleBackColor = true;
            btnCopyDecimal.Click += btnCopyDecimal_Click;
            // 
            // btnSwapMode
            // 
            btnSwapMode.Location = new Point(511, 250);
            btnSwapMode.Name = "btnSwapMode";
            btnSwapMode.Size = new Size(150, 24);
            btnSwapMode.TabIndex = 19;
            btnSwapMode.Text = "Swap to XYZ";
            btnSwapMode.UseVisualStyleBackColor = true;
            btnSwapMode.Click += btnSwapMode_Click;
            // 
            // MainMenu
            // 
            ClientSize = new Size(680, 300);
            Controls.Add(labelHEX);
            Controls.Add(trackBarR);
            Controls.Add(trackBarG);
            Controls.Add(trackBarB);
            Controls.Add(trackBarA);
            Controls.Add(numR);
            Controls.Add(numG);
            Controls.Add(numB);
            Controls.Add(numA);
            Controls.Add(lblR);
            Controls.Add(lblG);
            Controls.Add(lblB);
            Controls.Add(lblA);
            Controls.Add(panelColor);
            Controls.Add(txtHEXFormat);
            Controls.Add(txtDecimalFormat);
            Controls.Add(labelDecimal);
            Controls.Add(btnCopyHEX);
            Controls.Add(btnCopyDecimal);
            Controls.Add(btnSwapMode);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ((System.ComponentModel.ISupportInitialize)trackBarR).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarG).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarB).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numR).EndInit();
            ((System.ComponentModel.ISupportInitialize)numG).EndInit();
            ((System.ComponentModel.ISupportInitialize)numB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numA).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.TrackBar trackBarG;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.TrackBar trackBarA;
        private System.Windows.Forms.NumericUpDown numR;
        private System.Windows.Forms.NumericUpDown numG;
        private System.Windows.Forms.NumericUpDown numB;
        private System.Windows.Forms.NumericUpDown numA;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtHEXFormat;
        private System.Windows.Forms.TextBox txtDecimalFormat;
        private System.Windows.Forms.Label labelHEX;
        private System.Windows.Forms.Label labelDecimal;
        private System.Windows.Forms.Button btnCopyHEX;
        private System.Windows.Forms.Button btnCopyDecimal;
        private System.Windows.Forms.Button btnSwapMode;
        private NFSColorRX.DoubleBufferedPanel panelColor;
    }
}
