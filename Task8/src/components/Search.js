import React, { Component} from "react";
import {connect} from 'react-redux';
import {getVideo} from '../api/video';

import './Search.css';

class Search extends Component{
    loadVideo() {
        this.props.onLoadVideo(this.searchString.value)
    }
    render(){
        return(
            <div className="header__search">
                <input className="search__input" type="text" size="30" ref={(input) => this.searchString = input}/>
                <button onClick={this.loadVideo.bind(this)} className="search__button">{this.props.bName}</button>
            </div>
        );
    }
}

export default connect(
    state => ({
      GlobalStore: state
    }),
    dispatch => ({
        onLoadVideo: (searchString) =>{
            dispatch({type: 'Loading', GlobalStore: {}});
            dispatch(getVideo(searchString, false));
        }
    })
  )(Search);