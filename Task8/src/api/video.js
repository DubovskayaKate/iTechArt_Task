

const API_KEY = "AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs";
let Next_Page_token;
let Search_str;

const loadSources = (dispatch, searchStr, isAppend) =>{
    let url = `https://www.googleapis.com/youtube/v3/search?part=snippet&key=${API_KEY}`; 
    if (isAppend) {
        url += `&q=${Search_str}&pageToken=${Next_Page_token}`;
    }else{
        Search_str = searchStr;
        url += `&q=${searchStr}`;
    }

    const request = new Request(url);
    fetch(request)
        .then( (response) => 
        {
            if (response.ok){
                return response.json();
            }
            return null;
        })
        .then(
            (data) => {            
                if (data != null){
                    Next_Page_token = data.nextPageToken;
                    return data.items.map((video) => {
                        return {
                            imageUrlMedium: video.snippet.thumbnails.medium.url, 
                            imageUrlHigh: video.snippet.thumbnails.high.url,
                            imageUrlDefault: video.snippet.thumbnails.default.url,
                            title: video.snippet.title, 
                            description: video.snippet.description,
                            id: (video.id.videoId == null)? video.id.channelId :video.id.videoId ,
                        }
                    });
                }
                return null;
            }            
        ).then(            
            (video) => {              
                if(video != null){
                    if(isAppend){
                        dispatch({type: 'APPEND_SUCCESS', GlobalStore: {video: video}})
                    } else{
                        dispatch({type: 'FETCH_SUCCESS', GlobalStore: {video: video}})
                    }
                } else{
                    dispatch({type: 'ERROR', GlobalStore: {video: video}})
                }
            }
        );
}

export const getVideo = (searchStr, isAppend) => {
    return dispatch => {
        loadSources(dispatch, searchStr, isAppend);
    }
}

