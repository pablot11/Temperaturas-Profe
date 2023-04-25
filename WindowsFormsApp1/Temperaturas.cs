using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Temperaturas
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;
        public Temperaturas()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=CLIMA.mdb");
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Temperaturas";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[2];
            dc[0] = tabla.Columns["localidad"];
            dc[1] = tabla.Columns["fecha"];
            tabla.PrimaryKey = dc;

        }

        public void buscar(int localidad, string fecha, TextBox txtMinima, TextBox txtMaxima)
        {
            Object[] busco = new object[2];
            busco[0] = localidad;
            busco[1] = fecha;
            DataRow fila = tabla.Rows.Find(busco);

            if(fila is null)
            {
                txtMinima.Text = "";
                txtMaxima.Text = "";

            }
            else
            {
                txtMinima.Text = fila["minima"].ToString();
                txtMaxima.Text = fila["maxima"].ToString();
            }
            
        }

        public string[] buscar(int localidad, string fecha)
        {
            Object[] busco = new object[2];
            busco[0] = localidad;
            busco[1] = fecha;
            DataRow fila = tabla.Rows.Find(busco);

            string[] encontro = new string[2];
            if (fila is null)
            {
                encontro[0] = "";
                encontro[1] = "";
            }
            else
            {
                encontro[0] = fila["minima"].ToString();
                encontro[1] = fila["maxima"].ToString();
            }

            return encontro;

        }

    }
    
}
