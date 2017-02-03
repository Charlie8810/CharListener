﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Data.SqlClient;
using System.Configuration;

namespace Charlistener
{
    public partial class CharListener : ServiceBase
    {
        public CharListener()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            int intervalo = Convert.ToInt32(ConfigurationSettings.AppSettings["intervaloListener"].ToString());
            Timer t = new Timer { AutoReset=true, Enabled=true, Interval=intervalo };
            t.Elapsed += t_Elapsed;
            t.Start();
        }

        protected override void OnStop()
        {
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            FileInfo file = new FileInfo(ConfigurationSettings.AppSettings["rutaArchivo"].ToString());
            
            if (file.LastWriteTime != this.LeerDato())
            {
                this.EscribirDato(file.LastWriteTime);
                Persistencia.Data.ServicioDataAccess.EjecutarTareaMSSQL(ConfigurationSettings.AppSettings["nombreTarea"].ToString());
            }
            
        }



        private void EscribirDato(DateTime Fecha)
        {
            string[] lines = { Fecha.TimeOfDay.ToString() };
            using (StreamWriter outputFile = new StreamWriter(ConfigurationSettings.AppSettings["FechAct"].ToString()))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }

        private DateTime LeerDato()
        {
            try
            {
                StreamReader sr = new StreamReader(ConfigurationSettings.AppSettings["FechAct"].ToString());
                string t = sr.ReadToEnd();
                sr.Close();

                return Convert.ToDateTime(t.Replace(@"\t","").Replace(@"\r","").Replace(@"\n",""));

            }catch(Exception ex)
            {
                return DateTime.MinValue;
            }
             
        }

    }
}