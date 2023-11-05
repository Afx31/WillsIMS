import React from 'react';
import { Link } from 'react-router-dom';
import './Navbar.css';

const Navbar = () => {
  // static displayName = Navbar.name;

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

  return (
    <div className='topnav'>
      <Link className='active' to='/'>Home</Link>
      <Link to='/company'>Company</Link>
      <Link to='product'>Product</Link>
      <Link to='/inventoryItems'>Inventory Items</Link>
      <Link to='/binlocations'>Bin Locations</Link>
      <Link to='/inboundOrders'>Inbound Orders</Link>
      <Link to='/outboundOrders'>Outbound Orders</Link>
    </div>
  );
}

export default Navbar;