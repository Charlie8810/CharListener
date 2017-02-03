using CDK.Data;

namespace CDK.Integration
{
    public class DBHelper
    {
        #region Instancias Privadas

        private static DBHelperBase _instanceReporteria;
        private static DBHelperBase _instanceCampanias;

        #endregion

        #region Instancias Singleton

        public static DBHelperBase InstanceReporteria
        {
            get { return (_instanceReporteria = _instanceReporteria ?? new DBHelperBase("CN_REPORTERIA")); }
        }


        public static DBHelperBase InstanceCampanias
        {
            get { return (_instanceCampanias = _instanceCampanias ?? new DBHelperBase("CN_CAMPANIAS")); }
        }

        public static DBHelperBase InstanceSecurity
        {
            get { return (_instanceCampanias = _instanceCampanias ?? new DBHelperBase("CN_SECURITY")); }
        }

        public static DBHelperBase InstanceMSDB
        {
            get { return (_instanceCampanias = _instanceCampanias ?? new DBHelperBase("CN_MSDB")); }
        }

        #endregion
    }
}
