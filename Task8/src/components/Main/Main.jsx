import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import classNames from 'classnames/bind';

import VideoItemList from '../VideoItemList/VideoItemList';
import * as TodoActionCreators from '../../api/video';

import './Main.css';

class Main extends Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  appendVideo() {
    this.props.onAppendVideo();
  }

  render() {
    const classNamesErrorlabel = classNames({
      'main__error-label': true,
      'main__error-label--error': this.props.GlobalStore.isError,
    });
    const classNamesButton = classNames({
      'main__load-button': true,
      'main__load-button--success': !this.props.GlobalStore.isError && !this.props.GlobalStore.isLoading,
    });
    const classNamesImage = classNames({
      'main__load-image': true,
      'main__load-image--loading': this.props.GlobalStore.isLoading,
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

export default connect(
  (state) => ({
    GlobalStore: state,
  }),
  (dispatch) => ({
    onAppendVideo: () => {
      const action = bindActionCreators(TodoActionCreators, dispatch);
      action.loading();
      action.loadSources('', true);
    },
  }
  ),
)(Main);
