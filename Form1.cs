using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data.Linq;
using System.Windows.Forms;

namespace PRI_adatlap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string SZUM_Jaras;
        public static string SZUM_TIG_engedely;
        public static string SZUM_D1;
        public static string SZUM_D3;
        public static string SZUM_D3_szla;
        public static string SZUM_Nemz_Konyv;
        public static string SZUM_Nemz_Prime;
        public bool hibas;


        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length > 0 && maskedTextBox1.Text != "0" && textBox46.Text.Length == 0 ||
                //maskedTextBox9.Text.Length > 0 && maskedTextBox9.Text != "0" && textBox50.Text.Length == 0 ||
                maskedTextBox4.Text.Length > 0 && maskedTextBox4.Text != "0" && textBox48.Text.Length == 0 ||
                maskedTextBox5.Text.Length > 0 && maskedTextBox5.Text != "0" && textBox49.Text.Length == 0 ||
                maskedTextBox6.Text.Trim().Length != 4)
            {
                MessageBox.Show("Adatrögzítési hiba!\n\n A talált küldemények vonatkozásában nem mindenhol írtál indoklást");
            }
            else
            {
                if (maskedTextBox6.Text.Length == 4 && maskedTextBox6.Text.Substring(0,1) != " ")
                {
                    if (textBox1.Text.Contains(maskedTextBox6.Text))
                    {
                        MessageBox.Show("Erre a járásra vonatkozóan rögzítettél már adatot!");
                        maskedTextBox6.Text = "";
                    }
                    else
                    {
                        textBox1.Text = string.Concat(maskedTextBox6.Text, ",", textBox1.Text);


                        nullazo_tab3();

                        dataGridView1.Rows.Add(maskedTextBox6.Text, comboBox3.Text, maskedTextBox1.Text, maskedTextBox2.Text, maskedTextBox3.Text, maskedTextBox4.Text, maskedTextBox5.Text, textBox46.Text, textBox47.Text, textBox48.Text, textBox49.Text);
                        dataGridView1.AllowUserToAddRows = false;

                        if (dataGridView1.Rows.Count > 1)
                        {
                            dataGridView1.AllowUserToDeleteRows = true;
                        }

                        maskedTextBox6.Text = "";
                        comboBox3.Text = "Nem";
                        maskedTextBox1.Text = "";
                        maskedTextBox2.Text = "";
                        maskedTextBox3.Text = "";
                        maskedTextBox4.Text = "";
                        maskedTextBox5.Text = "";
                        textBox46.Text = "";
                        textBox47.Text = "";
                        textBox48.Text = "";
                        textBox49.Text = "";
                        textBox46.BackColor = Color.Empty;
                        textBox47.BackColor = Color.Empty;
                        textBox48.BackColor = Color.Empty;
                        textBox49.BackColor = Color.Empty;
                        maskedTextBox6.Select();
                    }
                 }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox3.Text = "Nem";
            comboBox4.Text = "Nem";
            maskedTextBox36.Enabled = false;
            textBox1.Text = FormCode.ChkList_Kezd_IndElott;
            textBox2.Text = FormCode.ChkList_Kezd_IndUtan;

            toolTip1.SetToolTip(maskedTextBox7, "Kézbesítõjárás száma");

            if (dataGridView1.Rows.Count == 1)
            {
                dataGridView1.AllowUserToDeleteRows = false;
            }

            if (dataGridView2.Rows.Count == 1)
            {
                dataGridView2.AllowUserToDeleteRows = false;
            }

            foreach (object uzemlista in FormCode.pfuLista)
            {
                comboBox5.Items.Add(uzemlista.ToString());
            }

            datagridcombo_betoltes();

            //4,5,6,12,14
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox12.Enabled = false;
            textBox14.Enabled = false;

            //15,16,13,24,20,25,30,33,31,26
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox13.Enabled = false;
            textBox24.Enabled = false;
            textBox20.Enabled = false;
            textBox25.Enabled = false;
            textBox30.Enabled = false;
            textBox33.Enabled = false;
            textBox31.Enabled = false;
            textBox26.Enabled = false;
        }

        public void datagridcombo_betoltes()        // LCPM datagrid feltöltése a postalistából, név adatokkal
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            
                foreach (object postlist in FormCode.postaLista) // posta_neve)
                {
                    cmb.Items.Add(postlist.ToString());
                }
            
            cmb.HeaderText = "Felvevõ posta";
            cmb.MaxDropDownItems = 25;
            cmb.Width = 285;
            
            dataGridView3.Columns.Add(cmb);
            dataGridView3.Enabled = false;
        }



        private void nullazo_tab3()      // Ha üres a dbszám, akkor 0-t ír a mezõbe
        {
            if (maskedTextBox1.Text.Trim().Length  == 0)
            {
                maskedTextBox1.Text = "0";
            }

            if (maskedTextBox2.Text.Trim().Length  == 0)
            {
                maskedTextBox2.Text = "0";
            }

            if (maskedTextBox3.Text.Trim().Length  == 0)
            {
                maskedTextBox3.Text = "0";
            }

            if (maskedTextBox4.Text.Trim().Length  == 0)
            {
                maskedTextBox4.Text = "0";
            }

            if (maskedTextBox5.Text.Trim().Length  == 0)
            {
                maskedTextBox5.Text = "0";
            }
        }

        private void nullazo_tab4()
        {

            if (maskedTextBox8.Text.Trim().Length  == 0)
            {
                maskedTextBox8.Text = "0";
            }

            if (maskedTextBox9.Text.Trim().Length  == 0)
            {
                maskedTextBox9.Text = "0";
            }

            if (maskedTextBox10.Text.Trim().Length  == 0)
            {
                maskedTextBox10.Text = "0";
            }

            if (maskedTextBox11.Text.Trim().Length  == 0)
            {
                maskedTextBox11.Text = "0";
            }

            if (maskedTextBox12.Text.Trim().Length  == 0)
            {
                maskedTextBox12.Text = "0";
            }
        }

        private void tab2_Leave(object sender, EventArgs e)
        {
            nullazo_tab2();
        }

        private void nullazo_tab2()
        {
            
            if (maskedTextBox13.Text.Trim().Length  == 0)
            {
                maskedTextBox13.Text = "0";
            }

            if (maskedTextBox14.Text.Trim().Length  == 0)
            {
                maskedTextBox14.Text = "0";
            }

            if (maskedTextBox15.Text.Trim().Length  == 0)
            {
                maskedTextBox15.Text = "0";
            }

            if (maskedTextBox20.Text.Trim().Length  == 0)
            {
                maskedTextBox20.Text = "0";
            }

            if (maskedTextBox21.Text.Trim().Length  == 0)
            {
                maskedTextBox21.Text = "0";
            }

            if (maskedTextBox22.Text.Trim().Length  == 0)
            {
                maskedTextBox22.Text = "0";
            }

            if (maskedTextBox23.Text.Trim().Length  == 0)
            {
                maskedTextBox23.Text = "0";
            }

            if (maskedTextBox24.Text.Trim().Length  == 0)
            {
                maskedTextBox24.Text = "0";
            }

            if (maskedTextBox25.Text.Trim().Length  == 0)
            {
                maskedTextBox25.Text = "0";
            }

            if (maskedTextBox16.Text.Trim().Length  == 0)
            {
                maskedTextBox16.Text = "0";
            }

            if (maskedTextBox17.Text.Trim().Length  == 0)
            {
                maskedTextBox17.Text = "0";
            }

            if (maskedTextBox18.Text.Trim().Length  == 0)
            {
                maskedTextBox18.Text = "0";
            }

            if (maskedTextBox19.Text.Trim().Length  == 0)
            {
                maskedTextBox19.Text = "0";
            }
        }

        private void nullazo_tab1()
        {
            if (maskedTextBox26.Text.Trim().Length  == 0)
            {
                maskedTextBox26.Text = "0";
            }

            if (maskedTextBox27.Text.Trim().Length  == 0)
            {
                maskedTextBox27.Text = "0";
            }

            if (maskedTextBox28.Text.Trim().Length  == 0)
            {
                maskedTextBox28.Text = "0";
            }

            if (maskedTextBox29.Text.Trim().Length  == 0)
            {
                maskedTextBox29.Text = "0";
            }

            if (maskedTextBox30.Text.Trim().Length  == 0)
            {
                maskedTextBox30.Text = "0";
            }

            if (maskedTextBox31.Text.Trim().Length  == 0)
            {
                maskedTextBox31.Text = "0";
            }

            if (maskedTextBox32.Text.Trim().Length  == 0)
            {
                maskedTextBox32.Text = "0";
            }

            if (maskedTextBox33.Text.Trim().Length  == 0)
            {
                maskedTextBox33.Text = "0";
            }

            if (maskedTextBox34.Text.Trim().Length  == 0)
            {
                maskedTextBox34.Text = "0";
            }

            if (maskedTextBox35.Text.Trim().Length  == 0)
            {
                maskedTextBox35.Text = "0";
            }

            if (maskedTextBox36.Text.Trim().Length  == 0)
            {
                maskedTextBox36.Text = "0";
            }
        }

        

        private void tab1_Leave(object sender, EventArgs e)
        {
            nullazo_tab1();
        }

        private void button2_Click(object sender, EventArgs e)          //Tab4-en adatrögzítése
        {
            if (maskedTextBox8.Text.Length > 0 && maskedTextBox8.Text != "0" && textBox45.Text.Length == 0 ||
                //maskedTextBox9.Text.Length > 0 && maskedTextBox9.Text != "0" && textBox50.Text.Length == 0 ||
                maskedTextBox11.Text.Length > 0 && maskedTextBox11.Text != "0" && textBox51.Text.Length == 0 ||
                maskedTextBox12.Text.Length > 0 && maskedTextBox12.Text != "0" && textBox52.Text.Length == 0 ||
                maskedTextBox7.Text.Trim().Length != 4)
            {
                MessageBox.Show("Adatrögzítési hiba!\n\n A talált küldemények vonatkozásában nem mindenhol írtál indoklást");
            }
            else
            {

                if (maskedTextBox7.Text.Length == 4 && maskedTextBox7.Text.Substring(0, 1) != " ")
                {
                    if (textBox2.Text.Contains(maskedTextBox7.Text))
                    {
                        MessageBox.Show("Erre a járásra vonatkozóan rögzítettél már adatot!");
                        maskedTextBox7.Text = "";
                    }
                    else
                    {
                        textBox2.Text = string.Concat(maskedTextBox7.Text, ",", textBox2.Text);
                
                        nullazo_tab4();

                        dataGridView2.Rows.Add(maskedTextBox7.Text, comboBox4.Text, maskedTextBox8.Text, maskedTextBox9.Text, maskedTextBox10.Text, maskedTextBox11.Text, maskedTextBox12.Text, textBox45.Text, textBox50.Text, textBox51.Text, textBox52.Text);
                        dataGridView2.AllowUserToAddRows = false;

                        if (dataGridView2.Rows.Count > 1)
                        {
                            dataGridView2.AllowUserToDeleteRows = true;
                        }

                        maskedTextBox7.Text = "";
                        comboBox4.Text = "Nem";
                        maskedTextBox8.Text = "";
                        maskedTextBox9.Text = "";
                        maskedTextBox10.Text = "";
                        maskedTextBox11.Text = "";
                        maskedTextBox12.Text = "";
                        textBox45.Text = "";
                        textBox50.Text = "";
                        textBox52.Text = "";
                        textBox51.Text = "";
                        textBox45.BackColor = Color.Empty;
                        textBox50.BackColor = Color.Empty;
                        textBox51.BackColor = Color.Empty;
                        textBox52.BackColor = Color.Empty;
                        maskedTextBox7.Select();
                    }
                }
            }
        }


        private void maskedTextBox10_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox10.Text.Length > 0 && Convert.ToInt32(maskedTextBox10.Text) > Convert.ToInt32(maskedTextBox9.Text))
            {
                MessageBox.Show("Adatrögzítési hiba!\n\n A számlalevél nem lehet több, mint az összes NEK küldemény!");
                maskedTextBox10.Text = "";
            }
        }

        private void maskedTextBox8_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox8.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox45.Enabled = true;
                textBox45.BackColor = Color.Tomato;
            }
            else
            {
                textBox45.Enabled = false;
                textBox45.Text = "";
                textBox45.BackColor = Color.Empty;
            }

            if (textBox45.Text.Length > 0 && maskedTextBox8.Text.Length == 0 || 
                    textBox45.Text.Length > 0 && maskedTextBox8.Text == "0")
            {
                textBox45.Enabled = false;
                textBox45.Text = "";
            }
        }

        private void maskedTextBox9_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox9.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox50.Enabled = true;
                textBox50.BackColor = Color.Tomato;
            }
            else
            {
                textBox50.Enabled = false;
                textBox50.Text = "";
                textBox50.BackColor = Color.Empty;
            }

            if (textBox50.Text.Length > 0 && maskedTextBox9.Text.Length == 0 ||
                    textBox50.Text.Length > 0 && maskedTextBox9.Text == "0")
            {
                textBox50.Enabled = false;
                textBox50.Text = "";
                textBox50.BackColor = Color.Empty;
            }

            if (maskedTextBox9.Text.Length > 0  && maskedTextBox10.Text.Length > 0 && Convert.ToInt32(maskedTextBox10.Text) > Convert.ToInt32(maskedTextBox9.Text))
            {
                maskedTextBox10.Text = "";
            }
        }

        private void maskedTextBox11_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox11.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox51.Enabled = true;
                textBox51.BackColor = Color.Tomato;
            }
            else
            {
                textBox51.Enabled = false;
                textBox51.Text = "";
                textBox51.BackColor = Color.Empty;
            }

            if (textBox51.Text.Length > 0 && maskedTextBox11.Text.Length == 0 ||
                    textBox51.Text.Length > 0 && maskedTextBox11.Text == "0")
            {
                textBox51.Enabled = false;
                textBox51.Text = "";
                textBox51.BackColor = Color.Empty;
            }
        }

        private void maskedTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox12.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox52.Enabled = true;
                textBox52.BackColor = Color.Tomato;

            }
            else
            {
                textBox52.Enabled = false;
                textBox52.Text = "";
                textBox52.BackColor = Color.Empty;
            }

            if (textBox52.Text.Length > 0 && maskedTextBox12.Text.Length == 0 ||
                    textBox52.Text.Length > 0 && maskedTextBox12.Text == "0")
            {
                textBox52.Enabled = false;
                textBox52.Text = "";
                textBox52.BackColor = Color.Empty;
            }
        }

        private void maskedTextBox7_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(maskedTextBox7.Text) < 6000 && maskedTextBox7.Text.Length == 4 || Convert.ToInt32(maskedTextBox7.Text) > 8000 && maskedTextBox7.Text.Length == 4)
                {
                    MessageBox.Show("Hibás járásszám!");
                    maskedTextBox7.Text = "";
                }
                else
                {
                }
            }
            catch
            {
            }
            
            
            //if (maskedTextBox7.Text.Length == 4 && maskedTextBox7.Text.Substring(0, 1) != " ")
            //{
            //    if (textBox2.Text.Contains(maskedTextBox7.Text))
            //    {
            //        MessageBox.Show("Erre a járásra vonatkozóan rögzítettél már adatot!");
            //        maskedTextBox7.Text = "";
            //    }
            //    else
            //    {
            //        textBox2.Text = string.Concat(maskedTextBox7.Text, ",", textBox2.Text);
            //    }
            //}
        }

        private void maskedTextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(maskedTextBox6.Text) < 6000 && maskedTextBox6.Text.Length == 4 || Convert.ToInt32(maskedTextBox6.Text) > 8000 && maskedTextBox6.Text.Length == 4)
                {
                    MessageBox.Show("Hibás azonosító!");
                    maskedTextBox6.Text = "";
                }
                else
                {
                }
            }
            catch
            {
            }
            
            //if (maskedTextBox6.Text.Length == 4 && maskedTextBox6.Text.Substring(0,1) != " ")
            //{
            //    if (textBox1.Text.Contains(maskedTextBox6.Text))
            //    {
            //        MessageBox.Show("Erre a járásra vonatkozóan rögzítettél már adatot!");
            //        maskedTextBox6.Text = "";
            //    }
            //    else
            //    {
            //        textBox1.Text = string.Concat(maskedTextBox6.Text, ",", textBox1.Text);
            //    }
            //}
            
            
            //if (dataGridView1.Rows.Count > 0)   // dupla rögzítés ellenõrzése
            //{
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == maskedTextBox6.Text)
            //        {
            //            MessageBox.Show("Erre a járásra vonatkozóan rögzítettél már adatot!");
            //            maskedTextBox6.Text = "";
            //            break; // kilépés a ciklusból
            //        }
            //    }
            //}
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox46.Enabled = true;
                textBox46.BackColor = Color.Tomato;
            }
            else
            {
                textBox46.Enabled = false;
                textBox46.Text = "";
                textBox46.BackColor = Color.Empty;
            }

            if (textBox46.Text.Length > 0 && maskedTextBox1.Text.Length == 0 ||
                    textBox46.Text.Length > 0 && maskedTextBox1.Text == "0")
            {
                textBox46.Enabled = false;
                textBox46.Text = "";
                textBox46.BackColor = Color.Empty;
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox47.Enabled = true;
                textBox47.BackColor = Color.Tomato;
            }
            else
            {
                textBox47.Enabled = false;
                textBox47.Text = "";
                textBox47.BackColor = Color.Empty;
            }

            if (textBox47.Text.Length > 0 && maskedTextBox2.Text.Length == 0 ||
                    textBox47.Text.Length > 0 && maskedTextBox2.Text == "0")
            {
                textBox47.Enabled = false;
                textBox47.Text = "";
                textBox47.BackColor = Color.Empty;
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox4.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox48.Enabled = true;
                textBox48.BackColor = Color.Tomato;
            }
            else
            {
                textBox48.Enabled = false;
                textBox48.Text = "";
                textBox48.BackColor = Color.Empty;
            }

            if (textBox48.Text.Length > 0 && maskedTextBox4.Text.Length == 0 ||
                    textBox48.Text.Length > 0 && maskedTextBox4.Text == "0")
            {
                textBox48.Enabled = false;
                textBox48.Text = "";
                textBox48.BackColor = Color.Empty;
            }
        }

        private void maskedTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text.Length > 0)// textBox45.Text.Length == 0)
            {
                textBox49.Enabled = true;
                textBox49.BackColor = Color.Tomato;
            }
            else
            {
                textBox49.Enabled = false;
                textBox49.Text = "";
                textBox49.BackColor = Color.Empty;
            }

            if (textBox49.Text.Length > 0 && maskedTextBox5.Text.Length == 0 ||
                    textBox49.Text.Length > 0 && maskedTextBox5.Text == "0")
            {
                textBox49.Enabled = false;
                textBox49.Text = "";
                textBox49.BackColor = Color.Empty;
            }
        
        
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox3.Text.Length > 0 && Convert.ToInt32(maskedTextBox3.Text) > Convert.ToInt32(maskedTextBox2.Text))
            {
                MessageBox.Show("Adatrögzítési hiba! \n\n A számlalevél nem lehet több, mint az összes NEK küldemény!");
                maskedTextBox3.Text = "";
            }
        }

        private void maskedTextBox13_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox13.Text != "0" && maskedTextBox13.Text.Length > 0)
            {
                maskedTextBox14.Enabled = true;
                maskedTextBox15.Enabled = true;
                //maskedTextBox14.Text = "1";
                maskedTextBox14.Text = "";
            }
            
            if (maskedTextBox13.Text.Length == 0 || maskedTextBox13.Text == "0")
            {
                maskedTextBox14.Text = "";
                maskedTextBox14.Enabled = false;
                textBox27.Text = "";
                textBox27.Enabled = false;

                maskedTextBox15.Text = "";
                maskedTextBox14.Enabled = false;
                textBox28.Text = "";
                textBox28.Enabled = false;
            }
        }

        private void maskedTextBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox14.Text.Length == 0 || maskedTextBox14.Text == "0")
                {
                    textBox27.Enabled = false;
                    textBox27.Text = "";
                    textBox27.BackColor = Color.Empty;
                }
                else
                {

                    if (maskedTextBox14.Text.Length > 0)
                    {
                        if (Convert.ToInt32(maskedTextBox14.Text) > Convert.ToInt32(maskedTextBox13.Text))
                        {
                            MessageBox.Show("Hibás érték!");
                            maskedTextBox14.Text = "";
                        }
                        else
                        {
                            textBox27.Enabled = true;
                            textBox27.BackColor = Color.Tomato;
                            int mTbox15 = (Convert.ToInt32(maskedTextBox13.Text) - Convert.ToInt32(maskedTextBox14.Text));
                            maskedTextBox15.Text = mTbox15.ToString();

                            //int szum_PRI = Convert.ToInt32(maskedTextBox14.Text) + Convert.ToInt32(maskedTextBox15.Text);
                            //int mTbox15 = szum_PRI - Convert.ToInt32(maskedTextBox14.Text);
                            //maskedTextBox15.Text = mTbox15.ToString();
                        }
                    }
                }
               
            }
            catch
            {
            }
        }

        private void maskedTextBox15_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
                if (maskedTextBox15.Text.Length > 0)
                {
                    if (maskedTextBox14.Text.Length == 0)
                    {
                        maskedTextBox14.Text = "0";
                    }
                    if (Convert.ToInt32(maskedTextBox15.Text) > (Convert.ToInt32(maskedTextBox13.Text) - Convert.ToInt32(maskedTextBox14.Text)))
                    {
                        MessageBox.Show("Hibás érték!");
                        maskedTextBox15.Text = "";
                    }
                    else
                    {
                        textBox28.Enabled = true;
                        textBox28.BackColor = Color.Tomato;
                        maskedTextBox14.Text = (Convert.ToInt32(maskedTextBox13.Text) - Convert.ToInt32(maskedTextBox15.Text)).ToString();
                    }
                }
                
                if (maskedTextBox15.Text.Length == 0 || maskedTextBox15.Text == "0")
                    {
                        textBox28.Enabled = false;
                        textBox28.Text = "";
                        textBox28.BackColor = Color.Empty;
                    }
             //}
            //catch
            //{
            //}
        }

        private void maskedTextBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox20.Text != "0" && maskedTextBox20.Text.Length > 0)
                {
                    maskedTextBox22.Enabled = true;
                    maskedTextBox23.Enabled = true;
                    maskedTextBox22.Text = "";
                }

                if (maskedTextBox20.Text.Length == 0 || maskedTextBox20.Text == "0")
                {
                    maskedTextBox22.Text = "";
                    maskedTextBox23.Enabled = false;
                    textBox38.Text = "";
                    textBox38.Enabled = false;

                    maskedTextBox23.Text = "";
                    maskedTextBox22.Enabled = false;
                    textBox35.Text = "";
                    textBox35.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox22.Text.Length > 0)
                {
                    if (Convert.ToInt32(maskedTextBox22.Text) > Convert.ToInt32(maskedTextBox20.Text))
                    {
                        MessageBox.Show("Hibás adatrögzítés!");
                        maskedTextBox22.Text = "";
                    }
                    else
                    {
                        textBox38.Enabled = true;
                        textBox38.BackColor = Color.Tomato;
                        int mTbox23 = (Convert.ToInt32(maskedTextBox20.Text) - Convert.ToInt32(maskedTextBox22.Text));
                        maskedTextBox23.Text = mTbox23.ToString();
                    }
                }

                if (maskedTextBox22.Text.Length == 0 || maskedTextBox22.Text == "0")
                {
                    textBox38.Enabled = false;
                    textBox38.Text = "";
                    textBox38.BackColor = Color.Empty;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox23.Text.Length > 0)
                {
                    if (Convert.ToInt32(maskedTextBox23.Text) > Convert.ToInt32(maskedTextBox20.Text))
                    {
                        MessageBox.Show("Hibás adatrögzítés!");
                        maskedTextBox23.Text = "";
                    }
                    else
                    {
                        textBox35.Enabled = true;
                        textBox35.BackColor = Color.Tomato;
                        maskedTextBox22.Text = (Convert.ToInt32(maskedTextBox20.Text) - Convert.ToInt32(maskedTextBox23.Text)).ToString();
                    }
                }

                if (maskedTextBox23.Text.Length == 0 || maskedTextBox23.Text == "0")
                {
                    textBox35.Enabled = false;
                    textBox35.Text = "";
                    textBox35.BackColor = Color.Empty;
                }
            }
            catch
            {
                if (maskedTextBox22.Text.Length == 0)
                {
                    maskedTextBox22.Text = "0";
                }
            }
        }

        private void maskedTextBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox21.Text != "0" && maskedTextBox21.Text.Length > 0)
                {
                    maskedTextBox24.Enabled = true;
                    maskedTextBox25.Enabled = true;
                    maskedTextBox24.Text = "";
                }

                if (maskedTextBox21.Text.Length == 0 || maskedTextBox21.Text == "0")
                {
                    maskedTextBox24.Text = "";
                    maskedTextBox25.Enabled = false;
                    textBox43.Text = "";
                    textBox43.Enabled = false;

                    maskedTextBox25.Text = "";
                    maskedTextBox24.Enabled = false;
                    textBox40.Text = "";
                    textBox40.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox24_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox24.Text.Length > 0)
                {
                    if (Convert.ToInt32(maskedTextBox24.Text) > Convert.ToInt32(maskedTextBox21.Text))
                    {
                        MessageBox.Show("Hibás adatrögzítés!");
                        maskedTextBox24.Text = "";
                    }
                    else
                    {
                        textBox43.Enabled = true;
                        textBox43.BackColor = Color.Tomato;
                        maskedTextBox25.Text = (Convert.ToInt32(maskedTextBox21.Text) - Convert.ToInt32(maskedTextBox24.Text)).ToString();
                        
                    }
                }

                if (maskedTextBox24.Text.Length == 0 || maskedTextBox24.Text == "0")
                {
                    textBox43.Enabled = false;
                    textBox43.Text = "";
                    textBox43.BackColor = Color.Empty;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox25_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox25.Text.Length > 0)
                {
                    if (Convert.ToInt32(maskedTextBox25.Text) > Convert.ToInt32(maskedTextBox21.Text))
                    {
                        MessageBox.Show("Hibás adatrögzítés!");
                        maskedTextBox25.Text = ""; // IDE be kellene tenni, hogy a számított értéket adjon inkább vissza
                    }
                    else
                    {
                        textBox40.Enabled = true;
                        textBox40.BackColor = Color.Tomato;
                        maskedTextBox24.Text = (Convert.ToInt32(maskedTextBox21.Text) - Convert.ToInt32(maskedTextBox25.Text)).ToString();
                    }
                }

                if (maskedTextBox25.Text.Length == 0 || maskedTextBox25.Text == "0")
                {
                    textBox40.Enabled = false;
                    textBox40.Text = "";
                    textBox40.BackColor = Color.Empty;
                }
            }
            catch
            {
                if (maskedTextBox24.Text.Length == 0)
                {
                    maskedTextBox24.Text = "0";
                }
            }
        
        }

        private void maskedTextBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox16.Text != "0" && maskedTextBox16.Text.Length > 0)
                {
                    maskedTextBox17.Enabled = true;
                    maskedTextBox18.Enabled = true;
                    maskedTextBox19.Enabled = true;
                    maskedTextBox17.Text = "";
                    maskedTextBox18.Text = "";
                    maskedTextBox19.Text = "";
                }

                if (maskedTextBox16.Text.Length == 0 || maskedTextBox16.Text == "0")
                {
                    maskedTextBox17.Text = "";
                    maskedTextBox17.Enabled = false;
                    maskedTextBox18.Text = "";
                    maskedTextBox18.Enabled = false;
                    maskedTextBox19.Text = "";
                    maskedTextBox19.Enabled = false;
                    
                    //maskedTextBox19.Text = "";
                    textBox32.Text = "";
                    textBox32.Enabled = false;
                    
                    textBox29.Text = "";
                    textBox29.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox17_TextChanged(object sender, EventArgs e)
        {
             try
            {
                if (maskedTextBox17.Text != "0" && maskedTextBox17.Text.Length > 0)
                {
                    maskedTextBox17.Enabled = true;
                    

                    if (Convert.ToInt32(maskedTextBox17.Text) > Convert.ToInt32(maskedTextBox16.Text))
                    {
                        MessageBox.Show("A számlalevél nem lehet több, mint az összes NEK küldemény!");
                        maskedTextBox17.Text = "";
                    }

                }

                if (maskedTextBox17.Text.Length == 0 && maskedTextBox16.Text.Length > 0 || maskedTextBox17.Text == "0" && maskedTextBox16.Text.Length > 0)
                {
                    maskedTextBox17.Text = "0";

                }
                else if (maskedTextBox17.Text.Length == 0 && maskedTextBox16.Text.Length == 0 || maskedTextBox17.Text == "0" && maskedTextBox16.Text.Length == 0)
                {
                    maskedTextBox17.Text = "";
                    maskedTextBox17.Enabled = false;
                    maskedTextBox18.Text = "";
                    maskedTextBox18.Enabled = false;
                    maskedTextBox19.Text = "";
                    maskedTextBox19.Enabled = false;

                    maskedTextBox19.Text = "";
                    textBox32.Text = "";
                    textBox32.Enabled = false;

                    textBox29.Text = "";
                    textBox29.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox18.Text.Length > 0)
                {
                    if (Convert.ToInt32(maskedTextBox18.Text) > Convert.ToInt32(maskedTextBox16.Text))
                    {
                        MessageBox.Show("Hibás adatrögzítés");
                        maskedTextBox18.Text = "";
                    }
                    else
                    {
                        textBox32.Enabled = true;
                        textBox32.BackColor = Color.Tomato;
                        maskedTextBox19.Text = (Convert.ToInt32(maskedTextBox16.Text) - Convert.ToInt32(maskedTextBox18.Text)).ToString();
                    }
                }

                if (maskedTextBox18.Text.Length == 0 || maskedTextBox18.Text == "0")
                {
                    textBox32.Enabled = false;
                    textBox32.Text = "";
                    textBox32.BackColor = Color.Empty;
                }
            }
            catch
            {
            }
        }

        private void maskedTextBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox19.Text.Length > 0)
                {
                    if (Convert.ToInt32(maskedTextBox19.Text) > Convert.ToInt32(maskedTextBox16.Text))
                    {
                        MessageBox.Show("Hibás adatrögzítés!");
                        maskedTextBox19.Text = ""; // IDE be kellene tenni, hogy a számított értéket adjon inkább vissza
                    }
                    
                    else
                    {
                        textBox29.Enabled = true;
                        textBox29.BackColor = Color.Tomato;
                        maskedTextBox18.Text = (Convert.ToInt32(maskedTextBox16.Text) - Convert.ToInt32(maskedTextBox19.Text)).ToString();
                    }
                }

                if (maskedTextBox19.Text.Length == 0 || maskedTextBox19.Text == "0")
                {
                    textBox29.Enabled = false;
                    textBox29.Text = "";
                    textBox29.BackColor = Color.Empty;
                }
            }
            catch
            {
                if (maskedTextBox18.Text.Length == 0)
                {
                    maskedTextBox18.Text = "0";
                }
            }
        
        }

        private void maskedTextBox19_Leave(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(maskedTextBox19.Text) + Convert.ToInt32(maskedTextBox18.Text)) > Convert.ToInt32(maskedTextBox16.Text))
            {
                MessageBox.Show("Hibás adatrögzítés - nem egyezõ adatok!");
                maskedTextBox19.Text = "";
                textBox29.Enabled = false;
            }
        }

        private void maskedTextBox30_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox30.Text.Length > 0 && maskedTextBox30.Text != "0")
            {
                try
                {
                    if (maskedTextBox30.Text != "0" && maskedTextBox30.Text.Length > 0)
                    {
                        maskedTextBox31.Enabled = true;
                        maskedTextBox32.Enabled = true;
                    }
                }

                catch
                {
                }
            }
            else if (maskedTextBox30.Text.Length == 0 || maskedTextBox30.Text == "0")
            {
                maskedTextBox31.Enabled = false;
                maskedTextBox31.Text = "";
                maskedTextBox32.Enabled = false;
                maskedTextBox32.Text = "";
            }
        }

        private void maskedTextBox31_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox31.Text.Length > 0 )
            {
                try
                {
                    if (maskedTextBox31.Text.Length > 0 && maskedTextBox31.Text != "0")
                    {
                        textBox8.Enabled = true;
                        textBox8.BackColor = Color.Tomato;
                        maskedTextBox32.Text = (Convert.ToInt32(maskedTextBox30.Text) - Convert.ToInt32(maskedTextBox31.Text)).ToString();
                    }
                    else
                    {
                        textBox8.Enabled = false;
                        textBox8.Text = "";
                        textBox8.BackColor = Color.Empty;
                        
                    }

                    if (Convert.ToInt32(maskedTextBox31.Text) > Convert.ToInt32(maskedTextBox30.Text) ||
                        Convert.ToInt32(maskedTextBox32.Text) > Convert.ToInt32(maskedTextBox30.Text))
                    {
                        textBox8.Text = "";
                        textBox8.Enabled = false;
                        textBox8.BackColor = Color.Empty;
                        MessageBox.Show("A részösszeg nem lehet nagyobb, mint az összesen érték!");
                        maskedTextBox31.Text = "";
                        maskedTextBox32.Text = "";

                    }
                }
                catch
                {

                }
            }
            else if (maskedTextBox31.Text.Length == 0 || maskedTextBox31.Text == "0")
            {
                textBox8.Text = "";
                textBox8.Enabled = false;
                textBox8.BackColor = Color.Empty;
            }
        }

        private void maskedTextBox32_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox32.Text.Length > 0)
            {
                try
                {
                    if (maskedTextBox32.Text.Length > 0 && maskedTextBox32.Text != "0")
                    {
                        textBox7.Enabled = true;
                        textBox7.BackColor = Color.Tomato;
                        //int m31 = Convert.ToInt32(maskedTextBox30.Text) - Convert.ToInt32(maskedTextBox32.Text);

                        //if ((Convert.ToInt32(maskedTextBox30.Text) - Convert.ToInt32(maskedTextBox32.Text)) != Convert.ToInt32(maskedTextBox31.Text))// && maskedTextBox31.Text.Length > 0)
                        //if (m31 != Convert.ToInt32(maskedTextBox31.Text))
                        //{
                            maskedTextBox31.Text = (Convert.ToInt32(maskedTextBox30.Text) - Convert.ToInt32(maskedTextBox32.Text)).ToString();
                        //}
                    }
                    else
                    {
                        textBox7.Enabled = false;
                        textBox7.Text = "";
                        textBox7.BackColor = Color.Empty;
                        
                    }

                    if (Convert.ToInt32(maskedTextBox32.Text) > Convert.ToInt32(maskedTextBox30.Text) ||
                        Convert.ToInt32(maskedTextBox31.Text) > Convert.ToInt32(maskedTextBox30.Text))
                    {
                        textBox7.Text = "";
                        textBox7.BackColor = Color.Empty;
                        textBox7.Enabled = false;
                        MessageBox.Show("A részösszeg nem lehet nagyobb, mint az összesen érték!");
                        maskedTextBox31.Text = "";
                        maskedTextBox32.Text = "";
                    }
                }
                catch
                {
                }
            }
            else if (maskedTextBox32.Text.Length == 0 || maskedTextBox32.Text == "0")
            {
                textBox7.Text = "";
                textBox7.BackColor = Color.Empty;
                textBox7.Enabled = false;
            }
        }

        private void maskedTextBox33_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox33.Text.Length > 0 && maskedTextBox33.Text != "0")
            {
                try
                {
                    if (maskedTextBox33.Text != "0" && maskedTextBox33.Text.Length > 0)
                    {
                        maskedTextBox34.Enabled = true;
                        maskedTextBox35.Enabled = true;
                    }
                }

                catch
                {
                }
            }
            else if (maskedTextBox33.Text.Length == 0 || maskedTextBox33.Text == "0")
            {
                maskedTextBox34.Enabled = false;
                maskedTextBox34.Text = "";
                maskedTextBox35.Enabled = false;
                maskedTextBox35.Text = "";
            }
        }

        private void maskedTextBox34_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox34.Text.Length > 0)
            {
                try
                {
                    if (maskedTextBox34.Text.Length > 0 && maskedTextBox34.Text != "0")
                    {
                        textBox9.Enabled = true;
                        textBox9.BackColor = Color.Tomato;
                        maskedTextBox35.Text = (Convert.ToInt32(maskedTextBox33.Text) - Convert.ToInt32(maskedTextBox34.Text)).ToString();
                    }
                    else
                    {
                        textBox9.Enabled = false;
                        textBox9.Text = "";
                        textBox9.BackColor = Color.Empty;
                        
                    }

                    if (Convert.ToInt32(maskedTextBox34.Text) > Convert.ToInt32(maskedTextBox33.Text) ||
                        Convert.ToInt32(maskedTextBox35.Text) > Convert.ToInt32(maskedTextBox33.Text))
                    {
                        textBox9.Text = "";
                        textBox9.Enabled = false;
                        textBox9.BackColor = Color.Empty;
                        MessageBox.Show("A részösszeg nem lehet nagyobb, mint az összesen érték!");
                        maskedTextBox34.Text = "";
                        maskedTextBox35.Text = "";
                    }
                }
                catch
                {
                }
            }
            else if (maskedTextBox34.Text.Length == 0 || maskedTextBox34.Text == "0")
            {
                textBox9.Text = "";
                textBox9.BackColor = Color.Empty;
                textBox9.Enabled = false;
            }
        }

        private void maskedTextBox35_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox35.Text.Length > 0)
            {
                try
                {
                    if (maskedTextBox35.Text.Length > 0 && maskedTextBox35.Text != "0")
                    {
                        textBox10.Enabled = true;
                        textBox10.BackColor = Color.Tomato;
                        //if ((Convert.ToInt32(maskedTextBox33.Text) - Convert.ToInt32(maskedTextBox35.Text)) != Convert.ToInt32(maskedTextBox34.Text) && maskedTextBox34.Text.Length > 0)
                        //{
                            maskedTextBox34.Text = (Convert.ToInt32(maskedTextBox33.Text) - Convert.ToInt32(maskedTextBox35.Text)).ToString();
                        //}
                    }
                    else
                    {
                        textBox10.Enabled = false;
                        textBox10.Text = "";
                        textBox10.BackColor = Color.Empty;
                    }

                    if (Convert.ToInt32(maskedTextBox35.Text) > Convert.ToInt32(maskedTextBox33.Text) ||
                        Convert.ToInt32(maskedTextBox34.Text) > Convert.ToInt32(maskedTextBox33.Text))
                    {
                        textBox10.Text = "";
                        textBox10.Enabled = false;
                        textBox10.BackColor = Color.Empty;
                        MessageBox.Show("A részösszeg nem lehet nagyobb, mint az összesen érték!");
                        maskedTextBox34.Text = "";
                        maskedTextBox35.Text = "";
                    }
                }
                catch
                {
                }
            }
            else if (maskedTextBox35.Text.Length == 0 || maskedTextBox35.Text == "0")
            {
                textBox10.Text = "";
                textBox10.Enabled = false;
                textBox10.BackColor = Color.Empty;
            }
        }

        //private void button3_Click(object sender, EventArgs e) // Adatküldés a formcode-nak
        //{
            

        //}

        private void sp_iras_indulas_elott()
        {

            int sor = dataGridView1.Rows.Count;

            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_Kezb_Reggel", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);


            if (dataGridView1.Rows[0].Cells[0].Value != null)
            {
                for (int i = 0; i < sor; ++i)
                {

                
                    string jaras = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string TIG = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    string pri_D1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string pri_D1_Megjegyzes = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string nek_D3 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string nek_D3_Szla = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string nek_D3_Megjegyzes = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    string nemz_konyv = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string nemz_konyv_megj = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    string nemz_Prime = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string nemz_Prime_megj = dataGridView1.Rows[i].Cells[10].Value.ToString();

                    try
                    {
                        if (i == 0)
                        {
                            SZUM_Jaras = jaras; // dataGridView1.Rows[i].Cells[0].Value.ToString();
                            SZUM_TIG_engedely = TIG;// dataGridView1.Rows[i].Cells[1].Value.ToString();
                            SZUM_D1 = pri_D1; // dataGridView1.Rows[i].Cells[2].Value.ToString();
                            SZUM_D3 = nek_D3; // dataGridView1.Rows[i].Cells[3].Value.ToString();
                            SZUM_D3_szla = nek_D3_Szla;
                            SZUM_Nemz_Konyv = nemz_konyv;
                            SZUM_Nemz_Prime = nemz_Prime;
                        }
                        else
                        {
                            SZUM_Jaras = string.Concat(SZUM_Jaras, "\n", dataGridView1.Rows[i].Cells[0].Value.ToString());
                            SZUM_TIG_engedely = string.Concat(SZUM_TIG_engedely, "\n", dataGridView1.Rows[i].Cells[1].Value.ToString());
                            SZUM_D1 = string.Concat(SZUM_D1, "\n", dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());
                            SZUM_D3 = string.Concat(SZUM_D3, "\n", dataGridView1.Rows[i].Cells[3].Value.ToString().Trim());
                            SZUM_D3_szla = string.Concat(SZUM_D3_szla, "\n", dataGridView1.Rows[i].Cells[4].Value.ToString().Trim());
                            SZUM_Nemz_Konyv = string.Concat(SZUM_Nemz_Konyv, "\n", dataGridView1.Rows[i].Cells[5].Value.ToString().Trim());
                            SZUM_Nemz_Prime = string.Concat(SZUM_Nemz_Prime, "\n", dataGridView1.Rows[i].Cells[6].Value.ToString().Trim());
                        }

                    }
                    catch
                    {
                    }

                    batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                        "<Field Name='Title'>" + FormCode.posta + "</Field>" +
                        "<Field Name='Datum'>" + FormCode.datum + "</Field>" +
                        "<Field Name='Ellenorzes_helye'>" + FormCode.helye + "</Field>" +
                        "<Field Name='Csoport'>" + FormCode.csoport + "</Field>" +
                        "<Field Name='Jaras'>" + jaras + "</Field>" +

                        "<Field Name='PRI_D1_tul'>" + pri_D1.ToString().Trim() + "</Field>" +
                        "<Field Name='PRI_D1_tul_Megjegyzes'>" + pri_D1_Megjegyzes + "</Field>" +
                        "<Field Name='NEK_D3_tul'>" + nek_D3.ToString().Trim() + "</Field>" +
                        "<Field Name='NEK_D3_Szla'>" + nek_D3_Szla.ToString().Trim() + "</Field>" +
                        "<Field Name='NEK_D3_tul_Megjegyzes'>" + nek_D3_Megjegyzes + "</Field>" +
                        "<Field Name='Nemz_konyv_Db'>" + nemz_konyv.ToString().Trim() + "</Field>" +
                        "<Field Name='Nemz_konyv_Megj'>" + nemz_konyv_megj + "</Field>" +
                        "<Field Name='Nemz_Prime_DB'>" + nemz_Prime.ToString().Trim() + "</Field>" +
                        "<Field Name='Nemz_Prime_Megj'>" + nemz_Prime_megj + "</Field>" +
                        "<Field Name='TIG_engedely'>" + TIG + "</Field></Method>";

                    try
                    {
                        listService.UpdateListItems(strListID, batchElement);
                    }

                    catch
                    {
                        MessageBox.Show("Adatmentési hiba (Hibakód: IndE!");
                    }
                }

                sp_iras_reggeli_osszevont_adat();
            }
        }


        private void sp_iras_reggeli_osszevont_adat() // KÉZBESÍTÕK - REGGEL - TAB3 lap - az ismétlõdõ adatokat egy cellába rakja össze, majd azokat egy SP mezõbe írja. Kell, hogy a KTIG-nak emil mennyen, adatokkal
        {

            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_atfutas_(Reggel)", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);


                batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                    "<Field Name='Title'>" + FormCode.posta + "</Field>" +
                    "<Field Name='Datum'>" + FormCode.datum + "</Field>" +
                    "<Field Name='Jaras'>" + SZUM_Jaras + "</Field>" +

                    "<Field Name='PRI_D1_tul'>" + SZUM_D1.ToString().Trim() + "</Field>" +
                    "<Field Name='NEK_D3_tul'>" + SZUM_D3.ToString().Trim() + "</Field>" +
                    "<Field Name='NEK_D3_Szla'>" + SZUM_D3_szla.ToString().Trim() + "</Field>" +
                    "<Field Name='Nemz_konyv_Db'>" + SZUM_Nemz_Konyv.ToString().Trim() + "</Field>" +
                    "<Field Name='Nemz_Prime_DB'>" + SZUM_Nemz_Prime.ToString().Trim() + "</Field>" +
                    "<Field Name='TIG_engedely'>" + SZUM_TIG_engedely + "</Field></Method>";

                try
                {
                        listService.UpdateListItems(strListID, batchElement);
                }

                catch
                {
                    MessageBox.Show("Adatmentési hiba (Hibakód: Sp-be összevont írás (IndE)!");
                }

                        SZUM_Jaras = string.Empty;
                        SZUM_TIG_engedely = string.Empty;
                        SZUM_D1 = string.Empty;
                        SZUM_D3 = string.Empty;
                        SZUM_D3_szla = string.Empty;
                        SZUM_Nemz_Konyv = string.Empty;
                        SZUM_Nemz_Prime = string.Empty;
        }

        private void Sp_iras_indulas_utan()
        {
            int sor = dataGridView2.Rows.Count;

            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_Kezb_IndulasUtan", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);

            if (dataGridView2.Rows[0].Cells[0].Value != null)
            {
                for (int i = 0; i < sor; ++i)
                {
                    string jaras = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string TIG = dataGridView2.Rows[i].Cells[1].Value.ToString();

                    string pri_D1 = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    string pri_D1_Megjegyzes = dataGridView2.Rows[i].Cells[7].Value.ToString();
                    string nek_D3 = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    string nek_D3_Szla = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    string nek_D3_Megjegyzes = dataGridView2.Rows[i].Cells[8].Value.ToString();
                    string nemz_konyv = dataGridView2.Rows[i].Cells[5].Value.ToString();
                    string nemz_konyv_megj = dataGridView2.Rows[i].Cells[9].Value.ToString();
                    string nemz_Prime = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    string nemz_Prime_megj = dataGridView2.Rows[i].Cells[10].Value.ToString();

                    try
                    {
                        if (i == 0)
                        {
                            SZUM_Jaras = jaras; // dataGridView1.Rows[i].Cells[0].Value.ToString();
                            SZUM_TIG_engedely = TIG;// dataGridView1.Rows[i].Cells[1].Value.ToString();
                            SZUM_D1 = pri_D1; // dataGridView1.Rows[i].Cells[2].Value.ToString();
                            SZUM_D3 = nek_D3; // dataGridView1.Rows[i].Cells[3].Value.ToString();
                            SZUM_D3_szla = nek_D3_Szla;
                            SZUM_Nemz_Konyv = nemz_konyv;
                            SZUM_Nemz_Prime = nemz_Prime;
                        }
                        else
                        {
                            SZUM_Jaras = string.Concat(SZUM_Jaras, "\n", dataGridView2.Rows[i].Cells[0].Value.ToString());
                            SZUM_TIG_engedely = string.Concat(SZUM_TIG_engedely, "\n", dataGridView2.Rows[i].Cells[1].Value.ToString());
                            SZUM_D1 = string.Concat(SZUM_D1, "\n", dataGridView2.Rows[i].Cells[2].Value.ToString().Trim());
                            SZUM_D3 = string.Concat(SZUM_D3, "\n", dataGridView2.Rows[i].Cells[3].Value.ToString().Trim());
                            SZUM_D3_szla = string.Concat(SZUM_D3_szla, "\n", dataGridView2.Rows[i].Cells[4].Value.ToString().Trim());
                            SZUM_Nemz_Konyv = string.Concat(SZUM_Nemz_Konyv, "\n", dataGridView2.Rows[i].Cells[5].Value.ToString().Trim());
                            SZUM_Nemz_Prime = string.Concat(SZUM_Nemz_Prime, "\n", dataGridView2.Rows[i].Cells[6].Value.ToString().Trim());
                        }
                    }
                    catch
                    {
                    }

                    batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                        "<Field Name='Title'>" + FormCode.posta + "</Field>" +
                        "<Field Name='Datum'>" + FormCode.datum + "</Field>" +
                        "<Field Name='Ellenorzes_helye'>" + FormCode.helye + "</Field>" +
                        "<Field Name='Csoport'>" + FormCode.csoport + "</Field>" +
                        "<Field Name='Jaras'>" + jaras + "</Field>" +

                        "<Field Name='PRI_D1_tul'>" + pri_D1.ToString().Trim() + "</Field>" +
                        "<Field Name='PRI_D1_tul_Megjegyzes'>" + pri_D1_Megjegyzes + "</Field>" +
                        "<Field Name='NEK_D3_tul'>" + nek_D3.ToString().Trim() + "</Field>" +
                        "<Field Name='NEK_D3_tul_SzlaLevel'>" + nek_D3_Szla.ToString().Trim() + "</Field>" +
                        "<Field Name='NEK_D3_tul_Megjegyzes'>" + nek_D3_Megjegyzes + "</Field>" +
                        "<Field Name='Nemz_konyv_db'>" + nemz_konyv.ToString().Trim() + "</Field>" +
                        "<Field Name='Nemz_konyv_Megj'>" + nemz_konyv_megj + "</Field>" +
                        "<Field Name='Nemz_Prime_db'>" + nemz_Prime.ToString().Trim() + "</Field>" +
                        "<Field Name='Nemz_Prime_Megj'>" + nemz_Prime_megj + "</Field>" +
                        "<Field Name='TIG_engedely'>" + TIG + "</Field></Method>";

                    try
                    {
                        listService.UpdateListItems(strListID, batchElement);
                    }

                    catch
                    {
                        MessageBox.Show("Adatmentési hiba (Hibakód: SP_írás IndE!");
                    }
                }

                sp_iras_indulas_utan_osszesitett_adat();
            }
        }

        private void sp_iras_indulas_utan_osszesitett_adat()
        {
            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_atfutas_(Indulas_utan)", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);


            batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                "<Field Name='Title'>" + FormCode.posta + "</Field>" +
                "<Field Name='Datum'>" + FormCode.datum + "</Field>" +
                "<Field Name='Jaras'>" + SZUM_Jaras + "</Field>" +

                "<Field Name='PRI_D1_tul'>" + SZUM_D1.ToString().Trim() + "</Field>" +
                "<Field Name='NEK_D3_tul'>" + SZUM_D3.ToString().Trim() + "</Field>" +
                "<Field Name='NEK_D3_Szla'>" + SZUM_D3_szla.ToString().Trim() + "</Field>" +
                "<Field Name='Nemz_konyv_Db'>" + SZUM_Nemz_Konyv.ToString().Trim() + "</Field>" +
                "<Field Name='Nemz_Prime_DB'>" + SZUM_Nemz_Prime.ToString().Trim() + "</Field>" +
                "<Field Name='TIG_engedely'>" + SZUM_TIG_engedely + "</Field></Method>";

            try
            {
                listService.UpdateListItems(strListID, batchElement);
            }

            catch
            {
                MessageBox.Show("Adatmentési hiba (Hibakód: SP összesített írás (IndUtán)!");
            }

            SZUM_Jaras = string.Empty;
            SZUM_TIG_engedely = string.Empty;
            SZUM_D1 = string.Empty;
            SZUM_D3 = string.Empty;
            SZUM_D3_szla = string.Empty;
            SZUM_Nemz_Konyv = string.Empty;
            SZUM_Nemz_Prime = string.Empty;
        }

        private void Sp_iras_Pfu_Inditas()
        {
            nullazo_pfu();

            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_PFU", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);


            batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                "<Field Name='Title'>" + FormCode.posta + "</Field>" +
                "<Field Name='Datum'>" + FormCode.datum + "</Field>" +
                "<Field Name='Csoport'>" + FormCode.csoport + "</Field>" +

                "<Field Name='Indito_LU'>" + comboBox5.Text + "</Field>" +
                "<Field Name='SZUM_PRI'>" + textBox3.Text + "</Field>" +
                "<Field Name='Kesedelmes_D1_tul'>" + textBox5.Text + "</Field>" +
                "<Field Name='Teviranyitott_kesett_PRI'>" + textBox6.Text + "</Field>" +
                "<Field Name='PRI_KK_nelkul'>" + textBox14.Text + "</Field>" +
                "<Field Name='NEK_kozott_PRI'>" + textBox4.Text + "</Field>" +
                "<Field Name='NEKben_PRI_D1_tul'>" + textBox12.Text + "</Field>" +
                "<Field Name='SZUM_NEK_Gepi'>" + textBox15.Text + "</Field>" +
                "<Field Name='SZUM_NEK_Kezi'>" + textBox16.Text + "</Field>" +
                "<Field Name='NEK_D3_Gepi'>" + textBox13.Text + "</Field>" +
                "<Field Name='NEK_D3_Gepi_TevIr'>" + textBox24.Text + "</Field>" +
                "<Field Name='NEK_D3_Kezi'>" + textBox20.Text + "</Field>" +
                "<Field Name='NEK_D3_Kezi_TevIr'>" + textBox25.Text + "</Field>" +
                "<Field Name='NEK_D3tul_Gepi'>" + textBox30.Text + "</Field>" +
                "<Field Name='NEK_D3tul_Gepi_TevIr'>" + textBox33.Text + "</Field>" +
                "<Field Name='NEK_D3tul_Kezi'>" + textBox31.Text + "</Field>" +
                "<Field Name='NEK_D3tul_Kezi_TevIr'>" + textBox26.Text + "</Field></Method>";

            try
            {
                listService.UpdateListItems(strListID, batchElement);
            }

            catch
            {
                MessageBox.Show("Adatmentési hiba (Hibakód: SP LU inditás!");
            }

            //SZUM_Jaras = string.Empty;
            //SZUM_TIG_engedely = string.Empty;
            //SZUM_D1 = string.Empty;
            //SZUM_D3 = string.Empty;
            //SZUM_D3_szla = string.Empty;
            //SZUM_Nemz_Konyv = string.Empty;
            //SZUM_Nemz_Prime = string.Empty;
        }

        private void SP_iras_LCPM()
        {
            
            teamweb2.Lists listService = new teamweb2.Lists();
            listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
            listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
            System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_IRV", "");
            string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
            string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
            batchElement.SetAttribute("OnError", "Continue");
            batchElement.SetAttribute("ListVersion", "1");
            batchElement.SetAttribute("ViewName", strViewID);

            int sor = dataGridView3.Rows.Count;

            if (dataGridView3.Rows[0].Cells[0].Value != null)
            {
                for (int i = 0; i < sor-1; ++i)
                {

                    batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                        "<Field Name='Title'>" + FormCode.posta + "</Field>" +
                        "<Field Name='Datum'>" + FormCode.datum + "</Field>" +
                        "<Field Name='Csoport'>" + FormCode.csoport + "</Field>" +

                        "<Field Name='IRV_Felv_posta'>" + dataGridView3.Rows[i].Cells[1].Value.ToString() + "</Field>" +
                        "<Field Name='IRV_Kod_db'>" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "</Field></Method>";

                    try
                    {
                        listService.UpdateListItems(strListID, batchElement);
                    }

                    catch
                    {
                        MessageBox.Show("Adatmentési hiba (Hibakód: SP LCPM!");
                    }
                }
            }
        }



        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Teljeskörû")
            {
                maskedTextBox36.Enabled = true;
                maskedTextBox36.BackColor = Color.Tomato;
            }
            else
            {
                maskedTextBox36.Enabled = false;
                maskedTextBox36.Text = "";
                maskedTextBox36.BackColor = Color.Empty;
            }
        }

        private void felv_chk()
        {
            int szum_felv = Convert.ToInt32(maskedTextBox26.Text) + Convert.ToInt32(maskedTextBox27.Text) + Convert.ToInt32(maskedTextBox28.Text) + Convert.ToInt32(maskedTextBox29.Text) + Convert.ToInt32(maskedTextBox30.Text) + Convert.ToInt32(maskedTextBox33.Text);

            if (szum_felv > 0 && FormCode.felvetel_chk == "0")
            {
                FormCode.felvetel_chk = "1";
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.Text.Length > 0)
            {
                textBox27.BackColor = Color.Empty;
            }
            else
            {
                textBox27.BackColor = Color.Tomato;
            }
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (textBox28.Text.Length > 0)
            {
                textBox28.BackColor = Color.Empty;
            }
            else
            {
                textBox28.BackColor = Color.Tomato;
            }
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            if (textBox38.Text.Length > 0)
            {
                textBox38.BackColor = Color.Empty;
            }
            else
            {
                textBox38.BackColor = Color.Tomato;
            }
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (textBox35.Text.Length > 0)
            {
                textBox35.BackColor = Color.Empty;
            }
            else
            {
                textBox35.BackColor = Color.Tomato;
            }
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (textBox43.Text.Length > 0)
            {
                textBox43.BackColor = Color.Empty;
            }
            else
            {
                textBox43.BackColor = Color.Tomato;
            }
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            if (textBox40.Text.Length > 0)
            {
                textBox40.BackColor = Color.Empty;
            }
            else
            {
                textBox40.BackColor = Color.Tomato;
            }
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            if (textBox32.Text.Length > 0)
            {
                textBox32.BackColor = Color.Empty;
            }
            else
            {
                textBox32.BackColor = Color.Tomato;
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            if (textBox29.Text.Length > 0)
            {
                textBox29.BackColor = Color.Empty;
            }
            else
            {
                textBox29.BackColor = Color.Tomato;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0)
            {
                textBox8.BackColor = Color.Empty;
            }
            else
            {
                textBox8.BackColor = Color.Tomato;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0)
            {
                textBox7.BackColor = Color.Empty;
            }
            else
            {
                textBox7.BackColor = Color.Tomato;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0)
            {
                textBox9.BackColor = Color.Empty;
            }
            else
            {
                textBox9.BackColor = Color.Tomato;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length > 0)
            {
                textBox10.BackColor = Color.Empty;
            }
            else
            {
                textBox10.BackColor = Color.Tomato;
            }
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            if (textBox46.Text.Length > 0)
            {
                textBox46.BackColor = Color.Empty;
            }
            else
            {
                textBox46.BackColor = Color.Tomato;
            }
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            if (textBox47.Text.Length > 0)
            {
                textBox47.BackColor = Color.Empty;
            }
            else
            {
                textBox47.BackColor = Color.Tomato;
            }
        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            if (textBox48.Text.Length > 0)
            {
                textBox48.BackColor = Color.Empty;
            }
            else
            {
                textBox48.BackColor = Color.Tomato;
            }
        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {
            if (textBox49.Text.Length > 0)
            {
                textBox49.BackColor = Color.Empty;
            }
            else
            {
                textBox49.BackColor = Color.Tomato;
            }
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            if (textBox45.Text.Length > 0)
            {
                textBox45.BackColor = Color.Empty;
            }
            else
            {
                textBox45.BackColor = Color.Tomato;
            }
        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {
            if (textBox50.Text.Length > 0)
            {
                textBox50.BackColor = Color.Empty;
            }
            else
            {
                textBox50.BackColor = Color.Tomato;
            }
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {
            if (textBox51.Text.Length > 0)
            {
                textBox51.BackColor = Color.Empty;
            }
            else
            {
                textBox51.BackColor = Color.Tomato;
            }
        }

        private void textBox52_TextChanged(object sender, EventArgs e)
        {
            if (textBox52.Text.Length > 0)
            {
                textBox52.BackColor = Color.Empty;
            }
            else
            {
                textBox52.BackColor = Color.Tomato;
            }
        }

        private void maskedTextBox36_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox36.Text.Length > 0 && maskedTextBox36.Text != "0")
            {
                maskedTextBox36.BackColor = Color.Empty;
            }
        }


        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                dataGridView1.AllowUserToDeleteRows = false;
                MessageBox.Show("Sortörlés csak akkor lehetséges, ha már legalább 2 járásra rögzítettél adatot!", "Nem engedélyezett mûvelet!");
            }
            else
            {
                dataGridView1.AllowUserToDeleteRows = true;
                string jaras = dataGridView1.CurrentRow.Cells[0].Value.ToString() + ",";
                textBox1.Text = textBox1.Text.Replace(jaras, "");

                if (dataGridView1.Rows.Count == 2)
                {
                    dataGridView1.AllowUserToDeleteRows = false;
                }
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView2.Rows.Count == 1)
            {
                dataGridView2.AllowUserToDeleteRows = false;
                MessageBox.Show("Sortörlés csak akkor lehetséges, ha már legalább 2 járásra rögzítettél adatot!", "Nem engedélyezett mûvelet!");
            }
            else
            {
                dataGridView2.AllowUserToDeleteRows = true; 
                string jaras = dataGridView2.CurrentRow.Cells[0].Value.ToString() + ",";
                textBox2.Text = textBox2.Text.Replace(jaras, "");

                if (dataGridView2.Rows.Count == 2)
                {
                    dataGridView2.AllowUserToDeleteRows = false;
                }
            }
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            maskedTextBox6.Select();
        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        // ------------------------ Billentyûzet korlátozása --------------------------- \\
        
        private void textBox_Keypress(object sender, KeyPressEventArgs e)       // a textbox-oknál CSAK a számokat engedélyezi
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // ------------------------------------------------------------------------------ \\

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox5.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox5.Text) > Convert.ToInt32(textBox3.Text))
                {
                    DialogResult dr_t5 = MessageBox.Show("A késedelmes küldemények száma nem lehet több, mint az összes küldemény!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox6.Enabled = false;
                    textBox5.Focus();
                }
                else if (textBox5.Text == "0" || textBox5.Text == "")
                {
                    textBox6.Text = "0";
                    textBox6.Enabled = false;
                }
                else
                {
                    textBox6.Enabled = true;
                    textBox6.Focus();
                }
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox6.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox6.Text) > Convert.ToInt32(textBox5.Text))
                {
                    DialogResult dr_t6 = MessageBox.Show("A tévirányított, késedelmes küldemények száma nem lehet több, mint az összes késedelmesen továbbított küldemény!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox6.Text = "0";
                    textBox6.Focus();
                }
            }
        }

        private void textBox12_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox12.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox12.Text) > Convert.ToInt32(textBox4.Text))
                {
                    DialogResult dr_t12 = MessageBox.Show("A NEK között talált, késedelmes PRI küldemények száma nem lehet több, mint a NEK között talált összes PRI küldemény!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox12.Text = "0";
                    textBox12.Focus();
                }
            }
        }

        private void textBox14_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox14.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox14.Text) > Convert.ToInt32(textBox3.Text))
                {
                    DialogResult dr_t14 = MessageBox.Show("A 'KK' jelzõ nélküli PRI küldemények száma nem lehet több, mint az összes PRI küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox14.Text = "0";
                    textBox14.Focus();
                }
                else
                {
                    textBox15.Focus();
                }
            }
            
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox13.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox13.Text) > Convert.ToInt32(textBox15.Text))
                {
                    DialogResult dr_t13 = MessageBox.Show("A D+3 késedelmes NEK küldemények (Gépi) száma nem lehet több, mint az összes NEK küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox13.Text = "0";
                    textBox13.Focus();
                }
                else
                {
                    textBox24.Enabled = true;
                    textBox24.Focus();
                }
            }
        }

        private void textBox24_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox24.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox24.Text) > Convert.ToInt32(textBox13.Text))
                {
                    DialogResult dr_t24 = MessageBox.Show("A tévirányított (Gépi), D+3 késedelmes NEK küldemények száma nem lehet több, mint az összes NEK D+3 (Gépi) küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox24.Text = "0";
                    textBox24.Focus();
                }
            }
        }

        private void textBox20_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox20.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox20.Text) > Convert.ToInt32(textBox16.Text))
                {
                    DialogResult dr_t20 = MessageBox.Show("A D+3 késedelmes NEK küldemények (Kézi) száma nem lehet több, mint az összes NEK küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox20.Text = "0";
                    textBox20.Focus();
                }
                else if (textBox20.Text == "0" || textBox20.Text == "")
                {
                    textBox25.Text = "0";
                    textBox25.Enabled = false;
                }
                else
                {
                    textBox25.Enabled = true;
                    textBox25.Focus();
                }
            }
        }

        private void textBox25_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox25.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox25.Text) > Convert.ToInt32(textBox20.Text))
                {
                    DialogResult dr_t25 = MessageBox.Show("A tévirányított (Kézi), D+3 késedelmes NEK küldemények száma nem lehet több, mint az összes NEK D+3 (Kézi) küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox25.Text = "0";
                    textBox25.Focus();
                }
            }
        }

        private void textBox30_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox30.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox30.Text) > Convert.ToInt32(textBox15.Text))
                {
                    DialogResult dr_t30 = MessageBox.Show("A D+3 késedelmes NEK küldemények (Gépi) száma nem lehet több, mint az összes NEK küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox30.Text = "0";
                    textBox30.Focus();
                    textBox33.Enabled = false;

                }
                else if (textBox30.Text == "0" || textBox30.Text == "")
                {
                    textBox33.Text = "0";
                    textBox33.Enabled = false;
                }
                else
                {
                    textBox33.Enabled = true;
                    textBox33.Focus();
                }
            }
        }

        private void textBox33_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox33.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox33.Text) > Convert.ToInt32(textBox30.Text))
                {
                    DialogResult dr_t33 = MessageBox.Show("A tévirányított (Gépi), D+3 napon túli késedelmes NEK küldemények száma nem lehet több, mint az összes NEK D+3 (Gépi) küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox33.Text = "0";
                    textBox33.Focus();
                }
            }
        }

        private void textBox31_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox31.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox31.Text) > Convert.ToInt32(textBox16.Text))
                {
                    DialogResult dr_t31 = MessageBox.Show("A D+3 napon túli késedelmes NEK küldemények (Kézi) száma nem lehet több, mint az összes NEK küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox31.Text = "0";
                    textBox31.Focus();
                }
                else if (textBox31.Text == "0" || textBox31.Text == "")
                {
                    textBox26.Text = "0";
                    textBox26.Enabled = false;
                }
                else
                {
                    textBox26.Enabled = true;
                    textBox26.Focus();
                }
            }
        }

        private void textBox26_Validating(object sender, CancelEventArgs e)
        {
            if ((textBox26.Text).Length > 0)
            {
                if (Convert.ToInt32(textBox26.Text) > Convert.ToInt32(textBox31.Text))
                {
                    DialogResult dr_t26 = MessageBox.Show("A tévirányított (Kézi), D+3 napon túli késedelmes NEK küldemények száma nem lehet több, mint az összes NEK D+3 (Kézi) küldemény száma!\n\nKérem, hogy helyes értéket megadni szíveskedj!", "Hibás érték!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox26.Text = "0";
                    textBox26.Focus();
                }
                else
                {
                    textBox4.Focus();
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text.Length > 0)
            {
                textBox3.Enabled = true;
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                dataGridView3.Enabled = true;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox3.Text) > 0 && textBox3.Text.Length > 0)
                {
                    textBox5.Enabled = true;
                    textBox5.Focus();
                    textBox14.Enabled = true;
                }
                else
                {
                    textBox5.Enabled = false;
                    if (textBox5.Text != "")
                    {
                        textBox5.Text = "0";
                    }

                    textBox14.Enabled = false;
                    if (textBox14.Text != "")
                    {
                        textBox14.Text = "0";
                    }
                }
            }
            catch (System.FormatException)
            {
                textBox3.Text = "0";
                textBox3.Focus();
            }
        }

        private void textBox15_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox15.Text) > 0 && textBox15.Text.Length > 0)
                {
                    textBox13.Enabled = true;
                    textBox30.Enabled = true;
                    textBox4.Enabled = true;
                }
                else
                {
                    textBox13.Enabled = false;
                    textBox30.Enabled = false;

                    if (textBox13.Text != "")
                    {
                        textBox13.Text = "0";
                    }
                    
                    if (textBox30.Text != "")
                    {
                        textBox30.Text = "0";
                    }

                    if (textBox15.Text.Length == 0 && textBox16.Text.Length == 0 ||
                        Convert.ToInt32(textBox15.Text) == 0 && Convert.ToInt32(textBox16.Text) == 0)
                    {
                        textBox4.Enabled = false;
                        textBox4.Text = "0";
                    }
                }
            }
            catch (System.FormatException)
            {
                textBox15.Text = "0";
                textBox15.Focus();
            }
        }

        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox16.Text) > 0 && textBox16.Text.Length > 0 ||
                    Convert.ToInt32(textBox15.Text) == 0 && Convert.ToInt32(textBox16.Text) == 0)
                {
                    textBox20.Enabled = true;
                    textBox31.Enabled = true;
                    textBox4.Enabled = true;
                    textBox13.Focus();
                }
                else
                {
                    textBox20.Enabled = false;
                    textBox31.Enabled = false;

                    if (textBox20.Text != "")
                    {
                        textBox20.Text = "0";
                    }

                    if (textBox31.Text != "")
                    {
                        textBox31.Text = "0";
                    }

                    if (textBox15.Text.Length == 0 && textBox16.Text.Length == 0)
                    {
                        textBox4.Enabled = false;
                        textBox4.Text = "0";
                    }
                }
            }
            catch (System.FormatException)
            {
                textBox16.Text = "0";
                textBox16.Focus();
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text.Length > 0 && Convert.ToInt32(textBox4.Text) > 0)
            {
                textBox12.Enabled = true;
                textBox12.Focus();
            }
            //else if (Convert.ToInt32(textBox4.Text) > (Convert.ToInt32(textBox15.Text) + Convert.ToInt32(textBox16.Text)))
            //{
            //    DialogResult dr_04 = MessageBox.Show("Nem találhattál a megszámlált NEK között több PRI küldeményt, mint amennyi NEK-t számláltál!", "Adatrögzítési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
            else if (textBox4.Text.Length > 0 && textBox4.Text == "0")
            {
                textBox12.Enabled = false;
                textBox12.Text = "0";
                textBox4.Focus();
            }
            else
            {
                textBox4.Text = "0";
                textBox12.Enabled = false;
                textBox12.Text = "0";
            }
        }

        private void nullazo_pfu()
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }

            if (textBox5.Text == "")
            {
                textBox5.Text = "0";
            }

            if (textBox6.Text == "")
            {
                textBox6.Text = "0";
            }

            if (textBox14.Text == "")
            {
                textBox14.Text = "0";
            }

            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }

            if (textBox12.Text == "")
            {
                textBox12.Text = "0";
            }

            if (textBox15.Text == "")
            {
                textBox15.Text = "0";
            }

            if (textBox16.Text == "")
            {
                textBox16.Text = "0";
            }

            if (textBox13.Text == "")
            {
                textBox13.Text = "0";
            }

            if (textBox24.Text == "")
            {
                textBox24.Text = "0";
            }

            if (textBox20.Text == "")
            {
                textBox20.Text = "0";
            }

            if (textBox25.Text == "")
            {
                textBox25.Text = "0";
            }

            if (textBox30.Text == "")
            {
                textBox30.Text = "0";
            }

            if (textBox33.Text == "")
            {
                textBox33.Text = "0";
            }

            if (textBox31.Text == "")
            {
                textBox31.Text = "0";
            }
            
            if (textBox26.Text == "")
            {
                textBox26.Text = "0";
            }
        }

        private void lcpmTest()
        {
            int sor = dataGridView3.Rows.Count;
            
                for (int i = 0; i < sor-1; ++i)
                {
                    if (dataGridView3.Rows[i].Cells[0].Value != null && dataGridView3.Rows[i].Cells[1].Value == null ||
                        dataGridView3.Rows[i].Cells[0].Value == null && dataGridView3.Rows[i].Cells[1].Value != null)
                    {
                        DialogResult dr_lcpm = MessageBox.Show("Az LCPM táblázatba nem rögzítettél minden szükséges adatot!\n\nAmíg a hiányzó adatokat nem pótolod, a mentés nem lesz lehetséges!", "Adatrögzítési hiba!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        hibas = true;
                        break;
                    }
                    else
                    {
                        hibas = false;       
                    }
                }

                if (hibas == true)
                {
                    //MessageBox.Show("Megáll");
                }
                else
                {
                    DialogResult dialogresult = MessageBox.Show("Biztos, hogy befejezed az adatrögzítést?\n\n Az adatlap bezárását követõen megkezdõdik az adatok adatbázisba történõ küldése, így azokban már nem tudsz módosítást végezni.\n\n A továbbiakban csak a hibás, ezért még el nem tárolt adatokat tudod  módosítani!", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (dialogresult == DialogResult.No)
                    {
                    }
                    else
                    {
                        nullazo_tab1();
                        nullazo_tab2();
                        
                        FormCode.u_PRI = maskedTextBox26.Text;
                        FormCode.u_NEK = maskedTextBox27.Text;
                        FormCode.F_PRI = maskedTextBox30.Text;
                        FormCode.f_NEK = maskedTextBox33.Text;
                        FormCode.f_PRI_felv = maskedTextBox31.Text;
                        FormCode.f_PRI_felv_m = textBox8.Text;
                        FormCode.f_PRI_rov = maskedTextBox32.Text;
                        FormCode.f_PRI_rov_m = textBox7.Text;
                        FormCode.f_NEK_felv_SZUM = maskedTextBox33.Text;
                        FormCode.f_NEK_felv = maskedTextBox34.Text;
                        FormCode.f_NEK_felv_m = textBox9.Text;
                        FormCode.f_NEK_rov = maskedTextBox35.Text;
                        FormCode.f_NEK_rov_m = textBox10.Text;
                        FormCode.f_KK = comboBox1.Text;
                        FormCode.f_KK_db = maskedTextBox36.Text;
                        FormCode.f_KK_koz = comboBox2.Text;
                        FormCode.f_PRI_uvk = maskedTextBox28.Text;
                        FormCode.f_NEK_uvk = maskedTextBox29.Text;

                        FormCode.k_PRI_SZUM = maskedTextBox13.Text.Trim();
                        FormCode.k_Nemz_Konyvelt = maskedTextBox20.Text.Trim();
                        FormCode.k_Nemz_Prime = maskedTextBox21.Text.Trim();
                        FormCode.k_NEK_SZUM = maskedTextBox16.Text.Trim();
                        FormCode.k_NEK_szla = maskedTextBox17.Text.Trim();
                        FormCode.k_PRI_Felv = maskedTextBox14.Text.Trim();
                        FormCode.k_PRI_Felv_m = textBox27.Text;
                        FormCode.k_PRI_Kezb = maskedTextBox15.Text.Trim();
                        FormCode.k_PRI_Kezb_m = textBox28.Text;
                        FormCode.k_Nemz_Konyv_Rov = maskedTextBox22.Text.Trim();
                        FormCode.k_Nemz_Konyv_Rov_m = textBox38.Text;
                        FormCode.k_Nemz_Konyv_Kezb = maskedTextBox23.Text.Trim();
                        FormCode.k_Nemz_Konyv_Kezb_m = textBox35.Text;
                        FormCode.k_Nemz_Prime_Rov = maskedTextBox24.Text.Trim();
                        FormCode.k_Nemz_Prime_Rov_m = textBox43.Text;
                        FormCode.k_Nemz_Prime_Kezb = maskedTextBox25.Text.Trim();
                        FormCode.k_Nemz_Prime_Kezb_m = textBox40.Text;
                        FormCode.k_NEK_Rov = maskedTextBox18.Text.Trim();
                        FormCode.k_NEK_Rov_m = textBox32.Text;
                        FormCode.k_NEK_Kezb = maskedTextBox19.Text.Trim();
                        FormCode.k_NEK_Kezb_m = textBox29.Text;


                        felv_chk();
                        sp_iras_indulas_elott();
                        Sp_iras_indulas_utan();

                        if (comboBox5.Text != "")
                        {
                            Sp_iras_Pfu_Inditas();
                            SP_iras_LCPM();
                        }

                        FormCode.ChkList_Kezd_IndElott = textBox1.Text;
                        FormCode.ChkList_Kezd_IndUtan = textBox2.Text;


                        this.Close();
                    }   //MessageBox.Show("futhat a többi...");
                }
        }

        private void button4_Click(object sender, EventArgs e)      // Adatküldés a formcode-nak
        {
            lcpmTest();
        }
        
                
    }
}