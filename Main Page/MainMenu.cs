using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NFSColorRX
{
    public partial class MainMenu : Form
    {
        private bool isUpdating = false;
        private bool ModeRGB = true;
        private bool ModeXYZ = false;

        public MainMenu()
        {
            // Settings
            new ToolOptions(this);
            this.Text = ToolInfo.FullTitle;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            InitializeComponent();

            trackBarR.Value = 0;
            trackBarG.Value = 0;
            trackBarB.Value = 0;
            trackBarA.Value = 0;

            numR.Value = 0;
            numG.Value = 0;
            numB.Value = 0;
            numA.Value = 0;

            txtHEXFormat.TextChanged += TxtHEXFormat_TextChanged;
            txtDecimalFormat.TextChanged += TxtDecimalFormat_TextChanged;
            panelColor.Click += panelColor_Click;
            btnCopyHEX.Click += btnCopyHEX_Click;
            btnCopyDecimal.Click += btnCopyDecimal_Click;

            UpdateColor();
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            isUpdating = true;

            if (ModeXYZ)
            {
                numR.Value = (decimal)(trackBarR.Value / 100.0);
                numG.Value = (decimal)(trackBarG.Value / 100.0);
                numB.Value = (decimal)(trackBarB.Value / 100.0);
                numA.Value = (decimal)(trackBarA.Value / 100.0);
            }
            else
            {
                numR.Value = trackBarR.Value;
                numG.Value = trackBarG.Value;
                numB.Value = trackBarB.Value;
                numA.Value = trackBarA.Value;
            }

            isUpdating = false;
            UpdateColor();
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            isUpdating = true;

            if (ModeXYZ)
            {
                trackBarR.Value = (int)(numR.Value * 100);
                trackBarG.Value = (int)(numG.Value * 100);
                trackBarB.Value = (int)(numB.Value * 100);
                trackBarA.Value = (int)(numA.Value * 100);
            }
            else
            {
                trackBarR.Value = (int)numR.Value;
                trackBarG.Value = (int)numG.Value;
                trackBarB.Value = (int)numB.Value;
                trackBarA.Value = (int)numA.Value;
            }

            isUpdating = false;
            UpdateColor();
        }

        private void UpdateColor()
        {
            if (isUpdating) return;
            isUpdating = true;

            if (ModeXYZ)
            {
                int r = (int)(numR.Value * 255);
                int g = (int)(numG.Value * 255);
                int b = (int)(numB.Value * 255);
                int a = (int)(numA.Value * 255);
                panelColor.BackColor = Color.FromArgb(a, r, g, b);
            }
            else
            {
                int r = trackBarR.Value;
                int g = trackBarG.Value;
                int b = trackBarB.Value;
                int a = trackBarA.Value;

                panelColor.BackColor = Color.FromArgb(a, r, g, b);

                string hex = $"{r:X2}{g:X2}{b:X2}{a:X2}";
                txtHEXFormat.Text = hex;

                uint decimalValue = (uint)((r << 24) | (g << 16) | (b << 8) | a);
                txtDecimalFormat.Text = decimalValue.ToString();
            }

            isUpdating = false;
        }

        private void TxtHEXFormat_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating || ModeXYZ) return;

            string hex = txtHEXFormat.Text.Trim().Replace("#", "");
            if (hex.Length != 8) return;

            try
            {
                isUpdating = true;
                int r = int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                int g = int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                int b = int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                int a = int.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);

                trackBarR.Value = r; numR.Value = r;
                trackBarG.Value = g; numG.Value = g;
                trackBarB.Value = b; numB.Value = b;
                trackBarA.Value = a; numA.Value = a;

                uint decimalValue = (uint)((r << 24) | (g << 16) | (b << 8) | a);
                txtDecimalFormat.Text = decimalValue.ToString();

                panelColor.BackColor = Color.FromArgb(a, r, g, b);
            }
            catch { }
            finally { isUpdating = false; }
        }

        private void TxtDecimalFormat_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating || ModeXYZ) return;

            try
            {
                if (!uint.TryParse(txtDecimalFormat.Text.Trim(), out uint decValue))
                    return;

                isUpdating = true;

                int r = (int)((decValue >> 24) & 0xFF);
                int g = (int)((decValue >> 16) & 0xFF);
                int b = (int)((decValue >> 8) & 0xFF);
                int a = (int)(decValue & 0xFF);

                trackBarR.Value = r; numR.Value = r;
                trackBarG.Value = g; numG.Value = g;
                trackBarB.Value = b; numB.Value = b;
                trackBarA.Value = a; numA.Value = a;

                string hex = $"{r:X2}{g:X2}{b:X2}{a:X2}";
                txtHEXFormat.Text = hex;

                panelColor.BackColor = Color.FromArgb(a, r, g, b);
            }
            catch { }
            finally { isUpdating = false; }
        }

        private void panelColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = panelColor.BackColor;
                dlg.FullOpen = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    isUpdating = true;
                    Color selected = dlg.Color;

                    if (ModeXYZ)
                    {
                        if (numA.Value == 0)
                            selected = Color.FromArgb(255, selected.R, selected.G, selected.B);
                        else
                            selected = Color.FromArgb((int)(numA.Value * 255), selected.R, selected.G, selected.B);

                        numR.Value = Math.Round((decimal)(selected.R / 255.0), 2);
                        numG.Value = Math.Round((decimal)(selected.G / 255.0), 2);
                        numB.Value = Math.Round((decimal)(selected.B / 255.0), 2);
                        numA.Value = Math.Round((decimal)(selected.A / 255.0), 2);
                        trackBarR.Value = (int)(numR.Value * 100);
                        trackBarG.Value = (int)(numG.Value * 100);
                        trackBarB.Value = (int)(numB.Value * 100);
                        trackBarA.Value = (int)(numA.Value * 100);
                    }
                    else if (ModeRGB)
                    {
                        if (numA.Value == 0)
                            selected = Color.FromArgb(255, selected.R, selected.G, selected.B);
                        else
                            selected = Color.FromArgb((int)numA.Value, selected.R, selected.G, selected.B);

                        numR.Value = selected.R;
                        numG.Value = selected.G;
                        numB.Value = selected.B;
                        numA.Value = selected.A;
                        trackBarR.Value = selected.R;
                        trackBarG.Value = selected.G;
                        trackBarB.Value = selected.B;
                        trackBarA.Value = selected.A;

                        string hex = $"{selected.R:X2}{selected.G:X2}{selected.B:X2}{selected.A:X2}";
                        txtHEXFormat.Text = hex;

                        uint decimalValue = (uint)((selected.R << 24) | (selected.G << 16) | (selected.B << 8) | selected.A);
                        txtDecimalFormat.Text = decimalValue.ToString();
                    }

                    // End
                    panelColor.BackColor = selected;
                    isUpdating = false;
                }
            }
        }

        private void btnSwapMode_Click(object sender, EventArgs e)
        {
            ModeRGB = !ModeRGB;
            ModeXYZ = !ModeXYZ;

            var oldCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            isUpdating = true;

            if (ModeXYZ)
            {
                btnSwapMode.Text = "Swap to RGB";
                lblR.Text = "X"; lblG.Text = "Y"; lblB.Text = "Z"; lblA.Text = "W";

                foreach (var n in new[] { numR, numG, numB, numA })
                {
                    n.Minimum = decimal.MinValue;
                    n.Maximum = decimal.MaxValue;
                }

                numR.Value = Math.Round(numR.Value / 255.0M, 2);
                numG.Value = Math.Round(numG.Value / 255.0M, 2);
                numB.Value = Math.Round(numB.Value / 255.0M, 2);
                numA.Value = Math.Round(numA.Value / 255.0M, 2);

                SetNumericModeXYZ(true);
                SetTrackBarModeXYZ(true);

                labelHEX.Visible = false;
                txtHEXFormat.Visible = false;
                btnCopyHEX.Visible = false;
                labelDecimal.Visible = false;
                txtDecimalFormat.Visible = false;
                btnCopyDecimal.Visible = false;
            }
            else
            {
                btnSwapMode.Text = "Swap to XYZ";
                lblR.Text = "R"; lblG.Text = "G"; lblB.Text = "B"; lblA.Text = "A";

                foreach (var n in new[] { numR, numG, numB, numA })
                {
                    n.Minimum = decimal.MinValue;
                    n.Maximum = decimal.MaxValue;
                }

                numR.Value = Math.Round(numR.Value * 255.0M, 0);
                numG.Value = Math.Round(numG.Value * 255.0M, 0);
                numB.Value = Math.Round(numB.Value * 255.0M, 0);
                numA.Value = Math.Round(numA.Value * 255.0M, 0);

                SetNumericModeXYZ(false);
                SetTrackBarModeXYZ(false);

                labelHEX.Visible = true;
                txtHEXFormat.Visible = true;
                btnCopyHEX.Visible = true;
                labelDecimal.Visible = true;
                txtDecimalFormat.Visible = true;
                btnCopyDecimal.Visible = true;
            }

            isUpdating = false;
            UpdateColor();

            Thread.CurrentThread.CurrentCulture = oldCulture;
        }

        private void SetNumericModeXYZ(bool isXYZ)
        {
            if (isXYZ)
            {
                foreach (var n in new[] { numR, numG, numB, numA })
                {
                    n.DecimalPlaces = 2;
                    n.Increment = 0.01M;
                    n.Minimum = 0.00M;
                    n.Maximum = 1.00M;
                }
            }
            else
            {
                foreach (var n in new[] { numR, numG, numB, numA })
                {
                    n.DecimalPlaces = 0;
                    n.Increment = 1;
                    n.Minimum = 0;
                    n.Maximum = 255;
                }
            }
        }

        private void SetTrackBarModeXYZ(bool isXYZ)
        {
            if (isXYZ)
            {
                trackBarR.Minimum = trackBarG.Minimum = trackBarB.Minimum = trackBarA.Minimum = 0;
                trackBarR.Maximum = trackBarG.Maximum = trackBarB.Maximum = trackBarA.Maximum = 100;
                trackBarR.TickFrequency = trackBarG.TickFrequency = trackBarB.TickFrequency = trackBarA.TickFrequency = 10;

                trackBarR.Value = (int)(numR.Value * 100);
                trackBarG.Value = (int)(numG.Value * 100);
                trackBarB.Value = (int)(numB.Value * 100);
                trackBarA.Value = (int)(numA.Value * 100);
            }
            else
            {
                trackBarR.Minimum = trackBarG.Minimum = trackBarB.Minimum = trackBarA.Minimum = 0;
                trackBarR.Maximum = trackBarG.Maximum = trackBarB.Maximum = trackBarA.Maximum = 255;
                trackBarR.TickFrequency = trackBarG.TickFrequency = trackBarB.TickFrequency = trackBarA.TickFrequency = 32;

                trackBarR.Value = (int)numR.Value;
                trackBarG.Value = (int)numG.Value;
                trackBarB.Value = (int)numB.Value;
                trackBarA.Value = (int)numA.Value;
            }
        }

        private void btnCopyHEX_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHEXFormat.Text))
                Clipboard.SetText(txtHEXFormat.Text);
        }

        private void btnCopyDecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDecimalFormat.Text))
                Clipboard.SetText(txtDecimalFormat.Text);
        }
    }
}
