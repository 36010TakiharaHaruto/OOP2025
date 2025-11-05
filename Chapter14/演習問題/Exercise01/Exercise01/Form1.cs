using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e) {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "走れメロス.txt");
            if (!File.Exists(filePath)) {
                MessageBox.Show("ファイルが見つかりません。");
                return;
            }
            try {
                toolStripStatusLabel1.Text = "読み込み開始";
                listBox1.Items.Clear();

                using (var reader = new StreamReader(filePath)) {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null) {
                        listBox1.Items.Add(line);
                        toolStripStatusLabel1.Text = $"読み込み中: {listBox1.Items.Count} 行";
                        Application.DoEvents();
                    }
                }
                toolStripStatusLabel1.Text = "読み込み完了";
            }
            catch (Exception ex) {
                toolStripStatusLabel1.Text = "エラー";
                MessageBox.Show($"エラー: {ex.Message}");
            }
        }
    }
}
