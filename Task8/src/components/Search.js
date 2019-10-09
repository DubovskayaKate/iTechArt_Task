import React, { Component} from "react";
import {hot} from "react-hot-loader";

import './Search.css';

class Search extends Component{
    render(){
        return(
            <div className="header__search">
                <input className="search__input" type="text" size="30"/>
                <button className="search__button">{this.props.bName}</button>
            </div>
        );
    }
}

export default hot(module)(Search);