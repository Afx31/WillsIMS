using System.Data;
using WillsIMS.Models;
using WillsIMS.Utilities;

namespace WillsIMS.Repositories
{
    public class CompanyRepository
    {
        private readonly IDatabaseUtility _databaseUtility;

        public CompanyRepository(IDatabaseUtility databaseUtility)
        {
            _databaseUtility = databaseUtility;
        }

        public async Task<Company> GetCompany(string id)
        {
            try
            {
                string query = $@"
                            SELECT *
                            FROM Company
                            WHERE CompanyId = {id}
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<Company> companies = new List<Company>();

                foreach (DataRow row in dt.Rows)
                {
                    Company company = new Company
                    {
                        CompanyId = Convert.ToInt32(row["CompanyId"]),
                        Name = row["Name"].ToString(),
                        Email = row["Email"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString()
                    };
                    companies.Add(company);
                }
                
                return companies.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Company");
            }
        }
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                string query = @"
                            SELECT *
                            FROM Company
                            ";

                DataTable dt = await _databaseUtility.QueryDatabase(query);
                List<Company> companies = new List<Company>();

                foreach (DataRow row in dt.Rows)
                {
                    Company company = new Company
                    {
                        CompanyId = Convert.ToInt32(row["CompanyId"]),
                        Name = row["Name"].ToString(),
                        Email = row["Email"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString()
                    };
                    companies.Add(company);
                }

                return companies;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Company");
            }
        }
    }
}
