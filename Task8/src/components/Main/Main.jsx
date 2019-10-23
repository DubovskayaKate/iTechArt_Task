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
  }

  appendVideo() {
    const { onAppendVideo } = this.props;
    onAppendVideo();
  }

  render() {
    const { payload } = this.props;
    const { isError, isLoading } = payload;

    const classNamesErrorlabel = classNames({
      'main__error-label': true,
      'main__error-label--error': isError,
    });
    const classNamesButton = classNames({
      'main__load-button': true,
      'main__load-button--success': !isError && !isLoading,
    });
    const classNamesImage = classNames({
      'main__load-image': true,
      'main__load-image--loading': isLoading,
    });
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
          onClick={this.appendVideo.bind(this)}
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
  onAppendVideo: PropTypes.func.isRequired,
};

export default connect(
  (state) => ({
    payload: state,
  }),
  (dispatch) => ({
    onAppendVideo: () => {
      const action = bindActionCreators(TodoActionCreators, dispatch);
      action.loadSources('', true);
    },
  }
  ),
)(Main);
