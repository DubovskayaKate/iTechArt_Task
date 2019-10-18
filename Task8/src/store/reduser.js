const initialState = {
    isLoading: false,
    isError: false,
    video: [{
        id: 'xxx',
        imageUrlMedium: './images/smile.jpg',
        imageUrlHigh: './images/smile.jpg',
        imageUrlDefault: './images/smile.jpg',
        title: 'Keep calm and smile:)',
        description: 'Description'
    }]
}

export function videoList(state = initialState, action){
    switch(action.type){
        case 'LOADING':{
            return {
                isLoading: true,
                isError: false,
                video: state.video
            }
        }
        case 'FETCH_SUCCESS':{
            return {
                isLoading: false,
                isError: false,
                video: action.GlobalStore.video,
            };
        }
        case'ERROR':{
            return {
                isLoading: false,
                isError: true,
                video:[],
            };
        }
        case 'APPEND_SUCCESS':{
            let videoArray =  state.video.concat(action.GlobalStore.video);
            return {
                isLoading: false,
                isError: false,
                video:videoArray,
            };
        }
    }
    return state;
}