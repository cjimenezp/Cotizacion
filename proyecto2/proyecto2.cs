using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2
{
    internal class proyecto2
    {
        int numeroAleatorio = 0;
        public string archivo;
        public string ruta = @"D:\Archivos\";
        private int personas;
        private int numCotizacion;

        
        public int _NumCotizacion { get => numCotizacion; set => numCotizacion = value; }
        public int _Personas { get => personas; set => personas = value; }

        public proyecto2(int persona, int cotizacion)
        {
            this._Personas = persona;
            this._NumCotizacion = numCotizacion;
        }

        

        public proyecto2()
        {

        }

        public string Grabar(string comensales)//metodo para crear el archivo
        {
            calculo personas = new calculo();//instancia del objeto

            personas._Personas = Convert.ToInt32(_Personas);


            numeroAleatorio = int.Parse(personas.numAleatorio());//creacion del numero de la cotizacion por medio de un numero aleatorio

            archivo = "listaCotizaciones.txt";

            if (File.Exists(ruta + archivo))//si el archivo existe se escribe sobre el
            {
                StreamWriter escribir = new StreamWriter(ruta + archivo, true);
                escribir.WriteLine(numeroAleatorio + ";" + personas.calculoBanquete());
                escribir.Close();
            }
            else//sino se crea el archivo
            {
                FileStream flujo;
                Directory.CreateDirectory(ruta);
                flujo = File.Create(ruta + archivo);

                flujo.Close();
                StreamWriter escribir = new StreamWriter(ruta + archivo, true);
                escribir.WriteLine(numeroAleatorio + ";" + personas.calculoBanquete());
                escribir.Close();
            }

            return "El presupuesto para el banquete es de: $" + personas.calculoBanquete() + " y el número de cotización es: " + numeroAleatorio;
        }
        public KeyPressEventArgs validarnumber(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }


    }
}
