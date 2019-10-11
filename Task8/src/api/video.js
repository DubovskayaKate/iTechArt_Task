const API_KEY = "AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs";

const loadSources = (dispatch, searchStr) =>{
    const url = `https://www.googleapis.com/youtube/v3/search?part=snippet&q=${searchStr}&key=${API_KEY}`;
    const request = new Request(url);
    fetch(request)
        .then( (response) => response.json())
        .then(
            (data) => {
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
        ).then(
            (video) => dispatch({type: 'Fetch_success', video})
        );
}

export const getVideo = (searchStr) => {
    return dispatch => {
        loadSources(dispatch, searchStr);
    }
}

