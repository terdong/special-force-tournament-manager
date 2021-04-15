using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rsrc = SPTournament.Properties.Resources;

namespace SPTournament
{
    public partial class Form_map : Form
    {
        private Image selectImg;
        private String imgName;

        public String ImgName
        {
            get { return imgName; }
        }

        public Image SelectImg
        {
            get { return selectImg; }
        }
        public Form_map()
        {
            InitializeComponent();           
        }

        private void bt_map__00_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_bunker;
            imgName = "bunker";
            selectResult();
        }
        private void bt_map__01_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_crossroad;
            imgName = "crossroad";
            selectResult();
        }
        private void bt_map__02_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_decamp;
            imgName = "decamp";
            selectResult();
        }
        private void bt_map__03_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_gas;
            imgName = "gas";
            selectResult();
        }
        private void bt_map__04_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_harbor;
            imgName = "harbor";
            selectResult();
        }
        private void bt_map__05_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_missile;
            imgName = "missile";
            selectResult();
        }
        private void bt_map__06_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_neomissile;
            imgName = "neomissile";
            selectResult();
        }
        private void bt_map__07_Click(object sender, EventArgs e)
        {
            selectImg = Rsrc.map_satellite;
            imgName = "satellite";
            selectResult();
        }
        private void selectResult()
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
