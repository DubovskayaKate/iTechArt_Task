import { ActionType } from '../store/actionTypes';

const API_KEY = 'AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs';
let nextPageToken;
let searchString;

async function loading(url, dispatch, isAppend) {
    try {
        const request = new Request(url);
        const res = await fetch(request, {
            method: 'GET', // *GET, POST, PUT, DELETE, etc.
            mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            headers: {
              'Content-Type': 'application/json'
            }
          });

        const data = await res.json();
        //nextPageToken = data.nextPageToken;
        const videoItems = data.map((video) => ({
            imageUrlMedium : video.imageUrlMedium,
            imageUrlHigh: video.imageUrlHigh,
            imageUrlDefault : video.imageUrlDefault,
            title : video.title,
            description : video.description,
            id : video.id,
        }));
        console.log(videoItems);
        if (isAppend) {
            dispatch({ type: ActionType.append_success, payload: { video: videoItems } });
        } else {
            dispatch({ type: ActionType.fetch_success, payload: { video: videoItems } });
        }
    } catch (e) {
        console.log(e);
        dispatch({ type: ActionType.error, payload: {} });
    }
}

export function loadSources(searchStr, isAppend) {
    return function load(dispatch) {
        dispatch({ type: ActionType.loading, payload: {} });
        //let url = `https://www.googleapis.com/youtube/v3/search?part=snippet&key=${API_KEY}`;
        let url = `http://localhost:59517/api/youtube/`;
        if (isAppend) {
            url += `&q=${searchString}&pageToken=${nextPageToken}`;
        } else {
            searchString = searchStr;
            url += `&q=${searchStr}`;
        }
        loading(url, dispatch, isAppend);
        /*
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
                        dispatch({ type: ActionType.append_success, payload: { video } });
                    } else {
                        dispatch({ type: ActionType.fetch_success, payload: { video } });
                    }
                },
            )
            .catch(() => {
                dispatch({ type: ActionType.error, payload: {} });
            }); */
    };
}
