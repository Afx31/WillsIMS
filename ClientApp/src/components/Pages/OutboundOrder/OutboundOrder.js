import React, { useState, useEffect } from 'react';
import './OutboundOrder.css';

const OutboundOrder = () => {
  const [loading, setLoading] = useState(true);
  const [outboundOrders, setOutboundOrders] = useState([]);
  const [outboundOrderItems, setOutboundOrderItems] = useState([]);
  
  useEffect(() => {
    fetchOutboundOrdersData();
    fetchOutboundOrderItemsData();
  }, []);

  const renderOutboundOrdersTable = (outboundOrders) => {
    return (
      <table>
        <thead>
          <tr>
            <th>Outbound Orders Id</th>
            <th>Customer Id</th>
            <th>Order Date</th>
          </tr>
        </thead>
        <tbody>
          {outboundOrders.map(order =>
            <tr key={order.outboundOrderId}>
              <td>{order.outboundOrderId}</td>
              <td>{order.customerId}</td>
              <td>{order.orderDate}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  const renderOutboundOrderItemsTable = (outboundOrderItems) => {
    return (
      <table>
        <thead>
          <tr>
            <th>Order Item Id</th>
            <th>Orders Id</th>
            <th>Product Id</th>
            <th>Quantity</th>
            <th>UnitPrice</th>
          </tr>
        </thead>
        <tbody>
          {outboundOrderItems.map(orderItem =>
            <tr key={orderItem.outboundOrderItemId}>
              <td>{orderItem.outboundOrderItemId}</td>
              <td>{orderItem.outboundOrderId}</td>
              <td>{orderItem.productId}</td>
              <td>{orderItem.quantity}</td>
              <td>{orderItem.unitPrice}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  let contentsOutboundOrders = loading
    ? <p><em>Loading...</em></p>
    : renderOutboundOrdersTable(outboundOrders);
  let contentsOutboundOrderItems = loading
    ? <p><em>Loading...</em></p>
    : renderOutboundOrderItemsTable(outboundOrderItems);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Outbound Orders</h1>
      {contentsOutboundOrders}
      {contentsOutboundOrderItems}
    </div>
  );

  async function fetchOutboundOrdersData() {
    const res = await fetch('/api/outboundOrder');
    const data = await res.json();
    setOutboundOrders(data);
    setLoading(false);
  }
  async function fetchOutboundOrderItemsData() {
    const res = await fetch('/api/outboundOrderItem');
    const data = await res.json();
    setOutboundOrderItems(data);
    setLoading(false);
  }
}

export default OutboundOrder;