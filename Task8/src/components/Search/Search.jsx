import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';

import * as TodoActionCreators from '../../api/video';

import './Search.css';

class Search extends Component {
    constructor(props) {
        super(props);
        this.props = props;
        this.textInput = React.createRef();
        this.onLoadVideo = this.onLoadVideo.bind(this);
    }

    onLoadVideo() {
        this.props.loadVideo(this.textInput.current.value, false);
    }

    render() {
        const { buttonName } = this.props;
        return (
            <div className="header__search">
                <input
                    className="search__input"
                    type="text"
                    size="30"
                    ref={this.textInput}
                />
                <button
                    onClick={this.onLoadVideo}
                    className="search__button"
                    type="submit"
                >
                    {buttonName}
                </button>
            </div>
        );
    }
}

Search.propTypes = {
    loadVideo: PropTypes.func.isRequired,
    buttonName: PropTypes.string.isRequired,
};

export default connect(
    (state) => ({
        payload: state,
    }),
    (dispatch) => ({
        loadVideo: bindActionCreators(TodoActionCreators.loadSources, dispatch),

    }),
)(Search);
