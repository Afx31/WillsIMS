import React, { useState, useEffect } from 'react';
import './InboundOrder.css';

const InboundOrder = () => {
  const [loading, setLoading] = useState(true);
  const [inboundOrders, setInboundOrders] = useState([]);
  const [inboundOrderItems, setInboundOrderItems] = useState([]);

  useEffect(() => {
    fetchInboundOrdersData();
    fetchInboundOrderItemsData();
  }, []);

  const renderInboundOrdersTable = (inboundOrders) => {
    return (
      <table>
        <thead>
          <tr>
            <th>Inbound Orders Id</th>
            <th>Company Id</th>
            <th>Order Date</th>
          </tr>
        </thead>
        <tbody>
          {inboundOrders.map(order =>
            <tr key={order.inboundOrderId}>
              <td>{order.inboundOrderId}</td>
              <td>{order.companyId}</td>
              <td>{order.purchaseDate}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  const renderInboundOrderItemsTable = (inboundOrderItems) => {
    return (
      <table>
        <thead>
          <tr>
            <th>Order Item Id</th>
            <th>Orders Id</th>
            <th>Product Id</th>
            <th>Quantity</th>
            <th>Purchase Price</th>
          </tr>
        </thead>
        <tbody>
          {inboundOrderItems.map(orderItem =>
            <tr key={orderItem.inboundOrderItemId}>
              <td>{orderItem.inboundOrderItemId}</td>
              <td>{orderItem.inboundOrderId}</td>
              <td>{orderItem.productId}</td>
              <td>{orderItem.quantity}</td>
              <td>{orderItem.purchasePrice}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  let contentsInboundOrders = loading
    ? <p><em>Loading...</em></p>
    : renderInboundOrdersTable(inboundOrders);
  let contentsInboundOrderItems = loading
    ? <p><em>Loading...</em></p>
    : renderInboundOrderItemsTable(inboundOrderItems);

  return (
    <div className='dataContainer'>
      <h1 id='tableLabel'>Inbound Orders</h1>
      {contentsInboundOrders}
      {contentsInboundOrderItems}
    </div>
  );

  async function fetchInboundOrdersData() {
    const res = await fetch('/api/inboundOrder');
    const data = await res.json();
    setInboundOrders(data);
    setLoading(false);
  }
  async function fetchInboundOrderItemsData() {
    const res = await fetch('/api/inboundOrderItem');
    const data = await res.json();
    setInboundOrderItems(data);
    setLoading(false);
  }
}

export default InboundOrder;