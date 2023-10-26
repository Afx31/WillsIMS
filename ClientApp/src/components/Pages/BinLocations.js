import React, { Component } from 'react';
import './Data.css';

export class BinLocations extends Component {
  static displayName = BinLocations.name;

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
      : BinLocations.renderBinLocationTable(this.state.binLocation);

    return (
      <div className='dataContainer'>
        <h1 id='tableLabel'>Bin Locations</h1>
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
