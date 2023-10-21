import React, { Component } from 'react';
import './FetchData.css';

export class FetchDataCompany extends Component {
  static displayName = FetchDataCompany.name;

  constructor(props) {
    super(props);
    this.state = { companies: [], loading: true };
  }

  componentDidMount() {
    this.populateCompaniesData();
  }

  static renderCompaniesTable(companies) {
    return (
      <table>
        <thead>
          <tr>
            <th>Company Id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Address</th>
          </tr>
        </thead>
        <tbody>
          {companies.map(company =>
            <tr key={company.companyId}>
              <td>{company.companyId}</td>
              <td>{company.name}</td>
              <td>{company.email}</td>
              <td>{company.phone}</td>
              <td>{company.address}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    
    let contentCustomers = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataCompany.renderCompaniesTable(this.state.companies);
    
    return (
      <div className='fetchDataContainer'>
        <h1 id='tableLabel'>Fetched data - Company</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contentCustomers}
      </div>
    );
  }

  async populateCompaniesData() {
    const res = await fetch('/api/company');
    const data = await res.json();
    this.setState({ companies: data, loading: false });
  }
}
