import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import * as TodoActionCreators from '../../api/video';

import './Search.css';

class Search extends Component {
  constructor(props) {
    super(props);
    this.props = props;
    this.textInput = React.createRef();
  }

  loadVideo() {
    this.props.onLoadVideo(this.textInput.current.value);
  }

  render() {
    return (
        <div className="header__search">
            <input
              className="search__input"
              type="text"
              size="30"
              ref={this.textInput}
            />
            <button
              onClick={this.loadVideo.bind(this)}
              className="search__button"
              type="submit"
            >
                {this.props.buttonName}
            </button>
        </div>
    );
  }
}

export default connect(
  (state) => ({
    payload: state,
  }),
  (dispatch) => ({
    onLoadVideo: (searchString) => {
      const action = bindActionCreators(TodoActionCreators, dispatch);
      action.loading();
      action.loadSources(searchString, false);
    },
  }),
)(Search);
