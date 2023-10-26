import React, { Component } from 'react';
import './Data.css';

export class InventoryItems extends Component {
  static displayName = InventoryItems.name;

  constructor(props) {
    super(props);
    this.state = { inventoryItems: [], loading: true };
  }

  componentDidMount() {
    this.populateInventoryItemsData();
  }

  static renderInventoryItemsTable(inventoryItems) {
    return (
      <table>
        <thead>
          <tr>
            <th>Inventory Item Id</th>
            <th>Product Id</th>
            <th>Current Stock Quantity</th>
            <th>Min Stock Threshold</th>
            <th>Reorder Point</th>
            <th>Bin Location(s)</th>
          </tr>
        </thead>
        <tbody>
          {inventoryItems.map(item =>
            <tr key={item.inventoryItemId}>
              <td>{item.inventoryItemId}</td>
              <td>{item.productId}</td>
              <td>{item.currentStockQuantity}</td>
              <td>{item.minStockThreshold}</td>
              <td>{item.reorderPoint}</td>
              <td>{item.binLocations}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contentInventoryItems = this.state.loading
      ? <p><em>Loading...</em></p>
      : InventoryItems.renderInventoryItemsTable(this.state.inventoryItems);

    return (
      <div className='dataContainer'>
        <h1 id='tableLabel'>Inventory Items</h1>
        {contentInventoryItems}
      </div>
    );
  }

  async populateInventoryItemsData() {
    //const res = await fetch('/api/inventoryItem');
    const res = await fetch('/api/inventoryItemWithBinLocations');
    const data = await res.json();
    this.setState({ inventoryItems: data, loading: false });
  }
}
