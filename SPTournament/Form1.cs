using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rsrc = SPTournament.Properties.Resources;
using SPTournament.src.com.tournament.console;
using SPTournament.src.com.tournament.log;
using SPTournament.src.com.tournament.bean;

namespace SPTournament
{
    public partial class Form1 : Form
    {
        //private static Image poolImage = Tournament.Properties.Resources.bg_bottom;
        private MsgLogboxImpl mlb;
        private Random rnd;
        private Button[] bt_select_map;
        private Dictionary<String, Label> dtsetMap = new Dictionary<string, Label>();
        private Dictionary<String, Button> dtTeam = new Dictionary<string, Button>();
        private Dictionary<String, Bitmap> dtBitmap = new Dictionary<String, Bitmap>();
        private List<beanTeam> al = new List<beanTeam>();
        private Boolean start;
        private Boolean map;
        private int flag;
        public Form1()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            //Tracing.SetupDebugConsole();
            al.Clear();

            if (bt_select_map != null)
                foreach (Button b in bt_select_map)
                    b.Dispose();
            bt_select_map = new Button[4];
            for (int i = 0; i < bt_select_map.Length; i++)
            {
                bt_select_map[i] = new Button();
                bt_select_map[i].Location = new System.Drawing.Point(66, 88+(i*96));
                bt_select_map[i].Name = "bt_select_map"+i;
                bt_select_map[i].Size = new System.Drawing.Size(130, 90);
                bt_select_map[i].TabIndex = 5;
                bt_select_map[i].Text = "";
                bt_select_map[i].UseVisualStyleBackColor = true;
                bt_select_map[i].Click += new System.EventHandler(this.bt_select_map_Click);
                this.splitContainer1.Panel2.Controls.Add(bt_select_map[i]);
            }
            
            if (dtsetMap.Count==0)
            {
                dtsetMap.Add(lb_round_1st_a_map_00.Name, lb_round_1st_a_map_00);
                dtsetMap.Add(lb_round_1st_a_map_01.Name, lb_round_1st_a_map_01);
                dtsetMap.Add(lb_round_1st_b_map_00.Name, lb_round_1st_b_map_00);
                dtsetMap.Add(lb_round_1st_b_map_01.Name, lb_round_1st_b_map_01);
                dtsetMap.Add(lb_round_1st_c_map_00.Name, lb_round_1st_c_map_00);
                dtsetMap.Add(lb_round_1st_c_map_01.Name, lb_round_1st_c_map_01);
                dtsetMap.Add(lb_round_1st_d_map_00.Name, lb_round_1st_d_map_00);
                dtsetMap.Add(lb_round_1st_d_map_01.Name, lb_round_1st_d_map_01);
                dtsetMap.Add(lb_round_1st_e_map_00.Name, lb_round_1st_e_map_00);
                dtsetMap.Add(lb_round_1st_e_map_01.Name, lb_round_1st_e_map_01);
                dtsetMap.Add(lb_round_1st_f_map_00.Name, lb_round_1st_f_map_00);
                dtsetMap.Add(lb_round_1st_f_map_01.Name, lb_round_1st_f_map_01);
                dtsetMap.Add(lb_round_1st_g_map_00.Name, lb_round_1st_g_map_00);
                dtsetMap.Add(lb_round_1st_g_map_01.Name, lb_round_1st_g_map_01);
                dtsetMap.Add(lb_round_1st_h_map_00.Name, lb_round_1st_h_map_00);
                dtsetMap.Add(lb_round_1st_h_map_01.Name, lb_round_1st_h_map_01);
                dtsetMap.Add(lb_round_2nd_a_map_00.Name, lb_round_2nd_a_map_00);
                dtsetMap.Add(lb_round_2nd_a_map_01.Name, lb_round_2nd_a_map_01);
                dtsetMap.Add(lb_round_2nd_b_map_00.Name, lb_round_2nd_b_map_00);
                dtsetMap.Add(lb_round_2nd_b_map_01.Name, lb_round_2nd_b_map_01);
                dtsetMap.Add(lb_round_2nd_c_map_00.Name, lb_round_2nd_c_map_00);
                dtsetMap.Add(lb_round_2nd_c_map_01.Name, lb_round_2nd_c_map_01);
                dtsetMap.Add(lb_round_2nd_d_map_00.Name, lb_round_2nd_d_map_00);
                dtsetMap.Add(lb_round_2nd_d_map_01.Name, lb_round_2nd_d_map_01);
                dtsetMap.Add(lb_round_3rd_a_map_00.Name, lb_round_3rd_a_map_00);
                dtsetMap.Add(lb_round_3rd_a_map_01.Name, lb_round_3rd_a_map_01);
                dtsetMap.Add(lb_round_3rd_b_map_00.Name, lb_round_3rd_b_map_00);
                dtsetMap.Add(lb_round_3rd_b_map_01.Name, lb_round_3rd_b_map_01);
                dtsetMap.Add(lb_round_final_a_map_00.Name, lb_round_final_a_map_00);
                dtsetMap.Add(lb_round_final_a_map_01.Name, lb_round_final_a_map_01);
                Console.WriteLine("dtsetMap");
            }

