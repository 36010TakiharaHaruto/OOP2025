using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X�𐶐�
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

        // �L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbAuthor(string author) {
            // ���ɓo�^�ς݂��m�F
            if (!cbAuthor.Items.Contains(author)) {
                // ���o�^�Ȃ�o�^
                cbAuthor.Items.Add(author);
            }
        }

        // �Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbCarName(string carName) {
            // ���ɓo�^�ς݂��m�F
            if (!cbCarName.Items.Contains(carName)) {
                // ���o�^�Ȃ�o�^
                cbCarName.Items.Add(carName);
            }
        }



        private void btRecordAdd_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
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
            setCbAuthor(cbAuthor.Text);    //�R���{�{�b�N�X�֓o�^
            setCbCarName(cbCarName.Text);
            InputItemsAllClear(); //�o�^��͍��ڂ��N���A
        }
        //���͍��ڂ��ׂăN���A
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
                return CarReport.MakerGroup.�g���^;
            if (rbNISAN.Checked)
                return CarReport.MakerGroup.���Y;
            if (rbSUBARU.Checked)
                return CarReport.MakerGroup.�X�o��;
            if (rbHONDA.Checked)
                return CarReport.MakerGroup.�z���_;
            if (rbImport.Checked)
                return CarReport.MakerGroup.�A����;

            return CarReport.MakerGroup.���̑�;
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

        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.�g���^:
                    rbTOYOTA.Checked = true;
                    break;
                case MakerGroup.���Y:
                    rbNISAN.Checked = true;
                    break;
                case MakerGroup.�z���_:
                    rbHONDA.Checked = true;
                    break;
                case MakerGroup.�X�o��:
                    rbSUBARU.Checked = true;
                    break;
                case MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;

            }
        }

        //�V�K�ǉ��̃C�x���g�n���h��
        private void btNewRecord_Click(object sender, EventArgs e) {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        //�C���̃C�x���g�n���h��
        private void btRecordModify_Click(object sender, EventArgs e) {
            int index = dgvRecord.CurrentRow.Index;
            listCarReports[index].Author = cbAuthor.Text;
            listCarReports[index].Maker = getRadioButtonMaker();
            listCarReports[index].CarName = cbCarName.Text;
            listCarReports[index].Report = tbReport.Text;
            listCarReports[index].Picture = pbPicture.Image;
            dgvRecord.Refresh();�@�@//�f�[�^�O���b�h�r���[�̍X�V
        }

        //�폜�{�^���̃C�x���g�n���h��
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //if (dgvRecord.CurrentRow is null) return;
            //listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
            //�I������Ă���C���f�b�N�X���擾
            int index = dgvRecord.CurrentRow.Index;
            //�폜�������C���f�b�N�X���w�肵�ă��X�g����폜
            listCarReports.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //���݂ɐF��ݒ�i�f�[�^�O���b�h�r���[�j
            dgvRecord.DefaultCellStyle.BackColor = Color.LightBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.Pink;

            //�ݒ�t�@�C����ǂݍ��ݔw�i�F��ݒ肷��(�t�V���A����)
            //P284�ȍ~���Q�l�ɂ���(�t�@�C����:setting.xml)

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
                        //�w�i�F�ݒ�
                        BackColor = Color.FromArgb(set.MainFormBackColor);
                        //�ݒ�N���X�̃C���X�^���X�ɂ����݂̐ݒ�F��ݒ�
                        //settings.MainFormBackColor = BackColor.ToArgb();
                        settings = set;
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C���ǂݍ��݃G���[";
                    MessageBox.Show(ex.Message);//����̓I�ȃG���[���o��
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

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cdColor.Color.ToArgb();//�w�i�F��ݒ�


            }
        }

        //�t�@�C���I�[�v������
        private void reportOpenFile() {
            if (ofdReportfileopen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(
                        ofdReportfileopen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        //�R���{�{�b�N�X�ɓo�^
                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                    MessageBox.Show(ex.Message);//����̓I�ȃG���[���o��
                }
            }
        }
        //�t�@�C���Z�[�u����
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message);//����̓I�ȃG���[���o��
                }
            }
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();//�t�@�C���Z�[�u����
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();//�t�@�C���I�[�v������
        }

        //�t�H�[����������Ă΂��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {


            //�ݒ�t�@�C���֐F����ۑ����鏈���i�V���A����)

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
                tsslbMessage.Text = "�t�@�C�������o���G���[";
                MessageBox.Show(ex.Message);

            }
        }
    }
}
