//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.OleDb;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;

namespace Rip_Ice
{
    public partial class FormHelp : Form
    {
        // The name of the key must include a valid root.
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = @"Software\ALI\Rip_Ice";
        const string keyNameHelp = userRoot + "\\" + subkey + "\\Help";


        public string dataoggiInv;
        public string lineaProduzione;
        public string query;
        public string codDivisione;

        public string sdwConnectionString;
        public string sdwConnectionSQLITEString;
        public string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        public string PercorsoLocale;
        public string nomeStampante;
        public string stampaSINO;
        public string PrefissoMatricola;

        public SqlConnection sdwDBWConnection;
        public SqlCommand queryCommandQRY;
        public OleDbConnection conn;
        public OleDbConnection connSQL;

        public DateTime oggi;
        public DateTime oggimeno10;
        public DateTime oggimeno40;
        public DateTime nuovogiorno;
        public string orario;
        public string servernameDB;
        public int numeroriga = 0;

        public SqlConnection sdwDBWConnectionF;
        public SqlConnection sdwDBWConnectionC;
        public SqlConnection sdwDBWConnectionU;

        private string temp_query = string.Empty;


        public string temp
        {
            get { return temp_query; }

            set
            {
                temp_query = value;
            }
        }

        public FormHelp(string connectionStringDBl, string servernameDBl, string catalogNameDBl,  string dataoggiInvDBl, string percorsolocaleDBL, string modelloDBl)
        {
            InitializeComponent();
            servernameDB = servernameDBl;
            sdwConnectionString = connectionStringDBl;
            dataoggiInv = dataoggiInvDBl;
            PercorsoLocale = percorsolocaleDBL;
            temp_query = modelloDBl;
            dGridViewhelp.BackgroundColor = Color.LimeGreen;
            mostrarisultato();

        }


        public void mostrarisultato()
        {
            string modello = temp_query;
            string qry = "";

            connSQL = new OleDbConnection();

            this.Text = "Risoluzione per: " + modello;
            ////sdwConnectionString = @";Data source = " + servernameDB + "; uid=" + userNameDB + "; pwd=" + passwordDB + "; Initial Catalog = " + catalogNameDB + "; " + @"Provider=Microsoft.Jet.OLEDB.4.0;";
            //sdwConnectionString = @";Data source = " + servernameDB + "; " + @"Provider=Microsoft.Jet.OLEDB.4.0;";
            //conn.ConnectionString = sdwConnectionString; //  @"Provider = Microsoft.Jet.OLEDB.4.0; Data source = " + servernameDB;
            //conn.Open();

            sdwConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + servernameDB;
            //conn.ConnectionString = sdwConnectionString;//@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + servernameDB;
            //22/05/2017
            try
            {
                connSQL.ConnectionString = sdwConnectionString; //@"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + servernameDB;
                connSQL.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore di connessione al DataBase " + ex + " Riprova", "Rip.Ice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            qry = "SELECT RILAVORAZIONI_DET.DataIns, RILAVORAZIONI.AnomaliaRilevata, RILAVORAZIONI_DET.CodiceRilav, " +
                         "TAB_RILAVORAZIONI.Descrizione, RILAVORAZIONI_DET.InterventoEseguito " +
                  "FROM TAB_RILAVORAZIONI INNER JOIN (RILAVORAZIONI INNER JOIN RILAVORAZIONI_DET ON RILAVORAZIONI.ID = RILAVORAZIONI_DET.ID_Det) ON " +
                        "TAB_RILAVORAZIONI.Rilavorazione = RILAVORAZIONI_DET.CodiceRilav " +
                  "WHERE (((RILAVORAZIONI.Modello) = '" + modello + "')) " +
                  "ORDER BY RILAVORAZIONI_DET.DataIns DESC";
            caricaElenco(connSQL, qry, dGridViewhelp, true);
            if (dGridViewhelp.ColumnCount > 0)
            {
                dGridViewhelp.Columns[0].Width = 80;
                dGridViewhelp.Columns[1].Width = 60;
                dGridViewhelp.Columns[2].Width = 100;
                dGridViewhelp.Columns[3].Width = 320;
                dGridViewhelp.Columns[4].Width = 320;

                dGridViewhelp.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, FontStyle.Regular);//Data Inserimento

                dGridViewhelp.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dGridViewhelp.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                
                
            }
            dGridViewhelp.RowTemplate.Height = 200;
            dGridViewhelp.RowHeadersWidth = 10;
            //dGridViewhelp.RowTemplate.Resizable = DataGridViewTriState.True;
            //dGridViewhelp.RowTemplate.Height = 200;
            
        }

