using CDK.Data;

namespace CDK.Integration
{
    public class DBHelper
    {
        #region Instancias Privadas

        private static DBHelperBase instanceInterna;
        private static DBHelperBase _instanceMSDB;

        #endregion

        #region Instancias Singleton

        public static DBHelperBase InstanceInterna
        {
            get { return (instanceInterna = instanceInterna ?? new DBHelperBase("CN_INTERNA")); }
        }

        public static DBHelperBase InstanceMSDB
        {
            get { return (_instanceMSDB = _instanceMSDB ?? new DBHelperBase("CN_MSDB")); }
        }

        #endregion
    }
}
