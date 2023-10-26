import React, { Component } from 'react';
import './Data.css';

export class OutboundOrders extends Component {
  static displayName = OutboundOrders.name;

  constructor(props) {
    super(props);
    this.state = { outboundOrders: [], loading: true };
    this.state = { outboundOrderItems: [], loading: true };
  }

  componentDidMount() {
    this.populateOutboundOrdersData();
    this.populateOutboundOrderItemsData();
  }

  static renderOutboundOrdersTable(outboundOrders) {
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

  static renderOutboundOrderItemsTable(outboundOrderItems) {
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

  render() {
    let contentsOutboundOrders = this.state.loading
      ? <p><em>Loading...</em></p>
      : OutboundOrders.renderOutboundOrdersTable(this.state.outboundOrders);
    let contentsOutboundOrderItems = this.state.loading
      ? <p><em>Loading...</em></p>
      : OutboundOrders.renderOutboundOrderItemsTable(this.state.outboundOrderItems);

    return (
      <div className='dataContainer'>
        <h1 id='tableLabel'>Outbound Orders</h1>
        {contentsOutboundOrders}
        {contentsOutboundOrderItems}
      </div>
    );
  }

  async populateOutboundOrdersData() {
    const res = await fetch('/api/outboundOrder');
    const data = await res.json();
    this.setState({ outboundOrders: data, loading: false });
  }
  async populateOutboundOrderItemsData() {
    const res = await fetch('/api/outboundOrderItem');
    const data = await res.json();
    this.setState({ outboundOrderItems: data, loading: false });
  }
}
