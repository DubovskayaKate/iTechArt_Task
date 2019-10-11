import React, { Component} from "react";
import {connect} from 'react-redux';

import VideoInfo from "./VideoInfo";

class VideoItemList extends Component{
    render(){
        console.log(this.GlobalStore);
        const list = this.props.GlobalStore.video.map((video, index) =>
            <VideoInfo 
                key ={index} 
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
      GlobalStore: state
    }),
    dispatch => ({
        onLoadVideo: (video) =>{
            dispatch({type: 'Loading', GlobalStore: {}});
            dispatch(getVideo());
        }
    })
  )(VideoItemList);