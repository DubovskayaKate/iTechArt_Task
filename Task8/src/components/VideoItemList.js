import React, { Component} from "react";
import {connect} from 'react-redux';

import VideoInfo from "./VideoInfo";

class VideoItemList extends Component{
    render(){
        console.log(this.videoStore);
        const list = this.props.videoStore.map((video, index) =>
            <VideoInfo 
                id ={index} 
                imageUrlMedium={video.imageUrlMedium} 
                imageUrlHigh={video.imageUrlHigh}
                imageUrlDefault={video.imageUrlDefault} 
                title={video.title} 
                description={video.description}
            />
        )
        return(
            list
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
  )(VideoItemList);