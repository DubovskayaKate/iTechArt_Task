import React, { Component} from "react";
import {hot} from "react-hot-loader";
import {connect} from 'react-redux';

import VideoInfo from "./VideoInfo";
import "./Main.css";

class Main extends Component{
    render(){
        return(
            <main className="main__content">
                {this.props.videoStore.map((video, index) =>{
                    <VideoInfo image={video.imageUrl} title="My first Video" description="1 2  4 5 6 7 8 9"/>
                })}
                <VideoInfo image="./images/smile.jpg" title="My first Video" description="1 2  4 5 6 7 8 9"/>
                <VideoInfo image="./images/smile.jpg" title="My first Video" description="1 2  4 5 6 7 8 9"/>
                <VideoInfo image="./images/smile.jpg" title="My first Video" description="1 2  4 5 6 7 8 9"/>
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