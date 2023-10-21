import React, { Component } from 'react';
import './FetchData.css';

export class FetchDataBinLocation extends Component {
  static displayName = FetchDataBinLocation.name;

  constructor(props) {
    super(props);
    this.state = { binLocation: [], loading: true };
  }

  componentDidMount() {
    this.populateBinLocationData();
  }

  static renderBinLocationTable(binLocation) {
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

  render() {
    let contentBinLocation = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataBinLocation.renderBinLocationTable(this.state.binLocation);

    return (
      <div className='fetchDataContainer'>
        <h1 id='tableLabel'>Fetched data - Bin Location</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contentBinLocation}
      </div>
    );
  }

  async populateBinLocationData() {
    const res = await fetch('/api/binLocation');
    const data = await res.json();
    this.setState({ binLocation: data, loading: false });
  }
}
