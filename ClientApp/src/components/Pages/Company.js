import React, { Component } from 'react';
import './Data.css';

export class Company extends Component {
  static displayName = Company.name;

  constructor(props) {
    super(props);
    this.state = {
      companies: [],
      inputGetId: 0,
      inputDeleteId: 0,
      company: {
        companyId: 0,
        companyType: 0,
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
      updateCompany: {
        companyId: 0,
        companyType: 0,
        name: '',
        email: '',
        phone: '',
        address: '',
      },
      loading: true,
      isLoading: false,
    };

    this.handleGetInputChange = this.handleGetInputChange.bind(this);
    this.handleDeleteInputChange = this.handleDeleteInputChange.bind(this);
    this.onGetCompanyBtnClick = this.onGetCompanyBtnClick.bind(this);
    this.handleCreateInputChange = this.handleCreateInputChange.bind(this);
    this.onCreateBtnClick = this.onCreateBtnClick.bind(this);
    this.handleUpdateInputChange = this.handleUpdateInputChange.bind(this);
    this.onUpdateBtnClick = this.onUpdateBtnClick.bind(this);
    this.onDeleteCompanyBtnClick = this.onDeleteCompanyBtnClick.bind(this);
  }

  componentDidMount() {
    this.fetchCompaniesData();
  }

  handleGetInputChange(e) {
    this.setState({ inputGetId: e.target.value });
  }
  handleDeleteInputChange(e) {
    this.setState({ inputDeleteId: e.target.value });
  }

  async onGetCompanyBtnClick() {
    this.setState({ isLoading: true });
    
    try {
      await this.fetchCompanyData(this.state.inputGetId);
    } catch (error) {
      console.error('An error occurred: ', error);
    } finally {
      this.setState({ isLoading: false });
    }
  }

  handleCreateInputChange(e) {
    const { name, value } = e.target;
    this.setState((prevState) => ({
      createCompany: {
        ...prevState.createCompany,
        [name]: value,
      },
    }));
  }
  async onCreateBtnClick() {
    try {
      await this.fetchCreateCompany();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  handleUpdateInputChange(e) {
    const { name, value } = e.target;
    this.setState((prevState) => ({
      updateCompany: {
        ...prevState.updateCompany,
        [name]: value,
      },
    }));
  }
  async onUpdateBtnClick() {
    try {
      await this.fetchUpdateCompany();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  async onDeleteCompanyBtnClick() {
    try {
      await this.fetchDeleteCompany(this.state.inputDeleteId);
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
            type='number'
            placeholder='Enter Id'
            value={this.state.inputGetOrDeleteId}
            onChange={this.handleGetInputChange}
          />        
          <button onClick={this.onGetCompanyBtnClick}>Get company</button>
          {contentCompany}
        </div>

        <div className='company-create'>
          <h2>Create</h2>
          <input
            name='companyType'
            type='number'
            placeholder='Enter Type'
            value={this.state.createCompany.companyType}
            onChange={(e) => this.handleCreateInputChange(e)}
          />
          <input
            name='name'
            type='text'
            placeholder='Enter Name'
            value={this.state.createCompany.name}
            onChange={(e) => this.handleCreateInputChange(e)}
          />
          <input
            name='email'
            type='text'
            placeholder='Enter Email'
            value={this.state.createCompany.email}
            onChange={(e) => this.handleCreateInputChange(e)}
          />
          <input
            name='phone'
            type='text'
            placeholder='Enter Phone'
            value={this.state.createCompany.phone}
            onChange={(e) => this.handleCreateInputChange(e)}
          />
          <input
            name='address'
            type='text'
            placeholder='Enter Address'
            value={this.state.createCompany.address}
            onChange={(e) => this.handleCreateInputChange(e)}
          />
          <button type='submit' onClick={this.onCreateBtnClick}>Get company</button>
        </div>

        <div className='company-update'>
          <h2>Update</h2>
          <input
            name='companyId'
            type='number'
            placeholder='Enter Id'
            value={this.state.updateCompany.companyId}
            onChange={(e) => this.handleUpdateInputChange(e)}
          />
          <input
            name='companyType'
            type='number'
            placeholder='Enter Type'
            value={this.state.updateCompany.companyType}
            onChange={(e) => this.handleUpdateInputChange(e)}
          />
          <input
            name='name'
            type='text'
            placeholder='Enter Name'
            value={this.state.updateCompany.name}
            onChange={(e) => this.handleUpdateInputChange(e)}
          />
          <input
            name='email'
            type='text'
            placeholder='Enter Email'
            value={this.state.updateCompany.email}
            onChange={(e) => this.handleUpdateInputChange(e)}
          />
          <input
            name='phone'
            type='text'
            placeholder='Enter Phone'
            value={this.state.updateCompany.phone}
            onChange={(e) => this.handleUpdateInputChange(e)}
          />
          <input
            name='address'
            type='text'
            placeholder='Enter Address'
            value={this.state.updateCompany.address}
            onChange={(e) => this.handleUpdateInputChange(e)}
          />
          <button type='submit' onClick={this.onUpdateBtnClick}>Update company</button>
        </div>

        <div className='company-delete'>
          <h2>Delete</h2>
          <input
            type='number'
            placeholder='Enter Id'
            value={this.state.inputGetOrDeleteId}
            onChange={this.handleDeleteInputChange}
          />        
          <button onClick={this.onDeleteCompanyBtnClick}>Get company</button>
        </div>
      </div>
    );
  }

  async fetchCompaniesData() {
    try {
      const res = await fetch('/api/company');

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      this.setState({ companies: data, loading: false });
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async fetchCompanyData(companyId) {
    try {
      const res = await fetch(`/api/company/${companyId}`);

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

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
    } catch (err) {
      console.error('Fetch error:', err);
    } 
  }

  async fetchCreateCompany() {
    try {
      const res = await fetch('/api/company', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.state.createCompany),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async fetchUpdateCompany(companyId) {
    try {
      const res = await fetch(`/api/company/${companyId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.state.updateCompany),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async fetchDeleteCompany(companyId) {
    try {
      const res = await fetch(`/api/company/${companyId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.state.createCompany),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }
}
