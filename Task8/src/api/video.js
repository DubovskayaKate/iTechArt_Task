var mockApiData =[
    {
        imageUrl: 'http:/',
        title: 'Title1',
        description: 'Description'
    },
    {
        imageUrl: 'http:/',
        title: 'Title2',
        description: 'Description'
    }
]

export const getVideo = () => {
    return dispatch => {
        setTimeout(() => {
            console.log('I got some video');
            dispatch({type: 'Fetch_success', video: mockApiData})
        }, 2000);
    }
}