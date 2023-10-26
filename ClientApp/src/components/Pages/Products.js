import React, { Component } from 'react';
import './Data.css';

export class Products extends Component {
  static displayName = Products.name;

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
            <th>Product Name</th>
            <th>Description</th>
            <th>Category</th>
            <th>Supplier</th>
          </tr>
        </thead>
        <tbody>
          {products.map(product =>
            <tr key={product.productId}>
              <td>{product.productId}</td>
              <td>{product.name}</td>
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
    let contentProducts = this.state.loading
      ? <p><em>Loading...</em></p>
      : Products.renderProductsTable(this.state.products);

    return (
      <div className='dataContainer'>
        <h1 id='tableLabel'>Products</h1>
        {contentProducts}
      </div>
    );
  }

  async populateProductData() {
    const res = await fetch('/api/product');
    const data = await res.json();
    this.setState({ products: data, loading: false });
  }
}
