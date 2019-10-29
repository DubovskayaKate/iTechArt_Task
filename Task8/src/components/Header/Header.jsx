import React, { Component } from 'react';

import Search from '../Search/Search';
import ThemeContext from '../Сontext/context';

import './Header.css';

class Header extends Component {
    constructor(props) {
        super(props);
        this.props = props;
    }

    render() {
        return (
            <header className="header__context">
                <ThemeContext.Consumer>
                    {(theme) => <Search buttonName="Search" theme={theme} />}
                </ThemeContext.Consumer>
            </header>
        );
    }
}

export default (Header);
