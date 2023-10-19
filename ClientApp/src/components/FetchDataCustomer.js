import React, { Component } from 'react';
import './FetchData.css';

export class FetchDataCustomer extends Component {
  static displayName = FetchDataCustomer.name;

  constructor(props) {
    super(props);
    this.state = { customers: [], loading: true };
  }

  componentDidMount() {
    this.populateCustomersData();
  }

  static renderCustomersTable(customers) {
    return (
      <table>
        <thead>
          <tr>
            <th>Customer Id</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Address</th>
          </tr>
        </thead>
        <tbody>
          {customers.map(customer =>
            <tr key={customer.customerId}>
              <td>{customer.customerId}</td>
              <td>{customer.firstName}</td>
              <td>{customer.lastName}</td>
              <td>{customer.email}</td>
              <td>{customer.phone}</td>
              <td>{customer.address}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    
    let contentCustomers = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchDataCustomer.renderCustomersTable(this.state.customers);
    
    return (
      <div className='fetchDataContainer'>
        <h1 id="tableLabel">Fetched data - Customer</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contentCustomers}
      </div>
    );
  }

  async populateCustomersData() {
    const res = await fetch('/api/customer');
    const data = await res.json();
    this.setState({ customers: data, loading: false });
  }
}
