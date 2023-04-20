using consultationProjet.models;
using consultationProjet.views.Iviews;
using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace consultationProjet.views
{
    public partial class RpForm : Form, IRpView
    {
        public RpForm()
        {
            InitializeComponent();
            activeLesEventRdv();
        }






        //----------------------------------DEBUT_DELEGATE_EVENT------------------------
        public void activeLesEventRdv()
        {

            Datepres.ValueChanged += delegate
            {
                rechercherRdvParDatePres.Invoke(this, EventArgs.Empty);
            };


            btnfairePres.Click += delegate
            {
                AddPresEvent.Invoke(this, EventArgs.Empty);
            };




            Valider.Click += delegate
            {
                ValiderPresEvent.Invoke(this, EventArgs.Empty);
            };



            Annuler.Click += delegate
            {
                AnnulerPresEvent.Invoke(this, EventArgs.Empty);
            };


            comboEtat.SelectionChangeCommitted += delegate
            {
                etatRdvEvent.Invoke(this, EventArgs.Empty);
            };




            btnExport.Click += delegate
            {
                if (dtgprestation.Rows.Count > 0)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "CSV(.csv)|.csv";
                    save.FileName = "Result.csv";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                            Workbook excelWorkbook = excelApp.Workbooks.Add();
                            Worksheet excelWorksheet = (Worksheet)excelWorkbook.ActiveSheet;
                         
                            for (int i = 1; i < dtgprestation.Columns.Count + 1; i++)
                            {
                                excelWorksheet.Cells[1, i] = dtgprestation.Columns[i - 1].HeaderText;
                            }
                            for (int i = 0; i < dtgprestation.Rows.Count; i++)
                            {
                                for (int j = 0; j < dtgprestation.Columns.Count; j++)
                                {
                                    excelWorksheet.Cells[i + 2, j + 1] = dtgprestation.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                            excelWorkbook.SaveAs(save.FileName, XlFileFormat.xlCSVWindows);
                            excelWorkbook.Close();
                            excelApp.Quit();
                            MessageBox.Show(" success Bro!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur exportation: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No record found.", "Info");
                }
            };

        }



        public DateTime DaterecherchePres { get => Datepres.Value ; set => throw new NotImplementedException(); }
        public TypePrestation RecupTypePres { get => (TypePrestation)comboTypePres.SelectedItem; set => throw new NotImplementedException(); }
        public string recupResultat { get => boxResultats.Text; set => boxResultats.Text=value; }


       
        public Etatrdv etatrdvRecup { get => (Etatrdv)comboEtat.SelectedItem; set => throw new NotImplementedException(); }

        public event EventHandler rechercherRdvParDatePres;
        public event EventHandler AddPresEvent;
        public event EventHandler AnnulerPresEvent;
        public event EventHandler ValiderPresEvent;
        public event EventHandler etatRdvEvent;
        public event EventHandler PlannifierNouveau;

        public void setdtgRdvPres(BindingSource bindingSource)
        {
            dtgRdvPres.DataSource = bindingSource;
        }

        public void setdtgTypePres(BindingSource bindingSource)
        {
            comboTypePres.DataSource = bindingSource;
        }


        public void setdtgprestation(BindingSource bindingSource)
        {
            dtgprestation.DataSource=bindingSource;
        }





        private static RpForm instance = null;



        public static RpForm showForm(Form parent)
        {
            if(parent.ActiveMdiChild != null)
            {
                parent.ActiveMdiChild.Close();
            }
            if (instance == null)
            {
                instance = new RpForm();
                instance.MdiParent = parent;
                return instance;
            }
            return instance;


        }

        public void setdtgEtat(BindingSource bindingSource)
        {
            comboEtat.DataSource=bindingSource;
        }
























        private void RpForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtgprestation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
