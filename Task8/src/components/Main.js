import React, { Component} from "react";
import {connect} from 'react-redux';

import VideoItemList from "./VideoItemList";
import {State} from '../globalState';
import {getVideo} from '../api/video';
import "./Main.css";

class Main extends Component{
    appendVideo() {
        this.props.onAppendVideo()
    }
    render(){
        let imgStyle = (this.props.GlobalStore.state === State.loading)? {visibility: 'block'} : {display: 'none'} ;
        let errorStyle = (this.props.GlobalStore.state === State.error)? {visibility: 'block'} : {display: 'none'} ;
        let buttonStyle = (this.props.GlobalStore.state === State.static)? {visibility: 'block'} : {display: 'none'} ;
        return(
            <main className="main__content">
                <p className="main__error-label" style={errorStyle}>404 ERROR</p>
                <img className="main__load-image" style={imgStyle} src="./images/cat.gif"></img>
                <div className="main__videolist">
                    <VideoItemList key="1"/>
                </div>
                <button onClick={this.appendVideo.bind(this)} style={buttonStyle} className="main__load-button">Load more</button>
            </main>
        )
    }
}

export default connect(
    state => ({
      GlobalStore: state
    }),
    dispatch => ({ 
        onAppendVideo: () =>
        {
            dispatch({type: 'Loading', GlobalStore: {}});
            dispatch(getVideo('', true));
        }
    }
    )
  )(Main);