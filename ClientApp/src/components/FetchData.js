import React, { Component } from 'react';
import './FetchData.css';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { products: [], loading: true };
    this.state = { inventoryItems: [], loading: true };
  }

  componentDidMount() {
    this.populateProductData();
    this.populateInventoryItemsData();
  }

  static renderProductsTable(products) {
    return (
      <table>
        <thead>
          <tr>
            <th>Product ID</th>
            <th>Product Number</th>
            <th>Description</th>
            <th>Category</th>
            <th>Supplier</th>
          </tr>
        </thead>
        <tbody>
          {products.map(product =>
            <tr key={product.productId}>
              <td>{product.productId}</td>
              <td>{product.productName}</td>
              <td>{product.description}</td>
              <td>{product.category}</td>
              <td>{product.supplierId}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
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
            <th>Warehouse Location</th>
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
              <td>{item.warehouseLocation}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderProductsTable(this.state.products);
    let contents2 = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderInventoryItemsTable(this.state.inventoryItems);

    return (
      <div className='fetchDataContainer'>
        <h1 id="tableLabel">Fetched data - Products</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
        {contents2}
      </div>
    );
  }

  async populateProductData() {
    const res = await fetch('product');
    const data = await res.json();
    this.setState({ products: data, loading: false });
  }
  async populateInventoryItemsData() {
    const res = await fetch('inventoryItem');
    const data = await res.json();
    this.setState({ inventoryItems: data, loading: false });
  }
}
