import React, { Component} from "react";
import {connect} from 'react-redux';

import VideoItem from "./VideoItem";

class VideoItemList extends Component{
    render(){
        const list = this.props.GlobalStore.video.map((video, index) =>
            <VideoItem 
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
    })
  )(VideoItemList);