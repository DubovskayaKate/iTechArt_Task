import React, { Component } from 'react';
import './VideoItem.css';


class VideoItem extends Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  render() {
    return (
      <article className="video-list__video-item">
        <img
          alt="Img Preview"
          className="video-item__video-image"
          src={this.props.imageUrlDefalt}
          srcSet={`${this.props.imageUrlDefalt} 120w, 
                  ${this.props.imageUrlMedium} 320w, 
                  ${this.props.imageUrlHigh} 480w`}
          sizes="(max-width: 330px) 120px,
                (max-width: 1200px) 320px,
                                480px"
        />
        <div className="video-item__video-info">
          <p className="video-item__video-title">{this.props.title}</p>
          <p className="video-item__video-desciption">{this.props.description}</p>
        </div>
      </article>
    );
  }
}

export default (VideoItem);
