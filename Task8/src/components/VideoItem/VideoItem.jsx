import React from 'react';
import PropTypes from 'prop-types';

import './VideoItem.css';

function VideoItem(props) {
    const {
        imageUrlDefault, imageUrlMedium, imageUrlHigh, title, description,
    } = props;
    return (
        <article className="video-list__video-item">
            <img
                alt="Img Preview"
                className="video-item__video-image"
                src={imageUrlDefault}
                srcSet={`${imageUrlDefault} 120w, 
                  ${imageUrlMedium} 320w, 
                  ${imageUrlHigh} 480w`}
                sizes="(max-width: 330px) 120px,
                (max-width: 1200px) 320px,
                                480px"
            />
            <div className="video-item__video-info">
                <p className="video-item__video-title">{title}</p>
                <p className="video-item__video-desciption">{description}</p>
            </div>
        </article>
    );
}

VideoItem.propTypes = {
    imageUrlDefault: PropTypes.string.isRequired,
    imageUrlMedium: PropTypes.string.isRequired,
    imageUrlHigh: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
};

export default (VideoItem);