        private void FormHelp_SizeChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Size altezza = control.Size;
            int minAltezza = 200;
            int minLarghezza = 500;
            int deltahd = 5;
            int deltawd = 6;
            int deltahf = 43;
            int deltawf = 17;
            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height >= minAltezza)
            {
                panel1.Size = new Size(control.Size.Width - deltawf, control.Size.Height - deltahf);
                dGridViewhelp.Size = new Size(panel1.Size.Width - deltawd, panel1.Size.Height - deltahd);
            }
            else
            {
                control.Size = new Size(altezza.Width, minAltezza);
                panel1.Size = new Size(control.Size.Width - deltawf, control.Size.Height - deltahf);
                dGridViewhelp.Size = new Size(panel1.Size.Width- deltawd, panel1.Size.Height- deltahd);

            }
            if (control.Size.Width >= minLarghezza)
            {
                panel1.Size = new Size(control.Size.Width - deltawf, control.Size.Height - deltahf);
                dGridViewhelp.Size = new Size(panel1.Size.Width - deltawd, panel1.Size.Height - deltahd);
            }
            else
            {
                panel1.Size = new Size(control.Size.Width - deltawf, control.Size.Height - deltahf);
                control.Size = new Size(minLarghezza, altezza.Width);
                dGridViewhelp.Size = new Size(panel1.Size.Width - deltawd, panel1.Size.Height - deltahd);

            }
        }

        public static bool GetData(OleDbConnection conn1, string sdwConnectionString, string selectCommand, DataGridView griglia, string servernameDB, Boolean visibile)
        {
            BindingSource bindingSource1 = new BindingSource();
            try
            {
                //OleDbConnection conn1 = new OleDbConnection();
                //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + servernameDB;
                OleDbDataReader mio = null;
                //conn1.Open();
                griglia.Visible = false;
                // Create a new data adapter based on the specified query.
                //dataAdapter = new SqlDataAdapter(selectCommand, connectionString1);
                OleDbCommand cmd1 = new OleDbCommand(selectCommand, conn1);
                try

                {

                    mio = cmd1.ExecuteReader();
                    griglia.Rows.Clear();
                    griglia.Columns.Clear();
                    //griglia.Refresh();

                    Application.DoEvents();
                    if (mio.Read())
                    {

                        griglia.ColumnCount = mio.FieldCount;
                        for (int i = 0; i < mio.FieldCount; i++)
                        {
                            griglia.Columns[i].HeaderText = mio.GetName(i);
                        }


                        int r = 0;
                        do
                        {
                            griglia.Rows.Add();
                            for (int i = 0; i < mio.FieldCount; i++)
                            {

                                griglia.Rows[r].Cells[i].Value = Convert.ToString(mio[i]);
                            }
                            r++;
                            //Console.WriteLine(mio[0]);
                        } while (mio.Read());
                    }



                    griglia.BorderStyle = BorderStyle.Fixed3D;
                    //conn1.Close();

                    if (visibile)
                    {
                        griglia.Visible = true;
                    }
                    //mio.Close();
                    return true;
                }
                catch (Exception se)
                {
                    //MessageBox.Show("Errore: " + se.Message + " Contattare ICT. Query:" + selectCommand, "Rip.Ice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    /*
                    Console.WriteLine("errore");
                    Console.WriteLine(se);
                    Console.ReadLine();
                    */
                    Console.WriteLine("errore");
                    //22/05/2017
                    conn1.Close();
                    conn1.ConnectionString = sdwConnectionString;
                    conn1.Open();
                    return false;
                }
            }
            catch (SqlException sqe)
            {

                MessageBox.Show("Errore: " + sqe.Message + " Contattare ICT. Query:" + selectCommand, "Rip_Ice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //22/05/2017
                conn1.Close();
                conn1.ConnectionString = sdwConnectionString;
                conn1.Open();

                return false;
            }
        }


        private void caricaElenco(OleDbConnection connc, string qryR, DataGridView Griglia, Boolean visibile)
        {
            clearDataGridView(Griglia);
            bool esito = false;
            esito = GetData(connc, sdwConnectionString, qryR, Griglia, servernameDB, visibile);
            //MessageBox.Show("ok1", "Rip.Ice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (!esito)
            {
                esito = GetData(connc, sdwConnectionString, qryR, Griglia, servernameDB, visibile);
                //MessageBox.Show("ok2", "Rip.Ice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void clearDataGridView(DataGridView Griglia)
        {
            Griglia.Rows.Clear();
            Griglia.Columns.Clear();
            Griglia.Refresh();
            Application.DoEvents();
        }

        private void FormHelp_ResizeEnd(object sender, EventArgs e)
        {
            
        }

        private void FormHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveMyConfigRegistroHelp();
        }

        public void SaveMyConfigRegistroHelp()  // 12/10/2020
        {
            Registry.SetValue(keyNameHelp, "HelpPosiL", this.Left , RegistryValueKind.String);
            Registry.SetValue(keyNameHelp, "HelpPosiT", this.Top, RegistryValueKind.String);
            Registry.SetValue(keyNameHelp, "HelpPosiW", this.Width, RegistryValueKind.String);
            Registry.SetValue(keyNameHelp, "HelpPosiH", this.Height, RegistryValueKind.String);

        }
    }
}
