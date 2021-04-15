namespace SPTournament
{
    partial class Form_team
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_team = new System.Windows.Forms.TextBox();
            this.bt_prev = new System.Windows.Forms.Button();
            this.bt_next = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_team
            // 
            this.tb_team.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_team.Location = new System.Drawing.Point(40, 51);
            this.tb_team.Name = "tb_team";
            this.tb_team.Size = new System.Drawing.Size(273, 35);
            this.tb_team.TabIndex = 0;
            this.tb_team.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_team_KeyDown);
            // 
            // bt_prev
            // 
            this.bt_prev.Location = new System.Drawing.Point(40, 113);
            this.bt_prev.Name = "bt_prev";
            this.bt_prev.Size = new System.Drawing.Size(75, 23);
            this.bt_prev.TabIndex = 1;
            this.bt_prev.Text = "<< PREV";
            this.bt_prev.UseVisualStyleBackColor = true;
            this.bt_prev.Click += new System.EventHandler(this.bt_prev_Click);
            // 
            // bt_next
            // 
            this.bt_next.Location = new System.Drawing.Point(238, 113);
            this.bt_next.Name = "bt_next";
            this.bt_next.Size = new System.Drawing.Size(75, 23);
            this.bt_next.TabIndex = 1;
            this.bt_next.Text = "NEXT >>";
            this.bt_next.UseVisualStyleBackColor = true;
            this.bt_next.Click += new System.EventHandler(this.bt_next_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(139, 113);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 1;
            this.bt_ok.Text = "OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "추가할 팀을 입력해주세요.";
            // 
            // Form_team
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_next);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.bt_prev);
            this.Controls.Add(this.tb_team);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_team";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Team Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_team;
        private System.Windows.Forms.Button bt_prev;
        private System.Windows.Forms.Button bt_next;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label label1;
    }
}