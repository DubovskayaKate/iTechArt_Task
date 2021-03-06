import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import classNames from 'classnames/bind';
import PropTypes from 'prop-types';

import VideoItemList from '../VideoItemList/VideoItemList';
import * as TodoActionCreators from '../../api/video';

import './Main.css';


class Main extends Component {
    constructor(props) {
        super(props);
        this.props = props;
        this.onAppendVideo = this.onAppendVideo.bind(this);
    }

    onAppendVideo() {
        this.props.appendVideo('', true);
    }

    render() {
        const { payload } = this.props;
        const { isError, isLoading } = payload;

        const classNamesErrorlabel = classNames('main__error-label', {
            'main__error-label--error': isError,
        });
        const classNamesButton = classNames('main__load-button', {
            'main__load-button--success': !isError && !isLoading,
        });
        const classNamesImage = classNames(
            'main__load-image', {
                'main__load-image--loading': isLoading,
            },
        );
        return (
            <main className="main__content">
                <p className={classNamesErrorlabel}>
          404 ERROR
                </p>
                <img
                    className={classNamesImage}
                    src="./images/cat.gif"
                    alt="Loading"
                />
                <section className="main__videolist">
                    <VideoItemList />
                </section>

                <button
                    onClick={this.onAppendVideo}
                    className={classNamesButton}
                    type="submit"
                >
            Load more
                </button>

            </main>
        );
    }
}

Main.propTypes = {
    payload: PropTypes.shape({
        isError: PropTypes.bool,
        isLoading: PropTypes.bool,
    }).isRequired,
    appendVideo: PropTypes.func.isRequired,
};


export default connect(
    (state) => ({
        payload: state,
    }),
    (dispatch) => ({
        appendVideo: bindActionCreators(TodoActionCreators.loadSources, dispatch),

    }
    ),
)(Main);
