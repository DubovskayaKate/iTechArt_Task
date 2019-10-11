import React, { Component} from "react";
import {hot} from "react-hot-loader";
import {connect} from 'react-redux';

import VideoItemList from "./VideoItemList";
import "./Main.css";

class Main extends Component{
    render(){
        return(
            <main className="main__content">
                <VideoItemList key="1"/>
            </main>
        )
    }
}

export default connect(
    state => ({
      videoStore: state
    }),
    dispatch => ({
        onLoadVideo: (video) =>{
            dispatch(getVideo());
        }
    })
  )(Main);