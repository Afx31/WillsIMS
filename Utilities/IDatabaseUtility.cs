using System.Data;

namespace WillsIMS.Utilities
{
    public interface IDatabaseUtility
    {
        public int GetNextAvailableId(string tableName);
        public Task<DataTable> QueryDatabase(string query);
    }
}
