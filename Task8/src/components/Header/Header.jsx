import React, { Component } from 'react';

import Search from '../Search/Search';

import './Header.css';

class Header extends Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  render() {
    return (
      <header className="header__context">
        <Search buttonName="Search" />
      </header>
    );
  }
}

export default (Header);
