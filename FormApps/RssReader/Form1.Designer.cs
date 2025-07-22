namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btMove = new Button();
            btReturn = new Button();
            tbFavorite = new TextBox();
            btRegistration = new Button();
            label1 = new Label();
            cbUrl = new ComboBox();
            btDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(735, 12);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(76, 35);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click_1;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 116);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(990, 256);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 378);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(990, 259);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            // 
            // btMove
            // 
            btMove.Location = new Point(126, 14);
            btMove.Name = "btMove";
            btMove.Size = new Size(86, 36);
            btMove.TabIndex = 4;
            btMove.Text = "進む";
            btMove.UseVisualStyleBackColor = true;
            btMove.Click += btMove_Click;
            // 
            // btReturn
            // 
            btReturn.Location = new Point(12, 15);
            btReturn.Name = "btReturn";
            btReturn.Size = new Size(90, 35);
            btReturn.TabIndex = 5;
            btReturn.Text = "戻る";
            btReturn.UseVisualStyleBackColor = true;
            btReturn.Click += btReturn_Click;
            // 
            // tbFavorite
            // 
            tbFavorite.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbFavorite.Location = new Point(127, 65);
            tbFavorite.Name = "tbFavorite";
            tbFavorite.Size = new Size(457, 35);
            tbFavorite.TabIndex = 6;
            // 
            // btRegistration
            // 
            btRegistration.Location = new Point(599, 65);
            btRegistration.Name = "btRegistration";
            btRegistration.Size = new Size(86, 35);
            btRegistration.TabIndex = 7;
            btRegistration.Text = "登録";
            btRegistration.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 80);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 8;
            label1.Text = "お気に入り登録";
            // 
            // cbUrl
            // 
            cbUrl.FormattingEnabled = true;
            cbUrl.Location = new Point(291, 15);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(431, 23);
            cbUrl.TabIndex = 9;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(706, 65);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(86, 35);
            btDelete.TabIndex = 11;
            btDelete.Text = "削除";
            btDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 763);
            Controls.Add(btDelete);
            Controls.Add(cbUrl);
            Controls.Add(label1);
            Controls.Add(btRegistration);
            Controls.Add(tbFavorite);
            Controls.Add(btReturn);
            Controls.Add(btMove);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btMove;
        private Button btReturn;
        private TextBox tbFavorite;
        private Button btRegistration;
        private Label label1;
        private ComboBox cbUrl;
        private Button btDelete;
    }
}
