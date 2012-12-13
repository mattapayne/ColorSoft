using Simple.Data;

namespace ColorSoft.Web.Data
{
    public class SimpleDbDatabaseProvider : IDatabaseProvider
    {
        private readonly string _connectionString;

        public SimpleDbDatabaseProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region IDatabaseProvider Members

        public dynamic Db()
        {
            return Database.OpenConnection(_connectionString);
        }

        #endregion
    }
}