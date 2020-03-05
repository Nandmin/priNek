using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRI_adatlap
{
    public partial class EK_form : Form
    {
        public EK_form()
        {
            InitializeComponent();
        }

        private void EK_form_Load(object sender, EventArgs e)
        {
            label2.Text = "Intézkedési terv végrehajtása";
            label3.Text = "Bélyegzéssel kapcsolatos utasítások végrehajtása";
            label4.Text = "KK jelzõ használata"; 
            label5.Text = "Felvett küldemények rögzítése";

            if (FormCode.IntTerv_gond == "Hiba")
            {
                label2.Show();
            }
            else
            {
                label2.Hide();
            }


            if (FormCode.Belyegzes_gond == "Hiba")
            {
                label3.Show();
            }
            else
            {
                label3.Hide();
            }

            if (FormCode.KK_Hasznalat_gond == "Hiba")
            {
                label4.Show();
            }
            else
            {
                label4.Hide();
            }

            if (FormCode.KK_Rogzites_gond == "Hiba")
            {
                label5.Show();
            }
            else
            {
                label5.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}