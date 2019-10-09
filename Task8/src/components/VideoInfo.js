import React, { Component} from "react";
import {hot} from "react-hot-loader";
import './VideoInfo.css';


class VideoInfo extends Component{
    render(){
        return(
            <div className="main__video-item">
                <image className="main__video-image" src={this.props.image}></image>
                <p className="main__video-title">{this.props.title}</p>
                <p className="main__video-desciption">{this.props.description}</p>
            </div>
        )
    }
}

export default hot(module)(VideoInfo);