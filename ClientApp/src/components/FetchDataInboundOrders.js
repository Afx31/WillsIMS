import React, { Component } from 'react';
import './FetchData.css';

export class FetchDataInboundOrders extends Component {
  static displayName = FetchDataInboundOrders.name;

  constructor(props) {
    super(props);
    this.state = { inboundOrders: [], loading: true };
    this.state = { inboundOrderItems: [], loading: true };
  }

  componentDidMount() {
    this.populateInboundOrdersData();
    this.populateInboundOrderItemsData();
  }

  static renderInboundOrdersTable(inboundOrders) {
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

  static renderInboundOrderItemsTable(inboundOrderItems) {
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

  render() {
    let contentsInboundOrders = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataInboundOrders.renderInboundOrdersTable(this.state.inboundOrders);
    let contentsInboundOrderItems = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataInboundOrders.renderInboundOrderItemsTable(this.state.inboundOrderItems);

    return (
      <div className='fetchDataContainer'>
        <h1 id='tableLabel'>Fetched data - Inbound Orders</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contentsInboundOrders}
        {contentsInboundOrderItems}
      </div>
    );
  }

  async populateInboundOrdersData() {
    const res = await fetch('/api/inboundOrder');
    const data = await res.json();
    this.setState({ inboundOrders: data, loading: false });
  }
  async populateInboundOrderItemsData() {
    const res = await fetch('/api/inboundOrderItem');
    const data = await res.json();
    this.setState({ inboundOrderItems: data, loading: false });
  }
}
