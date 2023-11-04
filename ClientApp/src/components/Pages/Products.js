import React, { useState, useEffect } from 'react';
import './Data.css';

const Products = () => {
  const [loading, setLoading] = useState(true);
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetchProductData();
  }, []);

  const renderProductsTable = (products) => {
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

  let contentProducts = loading
    ? <p><em>Loading...</em></p>
    : renderProductsTable(products);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Products</h1>
      {contentProducts}
    </div>
  );

  async function fetchProductData() {
    const res = await fetch('/api/product');
    const data = await res.json();
    setProducts(data);
    setLoading(false);
  }
}

export default Products;