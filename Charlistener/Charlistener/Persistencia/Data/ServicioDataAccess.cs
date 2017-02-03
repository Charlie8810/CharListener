using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CDK.Data;
using CDK.Integration;

namespace Charlistener.Persistencia.Data
{
    public static class ServicioDataAccess
    {

        public static void EjecutarTareaMSSQL(string nombreTarea)
        {
            Parametro x = new Parametro("@job_name", nombreTarea);
            DBHelper.InstanceMSDB.EjecutarProcedimiento("sp_start_job", x);
        }


        public static void EscribirPrueba()
        {
            DBHelper.InstanceReporteria.EjecutarSql("insert into BD_INTERNA.dbo.CharliTest values ('Hola')");
        }

        
        
    }
}
