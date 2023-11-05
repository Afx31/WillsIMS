import React, { useState, useEffect } from 'react';
import './Data.css';

const Company = () => {
  const [loading, setLoading] = useState(true);
  const [inputGetId, setInputGetId] = useState(0);
  const [inputDeleteId, setInputDeleteId] = useState(0);
  const [companies, setCompanies] = useState([]);
  const [company, setCompany] = useState({
    companyId: 0,
    companyType: 0,
    name: '',
    email: '',
    phone: '',
    address: '',
  });
  const [createCompany, setCreateCompany] = useState({
    companyId: 0,
    companyType: 0,
    name: '',
    email: '',
    phone: '',
    address: '',
  });
  const [updateCompany, setUpdateCompany] = useState({
    companyId: 0,
    companyType: 0,
    name: '',
    email: '',
    phone: '',
    address: '',
  });

  useEffect(() => {
    fetchCompaniesData();
  }, []);

  const handleGetInputChange = (e) => {
    setInputGetId(e.target.value);
  }
  const handleDeleteInputChange = (e) => {
    setInputDeleteId(e.target.value);
  }

  const onGetCompanyBtnClick = () => {
    try {
      fetchCompanyData(inputGetId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleCreateInputChange = (e) => {
    e.preventDefault();
    setCreateCompany({
      ...createCompany,
      [e.target.name]: e.target.value
    });
  }
  const onCreateBtnClick = () => {
    try {
      fetchCreateCompany();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleUpdateInputChange = (e) => {
    e.preventDefault();
    setUpdateCompany({
      ...updateCompany,
      [e.target.name]: e.target.value
    });
  }
  const onUpdateBtnClick = () => {
    try {
      fetchUpdateCompany();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const onDeleteCompanyBtnClick = () => {
    try {
      fetchDeleteCompany(inputDeleteId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const renderCompaniesTable = (companies) => {
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

  const renderCompanyTable = (company) => {
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
            <tr>
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

  
  let contentCompanies = loading
    ? <p><em>Loading...</em></p>
    : renderCompaniesTable(companies);
  let contentCompany = loading
    ? <p><em>Loading...</em></p>
    : renderCompanyTable(company);
    
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
          value={inputGetId}
          onChange={handleGetInputChange}
        />        
        <button onClick={onGetCompanyBtnClick}>Get company</button>
        {contentCompany}
      </div>

      <div className='company-create'>
        <h2>Create</h2>
        <input
          name='companyType'
          type='number'
          placeholder='Enter Type'
          value={createCompany.companyType}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='name'
          type='text'
          placeholder='Enter Name'
          value={createCompany.name}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='email'
          type='text'
          placeholder='Enter Email'
          value={createCompany.email}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='phone'
          type='text'
          placeholder='Enter Phone'
          value={createCompany.phone}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='address'
          type='text'
          placeholder='Enter Address'
          value={createCompany.address}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <button type='submit' onClick={onCreateBtnClick}>Get company</button>
      </div>

      <div className='company-update'>
        <h2>Update</h2>
        <input
          name='companyId'
          type='number'
          placeholder='Enter Id'
          value={updateCompany.companyId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='companyType'
          type='number'
          placeholder='Enter Type'
          value={updateCompany.companyType}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='name'
          type='text'
          placeholder='Enter Name'
          value={updateCompany.name}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='email'
          type='text'
          placeholder='Enter Email'
          value={updateCompany.email}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='phone'
          type='text'
          placeholder='Enter Phone'
          value={updateCompany.phone}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='address'
          type='text'
          placeholder='Enter Address'
          value={updateCompany.address}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <button type='submit' onClick={onUpdateBtnClick}>Update company</button>
      </div>

      <div className='company-delete'>
        <h2>Delete</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputDeleteId}
          onChange={handleDeleteInputChange}
        />        
        <button onClick={onDeleteCompanyBtnClick}>Delete company</button>
      </div>
    </div>
  );

  async function fetchCompaniesData() {
    try {
      const res = await fetch('/api/company');

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();      
      setCompanies(data);
      setLoading(false);
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchCompanyData(companyId) {
    try {
      const res = await fetch(`/api/company/${companyId}`);

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      setCompany((prevState) => ({
        ...prevState,
        company: {
          companyId: data.companyId,
          companyType: data.companyType,
          name: data.name,
          email: data.email,
          phone: data.phone,
          address: data.address,
        },
        loading: false,
      }));
    } catch (err) {
      console.error('Fetch error:', err);
    } 
  }

  async function fetchCreateCompany() {
    try {
      const res = await fetch('/api/company', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(createCompany),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchUpdateCompany(companyId) {
    try {
      const res = await fetch(`/api/company/${companyId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateCompany),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchDeleteCompany(companyId) {
    try {
      const res = await fetch(`/api/company/${companyId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        }
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }
}

export default Company;