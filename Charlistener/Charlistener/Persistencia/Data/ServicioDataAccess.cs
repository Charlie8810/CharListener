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

        public static int EjecutarProceso(string nombreTarea)
        {
            Parametro x = new Parametro("@nombre_tarea", nombreTarea);
            //DBHelper.InstanceInterna.EjecutarProcedimiento("sp_SRV_ListenerIA", x);
            return DBHelper.InstanceInterna.ObtenerEscalar<int>("sp_SRV_ListenerIA", x);
        }
        
    }
}
