import React, { Component} from "react";
import {hot} from "react-hot-loader";
import './VideoInfo.css';


class VideoInfo extends Component{
    render(){
        return(
            <div className="main__video-item">
                <img className="main__video-image" src={this.props.image}/>
                <div className="main__video-info">
                    <p className="main__video-title">{this.props.title}</p>
                    <p className="main__video-desciption">{this.props.description}</p>
                </div>
            </div>
        )
    }
}

export default hot(module)(VideoInfo);