import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  // static displayName = NavMenu.name;

  // constructor (props) {
  //   super(props);

  //   this.toggleNavbar = this.toggleNavbar.bind(this);
  //   this.state = {
  //     collapsed: true
  //   };
  // }

  // toggleNavbar () {
  //   this.setState({
  //     collapsed: !this.state.collapsed
  //   });
  // }

  render() {
    return (
      <div className='topnav'>
        <Link class='active' to='/'>Home</Link>
        <Link to='/fetch-data-company'>Company</Link>
        <Link to='/fetch-data'>Fetch data - Inventory Items</Link>
        <Link to='/fetch-data-binlocation'>Bin Locations</Link>
        <Link to='/fetch-data-inboundOrders'>Inbound Orders</Link>
        <Link to='/fetch-data-outboundOrders'>Outbound Orders</Link>
      </div>
    );
  }
}
