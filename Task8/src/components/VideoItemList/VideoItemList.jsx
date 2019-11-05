import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import VideoItem from '../VideoItem/VideoItem';

import './VideoItemList.css';

class VideoItemList extends Component {
    constructor(props) {
        super(props);
        this.props = props;
    }

    renderList() {
        const { payload } = this.props;
        return (payload.video.map((video) => (
            <VideoItem
                key={video.id}
                imageUrlMedium={video.imageUrlMedium}
                imageUrlHigh={video.imageUrlHigh}
                imageUrlDefault={video.imageUrlDefault}
                title={video.title}
                description={video.description}
            />
        ))
        );
    }

    render() {
        const list = this.renderList();
        return list;
    }
}

VideoItemList.propTypes = {
    payload: PropTypes.shape({
        video: PropTypes.array,
    }).isRequired,
};

export default connect(
    (state) => ({
        payload: state,
    }),
)(VideoItemList);
