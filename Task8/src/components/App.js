import React, { Component} from "react";
import {hot} from "react-hot-loader";

import {connect} from 'react-redux';
import "./App.css";
import Header from "./Header";
import Main from "./Main";

class App extends Component{
  render(){    
    return(
      <div className="layout">
        <Header/>
        <Main/>
    </div>
    );
  }
}

export default (App);