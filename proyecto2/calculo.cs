using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto2
{
    internal class calculo: proyecto2
    {
        double resultado = 0;

        public string calculoBanquete()//metodo para realizar el calculo del costo del banquete
        {
            

            if (_Personas<=200)
            {
                resultado = _Personas * 95;
            }
            else if (_Personas>200 && _Personas <= 300)
            {
                resultado = _Personas * 85;
            }
            else if (_Personas > 300)
            {
                resultado = _Personas * 75;
            }

            return resultado.ToString();
            
        }

        public string numAleatorio()//creacion de numero aleatorio
        {
            int numeroAleatorio = 0;
            Random numRandom = new Random();
            numeroAleatorio = numRandom.Next(0, 10000);
            return numeroAleatorio.ToString();
        }
    }
}
