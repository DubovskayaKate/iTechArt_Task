import {ActionType} from './actionTypes';

const initialState = {
  isLoading: false,
  isError: false,
  video: [{
    id: 'xxx',
    imageUrlMedium: './images/smile.jpg',
    imageUrlHigh: './images/smile.jpg',
    imageUrlDefault: './images/smile.jpg',
    title: 'Keep calm and smile:)',
    description: 'Description',
  }],
};

function videoList(state = initialState, action) {
  switch (action.type) {
    case ActionType.loading: {
      return {
        isLoading: true,
        isError: false,
        video: state.video,
      };
    }
    case ActionType.fetch_success: {
      return {
        isLoading: false,
        isError: false,
        video: action.payload.video,
      };
    }
    case ActionType.error: {
      return {
        isLoading: false,
        isError: true,
        video: [],
      };
    }
    case ActionType.append_success: {
      const videoArray = state.video.concat(action.payload.video);
      return {
        isLoading: false,
        isError: false,
        video: videoArray,
      };
    }
    default: {
      return state;
    }
  }
}

export default videoList;
