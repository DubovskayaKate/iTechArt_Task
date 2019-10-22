import React from "react";
import ReactDOM from "react-dom";
import {composeWithDevTools} from 'redux-devtools-extension';
import {Provider} from 'react-redux';
import {createStore, applyMiddleware} from 'redux';
import thunk from 'redux-thunk';

import videoList from "./store/reducer";
import App from "./components/App/App";

import "./global.css";

const store = createStore(videoList, composeWithDevTools(applyMiddleware(thunk)));

ReactDOM.render(
<Provider store={store}>
    <App />
</Provider>, document.getElementById("root"));