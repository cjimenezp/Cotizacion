using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2
{
    public partial class frmPrincipal : Form
    {
        public string archivo;
        public string ruta = @"D:\Archivos\"; //se establece la ruta del archivo
        int numeroAleatorio = 0;

        public frmPrincipal()
        {
            InitializeComponent();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {

            calculo calculo = new calculo(); //creacion del objeto de la clase calculo
            proyecto2 grabar = new proyecto2();// creacion del objeto de la clase proyecto

            try//se comprueba que se ingrese la cantidad de comenzales
            {
                if (txtComensales.Text.Equals(""))
                {
                    MessageBox.Show("Debe ingresar una cantidad de comenzales primero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    grabar._Personas = int.Parse(txtComensales.Text);//se graba en el archivo la cotizacion y el presupuesto
                    MessageBox.Show(grabar.Grabar(txtComensales.Text));//se muestra el mensaje de la clase proyecto2
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargarListView();
        }

        public void cargarListView()//metodo para cargar los encabezados del formulario
        {
            lsvDatos.Clear();
            lsvDatos.Columns.Add("COTIZACIÓN").Width = 100;
            lsvDatos.Columns.Add("PRESUPUESTO").Width = 146;
        }

        public void leerArchivo()//metodo para leer el archivo
        {
            try
            {

                archivo = "listaCotizaciones.txt"; //archivo en el cual se va a trabajar
                StreamReader leer = new StreamReader(ruta + archivo);//ubicacion del archivo

                string cotizacion, presupuesto;

                cargarListView();

                while (leer.Peek() != -1)//se leen las lineas del archivo y se cargan en el listview
                {
                    string linea = leer.ReadLine();
                    string[] separador = linea.Split(';');//separar la linea cuando llega al ;
                    cotizacion = separador[0];
                    presupuesto = separador[1];

                    if (String.IsNullOrEmpty(linea))//si la linea esta vacia continue
                    {
                        continue;
                    }

                    lsvDatos.Items.Add("#" + cotizacion);
                    lsvDatos.Items[lsvDatos.Items.Count - 1].SubItems.Add("$" + presupuesto);
                }
                leer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: aún no se ha creado un archivo. Debe realizar una cotización primero. ", ex.Message);//mensaje en caso que el archivo este vacio
            }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            leerArchivo();
        }

        public void limpiar()//limpiar el listview y el textbox
        {
            lsvDatos.Clear();
            txtComensales.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void COTIZAR(object sender, KeyPressEventArgs e)
        {
            proyecto2 proyecto2 = new proyecto2();
            proyecto2.validarnumber(e);

        }
    }
}
