import React, { useState, useEffect } from 'react';
import './Data.css';

const Product = () => {
  const [loading, setLoading] = useState(true);
  const [products, setProducts] = useState([]);
  const [inputGetId, setInputGetId] = useState(0);
  const [inputDeleteId, setInputDeleteId] = useState(0);
  const [product, setProduct] = useState({
    productId: 0,
    name: '',
    description: '',
    category: 0,
    supplierId: 0,
  });
  const [createProduct, setCreateProduct] = useState({
    productId: 0,
    name: '',
    description: '',
    category: 0,
    supplierId: 0,
  });
  const [updateProduct, setUpdateProduct] = useState({
    productId: 0,
    name: '',
    description: '',
    category: 0,
    supplierId: 0,
  });

  useEffect(() => {
    fetchProductsData();
  }, []);

  const handleGetInputChange = (e) => {
    setInputGetId(e.target.value);
  }
  const handleDeleteInputChange = (e) => {
    setInputDeleteId(e.target.value);
  }

  const onGetProductBtnClick = () => {
    try {
      fetchProductData(inputGetId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleCreateInputChange = (e) => {
    e.preventDefault();
    setCreateProduct({
      ...createProduct,
      [e.target.name]: e.target.value
    });
  }
  const onCreateBtnClick = () => {
    try {
      fetchCreateProduct();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleUpdateInputChange = (e) => {
    e.preventDefault();
    setUpdateProduct({
      ...updateProduct,
      [e.target.name]: e.target.value
    });
  }
  const onUpdateBtnClick = () => {
    try {
      fetchUpdateProduct();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const onDeleteProductBtnClick = () => {
    try {
      fetchDeleteProduct(inputDeleteId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

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

  const renderProductTable = (product) => {
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
          {
            <tr>
              <td>{product.productId}</td>
              <td>{product.name}</td>
              <td>{product.description}</td>
              <td>{product.category}</td>
              <td>{product.supplierId}</td>
            </tr>
          }
        </tbody>
      </table>
    );
  }

  let contentProducts = loading
    ? <p><em>Loading...</em></p>
    : renderProductsTable(products);
  let contentProduct = loading
  ? <p><em>Loading...</em></p>
  : renderProductTable(product);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Product</h1>

      <div className='product-get-all'>
        <h2>Get All</h2>
        {contentProducts}
      </div>

      <div className='product-get'>
        <h2>Get Individual</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputGetId}
          onChange={handleGetInputChange}
        />        
        <button onClick={onGetProductBtnClick}>Get product</button>
        {contentProduct}
      </div>

      <div className='product-create'>
        <h2>Create</h2>
        <input
          name='name'
          type='text'
          placeholder='Enter Name'
          value={createProduct.name}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='description'
          type='text'
          placeholder='Enter Description'
          value={createProduct.description}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='category'
          type='number'
          placeholder='Enter Category'
          value={createProduct.category}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='supplierId'
          type='number'
          placeholder='Enter SupplierId'
          value={createProduct.supplierId}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <button type='submit' onClick={onCreateBtnClick}>Create product</button>
      </div>

      <div className='product-update'>
        <h2>Update</h2>
        <input
          name='productId'
          type='number'
          placeholder='Enter Id'
          value={updateProduct.productId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='name'
          type='text'
          placeholder='Enter Name'
          value={updateProduct.name}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='description'
          type='text'
          placeholder='Enter Description'
          value={updateProduct.description}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='category'
          type='number'
          placeholder='Enter Category'
          value={updateProduct.category}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='supplierId'
          type='number'
          placeholder='Enter SupplierId'
          value={updateProduct.supplierId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <button type='submit' onClick={onUpdateBtnClick}>Update product</button>
      </div>

      <div className='product-delete'>
        <h2>Delete</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputDeleteId}
          onChange={handleDeleteInputChange}
        />        
        <button onClick={onDeleteProductBtnClick}>Delete product</button>
      </div>
    </div>
  );

  async function fetchProductsData() {
    try {
      const res = await fetch('/api/product');

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      setProducts(data);
      setLoading(false);
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchProductData(productId) {
    try {
      console.log('test1', productId)
      const res = await fetch(`/api/product/${productId}`);
console.log('test2')
      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      setProduct((prevState) => ({
        ...prevState,
        product: {
          productId: data.productId,
          name: data.name,
          description: data.description,
          category: data.category,
          supplierId: data.supplierId,
        },
        loading: false,
      }));
    } catch (err) {
      console.error('Fetch error:', err);
    } 
  }

  async function fetchCreateProduct() {
    try {
      const res = await fetch('/api/product', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(createProduct),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchUpdateProduct(productId) {
    try {
      const res = await fetch(`/api/product/${productId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateProduct),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchDeleteProduct(productId) {
    try {
      const res = await fetch(`/api/product/${productId}`, {
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

export default Product;