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
        <Link to='/company'>Company</Link>
        <Link to='products'>Products</Link>
        <Link to='/inventoryItems'>Inventory Items</Link>
        <Link to='/binlocations'>Bin Locations</Link>
        <Link to='/inboundOrders'>Inbound Orders</Link>
        <Link to='/outboundOrders'>Outbound Orders</Link>
      </div>
    );
  }
}
