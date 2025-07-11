using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンスを生成
        Settings settings = new Settings();


        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        // 記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            // 既に登録済みか確認
            if (!cbAuthor.Items.Contains(author)) {
                // 未登録なら登録
                cbAuthor.Items.Add(author);
            }
        }

        // 車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            // 既に登録済みか確認
            if (!cbCarName.Items.Contains(carName)) {
                // 未登録なら登録
                cbCarName.Items.Add(carName);
            }
        }



        private void btRecordAdd_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
            setCbAuthor(cbAuthor.Text);    //コンボボックスへ登録
            setCbCarName(cbCarName.Text);
            InputItemsAllClear(); //登録後は項目をクリア
        }
        //入力項目すべてクリア
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private CarReport.MakerGroup getRadioButtonMaker() {
            if (rbTOYOTA.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNISAN.Checked)
                return CarReport.MakerGroup.日産;
            if (rbSUBARU.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbHONDA.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;

            return CarReport.MakerGroup.その他;
        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            //if (dgvRecord.CurrentRow is null) return;

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
        }

        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbTOYOTA.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNISAN.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHONDA.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSUBARU.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;

            }
        }

        //新規追加のイベントハンドラ
        private void btNewRecord_Click(object sender, EventArgs e) {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        //修正のイベントハンドラ
        private void btRecordModify_Click(object sender, EventArgs e) {
            int index = dgvRecord.CurrentRow.Index;
            listCarReports[index].Author = cbAuthor.Text;
            listCarReports[index].Maker = getRadioButtonMaker();
            listCarReports[index].CarName = cbCarName.Text;
            listCarReports[index].Report = tbReport.Text;
            listCarReports[index].Picture = pbPicture.Image;
            dgvRecord.Refresh();　　//データグリッドビューの更新
        }

        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //if (dgvRecord.CurrentRow is null) return;
            //listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
            //選択されているインデックスを取得
            int index = dgvRecord.CurrentRow.Index;
            //削除したいインデックスを指定してリストから削除
            listCarReports.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //交互に色を設定（データグリッドビュー）
            dgvRecord.DefaultCellStyle.BackColor = Color.LightBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.Pink;

            //設定ファイルを読み込み背景色を設定する(逆シリアル化)
            //P284以降を参考にする(ファイル名:setting.xml)

            //var serializer = new XmlSerializer(typeof(Settings));
            //if (File.Exists("settings.xml")) {
            //    using (var reader = new StreamReader("settings.xml")) {
            //        settings = (Settings)serializer.Deserialize(reader);
            //        BackColor = Color.FromArgb(settings.MainFormBackColor);
            //    }
            //}
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var set = serializer.Deserialize(reader) as Settings;
                        //背景色設定
                        BackColor = Color.FromArgb(set.MainFormBackColor);
                        //設定クラスのインスタンスにも現在の設定色を設定
                        //settings.MainFormBackColor = BackColor.ToArgb();
                        settings = set;
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);//より具体的なエラーを出力
                }
            }
         }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.Show();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //設定ファイルへ保存
                settings.MainFormBackColor = cdColor.Color.ToArgb();//背景色を設定


            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportfileopen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                        ofdReportfileopen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        //コンボボックスに登録
                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル形式が違います";
                    MessageBox.Show(ex.Message);//より具体的なエラーを出力
                }
            }
        }
        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);//より具体的なエラーを出力
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();//ファイルセーブ処理
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();//ファイルオープン処理
        }

        //フォームが閉じたら呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {


            //設定ファイルへ色情報を保存する処理（シリアル化)

            //using (var writer = new StreamWriter("settings.xml")) {
            //    var serializer = new XmlSerializer(typeof(Settings));
            //    serializer.Serialize(writer, settings);
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "ファイル書き出しエラー";
                MessageBox.Show(ex.Message);

            }
        }
    }
}
