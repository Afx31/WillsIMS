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
        <Link class='active' to="/">Home</Link>
        <Link to="/fetch-data">Fetch data</Link>
        <Link to="/fetch-data-company">Fetch data - Company</Link>
        <Link to="/fetch-data-outboundOrders">Fetch data - Outbound Orders</Link>
      </div>
    );
  }
}
