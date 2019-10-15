import React from "react";
import ReactDOM from "react-dom";
import {composeWithDevTools} from 'redux-devtools-extension';
import {Provider} from 'react-redux';
import {createStore, applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import {State} from './globalState';

import App from "./components/App";
import './global.css';


const initialState = {
    state: State.static,
    video: [{
        imageUrlMedium: './images/smile.jpg',
        imageUrlHigh: './images/smile.jpg',
        imageUrlDefault: './images/smile.jpg',
        title: 'Keep calm and smile:)',
        description: 'Description'
    }]
}

function videoList(state = initialState, action){
    if (action.type === 'Loading'){
        return {
            state: State.loading,
            video: state.video
        }
    }else 
    if (action.type ==='Fetch_success'){
        return {
            state: State.static,
            video: action.GlobalStore.video,
        };
    }else
    if (action.type ==='Error'){
        return {
            state: State.error,
            video:[],
        };
    }
    else
    if (action.type ==='Append_success'){
        let videoArray =  state.video.concat(action.GlobalStore.video);
        return {
            state: State.static,
            video:videoArray,
        };
    }
    return state;
}

const store = createStore(videoList, composeWithDevTools(applyMiddleware(thunk)));

ReactDOM.render(
<Provider store={store}>
    <App />
</Provider>, document.getElementById("root"));