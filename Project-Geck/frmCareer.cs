﻿using System;
using System.Windows.Forms;

namespace Geck
{
    public partial class frmCareer : Form
    {

        Player player = new Player();

        public frmCareer(Player player)
        {
            this.player = player;
            InitializeComponent();
            progressBar1.Value = player.GetAttribute("maxHP");
        }

        private void frmCareer_Load(object sender, EventArgs e)
        {

        }

        private void splitKarmaNuyen_Panel1_Resize(object sender, EventArgs e)
        {

        }

        private void splitKarmaNuyen_Panel2_Resize(object sender, EventArgs e)
        {

        }

        private void cmdAddMugshot_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            player.ApplyPerks();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
