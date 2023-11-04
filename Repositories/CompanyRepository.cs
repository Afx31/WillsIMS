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

        public async Task<bool> Create(Company company)
        {
            try
            {
                int nextCompanyId = _databaseUtility.GetNextAvailableId(company.CompanyTableName);

                string query = $@"
                            INSERT INTO Company (CompanyId, CompanyType, Name, Email, Phone, Address)
                            VALUES ({nextCompanyId}, {company.CompanyType}, '{company.Name}', '{company.Email}', '{company.Phone}', '{company.Address}')
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Company - Create");
            }
        }

        public async Task<Company> Get(string id)
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
                throw new NotImplementedException("ERROR: Company - Get");
            }
        }

        public async Task<IEnumerable<Company>> GetAll()
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
                throw new NotImplementedException("ERROR: Company - GetAll");
            }
        }

        public async Task<bool> Update(Company company)
        {
            try
            {
                string query = $@"
                            UPDATE Company
                            SET CompanyType = {company.CompanyType}, Name = '{company.Name}',
                            Email = '{company.Email}', Phone = '{company.Phone}', Address = '{company.Address}'
                            WHERE CompanyId = {company.CompanyId}
                            ";

                var res = await _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Company - Update");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                string query = $@"
                            DELETE FROM Company
                            WHERE CompanyId = {id}
                            ";

                var res = _databaseUtility.QueryDatabase(query);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR: Company - Delete");
            }
        }
    }
}
