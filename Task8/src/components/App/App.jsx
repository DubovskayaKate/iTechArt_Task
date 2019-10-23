import React, { Component } from 'react';

import Header from '../Header/Header';
import Main from '../Main/Main';
import ThemeContext from '../Сontext/context';


class App extends Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  render() {
    return (
      <div className="layout">
        <ThemeContext.Provider value="green">
          <Header />
          <Main />
        </ThemeContext.Provider>
      </div>
    );
  }
}

export default (App);
