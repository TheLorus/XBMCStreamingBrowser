﻿namespace XBMCStreamingBrowser
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
            this.HosterBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MirrorBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BoxSeason = new System.Windows.Forms.ComboBox();
            this.BoxEpisode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // HosterBox
            // 
            this.HosterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HosterBox.FormattingEnabled = true;
            this.HosterBox.Location = new System.Drawing.Point(15, 68);
            this.HosterBox.Name = "HosterBox";
            this.HosterBox.Size = new System.Drawing.Size(121, 21);
            this.HosterBox.TabIndex = 0;
            this.HosterBox.SelectedIndexChanged += new System.EventHandler(this.HosterBox_SelectedIndexChanged);
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
            // MirrorBox
            // 
            this.MirrorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MirrorBox.FormattingEnabled = true;
            this.MirrorBox.Location = new System.Drawing.Point(154, 68);
            this.MirrorBox.Name = "MirrorBox";
            this.MirrorBox.Size = new System.Drawing.Size(121, 21);
            this.MirrorBox.TabIndex = 2;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Season";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(151, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Episode";
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
            // 
            // StreamInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 108);
            this.Controls.Add(this.BoxEpisode);
            this.Controls.Add(this.BoxSeason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MirrorBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HosterBox);
            this.Name = "StreamInfo";
            this.Text = "StreamInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox HosterBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MirrorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BoxSeason;
        private System.Windows.Forms.ComboBox BoxEpisode;
    }
}