import {State} from '../globalState';

const API_KEY = "AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs";

const loadSources = (dispatch, searchStr) =>{
    const url = `https://www.googleapis.com/youtube/v3/search?part=snippet&q=${searchStr}&key=${API_KEY}`;
    const request = new Request(url);
    fetch(request)
        .then( (response) => 
        {
            console.log(response); 
            if (response.ok){
                return response.json();
            }
            return null;

        })
        .then(
            (data) => {
                if (data != null){
                    return data.items.map((video) => {
                        return {
                            imageUrlMedium: video.snippet.thumbnails.medium.url, 
                            imageUrlHigh: video.snippet.thumbnails.high.url,
                            imageUrlDefault: video.snippet.thumbnails.default.url,
                            title: video.snippet.title, 
                            description: video.snippet.description,
                        }
                    });
                }
                return null;
            }            
        ).then(            
            (video) => (video != null)?
            dispatch({type: 'Fetch_success', GlobalStore: {video: video, state: State.static}}):
            dispatch({type: 'Error', GlobalStore: {video: video, state: State.error}})
        );
}

export const getVideo = (searchStr) => {
    return dispatch => {
        loadSources(dispatch, searchStr);
    }
}

