import { ActionType } from '../store/actionTypes';

const API_KEY = '...';
let nextPageToken;
let searchString;

async function loading(url, dispatch, isAppend) {
    try {
        const request = new Request(url);
        const res = await fetch(request);
        const data = await res.json();
        nextPageToken = data.nextPageToken;
        const videoItems = data.items.map((video) => ({
            imageUrlMedium: video.snippet.thumbnails.medium.url,
            imageUrlHigh: video.snippet.thumbnails.high.url,
            imageUrlDefault: video.snippet.thumbnails.default.url,
            title: video.snippet.title,
            description: video.snippet.description,
            id: (video.id.videoId == null) ? video.id.channelId : video.id.videoId,
        }));
        console.log(videoItems);
        if (isAppend) {
            dispatch({ type: ActionType.append_success, payload: { video: videoItems } });
        } else {
            dispatch({ type: ActionType.fetch_success, payload: { video: videoItems } });
        }
    } catch (e) {
        dispatch({ type: ActionType.error, payload: {} });
    }
}

export function loadSources(searchStr, isAppend) {
    return function load(dispatch) {
        dispatch({ type: ActionType.loading, payload: {} });
        let url = `https://www.googleapis.com/youtube/v3/search?part=snippet&key=${API_KEY}`;
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
