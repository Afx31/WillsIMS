import React, { useState, useEffect } from 'react';
import './Company.css';
import { Input, Button } from 'rixun-ui';

const Company = () => {
  const [loading, setLoading] = useState(true);
  const [inputGetId, setInputGetId] = useState(0);
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

  useEffect(() => {
    fetchCompaniesData();
  }, []);

  //#region Handling input and change code
  const handleGetInputChange = (e) => {
    setInputGetId(e.target.value);
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
    setCompany({
      ...company,
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
      fetchDeleteCompany(company.companyId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }
  //#endregion

  const renderCompaniesTable = (companies) => {
    return (
      <div className='company-table'>
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
      </div>
    );
  }

  let contentCompanies = loading
    ? <p><em>Loading...</em></p>
    : renderCompaniesTable(companies);
    
  return (
    <div className='company-container'>
      <h1 id='tableLabel'>Company</h1>
      <div className='company-top'>
        <div className='company-top-left'>
          <h2>New Company</h2>
          <hr />
          <div className='company-top-left-top'>
            <div className='company-top-left-top-input-container'>
              <label>Name: </label>
              <Input
                className='rixun-input-company-top-create'
                name='name'
                type='text'
                placeholder='Name'
                value={createCompany.name}
                onChange={(e) => handleCreateInputChange(e)}
              />
            </div>
            <div className='company-top-left-top-input-container'>
              <label> Type: </label>
              <Input
                className='rixun-input-company-top-create'
                name='companyType'
                type='number'
                placeholder='Type'
                value={createCompany.companyType}
                onChange={(e) => handleCreateInputChange(e)}
              />
            </div>
            <div className='company-top-left-top-input-container'>
              <label>Email: </label>
              <Input
                className='rixun-input-company-top-create'
                name='email'
                type='text'
                placeholder='Email'
                value={createCompany.email}
                onChange={(e) => handleCreateInputChange(e)}
              />
            </div>
            <div className='company-top-left-top-input-container'>
              <label> Phone: </label>
              <Input
                className='rixun-input-company-top-create'
                name='phone'
                type='text'
                placeholder='Phone'
                value={createCompany.phone}
                onChange={(e) => handleCreateInputChange(e)}
              />
            </div>
            <div className='company-top-left-top-input-container'>
              <label>Address: </label>
              <Input
                className='rixun-input-company-top-create'
                name='address'
                type='text'
                placeholder='Address'
                value={createCompany.address}
                onChange={(e) => handleCreateInputChange(e)}
              />
            </div>
          </div>
          <Button
            className='rixun-button-company-bottom-create'
            type='default'
            onClick={onCreateBtnClick}
            name='Create company'
          />
        </div>
        <div className='company-top-right'>
          <h2>Update | Delete</h2>
          <div className='company-top-right-top'>
            <label>Search for Company Id: </label>
            <Input
              className='rixun-input-company-top-right-search'
              type='number'
              value={inputGetId}
              onChange={handleGetInputChange}
            />
            <Button
              className='rixun-button-company-top-right-search'
              type='default'
              onClick={onGetCompanyBtnClick}
              name='Search'
            />
          </div>
          <hr/>
          <div className='company-top-right-bottom '>
            <div className='company-top-right-bottom-input-container'>
              <label>Name: </label>
              <Input
                className='rixun-input-company-bottom-update'
                name='name'
                type='text'
                // placeholder='Name'
                value={company.name}
                onChange={(e) => handleUpdateInputChange(e)}
              />
            </div>
            <div className='company-top-right-bottom-input-container'>
              <label> Type: </label>
              <Input
                className='rixun-input-company-bottom-update'
                name='companyType'
                type='number'
                // placeholder='Type'
                value={company.companyType}
                onChange={(e) => handleUpdateInputChange(e)}
              />
            </div>
            <div className='company-top-right-bottom-input-container'>
              <label>Email: </label>
              <Input
                className='rixun-input-company-bottom-update'
                name='email'
                type='text'
                // placeholder='Email'
                value={company.email}
                onChange={(e) => handleUpdateInputChange(e)}
              />
            </div>
            <div className='company-top-right-bottom-input-container'>
              <label> Phone: </label>
              <Input
                className='rixun-input-company-bottom-update'
                name='phone'
                type='text'
                // placeholder='Phone'
                value={company.phone}
                onChange={(e) => handleUpdateInputChange(e)}
              />
            </div>
            <div className='company-top-right-bottom-input-container'>
              <label>Address: </label>
              <Input
                className='rixun-input-company-bottom-update'
                name='address'
                type='text'
                // placeholder='Address'
                value={company.address}
                onChange={(e) => handleUpdateInputChange(e)}
              />
            </div>
          </div>
          <Button
            className='rixun-button-company-bottom-update'
            // type='submit'
            name='Update Company'
            onClick={onUpdateBtnClick}
          />
          <Button
            className='rixun-button-company-bottom-update'
            name='Delete Company'
            onClick={onDeleteCompanyBtnClick}
          />
        </div>
      </div>
      <div className='company-bottom'>
        <h2>All Companies</h2>
        {contentCompanies}
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

      const data = await res.json(); console.log(data)
      setCompany({
        companyId: data.companyId,
        companyType: data.companyType,
        name: data.name,
        email: data.email,
        phone: data.phone,
        address: data.address,
      });
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
        body: JSON.stringify(company),
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