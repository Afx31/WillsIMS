import React, { useState, useEffect } from 'react';
import './Data.css';

const BinLocations = () => {
  const [loading, setLoading] = useState(true);
  const [binLocation, setBinLocation] = useState([]);

  useEffect(() => {
    fetchBinLocationData();
  }, []);

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
          {binLocation.map(binLocation =>
            <tr key={binLocation.binLocationId}>
              <td>{binLocation.binLocationId}</td>
              <td>{binLocation.location}</td>
              <td>N/A</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
  
  let contentBinLocation = loading
    ? <p><em>Loading...</em></p>
    : renderBinLocationTable(binLocation);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Bin Locations</h1>
      {contentBinLocation}
    </div>
  );

  async function fetchBinLocationData() {
    const res = await fetch('/api/binLocation');
    const data = await res.json();
    setBinLocation(data);
    setLoading(false);
  }
}

export default BinLocations;
