using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace NFSColorRX
{
    public class ToolOptions
    {
        private readonly Form form;
        private readonly ContextMenuStrip menu;
        private ToolStripMenuItem themeItem;

        private bool DarkThemeActive = true;

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTSYSMENU = 3;

        private readonly string configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"FiLixsi", "NFS-Color-Picker");
        private readonly string configFile;

        public ToolOptions(Form targetForm)
        {
            form = targetForm ?? throw new ArgumentNullException(nameof(targetForm));
            form.HandleCreated += Form_HandleCreated;

            configFile = Path.Combine(configFolder, "settings.json");

            LoadConfig();

            menu = new ContextMenuStrip();
            themeItem = new ToolStripMenuItem(DarkThemeActive ? "Light Theme" : "Dark Theme");
            themeItem.Click += ThemeItem_Click;
            menu.Items.Add(themeItem);

            form.Load += (s, e) =>
            {
                if (DarkThemeActive)
                    ApplyDarkTheme();
                else
                    ApplyLightTheme();
            };
        }

        private void Form_HandleCreated(object sender, EventArgs e)
        {
            var hook = new NativeWindowHook(form, ShowMenuOnSysIcon);
        }

        private void ShowMenuOnSysIcon()
        {
            menu.Show(Cursor.Position);
        }

        private void ThemeItem_Click(object sender, EventArgs e)
        {
            if (DarkThemeActive)
            {
                ApplyLightTheme();
                DarkThemeActive = false;
                themeItem.Text = "Dark Theme";
            }
            else
            {
                ApplyDarkTheme();
                DarkThemeActive = true;
                themeItem.Text = "Light Theme";
            }

            SaveConfig();
        }

        private void ApplyLightTheme()
        {
            form.BackColor = SystemColors.Control;
            ApplyThemeToControls(form.Controls, SystemColors.Control, SystemColors.ControlText);
        }

        private void ApplyDarkTheme()
        {
            Color darkBack = Color.FromArgb(45, 45, 48);
            Color darkFore = Color.White;
            form.BackColor = darkBack;
            ApplyThemeToControls(form.Controls, darkBack, darkFore);
        }
        private void ApplyThemeToControls(Control.ControlCollection controls, Color back, Color fore)
        {
            foreach (Control c in controls)
            {
                if (c == form.Controls["panelColor"])
                    continue;

                if (c is Panel || c is Label || c is Button)
                {
                    c.BackColor = back;
                    c.ForeColor = fore;
                }
                else if (c is TextBox || c is NumericUpDown || c is TrackBar)
                {
                    c.BackColor = back;
                    c.ForeColor = fore;
                }

                if (c.HasChildren)
                    ApplyThemeToControls(c.Controls, back, fore);
            }
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(configFile))
                {
                    string json = File.ReadAllText(configFile);
                    var cfg = JsonSerializer.Deserialize<AppConfig>(json);
                    DarkThemeActive = cfg?.DarkTheme ?? true;
                }
                else
                {
                    DarkThemeActive = true;
                }
            }
            catch
            {
                DarkThemeActive = true;
            }
        }

        private void SaveConfig()
        {
            try
            {
                if (!Directory.Exists(configFolder))
                    Directory.CreateDirectory(configFolder);

                var cfg = new AppConfig { DarkTheme = DarkThemeActive };
                string json = JsonSerializer.Serialize(cfg, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configFile, json);
            }
            catch { }
        }

        private class AppConfig
        {
            public bool DarkTheme { get; set; }
        }

        private class NativeWindowHook : NativeWindow
        {
            private readonly Action onSysIconClick;
            private const int WM_NCLBUTTONDOWN = 0x00A1;
            private const int HTSYSMENU = 3;

            public NativeWindowHook(Form f, Action callback)
            {
                onSysIconClick = callback;
                AssignHandle(f.Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_NCLBUTTONDOWN && (int)m.WParam == HTSYSMENU)
                {
                    onSysIconClick?.Invoke();
                    return;
                }
                base.WndProc(ref m);
            }
        }
    }
}
