using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Citas;
using System.Data;
using System.Data.Odbc;

namespace Capa_Controlador_Citas
{
    public class Controlador
    {

        Sentencias sn = new Sentencias();

        //Llenar una tabla Capa Controlador
        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


    }
}
