using System.Data;

namespace WillsIMS.Utilities
{
    public interface IDatabaseUtility
    {
        public Task<DataTable> QueryDatabase(string query);
    }
}
