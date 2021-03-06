using Microsoft.Office.InfoPath;
using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using mshtml;

namespace PRI_adatlap
{
    public partial class FormCode
    {
        
        public void InternalStartup()
        {
            ((ButtonEvent)EventManager.ControlEvents["btn_Save"]).Clicked += new ClickedEventHandler(btn_Save_Clicked);
            EventManager.XmlEvents["/my:sajátMezők/my:Alapadatok/my:LogIn"].Changed += new XmlChangedEventHandler(LogIn_Changed);
            //EventManager.XmlEvents["/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_NEK_Szla_Db"].Changed += new XmlChangedEventHandler(Kezb_IndE_NEK_Szla_Db_Changed);
            //EventManager.XmlEvents["/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Kezb_IndE_NEK_D3_Szla"].Changed += new XmlChangedEventHandler(Kezb_IndE_NEK_D3_Szla_Changed);
            //EventManager.XmlEvents["/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan/my:Kezb_IndUtan_NEK_Szla_DB"].Changed += new XmlChangedEventHandler(Kezb_IndUtan_NEK_Szla_DB_Changed);
            //((ButtonEvent)EventManager.ControlEvents["btn_tst"]).Clicked += new ClickedEventHandler(btn_WinForm_Start_Clicked);
            ((ButtonEvent)EventManager.ControlEvents["btn_WinForm_Start"]).Clicked += new ClickedEventHandler(btn_WinForm_Start_Clicked);
            //((ButtonEvent)EventManager.ControlEvents["btn_WinForm_Start"]).Clicked += new ClickedEventHandler(btn_WinForm_Start_Clicked_1);
            //((ButtonEvent)EventManager.ControlEvents["btn_save_WinForm"]).Clicked += new ClickedEventHandler(btn_save_WinForm_Clicked);
            ((ButtonEvent)EventManager.ControlEvents["btn_save_WinForm"]).Clicked += new ClickedEventHandler(btn_Save_Clicked);
            ((ButtonEvent)EventManager.ControlEvents["btn_MK"]).Clicked += new ClickedEventHandler(btn_MK_Clicked);
        }

        public static string posta;
        public static string datum;
        public static string helye;
        public static string csoport;
        public static int adatkuldes;

        public static string IntTerv_gond;
        public static string Belyegzes_gond;
        public static string KK_Hasznalat_gond;
        public static string KK_Rogzites_gond;
        public static string felvetel_chk;

        public static string u_PRI; // MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_UgyfTer_PRI", Names
        public static string u_NEK;
        public static string F_PRI;
        public static string f_NEK;
        public static string f_PRI_felv; 
        public static string f_PRI_felv_m;
        public static string f_PRI_rov;
        public static string f_PRI_rov_m;
        public static string f_NEK_felv_SZUM;
        public static string f_NEK_felv;
        public static string f_NEK_felv_m;
        public static string f_NEK_rov;
        public static string f_NEK_rov_m;
        public static string f_KK;
        public static string f_KK_db;
        public static string f_KK_koz;
        public static string f_PRI_uvk;
        public static string f_NEK_uvk;

        public static string k_PRI_SZUM;
        public static string k_Nemz_Konyvelt;
        public static string k_Nemz_Prime;
        public static string k_NEK_SZUM;
        public static string k_NEK_szla;

        public static string k_PRI_Felv;
        public static string k_PRI_Felv_m;
        public static string k_PRI_Kezb;
        public static string k_PRI_Kezb_m;
        public static string k_Nemz_Konyv_Rov;
        public static string k_Nemz_Konyv_Rov_m;
        public static string k_Nemz_Konyv_Kezb;
        public static string k_Nemz_Konyv_Kezb_m;
        public static string k_Nemz_Prime_Rov;
        public static string k_Nemz_Prime_Rov_m;
        public static string k_Nemz_Prime_Kezb;
        public static string k_Nemz_Prime_Kezb_m;
        public static string k_NEK_Rov;
        public static string k_NEK_Rov_m;
        public static string k_NEK_Kezb;
        public static string k_NEK_Kezb_m;

        public static string ChkList_Kezd_IndElott;
        public static string ChkList_Kezd_IndUtan;

        public static XPathNodeIterator pfuLista;
        public static XPathNodeIterator postaLista;


        


        public void btn_Save_Clicked(object sender, ClickedEventArgs e)
        {
            string engedelyezettJaras = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Eng_Jaras_Db", NamespaceManager).Value;
            string szumRogzitettJaras = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:SZUM_TIG_Engedely", NamespaceManager).Value;
            
            //if (Convert.ToInt32(engedelyezettJaras) != 0 && Convert.ToInt32(engedelyezettJaras) != Convert.ToInt32(szumRogzitettJaras))
            //{
            //    MessageBox.Show
            //    ("Adatrögzítési hiba!  \n\n FIGYELEM: Az engedéllyel rendelkező és az általad rögzített, engedéllyel rendelkező járások száma nem egyezik! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges"
            //    , "Figyelem!");//, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            //}
            //else
            //{
                mentes_chk();
                //mentes(sender, e);
            //}
        }

        public void EK_chk()    //Ellenőrzési könyvi bejegyzésre figyelmeztetés
        {
            string IntTerv = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Intezkedesi_ertekeles", NamespaceManager).Value;
            string Belyegzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Belyegzes_ertekeles", NamespaceManager).Value;
            string KK_hasznalat = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Haszn_Db", NamespaceManager).Value;
            string KK_Rogzites = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Rogzites_Db", NamespaceManager).Value;

            if (IntTerv.Length > 0)
                {
                IntTerv_gond = "Hiba";
                }
            else
                {
                    IntTerv_gond = "";
                }

                if (Belyegzes.ToString() != "0")
                {
                    Belyegzes_gond = "Hiba";
                }
                else
                {
                    Belyegzes_gond = "";
                }

            if (KK_hasznalat.ToString() != "0")
                {
                   KK_Hasznalat_gond = "Hiba";
                }
                else
                {
                    KK_Hasznalat_gond = "";
                }
            
            if (KK_Rogzites.ToString() != "0")
                {
                    KK_Rogzites_gond = "Hiba";
                }
                else
                {
                    KK_Rogzites_gond = "";
                }

            if (IntTerv_gond == "Hiba" || Belyegzes_gond == "Hiba" || KK_Rogzites_gond == "Hiba" || KK_Hasznalat_gond == "Hiba")
            {
                EK_form form1 = new EK_form();
                form1.ShowDialog();
            }
        }