            foreach (KeyValuePair<String, Label> k in dtsetMap)
            {
                k.Value.Text = "";
                k.Value.BackColor = System.Drawing.Color.Orange;
            }

            if (dtTeam.Count == 0)
            {
                dtTeam.Add(bt_team_00.Name, bt_team_00);
                dtTeam.Add(bt_team_01.Name, bt_team_01);
                dtTeam.Add(bt_team_02.Name, bt_team_02);
                dtTeam.Add(bt_team_03.Name, bt_team_03);
                dtTeam.Add(bt_team_04.Name, bt_team_04);
                dtTeam.Add(bt_team_05.Name, bt_team_05);
                dtTeam.Add(bt_team_06.Name, bt_team_06);
                dtTeam.Add(bt_team_07.Name, bt_team_07);
                dtTeam.Add(bt_team_08.Name, bt_team_08);
                dtTeam.Add(bt_team_09.Name, bt_team_09);
                dtTeam.Add(bt_team_10.Name, bt_team_10);
                dtTeam.Add(bt_team_11.Name, bt_team_11);
                dtTeam.Add(bt_team_12.Name, bt_team_12);
                dtTeam.Add(bt_team_13.Name, bt_team_13);
                dtTeam.Add(bt_team_14.Name, bt_team_14);
                dtTeam.Add(bt_team_15.Name, bt_team_15);
            }
            int teamSet=0;
            foreach(KeyValuePair<String, Button> k in dtTeam)
            {
                if(teamSet<10)
                    k.Value.Text = "team0" + teamSet++;
                else
                    k.Value.Text = "team" + teamSet++;
                k.Value.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            
            if (dtBitmap == null)
            {
                dtBitmap.Add("map_bunker", SPTournament.Properties.Resources.map_bunker);
                dtBitmap.Add("map_crossroad", SPTournament.Properties.Resources.map_crossroad);
                dtBitmap.Add("map_decamp", SPTournament.Properties.Resources.map_decamp);
                dtBitmap.Add("map_gas", SPTournament.Properties.Resources.map_gas);
                dtBitmap.Add("map_harbor", SPTournament.Properties.Resources.map_harbor);
                dtBitmap.Add("map_missile", SPTournament.Properties.Resources.map_missile);
                dtBitmap.Add("map_neomissile", SPTournament.Properties.Resources.map_neomissile);
                dtBitmap.Add("map_satellite", SPTournament.Properties.Resources.map_satellite);
            }

            al.Add(new beanTeam(ref bt_team_00, ref bt_team_01, ref lb_round_1st_a_map_00, ref lb_round_1st_a_map_01));
            al.Add(new beanTeam(ref bt_team_02, ref bt_team_03, ref lb_round_1st_b_map_00, ref lb_round_1st_b_map_01));
            al.Add(new beanTeam(ref bt_team_04, ref bt_team_05, ref lb_round_1st_c_map_00, ref lb_round_1st_c_map_01));
            al.Add(new beanTeam(ref bt_team_06, ref bt_team_07, ref lb_round_1st_d_map_00, ref lb_round_1st_d_map_01));
            al.Add(new beanTeam(ref bt_team_08, ref bt_team_09, ref lb_round_1st_e_map_00, ref lb_round_1st_e_map_01));
            al.Add(new beanTeam(ref bt_team_10, ref bt_team_11, ref lb_round_1st_f_map_00, ref lb_round_1st_f_map_01));
            al.Add(new beanTeam(ref bt_team_12, ref bt_team_13, ref lb_round_1st_g_map_00, ref lb_round_1st_g_map_01));
            al.Add(new beanTeam(ref bt_team_14, ref bt_team_15, ref lb_round_1st_h_map_00, ref lb_round_1st_h_map_01));
         
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            

          // splitContainer1.Panel1.BackColor = Color.Transparent;
           //splitContainer1.Panel2.BackColor = Color.Transparent; 
          //  splitContainer1.Panel1.BackgroundImage = poolImage;

            start = map = false;
            
            flag = 0;

            rnd = new Random();

            mlb = new MsgLogboxImpl(rtb_log);

            mlb.printLog("Special Force Tournament Application 이 초기화 되었습니다.");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            
            //G.DrawLine(Pens.Black, team_00
        }

