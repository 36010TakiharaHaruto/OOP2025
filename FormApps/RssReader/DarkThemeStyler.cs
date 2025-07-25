using System.Drawing;
using System.Windows.Forms;

public static class DarkThemeStyler {
    public static void ApplyDarkTheme(Form form) {
        form.BackColor = Color.FromArgb(30, 30, 30);
        form.ForeColor = Color.White;
        form.Font = new Font("Segoe UI", 10);

        foreach (Control ctrl in form.Controls) {
            StyleControl(ctrl);
        }
    }

    private static void StyleControl(Control ctrl) {
        if (ctrl is Button btn) {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.BackColor = Color.FromArgb(50, 50, 50);
            btn.ForeColor = Color.White;

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(70, 70, 70);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(50, 50, 50);
        } else if (ctrl is ComboBox cb) {
            cb.FlatStyle = FlatStyle.Flat;
            cb.BackColor = Color.FromArgb(45, 45, 45);
            cb.ForeColor = Color.White;
        } else if (ctrl is ListBox lb) {
            lb.BackColor = Color.FromArgb(20, 20, 20);
            lb.ForeColor = Color.White;
            lb.BorderStyle = BorderStyle.None;
        }

        // 子コントロールがあれば再帰的に処理
        if (ctrl.HasChildren) {
            foreach (Control child in ctrl.Controls) {
                StyleControl(child);
            }
        }
    }
}
