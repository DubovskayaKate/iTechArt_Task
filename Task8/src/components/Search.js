import React, { Component} from "react";
import {hot} from "react-hot-loader";
import {connect} from 'react-redux';
import {getVideo} from '../api/video';

import './Search.css';

class Search extends Component{
    loadVideo() {
        this.props.onLoadVideo(this.searchString.value)
    }
    render(){
        console.log(this.videoStore);
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
      videoStore: state
    }),
    dispatch => ({
        onLoadVideo: (searchString) =>{
            console.log(searchString);
            dispatch(getVideo(searchString));
        }
    })
  )(Search);