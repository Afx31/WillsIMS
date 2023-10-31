import React, { Component } from 'react';
import './Data.css';

export class Company extends Component {
  static displayName = Company.name;

  constructor(props) {
    super(props);
    this.state = {
      companies: [],
      loading: true,
      company: {
        companyId: '',
        companyType: '',
        name: '',
        email: '',
        phone: '',
        address: '',
      },
      isLoading: false,
      inputId: ''
    };

    this.onGetCompanyBtnClick = this.onGetCompanyBtnClick.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  componentDidMount() {
    this.populateCompaniesData();
  }

  handleInputChange(event) {
    this.setState({ inputId: event.target.value });
  }

  async onGetCompanyBtnClick() {
    this.setState({ isLoading: true });
    
    try {
      await this.populateCompanyData(this.state.inputId);
    } catch (error) {
      console.error('An error occurred: ', error);
    } finally {
      this.setState({ isLoading: false });
    }
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

  static renderCompanyTable(company) {
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
          {
            <tr key={company.companyId}>
              <td>{company.companyId}</td>
              <td>{company.name}</td>
              <td>{company.email}</td>
              <td>{company.phone}</td>
              <td>{company.address}</td>
            </tr>
          }
        </tbody>
      </table>
    );
  }

  render() {
    let contentCompanies = this.state.loading
      ? <p><em>Loading...</em></p>
      : Company.renderCompaniesTable(this.state.companies);
    let contentCompany = this.state.loading
      ? <p><em>Loading...</em></p>
      : Company.renderCompanyTable(this.state.company);
    
    return (
      <div className='dataContainer'>
        <h1 id='tableLabel'>Company</h1>
        {contentCompanies}
        <input
          type='text'
          placeholder='Enter Company ID'
          value={this.state.inputId}
          onChange={this.handleInputChange}
        />
        <button onClick={this.onGetCompanyBtnClick}>
          Get company
        </button>
        {contentCompany}
      </div>
    );
  }

  async populateCompaniesData() {
    const res = await fetch('/api/company');
    const data = await res.json();
    this.setState({ companies: data, loading: false });
  }
  async populateCompanyData(companyId) {
    const res = await fetch(`/api/company/${companyId}`);
    if (!res.ok) { throw new Error(`Failed to fetch data: ${res.status} ${res.statusText}`) }
    
    const data = await res.json();

    this.setState({
      company: {
        companyId: data.companyId,
        companyType: data.companyType,
        name: data.name,
        email: data.email,
        phone: data.phone,
        address: data.address,
      },
      loading: false
    });    
  }
}
