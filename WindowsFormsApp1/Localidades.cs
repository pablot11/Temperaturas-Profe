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
    class Localidades
    {

        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;
        public Localidades()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=CLIMA.mdb");
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Localidades";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

          
        }

        public void llenar(ComboBox combo)
        {
            combo.DisplayMember = "nombre";
            combo.ValueMember = "localidad";
            combo.DataSource = tabla;
        }

        
    }
}
