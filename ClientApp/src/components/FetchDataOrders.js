import React, { Component } from 'react';
import './FetchData.css';

export class FetchDataOrders extends Component {
  static displayName = FetchDataOrders.name;

  constructor(props) {
    super(props);
    this.state = { orders: [], loading: true };
    this.state = { orderItems: [], loading: true };
  }

  componentDidMount() {
    this.populateOrdersData();
    this.populateOrderItemsData();
  }

  static renderOrdersTable(orders) {
    return (
      <table>
        <thead>
          <tr>
            <th>Orders Id</th>
            <th>Customer Id</th>
            <th>Order Date</th>
          </tr>
        </thead>
        <tbody>
          {orders.map(order =>
            <tr key={order.ordersId}>
              <td>{order.ordersId}</td>
              <td>{order.customerId}</td>
              <td>{order.orderDate}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  static renderOrderItemsTable(orderItems) {
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
          {orderItems.map(orderItem =>
            <tr key={orderItem.orderItemId}>
              <td>{orderItem.orderItemId}</td>
              <td>{orderItem.ordersId}</td>
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
    let contentsOrders = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataOrders.renderOrdersTable(this.state.orders);
    let contentsOrderItems = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataOrders.renderOrderItemsTable(this.state.orderItems);

    return (
      <div className='fetchDataContainer'>
        <h1 id="tableLabel">Fetched data - Orders</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contentsOrders}
        {contentsOrderItems}
      </div>
    );
  }

  async populateOrdersData() {
    const res = await fetch('/api/orders');
    const data = await res.json();
    this.setState({ orders: data, loading: false });
  }
  async populateOrderItemsData() {
    const res = await fetch('/api/orderItem');
    const data = await res.json();
    this.setState({ orderItems: data, loading: false });
  }
}