        public void mentes_chk()
        {
            string Felv_Pri_SZUM = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_PRI_SZUM_Db", NamespaceManager).Value;
            string CHK_PRI = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:CHK_PRI", NamespaceManager).Value;
            string Felv_NEK_SZUM = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_NEK_SZUM_Db", NamespaceManager).Value;
            string CHK_NEK = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:CHK_Felv_NEK", NamespaceManager).Value;
            string Kezb_IndE_PRI_DB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_PRI_Db", NamespaceManager).Value;
            string Kezb_IndE_NEK_DB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_NEK_Db", NamespaceManager).Value;
            string chk_kezb_PRI = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:CHK_Kezb_PRI", NamespaceManager).Value;
            string chk_kezb_NEK = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:cHK_Kezb_NEK", NamespaceManager).Value;

            string chkFelv_Db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:CHK_Felv_Db", NamespaceManager).Value; // Azon mezők száma, ahova db-t írtak és indokolni kell
            string chkFelv_Indoklas_DB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:CHK_Felv_Indoklas_DB", NamespaceManager).Value; //Kitöltött indolás mezők száma
            
            string felvetel = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Felvetel_eo", NamespaceManager).Value;
            string kezb_teljes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Kezb_teljes", NamespaceManager).Value;
            string kezb_reszleges = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Kezb_reszleges", NamespaceManager).Value;
            string chk_0 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Chk_0", NamespaceManager).Value;
            string chk_felvetel = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:CHK_Felvetel_SZUM", NamespaceManager).Value;
            string chk_kezbesites = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:CHK_Kezbesites", NamespaceManager).Value;

            string nemz_keses_DB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_Inde_Nemz_Konyv_DB", NamespaceManager).Value;
            string nemz_prime_DB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_Inde_Nemz_PRIME_DB", NamespaceManager).Value;
            string chk_keses = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:CHK_Nemz_Keses", NamespaceManager).Value;
            string chk_prime = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:CHK_Nemz_Prime", NamespaceManager).Value;

            string IntTerv = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Intezkedesi_vegrahajtas", NamespaceManager).Value;
            string IntTerv_megj = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Intezkedesi_ertekeles", NamespaceManager).Value;
            string Belyegzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Belyegzes_vegrehajtas", NamespaceManager).Value; ;
            string Belyegzes_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Belyegzes_ertekeles", NamespaceManager).Value;
            string KK_hasznalat = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Hasznalat", NamespaceManager).Value;
            string KK_Hasznalat_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Haszn_Db", NamespaceManager).Value;
            string KK_Rogzites = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Rogzites", NamespaceManager).Value;
            string KK_Rogzites_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Rogzites_Db", NamespaceManager).Value;
            string KK_Koz = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Koz", NamespaceManager).Value;
            string chk_KK = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:CHK_KK", NamespaceManager).Value;



            //if (chk_0 == "Nem" && felvetel == "1" && chk_felvetel == "0" && chk_KK == "0")
            //{
            //    MessageBox.Show("Adatrögzítési hiba!\n\nFIGYELEM: A kiválaszott postán csak a felvételen megállapított szabálytalanságot kell rögzíteni, csak 0 értékek nem rögzíthetők!\n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
            //    , "Figyelem!");
            //}
            //else
            //{
                //if (chk_0 == "Nem" && kezb_teljes == "1" && chk_kezbesites == "0" && (ChkList_Kezd_IndElott.Length + ChkList_Kezd_IndUtan.Length) == 0 ||
                //    chk_0 == "Nem" && kezb_reszleges == "1" && chk_kezbesites == "0" && (ChkList_Kezd_IndElott.Length + ChkList_Kezd_IndUtan.Length) == 0)
                //{
                //    MessageBox.Show("Adatrögzítési hiba!  \n\n FIGYELEM: A kiválaszott postán csak a kézbesítéssel kapcsolatban megállapított szabálytalanságot kell rögzíteni, csak 0 értékek nem rögzíthetők! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                //, "Adatrögzítési hiba!");
                //}
                //else
                //{
                    if (Felv_Pri_SZUM != CHK_PRI)
                    {
                        MessageBox.Show("A PRI 'Továbbítási késés mértéke 1 vagy több munkanap' adat nem egyezik meg a részletesen rögzített és összesített adatokkal! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                , "Adatrögzítési hiba!");
                    }
                    else
                    {
                        if (Felv_NEK_SZUM != CHK_NEK)
                        {
                            MessageBox.Show("A NEK 'Továbbítási késés mértéke 1 vagy több munkanap' adat nem egyezik meg a részletesen rögzített és összesített adatokkal! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                    , "Adatrözítési hiba!");
                        }
                        else
                        {
                            if (nemz_keses_DB != chk_keses)
                            {
                                MessageBox.Show("A Nemzetközi 'Késett könyvelt küldemény' adat nem egyezik meg a részletesen rögzített és összesített adatokkal! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                , "Adatrözítési hiba!");
                            }
                            else
                            {
                                if (nemz_prime_DB != chk_prime)
                                {
                                    MessageBox.Show("A Nemzetközi 'Késett, elsőbbségiként kezelendő közönséges küldemény' adat nem egyezik meg a részletesen rögzített és összesített adatokkal! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                , "Adatrözítési hiba!");
                                }
                                else
                                {
                                    if (felvetel == "1" && KK_hasznalat == "" ||
                                        felvetel == "1" && KK_Koz == "")
                                    {
                                        MessageBox.Show("A Közönséges Levél Küldeményazonosító kezelésével kapcsolatban nem töltöttél ki minden adatot! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                       , "Adatrögzítési hiba!");
                                    }
                                    else
                                    {
                                        if (IntTerv == "Nem megfelelő" && IntTerv_megj.Length == 0)
                                        {
                                            MessageBox.Show("Az intézkdeséi terv végrehajtásának ellenőrzése során nem megfelelőséget állapítottál meg, de annak okát nem részletezted! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                           , "Adatrögzítési hiba!");
                                        }
                                        else
                                        {
                                            if (Belyegzes == "Részleges" && Belyegzes_db == "0")
                                            {
                                                MessageBox.Show("A nem PRI közönséges küldemények hátoldalának bélyegzése során szabálytalanságot állapítottál meg, de ezt nem részletezted! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                           , "Adatrögzítési hiba!");
                                            }
                                            else
                                            {
                                                if (KK_hasznalat == "Részleges" && KK_Hasznalat_db == "0")
                                                {
                                                    MessageBox.Show("A KK jelző használata során hiányosságot állapítottál meg, de nem jelezted, hogy ez mennyi küldeményt érint! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                           , "Adatrögzítési hiba!");
                                                }
                                                else
                                                {
                                                    if (KK_Rogzites == "Részleges" && KK_Rogzites_db == "0")
                                                    {
                                                        MessageBox.Show("A KK jelzővel ellátott küldemények felvétele és IPH-ba történő rögzítése során szabálytalanságot állapítottál meg, de azt nem jelezted, hogy mennyi küldeményt érint! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                           , "Adatrögzítési hiba!");
                                                    }
                                                    else
                                                    {
                                                        if (Kezb_IndE_PRI_DB != chk_kezb_PRI)
                                                        {
                                                            MessageBox.Show("A PRI 'D+2 munkanapos vagy azon túl' adat nem egyezik meg a részletesen rögzített és összesített adatokkal! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                                    , "Adatrözítési hiba!");
                                                        }
                                                        else
                                                        {
                                                            if (Kezb_IndE_NEK_DB != chk_kezb_NEK)
                                                            {
                                                                MessageBox.Show("A NEK 'D+3 munkanapon túl' adat nem egyezik meg a részletesen rögzített és összesített adatokkal! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                                        , "Adatrözítési hiba!");
                                                            }
                                                            else
                                                            {
                                                                if (chkFelv_Db != chkFelv_Indoklas_DB)
                                                                {
                                                                    MessageBox.Show("'A reggeli munkakörnyezet ellenőrzés'-hez nem írtál minden szükséges mezőbe megjegyzést! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                                        , "Adatrözítési hiba!");
                                                                }
                                                                else
                                                                {
                                                                    string CKH_Kezb_DB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:CHK_Kezb_Db", NamespaceManager).Value;
                                                                    string Chk_Kezb_Megjegyzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:CHK_Kezb_Megjegyzes_DB", NamespaceManager).Value;

                                                                    if (CKH_Kezb_DB != Chk_Kezb_Megjegyzes)
                                                                    {
                                                                        MessageBox.Show("A kézbesítési tevékenységgel kapcsolatban nem írtál minden szükséges mezőbe megjegyzést! \n\n Amíg a hibát nem javítod, addig a mentés nem lehetséges!"
                                                            , "Adatrözítési hiba!");
                                                                    }
                                                                    else
                                                                    {
                                                                        mentes();
                                                                        //MessageBox.Show("mentés - teszt");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            //}
        //}

        public void emil()
        {
            XPathNavigator email = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:E-mail", NamespaceManager);
            string TIG = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:TIG", NamespaceManager).Value; //
            string csoport = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Csoport", NamespaceManager).Value;

            if (TIG == "Központi Területi Igazgatóság" && csoport != "Csoport4")
            {
                DialogResult dialog = MessageBox.Show("E-mailt akkor kell küldeni, ha a kézbesítőjárásokban fellelt, átfutási időn túli küldemények száma járásonként az 50 db-ot meghaladja.\n\nSzeretnéd, hogy a berögzített adatok a Területi Üzemeltetési Osztály (KTIG) részére e-mail-ban elküldésre kerüljenek?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    email.SetValue("Igen");
                }
                else
                {
                    email.SetValue("Nem");
                }
            }
        }


        public void mentes()//(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
                ("Biztos, hogy szeretnéd elmenteni az adatokat?\n\nFIGYELEM: A rögzített adatok az 'Igen' gomb megnyomását követően már nem módosíthatók!"
                , "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                intezkedesiTerv_lista();
                EK_chk();       // EK bejegyzés készítésére figyelmeztet....ha kell
                emil();

                //XPathNodeIterator sorok_Feldolgozott = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Terem_Indulas_Elott_Jaras", NamespaceManager);
                //XPathNodeIterator sorok_KiindulasUtan = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan/my:Terem_Indulas_Utan_Jaras", NamespaceManager); ;
                //XPathNodeIterator sorok_IRV = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:OLK_LU_Erkezett/my:IRV/my:IRV_PRI/my:IRV_PRI_Db", NamespaceManager); ;
                //int sorszam_Feld = sorok_Feldolgozott.Count;
                //int sorszam_Kiind = sorok_KiindulasUtan.Count;
                //int sorszam_IRV = sorok_IRV.Count;

                //string posta = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Posta", NamespaceManager).Value;
                //string datum = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Ellenorzes_datum", NamespaceManager).Value;
                //string helye = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Ellenorzes_helyszine", NamespaceManager).Value;
                //string csoport = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Csoport", NamespaceManager).Value;

                //teamweb2.Lists listService = new teamweb2.Lists();
                //listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
                //System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_Kezb_Reggel", "");
                //string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
                //string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

                //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                //System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
                //batchElement.SetAttribute("OnError", "Continue");
                //batchElement.SetAttribute("ListVersion", "1");
                //batchElement.SetAttribute("ViewName", strViewID);

                //for (int i = 1; i <= sorszam_Feld; ++i)
                //{
                //    string jaras = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Terem_Indulas_Elott_Jaras", NamespaceManager).Value;
                //    string pri_d3 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Terem_Indulas_Elott_PRI_D3", NamespaceManager).Value;
                //    string pri_d4 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Terem_Indulas_Elott_PRI_D4", NamespaceManager).Value;
                //    string nek_d5 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Terem_Indulas_Elott_NEK_D5", NamespaceManager).Value;
                //    string nek_d6 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Terem_Indulas_Elott_NEK_D6", NamespaceManager).Value;
                //    string TIG = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Terem_indulas_elott_TIG", NamespaceManager).Value;

                //    string pri_D1 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_PRI_D1_Db", NamespaceManager).Value;
                //    string pri_D1_Megjegyzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_PRI_D1_Megj", NamespaceManager).Value;
                //    string nek_D3 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_NEK_D3_Db", NamespaceManager).Value;
                //    string nek_D3_Szla = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_NEK_D3_Szla", NamespaceManager).Value;
                //    string nek_D3_Megjegyzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_NEK_D3_Megj", NamespaceManager).Value;
                //    string nemz_konyv = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_Nemz_Konyv_Db", NamespaceManager).Value;
                //    string nemz_konyv_megj = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_Nemz_Konyv_Megj", NamespaceManager).Value;
                //    string nemz_Prime = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_Nemz_PRIME_Db", NamespaceManager).Value;
                //    string nemz_Prime_megj = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_Nemz_PRIME_Megj", NamespaceManager).Value;


                //    batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                //        "<Field Name='Title'>" + posta + "</Field>" +
                //        "<Field Name='Datum'>" + datum + "</Field>" +
                //        "<Field Name='Ellenorzes_helye'>" + helye + "</Field>" +
                //        "<Field Name='Csoport'>" + csoport + "</Field>" +
                //        "<Field Name='Jaras'>" + jaras + "</Field>" +
                //        //"<Field Name='PRI_D3_alatt'>" + pri_d3 + "</Field>" +
                //        //"<Field Name='PRI_D3_felett'>" + pri_d4 + "</Field>" +
                //        //"<Field Name='NEK_D5_alatt'>" + nek_d5 + "</Field>" +
                //        //"<Field Name='NEK_D5_felett'>" + nek_d6 + "</Field>" +

                //        "<Field Name='PRI_D1_tul'>" + pri_D1 + "</Field>" +
                //        "<Field Name='PRI_D1_tul_Megjegyzes'>" + pri_D1_Megjegyzes+ "</Field>" +
                //        "<Field Name='NEK_D3_tul'>" + nek_D3 + "</Field>" +
                //        "<Field Name='NEK_D3_Szla'>" + nek_D3_Szla + "</Field>" +
                //        "<Field Name='NEK_D3_tul_Megjegyzes'>" + nek_D3_Megjegyzes + "</Field>" +
                //        "<Field Name='Nemz_konyv_Db'>" + nemz_konyv + "</Field>" +
                //        "<Field Name='Nemz_konyv_Megj'>" + nemz_konyv_megj + "</Field>" +
                //        "<Field Name='Nemz_Prime_DB'>" + nemz_Prime + "</Field>" +
                //        "<Field Name='Nemz_Prime_Megj'>" + nemz_Prime_megj + "</Field>" +
                //        "<Field Name='TIG_engedely'>" + TIG + "</Field></Method>";

                //    try
                //    {
                //        if (jaras.Length > 0)
                //        {
                //            listService.UpdateListItems(strListID, batchElement);
                //        }
                //    }

                //    catch
                //    {
                //        //MessageBox.Show(e.ToString());
                //        MessageBox.Show("Adatmentési hiba (Hibakód: IndE!");
                //    }
                //}
                ////----------------------------------- Kiindulás után -----------------------------------------------------

                //teamweb2.Lists listService2 = new teamweb2.Lists();
                //listService2.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //listService2.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
                //System.Xml.XmlNode ndListView2 = listService.GetListAndView("PRI_Kezb_IndulasUtan", "");
                //string strListID2 = ndListView2.ChildNodes[0].Attributes["Name"].Value;
                //string strViewID2 = ndListView2.ChildNodes[1].Attributes["Name"].Value;

                //System.Xml.XmlDocument doc2 = new System.Xml.XmlDocument();
                //System.Xml.XmlElement batchElement2 = doc2.CreateElement("Batch");
                //batchElement2.SetAttribute("OnError", "Continue");
                //batchElement2.SetAttribute("ListVersion", "1");
                //batchElement2.SetAttribute("ViewName", strViewID2);

                //for (int j = 1; j <= sorszam_Kiind; ++j)
                //{
                //    string jaras2 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_Jaras", NamespaceManager).Value;
                //    string pri_d3_v2 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_PRI_D3", NamespaceManager).Value;
                //    string pri_d4_v2 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_PRI_D4", NamespaceManager).Value;
                //    string nek_d3 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_NEK_D3", NamespaceManager).Value;
                //    string nek_d45 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_NEK_D45", NamespaceManager).Value;
                //    string nek_d5 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_NEK_5", NamespaceManager).Value; ;
                //    string TIG = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Terem_Indulas_Utan_TIG", NamespaceManager).Value; ;

                //    string pri_D1 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_PRI_DB", NamespaceManager).Value;
                //    string pri_D1_Megjegyzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_PRI_Megj", NamespaceManager).Value;
                //    string nek_D3_tul = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_NEK_DB", NamespaceManager).Value;
                //    string nek_d3_Szla = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_NEK_Szla_DB", NamespaceManager).Value;
                //    string nek_d3_Megjegyzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_NEM_Megj", NamespaceManager).Value;

                //    string nemz_konyv_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_Nemz_Konyvelt_DB", NamespaceManager).Value;
                //    string nemz_konyv_megj = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_Nemz_Konyvelt_Megj", NamespaceManager).Value;
                //    string nemz_Prime_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_Nemz_PRIME_DB", NamespaceManager).Value;
                //    string nemz_Prime_megj = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + j + "]/my:Kezb_IndUtan_Nemz_PRIME_Megj", NamespaceManager).Value;


                //    batchElement2.InnerXml = "<Method ID='4' Cmd='New'>" +
                //        "<Field Name='Title'>" + posta + "</Field>" +
                //        "<Field Name='Datum'>" + datum + "</Field>" +
                //        "<Field Name='Ellenorzes_helye'>" + helye + "</Field>" +
                //        "<Field Name='Csoport'>" + csoport + "</Field>" +
                //        "<Field Name='Jaras'>" + jaras2 + "</Field>" +
                //        //"<Field Name='PRI_D3_alatt'>" + pri_d3_v2 + "</Field>" +
                //        //"<Field Name='PRI_D3_felett'>" + pri_d4_v2 + "</Field>" +
                //        //"<Field Name='NEK_D3'>" + nek_d3 + "</Field>" +
                //        //"<Field Name='NEK_D45'>" + nek_d45 + "</Field>" +
                //        //"<Field Name='NEK_D5_felett'>" + nek_d5 + "</Field>" +

                //        "<Field Name='PRI_D1_tul'>" + pri_D1 + "</Field>" +
                //        "<Field Name='NEK_D3_tul'>" + nek_D3_tul + "</Field>" +
                //        "<Field Name='PRI_D1_tul_Megjegyzes'>" + pri_D1_Megjegyzes + "</Field>" +
                //        "<Field Name='NEK_D3_tul_SzlaLevel'>" + nek_d3_Szla + "</Field>" +
                //        "<Field Name='NEK_D3_tul_Megjegyzes'>" + nek_d3_Megjegyzes + "</Field>" +

                //        "<Field Name='Nemz_konyv_db'>" + nemz_konyv_db + "</Field>" +
                //        "<Field Name='Nemz_konyv_Megj'>" + nemz_konyv_megj + "</Field>" +
                //        "<Field Name='Nemz_Prime_db'>" + nemz_Prime_db + "</Field>" +
                //        "<Field Name='Nemz_Prime_Megj'>" + nemz_Prime_megj + "</Field>" +
                //        "<Field Name='TIG_engedely'>" + TIG + "</Field></Method>";

                //    try
                //    {
                //        if (jaras2.Length > 0)
                //        {
                //            listService2.UpdateListItems(strListID2, batchElement2);
                //        }
                //    }

                //    catch
                //    {
                //        MessageBox.Show("Adatmentési hiba! (Hibakód: IndU)");//e.ToString());
                //    }
                //}

                //// --------------------------------------------- IRV indul -------------------------------------------------- \\

                //teamweb2.Lists listService3 = new teamweb2.Lists();
                //listService3.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //listService3.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
                //System.Xml.XmlNode ndListView3 = listService.GetListAndView("PRI_IRV", "");
                //string strListID3 = ndListView3.ChildNodes[0].Attributes["Name"].Value;
                //string strViewID3 = ndListView3.ChildNodes[1].Attributes["Name"].Value;

                //System.Xml.XmlDocument doc3 = new System.Xml.XmlDocument();
                //System.Xml.XmlElement batchElement3 = doc3.CreateElement("Batch");
                //batchElement3.SetAttribute("OnError", "Continue");
                //batchElement3.SetAttribute("ListVersion", "1");
                //batchElement3.SetAttribute("ViewName", strViewID3);

                //for (int k = 1; k <= sorszam_IRV; ++k)
                //{
                //    string irv_kod = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:OLK_LU_Erkezett/my:IRV/my:IRV_PRI[" + k + "]/my:IRV_PRI_Db", NamespaceManager).Value;
                //    string irv_posta = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:OLK_LU_Erkezett/my:IRV/my:IRV_PRI[" + k + "]/my:IRV_Posta", NamespaceManager).Value;

                //    batchElement3.InnerXml = "<Method ID='4' Cmd='New'>" +
                //        "<Field Name='Title'>" + posta + "</Field>" +
                //        "<Field Name='Datum'>" + datum + "</Field>" +
                //        "<Field Name='Ellenorzes_helye'>" + helye + "</Field>" +
                //        "<Field Name='Csoport'>" + csoport + "</Field>" +
                //        "<Field Name='IRV_Kod_db'>" + irv_kod + "</Field>" +
                //        "<Field Name='IRV_Felv_posta'>" + irv_posta + "</Field></Method>";

                //    try
                //    {
                //        if (Convert.ToInt32(irv_kod) != 0)
                //        {
                //            listService3.UpdateListItems(strListID3, batchElement3);
                //        }
                //    }

                //    catch
                //    {
                //        MessageBox.Show("Adatmentési hiba! (Hibakód: IRV)");//e.ToString());
                //    }

                //}

                FileSubmitConnection fc = DataConnections["UpLoad"] as FileSubmitConnection;    // adatok Sharepoint-ba küldéshez deklaráció
                fc.Execute();                                                                   // adatok Sharepoint-ba küldése
                MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Zarolva", NamespaceManager).SetValue("1");

                DialogResult dr_002 = MessageBox.Show("A mentés sikeresen megtörtént!\n\nAz adatlap az 'OK' gomb megnyomása után automatikusan bezáródik!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Application.Quit();
            }

            else if (dialogResult == DialogResult.No)
            {
            }
        }


        public void LogIn_Changed(object sender, XmlEventArgs e)
        {
            //string user_login = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:LogIn", NamespaceManager).Value;
            string user_login_konv = (MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:LogIn", NamespaceManager).Value).ToLower();

            XPathNavigator LogIn_konv = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Login_konv", NamespaceManager);
            LogIn_konv.SetValue(user_login_konv);

        }

        public void Kezb_IndE_NEK_Szla_Db_Changed(object sender, XmlEventArgs e)
        {
            XPathNavigator nekDB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_NEK_Db", NamespaceManager);
            XPathNavigator nek_szla_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_NEK_Szla_Db", NamespaceManager);

            if (Convert.ToInt32(nek_szla_db.ToString()) > Convert.ToInt32(nekDB.ToString()))
            {
                nek_szla_db.SetValue("0");
                MessageBox.Show("A rögzített számlalevél értéke nagyobb, mint az összes NEK küldemény!  \n\n Kérem, hogy helyes adatot megadni szíveskedj!"
                , "Adatrögzítési hiba!");
            }
        }

        public void Kezb_IndE_NEK_D3_Szla_Changed(object sender, XmlEventArgs e)
        {
            XPathNodeIterator sorok_Feldolgozott = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Terem_Indulas_Elott_Jaras", NamespaceManager);
            XPathNodeIterator sorok_KiindulasUtan = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan/my:Terem_Indulas_Utan_Jaras", NamespaceManager); ;
           
            int sorszam_Feld = sorok_Feldolgozott.Count;

            for (int i = 1; i <= sorszam_Feld; i++)
            {

                XPathNavigator nekDB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_NEK_D3_Db", NamespaceManager);
                XPathNavigator nek_szla_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + i + "]/my:Kezb_IndE_NEK_D3_Szla", NamespaceManager);

                if (Convert.ToInt32(nek_szla_db.ToString()) > Convert.ToInt32(nekDB.ToString()))
                {
                    nek_szla_db.SetValue("0");
                    MessageBox.Show("A rögzített számlalevél értéke nagyobb, mint az összes NEK küldemény!  \n\n Kérem, hogy helyes adatot megadni szíveskedj!"
                    , "Adatrögzítési hiba!");
                }
            }
        }

        public void Kezb_IndUtan_NEK_Szla_DB_Changed(object sender, XmlEventArgs e)
        {
            
            XPathNodeIterator sorok_KiindulasUtan = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan/my:Terem_Indulas_Utan_Jaras", NamespaceManager); ;

            int sorszamTabla = sorok_KiindulasUtan.Count;

            for (int i = 1; i <= sorszamTabla; i++)
            {

                XPathNavigator nekDB = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + i + "]/my:Kezb_IndUtan_NEK_DB", NamespaceManager);
                XPathNavigator nek_szla_db = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas2/my:Utan[" + i + "]/my:Kezb_IndUtan_NEK_Szla_DB", NamespaceManager);

                if (Convert.ToInt32(nek_szla_db.ToString()) > Convert.ToInt32(nekDB.ToString()))
                {
                    nek_szla_db.SetValue("0");
                    MessageBox.Show("A rögzített számlalevél értéke nagyobb, mint az összes NEK küldemény!  \n\n Kérem, hogy helyes adatot megadni szíveskedj!"
                    , "Adatrögzítési hiba!");
                }
            }
        }

        public void btn_WinForm_Start_Clicked(object sender, ClickedEventArgs e)        // WinForm Start
        {

            posta = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Posta", NamespaceManager).Value;
            datum = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Ellenorzes_datum", NamespaceManager).Value;
            helye = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Ellenorzes_helyszine", NamespaceManager).Value;
            csoport = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Csoport", NamespaceManager).Value;

            ChkList_Kezd_IndElott = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:ChkList_Kezd_IndElott", NamespaceManager).Value;
            ChkList_Kezd_IndUtan = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:ChkList_Kezd_IndUtan", NamespaceManager).Value;
            felvetel_chk = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Felvetel_eo", NamespaceManager).Value;
            adatkuldes = 0;

            DataConnections["Postalista"].Execute();
            pfuLista = DataSources["Postalista"].CreateNavigator().Select("/dataroot/Postalista/Név[../Típus = 'Feldolgozóüzem']", NamespaceManager);
            DataConnections["Postalista"].Execute();
            postaLista = DataSources["Postalista"].CreateNavigator().Select("/dataroot/Postalista/Név", NamespaceManager);


            Form1 form1 = new Form1();
            form1.ShowDialog();

            adatkuldes = 1;
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Adatkuldes", NamespaceManager).SetValue(adatkuldes.ToString());
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:ChkList_Kezd_IndElott", NamespaceManager).SetValue(ChkList_Kezd_IndElott);
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:ChkList_Kezd_IndUtan", NamespaceManager).SetValue(ChkList_Kezd_IndUtan);
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Felvetel_eo", NamespaceManager).SetValue(felvetel_chk);

            
            adat_atadas();
            //MessageBox.Show("Az adatátadás megtörtént!\n\nAz átadott adatok eltárolása érdekében használd a 'Mentés' gombot", "Figyelem!");

            mentes_chk(); //Ez adatátadást követően automatikusan ellenőrzési és menti az adatokat. Előző MessageBox-ot ki kell venni


            //XPathNodeIterator tabla_sorok_start = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Terem_Indulas_Elott_Jaras", NamespaceManager);
            //int tabla_sor_db = tabla_sorok_start.Count;

            //if (form1.dataGridView1.Rows[0].Cells[0].Value != null)
            //{
            //    int db = form1.dataGridView1.Rows.Count;
            //    int sor;
            //    string chkSor = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Terem_Indulas_Elott_Jaras", NamespaceManager).Value;

            //    for (int i = 1; i <= db; ++i)
            //    {
            //        if (tabla_sor_db == 1 && chkSor.Length == 0 && i == 1)
            //        {
            //            sor = 1;
            //        }
            //        else
            //        {
            //            string myNamespace = NamespaceManager.LookupNamespace("my");
            //            using (XmlWriter writer = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1", NamespaceManager).AppendChild())
            //            {

            //                writer.WriteStartElement("Feldolgozott_kuld", myNamespace);
            //                writer.WriteElementString("Terem_Indulas_Elott_Jaras", myNamespace, "0");
            //                writer.WriteElementString("Terem_Indulas_Elott_PRI_D3", myNamespace, "0");
            //                writer.WriteElementString("Terem_Indulas_Elott_PRI_D4", myNamespace, "0");
            //                writer.WriteElementString("Terem_Indulas_Elott_NEK_D5", myNamespace, "0");
            //                writer.WriteElementString("Terem_Indulas_Elott_NEK_D6", myNamespace, "0");
            //                writer.WriteElementString("Terem_indulas_elott_TIG", myNamespace, "Nem");
            //                writer.WriteElementString("Kezb_IndE_PRI_D1_Db", myNamespace, "0");
            //                writer.WriteElementString("Kezb_IndE_NEK_D3_Db", myNamespace, "0");
            //                writer.WriteElementString("Kezb_IndE_PRI_D1_Megj", myNamespace, "");
            //                writer.WriteElementString("Kezb_IndE_NEK_D3_Megj", myNamespace, "");
            //                writer.WriteElementString("Kezb_IndE_NEK_D3_Szla", myNamespace, "0");
            //                writer.WriteElementString("Kezb_IndE_Nemz_Konyv_Db", myNamespace, "0");
            //                writer.WriteElementString("Kezb_IndE_Nemz_Konyv_Megj", myNamespace, "");
            //                writer.WriteElementString("Kezb_IndE_Nemz_PRIME_Db", myNamespace, "0");
            //                writer.WriteElementString("Kezb_IndE_Nemz_PRIME_Megj", myNamespace, "");
            //                writer.WriteEndElement();
            //                writer.Close();
                            
            //            }
                    
            //                tabla_sorok_start = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Terem_indulas_elott_TIG", NamespaceManager);
            //                sor = tabla_sorok_start.Count;
            //         }

            //                if (form1.dataGridView1.Rows[i - 1].Cells[0].Value != null)
            //                {
            //                    XPathNavigator tabla_ke_jaras = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Terem_Indulas_Elott_Jaras", NamespaceManager);
            //                    XPathNavigator tabla_ke_TIG = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Terem_indulas_elott_TIG", NamespaceManager);
            //                    XPathNavigator tabla_ke_PRI_D1 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_PRI_D1_Db", NamespaceManager);
            //                    XPathNavigator tabla_ke_PRI_D1_m = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_PRI_D1_Megj", NamespaceManager);
            //                    XPathNavigator tabla_ke_NEK_D3 = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_NEK_D3_Db", NamespaceManager);
            //                    XPathNavigator tabla_ke_NEK_szla = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_NEK_D3_Szla", NamespaceManager);
            //                    XPathNavigator tabla_ke_NEK_megj = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_NEK_D3_Megj", NamespaceManager);
            //                    XPathNavigator tabla_ke_Nemz_Konyv = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_Nemz_Konyv_Db", NamespaceManager);
            //                    XPathNavigator tabla_ke_Nemz_Konyv_m = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_Nemz_Konyv_Megj", NamespaceManager);
            //                    XPathNavigator tabla_ke_Nemz_Prime = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_Nemz_PRIME_Db", NamespaceManager);
            //                    XPathNavigator tabla_ke_Nemz_Prime_m = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + sor + "]/my:Kezb_IndE_Nemz_PRIME_Megj", NamespaceManager);


            //                    tabla_ke_jaras.SetValue(form1.dataGridView1.Rows[i - 1].Cells[0].Value.ToString());
            //                    tabla_ke_TIG.SetValue(form1.dataGridView1.Rows[i - 1].Cells[1].Value.ToString());
            //                    tabla_ke_PRI_D1.SetValue(form1.dataGridView1.Rows[i - 1].Cells[2].Value.ToString());
            //                    tabla_ke_PRI_D1_m.SetValue(form1.dataGridView1.Rows[i - 1].Cells[7].Value.ToString());
            //                    tabla_ke_NEK_D3.SetValue(form1.dataGridView1.Rows[i - 1].Cells[3].Value.ToString());
            //                    tabla_ke_NEK_szla.SetValue(form1.dataGridView1.Rows[i - 1].Cells[4].Value.ToString());
            //                    tabla_ke_NEK_megj.SetValue(form1.dataGridView1.Rows[i - 1].Cells[8].Value.ToString());
            //                    tabla_ke_Nemz_Konyv.SetValue(form1.dataGridView1.Rows[i - 1].Cells[5].Value.ToString());
            //                    tabla_ke_Nemz_Konyv_m.SetValue(form1.dataGridView1.Rows[i - 1].Cells[9].Value.ToString());
            //                    tabla_ke_Nemz_Prime.SetValue(form1.dataGridView1.Rows[i - 1].Cells[6].Value.ToString());
            //                    tabla_ke_Nemz_Prime_m.SetValue(form1.dataGridView1.Rows[i - 1].Cells[10].Value.ToString());
                            
            //                }
            //    }

                //XPathNodeIterator tabla = MainDataSource.CreateNavigator().Select("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld/my:Terem_Indulas_Elott_Jaras", NamespaceManager);
                //int tabla_sorok = tabla.Count;

                //int k = 1;
                //while (k <= tabla_sorok)
                //{
                //    XPathNavigator itemNav = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kiindulas1/my:Feldolgozott_kuld[" + tabla_sorok + "]", NamespaceManager);

                //    //Sortörlés
                //    if (itemNav == null)
                //    {
                //        itemNav.DeleteSelf();
                //    }
                //    ++k;
                //}

           // }
        }

        private void adat_atadas()      // itt írja be az InfoPath formba az adatokat ----> Forrás: Form1
        {
            try
            {
                Form1 form1 = new Form1();

                XPathNavigator u_PRI_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_UgyfTer_PRI", NamespaceManager);
                XPathNavigator u_NEK_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_UgyfTer_NEK", NamespaceManager);
                XPathNavigator F_PRI_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_PRI_SZUM_Db", NamespaceManager);
                XPathNavigator f_NEK_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_NEK_SZUM_Db", NamespaceManager);
                XPathNavigator f_PRI_felv_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_PRI_DB", NamespaceManager);
                XPathNavigator f_PRI_felv_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_PRI_megjegyz", NamespaceManager);
                XPathNavigator f_PRI_rov_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_Rov_PRI_Db", NamespaceManager);
                XPathNavigator f_PRI_rov_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_Rov_PRI_Megj", NamespaceManager);
                XPathNavigator f_NEK_felv_SZUM_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_NEK_SZUM_Db", NamespaceManager);

                XPathNavigator f_NEK_felv_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_NEK_DB", NamespaceManager);
                XPathNavigator f_NEK_felv_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_NEK_Megj", NamespaceManager);
                XPathNavigator f_NEK_rov_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_Rov_NEK_DB", NamespaceManager);
                XPathNavigator f_NEK_rov_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_Rov_NEK_Megj", NamespaceManager);
                XPathNavigator f_KK_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Hasznalat", NamespaceManager);
                XPathNavigator f_KK_db_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Haszn_Db", NamespaceManager);
                XPathNavigator f_KK_koz_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:KK_Koz", NamespaceManager);
                XPathNavigator f_PRI_uvk_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_Lesz_UVK_PRI", NamespaceManager);
                XPathNavigator f_NEK_uvk_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Felvetel/my:Felv_Lesz_UVK_NEK", NamespaceManager);

                XPathNavigator k_PRI_SZUM_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_PRI_Db", NamespaceManager);
                XPathNavigator k_Nemz_Konyvelt_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_Inde_Nemz_Konyv_DB", NamespaceManager);
                XPathNavigator k_Nemz_Prime_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_Inde_Nemz_PRIME_DB", NamespaceManager);
                XPathNavigator k_NEK_SZUM_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_NEK_Db", NamespaceManager);
                XPathNavigator k_NEK_szla_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_NEK_Szla_Db", NamespaceManager);

                XPathNavigator k_PRI_Felv_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Felv_PRI_Db", NamespaceManager);
                XPathNavigator k_PRI_Felv_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Felv_PRI_Megj", NamespaceManager);
                XPathNavigator k_PRI_Kezb_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Rov_PRI_Db", NamespaceManager);
                XPathNavigator k_PRI_Kezb_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Rov_PRI_Megj", NamespaceManager);
                XPathNavigator k_Nemz_Konyv_Rov_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Nemz_Kesett_KRL_DB", NamespaceManager);
                XPathNavigator k_Nemz_Konyv_Rov_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Nemz_Felv_Kesett_megj", NamespaceManager);
                XPathNavigator k_Nemz_Konyv_Kezb_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Nemz_Kesett_Kterem_Db", NamespaceManager);
                XPathNavigator k_Nemz_Konyv_Kezb_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Kezb_Nemz_Kesett_megj", NamespaceManager);
                XPathNavigator k_Nemz_Prime_Rov_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Prime_KRL_Db", NamespaceManager);
                XPathNavigator k_Nemz_Prime_Rov_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Prime_KRL_Megj", NamespaceManager);
                XPathNavigator k_Nemz_Prime_Kezb_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Prime_kezbter_Db", NamespaceManager);
                XPathNavigator k_Nemz_Prime_Kezb_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_PRIME_Kterem_Megj", NamespaceManager);
                XPathNavigator k_NEK_Rov_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Felv_NEK_Db", NamespaceManager);
                XPathNavigator k_NEK_Rov_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Felv_NEK_Megj", NamespaceManager);
                XPathNavigator k_NEK_Kezb_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Rov_NEK_Db", NamespaceManager);
                XPathNavigator k_NEK_Kezb_m_Temp = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Kezbesítes/my:Kezb_IndE_Rov_NEK_Megj", NamespaceManager);


                u_PRI_Temp.SetValue(u_PRI);
                u_NEK_Temp.SetValue(u_NEK);
                F_PRI_Temp.SetValue(F_PRI);
                f_NEK_Temp.SetValue(f_NEK);
                f_PRI_felv_Temp.SetValue(f_PRI_felv);
                f_PRI_felv_m_Temp.SetValue(f_PRI_felv_m);
                f_PRI_rov_Temp.SetValue(f_PRI_rov);
                f_PRI_rov_m_Temp.SetValue(f_PRI_rov_m);
                f_NEK_felv_SZUM_Temp.SetValue(f_NEK_felv_SZUM);
                f_NEK_felv_Temp.SetValue(f_NEK_felv);
                f_NEK_felv_m_Temp.SetValue(f_NEK_felv_m);
                f_NEK_rov_Temp.SetValue(f_NEK_rov);
                f_NEK_rov_m_Temp.SetValue(f_NEK_rov_m);
                f_KK_Temp.SetValue(f_KK);
                f_KK_db_Temp.SetValue(f_KK_db);
                f_KK_koz_Temp.SetValue(f_KK_koz);
                f_PRI_uvk_Temp.SetValue(f_PRI_uvk);
                f_NEK_uvk_Temp.SetValue(f_NEK_uvk);

                k_PRI_SZUM_Temp.SetValue(k_PRI_SZUM);
                k_Nemz_Konyvelt_Temp.SetValue(k_Nemz_Konyvelt);
                k_Nemz_Prime_Temp.SetValue(k_Nemz_Prime);
                k_NEK_SZUM_Temp.SetValue(k_NEK_SZUM);
                k_NEK_szla_Temp.SetValue(k_NEK_szla);

                k_PRI_Felv_Temp.SetValue(k_PRI_Felv);
                k_PRI_Felv_m_Temp.SetValue(k_PRI_Felv_m);
                k_PRI_Kezb_Temp.SetValue(k_PRI_Kezb);
                k_PRI_Kezb_m_Temp.SetValue(k_PRI_Kezb_m);
                k_Nemz_Konyv_Rov_Temp.SetValue(k_Nemz_Konyv_Rov);
                k_Nemz_Konyv_Rov_m_Temp.SetValue(k_Nemz_Konyv_Rov_m);
                k_Nemz_Konyv_Kezb_Temp.SetValue(k_Nemz_Konyv_Kezb);
                k_Nemz_Konyv_Kezb_m_Temp.SetValue(k_Nemz_Konyv_Kezb_m);
                k_Nemz_Prime_Rov_Temp.SetValue(k_Nemz_Prime_Rov);
                k_Nemz_Prime_Rov_m_Temp.SetValue(k_Nemz_Prime_Rov_m);
                k_Nemz_Prime_Kezb_Temp.SetValue(k_Nemz_Prime_Kezb);
                k_Nemz_Prime_Kezb_m_Temp.SetValue(k_Nemz_Prime_Kezb_m);
                k_NEK_Rov_Temp.SetValue(k_NEK_Rov);
                k_NEK_Rov_m_Temp.SetValue(k_NEK_Rov_m);
                k_NEK_Kezb_Temp.SetValue(k_NEK_Kezb);
                k_NEK_Kezb_m_Temp.SetValue(k_NEK_Kezb_m);
                
            }
            catch
            {
                
            }
        }

        public void btn_MK_Clicked(object sender, ClickedEventArgs e)
        {
            FileSubmitConnection fc = DataConnections["UpLoad"] as FileSubmitConnection;    // adatok Sharepoint-ba küldéshez deklaráció
            fc.Execute();                                                                   // adatok Sharepoint-ba küldése
            MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Zarolva", NamespaceManager).SetValue("1");

            DialogResult dr_001 = MessageBox.Show("A mentés sikeresen megtörtént!\n\nAz adatlap az 'OK' gomb megnyomása után automatikusan bezáródik!", "Adatküldés befejezve!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Application.Quit();
        }

        private void intezkedesiTerv_lista()        // Az intézkedési tervvel kapcsolatos adatokat egy külön listába gyűjti
        {
            XPathNavigator intTerv = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Intezkedesi_Terv", NamespaceManager);
            string szeaz = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Szeaz", NamespaceManager).Value;
            string user = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Ellenorzest_vegezte", NamespaceManager).Value;
            string vegrehajtas = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Intezkedesi_vegrahajtas", NamespaceManager).Value;
            string intMegjegyzes = MainDataSource.CreateNavigator().SelectSingleNode("/my:sajátMezők/my:Alapadatok/my:Intezkedesi_ertekeles", NamespaceManager).Value; 

            if (intTerv.ToString() == "Igen")
            {
                teamweb2.Lists listService = new teamweb2.Lists();
                listService.Credentials = System.Net.CredentialCache.DefaultCredentials;
                listService.Url = "http://teamweb2/sites/TMEK/adatszolg/_vti_bin/Lists.asmx";
                System.Xml.XmlNode ndListView = listService.GetListAndView("PRI_IntTerv", "");
                string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
                string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                System.Xml.XmlElement batchElement = doc.CreateElement("Batch");
                batchElement.SetAttribute("OnError", "Continue");
                batchElement.SetAttribute("ListVersion", "1");
                batchElement.SetAttribute("ViewName", strViewID);


                batchElement.InnerXml = "<Method ID='4' Cmd='New'>" +
                    "<Field Name='Title'>" + szeaz + "</Field>" +
                    "<Field Name='Posta'>" + posta + "</Field>" +
                    "<Field Name='Ellenorzest_vegezte'>" + user + "</Field>" +

                    "<Field Name='Ellenorzes_napja'>" + datum + "</Field>" +
                    "<Field Name='Int_Terv_Vegrehajtas'>" + vegrehajtas + "</Field>" +
                    "<Field Name='Megjegyzes'>" + intMegjegyzes + "</Field></Method>";

                try
                {
                    listService.UpdateListItems(strListID, batchElement);
                }

                catch
                {
                    MessageBox.Show("Adatmentési hiba (Hibakód: Intézkedési terv!");
                }
            }


        }
    }
}
