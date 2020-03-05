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
            label2.Text = "Int�zked�si terv v�grehajt�sa";
            label3.Text = "B�lyegz�ssel kapcsolatos utas�t�sok v�grehajt�sa";
            label4.Text = "KK jelz� haszn�lata"; 
            label5.Text = "Felvett k�ldem�nyek r�gz�t�se";

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