        private void setButton(ref Button b)
        {
            b.ForeColor = System.Drawing.SystemColors.ControlDark;
            //b.Enabled = false;
        }

        private void team_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (start == true && flag==0)
            {
                switch(b.TabIndex)
                {
                    case 0:
                    case 1:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_01);
                        else
                            setButton(ref bt_team_00);
                        bt_round_2nd_team_00.Text = b.Text;
                        break;
                    case 2:
                    case 3:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_03);
                        else
                            setButton(ref bt_team_02);
                        bt_round_2nd_team_01.Text = b.Text;
                        break;
                    case 4:
                    case 5:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_05);
                        else
                            setButton(ref bt_team_04);
                        bt_round_2nd_team_02.Text = b.Text;
                        break;
                    case 6:
                    case 7:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_07);
                        else
                            setButton(ref bt_team_06);
                        bt_round_2nd_team_03.Text = b.Text;
                        break;
                    case 8:
                    case 9:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_09);
                        else
                            setButton(ref bt_team_08);
                        bt_round_2nd_team_04.Text = b.Text;
                        break;
                    case 10:
                    case 11:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_10);
                        else
                            setButton(ref bt_team_11);
                        bt_round_2nd_team_05.Text = b.Text;
                        break;
                    case 12:
                    case 13:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_13);
                        else
                            setButton(ref bt_team_12);
                        bt_round_2nd_team_06.Text = b.Text;
                        break;
                    case 14:
                    case 15:
                        if (b.TabIndex % 2 == 0)
                            setButton(ref bt_team_15);
                        else
                            setButton(ref bt_team_14);
                        bt_round_2nd_team_07.Text = b.Text;
                        break;
                }
                b.ForeColor = System.Drawing.SystemColors.ControlText;
                return;
            }
            Form_team ft = new Form_team(b.TabIndex,ref splitContainer1);
            ft.ShowDialog();
            ft.Dispose();
        }

        private void bt_select_map_Click(object sender, EventArgs e)
        {
            if (start == true)
                return;

            Form_map fm = new Form_map();
            if (fm.ShowDialog() == DialogResult.Yes)
            {
                Button b = sender as Button;
                b.Image = fm.SelectImg;
                b.Name = fm.ImgName;
            }
            fm.Dispose();
        }

        private bool boolSetMap()
        {
            for (int i = 0; i < bt_select_map.Length; i++)
            {
                if (bt_select_map[i].Image == null)
                {
                    MessageBox.Show("대회 지정 맵이 다 선택되지 않았습니다. 선택해 주십시요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void bt_set_map_Click(object sender, EventArgs e)
        {
            if (!start && !boolSetMap())
            {
                return;
            }
            if (!this.map && start)
            {
                int rnd = 0;
                int alCount = al.Count * 2;
                String[] map = new String[al.Count * 2];
                Console.WriteLine(al.Count);
                for (int i = 0; i < map.Length; i++)
                {
                    rnd = this.rnd.Next(4);
                    map[i] = bt_select_map[rnd].Name;
                    Console.WriteLine(i + " " + map[i]);
                    if (i % 2 == 1 && map[i].Equals(map[i - 1]))
                    {
                        i--;
                        continue;
                    }
                    if (i % 2 == 1)
                        Console.WriteLine("----------------------------------------------");
                }

                foreach (beanTeam bt in al)
                    for (int i = 0; i < bt.Map.Length; i++)
                        bt.Map[i].Text = "";

                int mapCount = 0;
                foreach (beanTeam bt in al)
                {
                    for (int i = 0; i < bt.Map.Length; i++)
                    {
                        if (bt.Team[i].Text.Equals("Hypnotize`") || bt.Team[i].Text.Equals("Hypnotize"))
                        {
                            Boolean b = false;
                            for (int j = 0; j < bt_select_map.Length; j++)
                                if (bt_select_map[j].Name.Equals("decamp") || bt_select_map[j].Name.Equals("gas"))
                                    b = true;
                            if (b)
                            {
                                if (i % 2 == 0)
                                {
                                    String[] setMap = { "decamp", "gas" };
                                    for (int z = 0; z < setMap.Length; z++)
                                    {
                                        int r = this.rnd.Next(setMap.Length);
                                        String temp = setMap[z];
                                        setMap[z] = setMap[r];
                                        setMap[r] = temp;
                                    }
                                    bt.Map[i].Text = setMap[0];
                                    bt.Map[i + 1].Text = setMap[1];
                                    mapCount += 2;
                                }
                                else if (i % 2 == 1)
                                {
                                    if (bt.Map[i - 1].Text.Equals("decamp"))
                                        bt.Map[i].Text = "gas";
                                    else if (bt.Map[i - 1].Text.Equals("gas"))
                                        bt.Map[i].Text = "decamp";
                                    else
                                    {
                                        String[] setMap = { "decamp", "gas" };
                                        for (int z = 0; z < setMap.Length; z++)
                                        {
                                            int r = this.rnd.Next(setMap.Length);
                                            String temp = setMap[z];
                                            setMap[z] = setMap[r];
                                            setMap[r] = temp;
                                        }
                                        bt.Map[i].Text = setMap[0];
                                        bt.Map[i - 1].Text = setMap[1];
                                    }
                                    mapCount++;
                                }
                            }
                        }
                        else
                        {
                            if (bt.Map[i].Text.Length == 0)
                                bt.Map[i].Text = map[mapCount++];
                        }
                    }
                }
                this.map = true;
                mlb.printLog("맵 셋팅을 완료하였습니다.");
            }
            else
            {
                MessageBox.Show("아직 경기가 시작되지 않았습니다. 해당 라운드를 시작해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void bt_set_team_Click(object sender, EventArgs e)
        {
            if (start)
            {
                MessageBox.Show("팀 자동배치는 16강 시작 전에만 가능합니다.. 확인해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<String> l = getObject();
            String [] str = l.ToArray();
            for (int i = 0; i < str.Length; i++)
            {
                int r = this.rnd.Next(15);
                String tmp = str[i];
                str[i] = str[r];
                str[r] = tmp;
            }
            setTeam(str);
        }

        private void setTeam(String[] str)
        {
            int strCount=0;
            for (int i = 0; i < al.Count; i++)
                for (int j = 0; j < 2; j++)
                     al[i].Team[j].Text = str[strCount++];

        }

        private List<String> getObject()
        {
            List<String> l = new List<string>();
            for (int i = 0; i < splitContainer1.Panel1.Controls.Count; i++)
            {
                if (splitContainer1.Panel1.Controls[i].Name.Substring(0, 7).Equals("bt_team"))
                {
                    l.Add(splitContainer1.Panel1.Controls[i].Text);
                    Console.WriteLine(splitContainer1.Panel1.Controls[i].Text);
                }
            }
            return l;
        }

        private void bt_round_final_team_Click(object sender, EventArgs e)
        {
            if (!bt_round_final_team_00.Text.Equals("") && !bt_round_final_team_01.Text.Equals(""))
            {
                Button b = sender as Button;
                MessageBox.Show(b.Text.ToString() + "님 께서 우승하셨습니다.", "Congratulation!!");
            }
        }

        private void bt_round_1st_Click(object sender, EventArgs e)
        {
            if (!boolSetMap())
                return;

            if (start == false && DialogResult.Yes == MessageBox.Show("정말 경기를 시작하시겠습니까? 준비는 다 되셨는지요??", "Are You Ready?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                MessageBox.Show("앞으로 승리 Team 을 클릭 시 다음 라운드로 진입하게 됩니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = true;
                MessageBox.Show("16강전을 시작합니다. 맵 셋팅을 해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(start == true)
            {
                if (DialogResult.Yes == MessageBox.Show("경기를 새로 시작하시겠습니까?", "Reset?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    init();
                    for (int i = 0; i < splitContainer1.Panel1.Controls.Count; i++)
                        if (splitContainer1.Panel1.Controls[i].GetType().Name.Equals("Button") && 
                            !(splitContainer1.Panel1.Controls[i].Name.Equals("bt_round_1st") || splitContainer1.Panel1.Controls[i].Name.Equals("bt_round_2nd")
                            || splitContainer1.Panel1.Controls[i].Name.Equals("bt_round_3rd") || splitContainer1.Panel1.Controls[i].Name.Equals("bt_round_final")))
                            splitContainer1.Panel1.Controls[i].Text = "";
                    String[] str = new String[16];
                    for (int i = 0; i < str.Length; i++)
                        if (i < 10)
                            str[i] = "team0" + i;
                        else
                            str[i] = "team" + i;
                    setTeam(str);
                    

                    MessageBox.Show("초기화 되었습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void bt_round_2nd_Start(object sender, EventArgs e)
        {
            if (bt_round_2nd_team_00.Text.Equals("") || bt_round_2nd_team_01.Text.Equals("") || bt_round_2nd_team_02.Text.Equals("") || bt_round_2nd_team_03.Text.Equals("")
                || bt_round_2nd_team_04.Text.Equals("") || bt_round_2nd_team_05.Text.Equals("") || bt_round_2nd_team_06.Text.Equals("") || bt_round_2nd_team_07.Text.Equals(""))
            {
                MessageBox.Show("8강전 팀 등록이 완료되지 않았습니다. 확인해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            map = false;
            MessageBox.Show("8강전을 시작합니다. 맵 셋팅을 해주세요.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flag = 1;
            al.Clear();
            al.Add(new beanTeam(ref bt_round_2nd_team_00, ref bt_round_2nd_team_01, ref lb_round_2nd_a_map_00, ref lb_round_2nd_a_map_01));
            al.Add(new beanTeam(ref bt_round_2nd_team_02, ref bt_round_2nd_team_03, ref lb_round_2nd_b_map_00, ref lb_round_2nd_b_map_01));
            al.Add(new beanTeam(ref bt_round_2nd_team_04, ref bt_round_2nd_team_05, ref lb_round_2nd_c_map_00, ref lb_round_2nd_c_map_01));
            al.Add(new beanTeam(ref bt_round_2nd_team_06, ref bt_round_2nd_team_07, ref lb_round_2nd_d_map_00, ref lb_round_2nd_d_map_01));

        }
        private void bt_round_3rd_Start(object sender, EventArgs e)
        {
            if (bt_round_3rd_team_00.Text.Equals("") || bt_round_3rd_team_01.Text.Equals("") || bt_round_3rd_team_02.Text.Equals("") || bt_round_3rd_team_03.Text.Equals(""))
            {
                MessageBox.Show("4강전 팀 등록이 완료되지 않았습니다. 확인해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            map = false;
            MessageBox.Show("4강전을 시작합니다. 맵 셋팅을 해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flag = 2;
            al.Clear();
            al.Add(new beanTeam(ref bt_round_3rd_team_00, ref bt_round_3rd_team_01, ref lb_round_3rd_a_map_00, ref lb_round_3rd_a_map_01));
            al.Add(new beanTeam(ref bt_round_3rd_team_02, ref bt_round_3rd_team_03, ref lb_round_3rd_b_map_00, ref lb_round_3rd_b_map_01));

        }
        private void bt_round_final_Start(object sender, EventArgs e)
        {
            if (bt_round_final_team_00.Text.Equals("") || bt_round_final_team_01.Text.Equals(""))
            {
                MessageBox.Show("결승전 팀 등록이 완료되지 않았습니다. 확인해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            map = false;
            MessageBox.Show("결승전을 시작합니다. 맵 셋팅을 해주세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flag = 3;
            al.Clear();
            al.Add(new beanTeam(ref bt_round_final_team_00, ref bt_round_final_team_01, ref lb_round_final_a_map_00, ref lb_round_final_a_map_01));
        }


        private void bt_round_2nd_Click(object sender, EventArgs e)
        {
            if (start == false)
                return;
            Button b = sender as Button;
            if (start == true)
            {
                if (flag==1 && b.TabIndex > 15 && b.TabIndex < 24)
                {
                    switch (b.TabIndex)
                    {
                        case 16:
                        case 17:
                            if (b.TabIndex % 2 == 0)
                                setButton(ref bt_round_2nd_team_01);
                            else
                                setButton(ref bt_round_2nd_team_00);
                            bt_round_3rd_team_00.Text = b.Text;
                            break;
                        case 18:
                        case 19:
                            if (b.TabIndex % 2 == 0)
                                setButton(ref bt_round_2nd_team_03);
                            else
                                setButton(ref bt_round_2nd_team_02);
                            bt_round_3rd_team_01.Text = b.Text;
                            break;
                        case 20:
                        case 21:
                            if (b.TabIndex % 2 == 0)
                                setButton(ref bt_round_2nd_team_05);
                            else
                                setButton(ref bt_round_2nd_team_04);
                            bt_round_3rd_team_02.Text = b.Text;
                            break;
                        case 22:
                        case 23:
                            if (b.TabIndex % 2 == 0)
                                setButton(ref bt_round_2nd_team_07);
                            else
                                setButton(ref bt_round_2nd_team_06);
                            bt_round_3rd_team_03.Text = b.Text;
                            break;
                    }
                }
                else if (flag==2 && b.TabIndex > 23 && b.TabIndex < 28)
                {
                    switch (b.TabIndex)
                    {
                        case 24:
                        case 25:
                            if (b.TabIndex % 2 == 0)
                                setButton(ref bt_round_3rd_team_01);
                            else
                                setButton(ref bt_round_3rd_team_00);
                            bt_round_final_team_00.Text = b.Text;
                            break;
                        case 26:
                        case 27:
                            if (b.TabIndex % 2 == 0)
                                setButton(ref bt_round_3rd_team_03);
                            else
                                setButton(ref bt_round_3rd_team_02);
                            bt_round_final_team_01.Text = b.Text;
                            break;
                    }
                }
                b.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }
    }
}
