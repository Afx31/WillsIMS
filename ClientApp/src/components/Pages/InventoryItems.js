import React, { useState, useEffect } from 'react';
import './Data.css';

const InventoryItems = () => {
  const [loading, setLoading] = useState(true);
  const [inventoryItems, setInventoryItems] = useState([]);

  useEffect(() => {
    fetchInventoryItemsData();
  }, []);

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

  let contentInventoryItems = loading
    ? <p><em>Loading...</em></p>
    : renderInventoryItemsTable(inventoryItems);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Inventory Items</h1>
      {contentInventoryItems}
    </div>
  );
  
  async function fetchInventoryItemsData() {
    //const res = await fetch('/api/inventoryItem');
    const res = await fetch('/api/inventoryItemWithBinLocations');
    const data = await res.json();
    setInventoryItems(data);
    setLoading(false);
  }
}

export default InventoryItems;