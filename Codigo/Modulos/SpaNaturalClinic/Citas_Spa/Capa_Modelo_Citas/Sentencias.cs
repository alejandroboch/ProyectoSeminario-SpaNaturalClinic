using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Citas
{
    public class Sentencias
    {

        Conexion con = new Conexion();

        // Obtener datos de una tabla Capa Modelo
        public OdbcDataAdapter llenarTbl(string tabla) //método que obtiene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + ";";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }

    }
}
