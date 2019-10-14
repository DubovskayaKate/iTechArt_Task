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
        title: 'Title',
        description: 'Description'
    }]
}

function videoList(state = initialState, action){
    if (action.type === 'Loading'){
        return {
            state: State.loading,
            video: []
        }
    }else if (action.type ==='Fetch_success'){
        return {
            state: State.static,
            video: action.GlobalStore.video,
        };
    }
    if (action.type ==='Error'){
        return {
            state: State.error,
            video:[],
        };
    }
    return state;
}

const store = createStore(videoList, composeWithDevTools(applyMiddleware(thunk)));

ReactDOM.render(
<Provider store={store}>
    <App />
</Provider>, document.getElementById("root"));