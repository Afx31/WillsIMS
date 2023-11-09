import React, { useState, useEffect } from 'react';
import './Data.css';

const BinLocations = () => {
  const [loading, setLoading] = useState(true);
  const [binLocations, setBinLocations] = useState([]);
  const [inputGetId, setInputGetId] = useState(0);
  const [inputDeleteId, setInputDeleteId] = useState(0);
  const [binLocation, setBinLocation] = useState({
    binLocationId: 0,
    location: '',
    inventoryItemId: '',
    category: 0,
    supplierId: 0,
  });
  const [createBinLocation, setCreateBinLocation] = useState({
    binLocationId: 0,
    location: '',
    inventoryItemId: '',
    category: 0,
    supplierId: 0,
  });
  const [updateBinLocation, setUpdateBinLocation] = useState({
    binLocationId: 0,
    location: '',
    inventoryItemId: '',
    category: 0,
    supplierId: 0,
  });

  useEffect(() => {
    fetchBinLocationsData();
  }, []);

  const handleGetInputChange = (e) => {
    setInputGetId(e.target.value);
  }
  const handleDeleteInputChange = (e) => {
    setInputDeleteId(e.target.value);
  }

  const onGetBinLocationBtnClick = () => {
    try {
      fetchBinLocationData(inputGetId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleCreateInputChange = (e) => {
    e.preventDefault();
    setCreateBinLocation({
      ...createBinLocation,
      [e.target.name]: e.target.value
    });
  }
  const onCreateBtnClick = () => {
    try {
      fetchCreateBinLocation();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleUpdateInputChange = (e) => {
    e.preventDefault();
    setUpdateBinLocation({
      ...updateBinLocation,
      [e.target.name]: e.target.value
    });
  }
  const onUpdateBtnClick = () => {
    try {
      fetchUpdateBinLocation();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const onDeleteBinLocationBtnClick = () => {
    try {
      fetchDeleteBinLocation(inputDeleteId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const renderBinLocationsTable = (binLocations) => {
    return (
      <table>
        <thead>
          <tr>
            <th>BinLocation Id</th>
            <th>Location</th>
            <th>ProductId</th>
          </tr>
        </thead>
        <tbody>
          {binLocations.map(binLocation =>
            <tr key={binLocation.binLocationId}>
              <td>{binLocation.binLocationId}</td>
              <td>{binLocation.location}</td>
              <td>{binLocation.inventoryItemId}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  const renderBinLocationTable = (binLocation) => {
    return (
      <table>
        <thead>
          <tr>
            <th>BinLocation Id</th>
            <th>Location</th>
            <th>ProductId</th>
          </tr>
        </thead>
        <tbody>
          <tr key={binLocation.binLocationId}>
            <td>{binLocation.binLocationId}</td>
            <td>{binLocation.location}</td>
            <td>{binLocation.inventoryItemId}</td>
          </tr>
        </tbody>
      </table>
    );
  }

  
  let contentBinLocations = loading
    ? <p><em>Loading...</em></p>
    : renderBinLocationsTable(binLocations);
  let contentBinLocation = loading
    ? <p><em>Loading...</em></p>
    : renderBinLocationTable(binLocation);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Bin Locations</h1>
      {contentBinLocations}

      <div className='binLocation-get'>
        <h2>Get Individual</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputGetId}
          onChange={handleGetInputChange}
        />        
        <button onClick={onGetBinLocationBtnClick}>Get binLocation</button>
        {contentBinLocation}
      </div>

      <div className='binLocation-create'>
        <h2>Create</h2>
        <input
          name='location'
          type='text'
          placeholder='Enter Location'
          value={createBinLocation.location}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='inventoryItemId'
          type='text'
          placeholder='Enter InventoryItemId'
          value={createBinLocation.inventoryItemId}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <button type='submit' onClick={onCreateBtnClick}>Create binLocation</button>
      </div>

      <div className='binLocation-update'>
        <h2>Update</h2>
        <input
          name='binLocationId'
          type='number'
          placeholder='Enter BinLocationId'
          value={updateBinLocation.binLocationId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='location'
          type='text'
          placeholder='Enter Location'
          value={updateBinLocation.location}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='inventoryItemId'
          type='number'
          placeholder='Enter InventoryItemId'
          value={updateBinLocation.inventoryItemId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <button type='submit' onClick={onUpdateBtnClick}>Update binLocation</button>
      </div>

      <div className='binLocation-delete'>
        <h2>Delete</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputDeleteId}
          onChange={handleDeleteInputChange}
        />        
        <button onClick={onDeleteBinLocationBtnClick}>Delete binLocation</button>
      </div>
    </div>
  );

  async function fetchBinLocationsData() {
    try {
      const res = await fetch('/api/binLocation');

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      setBinLocations(data);
      setLoading(false);
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchBinLocationData(binLocationId) {
    try {
      const res = await fetch(`/api/binLocation/${binLocationId}`);
      
      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      setBinLocation((prevState) => ({
        ...prevState,
        binLocation: {
          binLocationId: data.binLocationId,
          location: data.location,
          inventoryItemId: data.inventoryItemId
        },
        loading: false,
      }));
    } catch (err) {
      console.error('Fetch error:', err);
    } 
  }

  async function fetchCreateBinLocation() {
    try {
      const res = await fetch('/api/binLocation', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(createBinLocation),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchUpdateBinLocation(binLocationId) {
    try {
      const res = await fetch(`/api/binLocation/${binLocationId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateBinLocation),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchDeleteBinLocation(binLocationId) {
    try {
      const res = await fetch(`/api/binLocation/${binLocationId}`, {
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

export default BinLocations;
