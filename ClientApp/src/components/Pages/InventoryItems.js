import React, { useState, useEffect } from 'react';
import './Data.css';

const InventoryItems = () => {
  const [loading, setLoading] = useState(true);
  const [inventoryItems, setInventoryItems] = useState([]);
  const [inputGetId, setInputGetId] = useState(0);
  const [inputDeleteId, setInputDeleteId] = useState(0);
  const [inventoryItem, setInventoryItem] = useState({
    inventoryItemId: 0,
    productId: 0,
    currentStockQuantity: 0,
    minStockThreshold: 0,
    reorderPoint: 0,
    binLocations: []
  });
  const [createInventoryItem, setCreateInventoryItem] = useState({
    inventoryItemId: 0,
    productId: 0,
    currentStockQuantity: 0,
    minStockThreshold: 0,
    reorderPoint: 0,
    binLocations: []
  });
  const [updateInventoryItem, setUpdateInventoryItem] = useState({
    inventoryItemId: 0,
    productId: 0,
    currentStockQuantity: 0,
    minStockThreshold: 0,
    reorderPoint: 0,
    binLocations: []
  });

  useEffect(() => {
    fetchInventoryItemsData();
  }, []);

  const handleGetInputChange = (e) => {
    setInputGetId(e.target.value);
  }
  const handleDeleteInputChange = (e) => {
    setInputDeleteId(e.target.value);
  }

  const onGetInventoryItemBtnClick = () => {
    try {
      fetchInventoryItemData(inputGetId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleCreateInputChange = (e) => {
    e.preventDefault();
    setCreateInventoryItem({
      ...createInventoryItem,
      [e.target.name]: e.target.value
    });
  }
  const onCreateBtnClick = () => {
    try {
      fetchCreateInventoryItem();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const handleUpdateInputChange = (e) => {
    e.preventDefault();
    setUpdateInventoryItem({
      ...updateInventoryItem,
      [e.target.name]: e.target.value
    });
  }
  const onUpdateBtnClick = () => {
    try {
      fetchUpdateInventoryItem();
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const onDeleteInventoryItemBtnClick = () => {
    try {
      fetchDeleteInventoryItem(inputDeleteId);
    } catch (error) {
      console.error('An error occurred: ', error);
    }
  }

  const renderInventoryItemsTable = (inventoryItems) => {
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

  const renderInventoryItemTable = (inventoryItem) => {
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
          <tr key={item.inventoryItemId}>
            <td>{item.inventoryItemId}</td>
            <td>{item.productId}</td>
            <td>{item.currentStockQuantity}</td>
            <td>{item.minStockThreshold}</td>
            <td>{item.reorderPoint}</td>
            <td>{item.binLocations}</td>
          </tr>
        </tbody>
      </table>
    );
  }

  let contentInventoryItems = loading
    ? <p><em>Loading...</em></p>
    : renderInventoryItemsTable(inventoryItems);
  let contentInventoryItem = loading
    ? <p><em>Loading...</em></p>
    : renderInventoryItemTable(inventoryItem);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Inventory Items</h1>

      <div className='inventoryItem-get-all'>
        <h2>Get All</h2>
        {contentInventoryItems}
      </div>

      <div className='inventoryItem-get'>
        <h2>Get Individual</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputGetId}
          onChange={handleGetInputChange}
        />        
        <button onClick={onGetInventoryItemBtnClick}>Get inventory item</button>
        {contentInventoryItem}
      </div>

      <div className='inventoryItem-create'>
        <h2>Create</h2>
        <input
          name='productId'
          type='number'
          placeholder='Enter ProductId'
          value={createInventoryItem.productId}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='currentStockQuantity'
          type='number'
          placeholder='Enter CurrentStockQuantity'
          value={createInventoryItem.currentStockQuantity}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='minStockThreshold'
          type='number'
          placeholder='Enter MinStockThreshold'
          value={createInventoryItem.minStockThreshold}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <input
          name='reorderPoint'
          type='number'
          placeholder='Enter ReorderPoint'
          value={createInventoryItem.reorderPoint}
          onChange={(e) => handleCreateInputChange(e)}
        />
        <button type='submit' onClick={onCreateBtnClick}>Create inventoryItem</button>
      </div>

      <div className='inventoryItem-update'>
        <h2>Update</h2>
        <input
          name='inventoryItemId'
          type='number'
          placeholder='Enter Id'
          value={updateInventoryItem.inventoryItemId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='productId'
          type='number'
          placeholder='Enter Id'
          value={updateInventoryItem.productId}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='currentStockQuantity'
          type='number'
          placeholder='Enter CurrentStockQuantity'
          value={updateInventoryItem.currentStockQuantity}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='minStockThreshold'
          type='number'
          placeholder='Enter MinStockThreshold'
          value={updateInventoryItem.minStockThreshold}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <input
          name='reorderPoint'
          type='number'
          placeholder='Enter ReorderPoint'
          value={updateInventoryItem.reorderPoint}
          onChange={(e) => handleUpdateInputChange(e)}
        />
        <button type='submit' onClick={onUpdateBtnClick}>Update inventoryItem</button>
      </div>

      <div className='inventoryItem-delete'>
        <h2>Delete</h2>
        <input
          type='number'
          placeholder='Enter Id'
          value={inputDeleteId}
          onChange={handleDeleteInputChange}
        />        
        <button onClick={onDeleteProductBtnClick}>Delete inventoryItem</button>
      </div>

    </div>
  );
  
  async function fetchInventoryItemsData() {
    const res = await fetch('/api/inventoryItem');
    // const res = await fetch('/api/inventoryItemWithBinLocations');
    const data = await res.json();
    setInventoryItems(data);
    setLoading(false);
  }

  async function fetchInventoryItemData(inventoryItemId) {
    try {
      const res = await fetch(`/api/inventoryItem/${inventoryItemId}`);
      
      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }

      const data = await res.json();
      setInventoryItem((prevState) => ({
        ...prevState,
        inventoryItem: {
          inventoryItemId: data.inventoryItemId,
          productId: data.productId,
          currentStockQuantity: data.currentStockQuantity,
          minStockThreshold: data.minStockThreshold,
          reorderPoint: data.reorderPoint,
          binLocations: data.binLocations,
        },
        loading: false,
      }));
    } catch (err) {
      console.error('Fetch error:', err);
    } 
  }

  async function fetchCreateInventoryItem() {
    try {
      const res = await fetch('/api/inventoryItem', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(createInventoryItem),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchUpdateInventoryItem(inventoryItemId) {
    try {
      const res = await fetch(`/api/inventoryItem/${inventoryItemId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateInventoryItem),
      });

      if (!res.ok) { throw new Error(`HTTP error! Status: ${res.status}`); }
    } catch (err) {
      console.error('Fetch error:', err);
    }
  }

  async function fetchDeleteInventoryItem(inventoryItemId) {
    try {
      const res = await fetch(`/api/inventoryItem/${inventoryItemId}`, {
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

export default InventoryItems;