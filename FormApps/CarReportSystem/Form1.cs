using System.ComponentModel;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

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
            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
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

        private CarReport.MakerGroup GetRadioButtonMaker() {
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

        }

        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {

        }
    }
}
