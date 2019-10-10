import React from "react";
import ReactDOM from "react-dom";


import App from "./components/App";
import './global.css';

import {Provider} from 'react-redux';
import {createStore} from 'redux';


const initialState = [
    {
        imageUrl: 'http:/',
        title: 'Title',
        description: 'Description'
    }
]

function videoList(state = initialState, action){
    if (action.type === 'Load'){
        return [
            ...state,
            action.video
        ];
    }
    return state;
}

const store = createStore(videoList, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

ReactDOM.render(
<Provider store={store}>
    <App />
</Provider>, document.getElementById("root"));