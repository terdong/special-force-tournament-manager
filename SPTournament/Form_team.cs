using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPTournament
{
    public partial class Form_team : Form
    {
        private int tabIdx;
        private SplitContainer sc;

        public Form_team(int tabIdx, ref SplitContainer sc)
        {
            InitializeComponent();
            this.tabIdx = tabIdx;
            this.sc = sc;
            this.label1.Text = setText(tabIdx+1);
        }

        private String setText(int tabIdx)
        {
            return tabIdx + "번째 팀명을 입력해주세요.";
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            setTeamName();
            DialogResult = DialogResult.Yes;
        }
        private void setTeamName()
        {
            setButtonText(tabIdx, tb_team.Text);
            tb_team.Text = "";
            tb_team.Focus();
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            if (tabIdx < 16)
            {
                setTeamName();
                tabIdx++;
                if (tabIdx >= 16)
                    tabIdx = 15;
            }
            this.label1.Text = setText(tabIdx+1);
            Console.WriteLine(tabIdx);
        }

        private void bt_prev_Click(object sender, EventArgs e)
        {
            if (tabIdx > 0)
            {
                setTeamName();
                tabIdx--;
            }
            this.label1.Text = setText(tabIdx+1);
            Console.WriteLine(tabIdx);
        }
        public void setButtonText(int tabIdx, String str)
        {
            for(int i=0; i<sc.Panel1.Controls.Count; i++)
                if(sc.Panel1.Controls[i].GetType().Name.Equals("Button")
                    && sc.Panel1.Controls[i].TabIndex.Equals(tabIdx) && tabIdx < 16)
                {
                    sc.Panel1.Controls[i].Text = str;
                }
        }

        private void tb_team_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) && tabIdx < 16)
            {
                setTeamName();
                tabIdx++;
            }
            else if(e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

    }
}
