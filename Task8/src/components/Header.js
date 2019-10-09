import React, { Component} from "react";
import {hot} from "react-hot-loader";
import Search from "./Search";

class Header extends Component{
    render(){
        return(
            <header className="header__context">
                <Search bName="Search"/>
            </header>
        )
    }
}

export default hot(module)(Header);

//<Search bName="Search"/>