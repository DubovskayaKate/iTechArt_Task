const API_KEY = 'AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs';
let nextPageToken;
let searchString;

export function loadSources(searchStr, isAppend) {
  return function load(dispatch) {
    let url = `https://www.googleapis.com/youtube/v3/search?part=snippet&key=${API_KEY}`;
    if (isAppend) {
      url += `&q=${searchString}&pageToken=${nextPageToken}`;
    } else {
      searchString = searchStr;
      url += `&q=${searchStr}`;
    }
    const request = new Request(url);
    fetch(request)
      .then(
        (response) => {
          if (response.ok) {
            return response.json();
          }
          return Promise.reject('Connection error');
        },
      )
      .then(
        (data) => {
          nextPageToken = data.nextPageToken;
          return data.items.map((video) => ({
            imageUrlMedium: video.snippet.thumbnails.medium.url,
            imageUrlHigh: video.snippet.thumbnails.high.url,
            imageUrlDefault: video.snippet.thumbnails.default.url,
            title: video.snippet.title,
            description: video.snippet.description,
            id: (video.id.videoId == null) ? video.id.channelId : video.id.videoId,
          }));
        },
      )
      .then(
        (video) => {
          if (isAppend) {
            console.log('append');
            dispatch({ type: 'APPEND_SUCCESS', GlobalStore: { video } });
          } else {
            console.log('fetch');
            dispatch({ type: 'FETCH_SUCCESS', GlobalStore: { video } });
          }
        },
      )
      .catch((errorStr) => {
        dispatch({ type: errorStr, GlobalStore: {} });
      });
  };
}

export function loading() {
  return { type: 'LOADING', GlobalStore: {} };
}
