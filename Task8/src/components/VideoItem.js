import React, { Component} from "react";
import {hot} from "react-hot-loader";
import './VideoItem.css';


class VideoItem extends Component{
    render(){
        return(
            <div id={this.props.id} className="main__video-item">
                <img key={this.props.id}
                        className="main__video-image" 
                        src={this.props.imageUrlDefalt}
                        srcSet={`${this.props.imageUrlDefalt} 120w, ${this.props.imageUrlMedium} 320w, ${this.props.imageUrlHigh} 480w`} 
                        sizes="(max-width: 330px) 120px,
                                (max-width: 1200px) 320px,
                                480px"/>
                <div className="main__video-info">
                    <p className="main__video-title">{this.props.title}</p>
                    <p className="main__video-desciption">{this.props.description}</p>
                </div>
            </div>
        )
    }
}

export default (VideoItem);