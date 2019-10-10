import React, { Component} from "react";
import {hot} from "react-hot-loader";
import {connect} from 'react-redux';

import './Search.css';

class Search extends Component{
    loadVideo() {
        console.log(this.searchString.value);
        this.props.onLoadVideo(    
            {
                imageUrl: 'http:/',
                title: this.searchString.value,
                description: 'Description'
            }
        )
    }
    render(){
        console.log(this.props.videoStore);
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
        onLoadVideo: (video) =>{
            dispatch({type: 'Load', video})
        }
    })
  )(Search);