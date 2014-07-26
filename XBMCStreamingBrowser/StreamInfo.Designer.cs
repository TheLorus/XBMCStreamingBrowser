namespace XBMCStreamingBrowser
{
    partial class StreamInfo
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.BoxHoster = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BoxMirror = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelSeason = new System.Windows.Forms.Label();
            this.LabelEpisode = new System.Windows.Forms.Label();
            this.BoxSeason = new System.Windows.Forms.ComboBox();
            this.BoxEpisode = new System.Windows.Forms.ComboBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.LabelPart = new System.Windows.Forms.Label();
            this.BoxPart = new System.Windows.Forms.ComboBox();
            this.LabelHosterLink = new System.Windows.Forms.Label();
            this.LabelPlay = new System.Windows.Forms.Label();
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoxHoster
            // 
            this.BoxHoster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxHoster.FormattingEnabled = true;
            this.BoxHoster.Location = new System.Drawing.Point(15, 68);
            this.BoxHoster.Name = "BoxHoster";
            this.BoxHoster.Size = new System.Drawing.Size(121, 21);
            this.BoxHoster.TabIndex = 0;
            this.BoxHoster.SelectedIndexChanged += new System.EventHandler(this.HosterBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoster";
            // 
            // BoxMirror
            // 
            this.BoxMirror.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxMirror.FormattingEnabled = true;
            this.BoxMirror.Location = new System.Drawing.Point(154, 68);
            this.BoxMirror.Name = "BoxMirror";
            this.BoxMirror.Size = new System.Drawing.Size(121, 21);
            this.BoxMirror.TabIndex = 2;
            this.BoxMirror.SelectedIndexChanged += new System.EventHandler(this.BoxMirror_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mirror";
            // 
            // LabelSeason
            // 
            this.LabelSeason.AutoSize = true;
            this.LabelSeason.Enabled = false;
            this.LabelSeason.Location = new System.Drawing.Point(15, 9);
            this.LabelSeason.Name = "LabelSeason";
            this.LabelSeason.Size = new System.Drawing.Size(43, 13);
            this.LabelSeason.TabIndex = 4;
            this.LabelSeason.Text = "Season";
            // 
            // LabelEpisode
            // 
            this.LabelEpisode.AutoSize = true;
            this.LabelEpisode.Enabled = false;
            this.LabelEpisode.Location = new System.Drawing.Point(151, 9);
            this.LabelEpisode.Name = "LabelEpisode";
            this.LabelEpisode.Size = new System.Drawing.Size(45, 13);
            this.LabelEpisode.TabIndex = 5;
            this.LabelEpisode.Text = "Episode";
            // 
            // BoxSeason
            // 
            this.BoxSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxSeason.Enabled = false;
            this.BoxSeason.FormattingEnabled = true;
            this.BoxSeason.Location = new System.Drawing.Point(15, 25);
            this.BoxSeason.Name = "BoxSeason";
            this.BoxSeason.Size = new System.Drawing.Size(115, 21);
            this.BoxSeason.TabIndex = 6;
            this.BoxSeason.SelectedIndexChanged += new System.EventHandler(this.BoxSeason_SelectedIndexChanged);
            // 
            // BoxEpisode
            // 
            this.BoxEpisode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxEpisode.Enabled = false;
            this.BoxEpisode.FormattingEnabled = true;
            this.BoxEpisode.Location = new System.Drawing.Point(154, 25);
            this.BoxEpisode.Name = "BoxEpisode";
            this.BoxEpisode.Size = new System.Drawing.Size(121, 21);
            this.BoxEpisode.TabIndex = 7;
            this.BoxEpisode.SelectedIndexChanged += new System.EventHandler(this.BoxEpisode_SelectedIndexChanged);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(12, 197);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 8;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // LabelPart
            // 
            this.LabelPart.AutoSize = true;
            this.LabelPart.Enabled = false;
            this.LabelPart.Location = new System.Drawing.Point(15, 97);
            this.LabelPart.Name = "LabelPart";
            this.LabelPart.Size = new System.Drawing.Size(26, 13);
            this.LabelPart.TabIndex = 10;
            this.LabelPart.Text = "Part";
            // 
            // BoxPart
            // 
            this.BoxPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxPart.Enabled = false;
            this.BoxPart.FormattingEnabled = true;
            this.BoxPart.Location = new System.Drawing.Point(15, 113);
            this.BoxPart.Name = "BoxPart";
            this.BoxPart.Size = new System.Drawing.Size(121, 21);
            this.BoxPart.TabIndex = 9;
            this.BoxPart.SelectedIndexChanged += new System.EventHandler(this.BoxPart_SelectedIndexChanged);
            // 
            // LabelHosterLink
            // 
            this.LabelHosterLink.AutoSize = true;
            this.LabelHosterLink.Location = new System.Drawing.Point(18, 146);
            this.LabelHosterLink.Name = "LabelHosterLink";
            this.LabelHosterLink.Size = new System.Drawing.Size(35, 13);
            this.LabelHosterLink.TabIndex = 11;
            this.LabelHosterLink.Text = "label3";
            // 
            // LabelPlay
            // 
            this.LabelPlay.AutoSize = true;
            this.LabelPlay.Location = new System.Drawing.Point(18, 169);
            this.LabelPlay.Name = "LabelPlay";
            this.LabelPlay.Size = new System.Drawing.Size(35, 13);
            this.LabelPlay.TabIndex = 12;
            this.LabelPlay.Text = "label3";
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.Location = new System.Drawing.Point(93, 197);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(75, 23);
            this.ButtonPlay.TabIndex = 13;
            this.ButtonPlay.Text = "Play";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // StreamInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 310);
            this.Controls.Add(this.ButtonPlay);
            this.Controls.Add(this.LabelPlay);
            this.Controls.Add(this.LabelHosterLink);
            this.Controls.Add(this.LabelPart);
            this.Controls.Add(this.BoxPart);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.BoxEpisode);
            this.Controls.Add(this.BoxSeason);
            this.Controls.Add(this.LabelEpisode);
            this.Controls.Add(this.LabelSeason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxMirror);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxHoster);
            this.Name = "StreamInfo";
            this.Text = "StreamInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BoxHoster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BoxMirror;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelSeason;
        private System.Windows.Forms.Label LabelEpisode;
        private System.Windows.Forms.ComboBox BoxSeason;
        private System.Windows.Forms.ComboBox BoxEpisode;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Label LabelPart;
        private System.Windows.Forms.ComboBox BoxPart;
        private System.Windows.Forms.Label LabelHosterLink;
        private System.Windows.Forms.Label LabelPlay;
        private System.Windows.Forms.Button ButtonPlay;
    }
}