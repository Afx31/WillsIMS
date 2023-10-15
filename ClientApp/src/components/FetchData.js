import React, { Component } from 'react';
import './FetchData.css';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { products: [], loading: true };
  }

  componentDidMount() {
    this.populateProductData();
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

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderProductsTable(this.state.products);

    return (
      <div className='fetchDataContainer'>
        <h1 id="tableLabel">Fetched data - Products</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateProductData() {
    const res = await fetch('product');
    const data = await res.json();
    console.log(data)
    this.setState({ products: data, loading: false });
  }
}
