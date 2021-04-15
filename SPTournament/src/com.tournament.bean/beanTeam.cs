using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace SPTournament.src.com.tournament.bean
{
    class beanTeam
    {
        private Button[] team;
        private Label[] map;

        public Button[] Team
        {
            get { return team; }
        }
        

        public Label[] Map
        {
            get { return map; }
        }

        public beanTeam()
        {
            team = new Button[2];
            map = new Label[2];
        }
        public beanTeam(ref Button team1, ref Button team2, ref Label map1, ref Label map2 )
        {
            team = new Button[2];
            map = new Label[2];

            team[0] = team1; team[1] = team2;
            map[0] = map1; map[1] = map2;
        }
        public void setTeam(ref Button team)
        {
            if (this.team[0]== null)
                this.team[0] = team;
            else
                this.team[1] = team;
        }
        public void setMap(ref Label l)
        {
            if (this.map[0]== null)
                this.map[0] = l;
            else
                this.map[1] = l;
        }
    }
}
