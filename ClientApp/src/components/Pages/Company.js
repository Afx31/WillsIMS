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
      createCompany: {
        companyId: 0,
        companyType: 0,
        name: '',
        email: '',
        phone: '',
        address: '',
      },
      isLoading: false,
      inputId: ''
    };

    this.handleInputChange = this.handleInputChange.bind(this);
    this.onGetCompanyBtnClick = this.onGetCompanyBtnClick.bind(this);
    this.handleCreateCompanyInputChange = this.handleCreateCompanyInputChange.bind(this);
    this.onCreateCompanyBtnClick = this.onCreateCompanyBtnClick.bind(this);
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

  handleCreateCompanyInputChange(e) {
    const { name, value } = e.target;
    this.setState((prevState) => ({
      createCompany: {
        ...prevState.createCompany,
        [name]: value,
      },
    }));
  }

  onCreateCompanyBtnClick = async () => {
    try {
      await this.populateCreateCompany();
    } catch (error) {
      console.error('An error occurred: ', error);
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
        <div className='company-get-all'>
          <h2>Get All</h2>
          {contentCompanies}
        </div>
        <div className='company-get'>
          <h2>Get Individual</h2>
          <input
            type='text'
            placeholder='Enter Id'
            value={this.state.inputId}
            onChange={this.handleInputChange}
          />        
          <button onClick={this.onGetCompanyBtnClick}>
            Get company
          </button>
          {contentCompany}
        </div>
        <div className='company-create'>
          <h2>Create</h2>
          <input
            name='type'
            type='number'
            placeholder='Enter Type'
            value={this.state.createCompany.type}
            onChange={(e) => this.handleCreateCompanyInputChange(e)}
          />
          <input
            name='name'
            type='text'
            placeholder='Enter Name'
            value={this.state.createCompany.name}
            onChange={(e) => this.handleCreateCompanyInputChange(e)}
          />
          <input
            name='email'
            type='text'
            placeholder='Enter Email'
            value={this.state.createCompany.email}
            onChange={(e) => this.handleCreateCompanyInputChange(e)}
          />
          <input
            name='phone'
            type='text'
            placeholder='Enter Phone'
            value={this.state.createCompany.phone}
            onChange={(e) => this.handleCreateCompanyInputChange(e)}
          />
          <input
            name='address'
            type='text'
            placeholder='Enter Address'
            value={this.state.createCompany.address}
            onChange={(e) => this.handleCreateCompanyInputChange(e)}
          />
          <button type='submit' onClick={this.onCreateCompanyBtnClick}>
            Get company
          </button>
        </div>        
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

  async populateCreateCompany() {
    console.log(this.state.createCompany)
    const res = await fetch('/api/company', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(this.state.createCompany),
    });

    console.log(res)

    if (res.ok) {
      // Handle a successful response here
    } else {
      // Handle an error response here
    }
  }
}
