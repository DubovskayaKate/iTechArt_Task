import React, { Component} from "react";
import {connect} from 'react-redux';

import VideoItemList from "./VideoItemList";
import "./Main.css";

class Main extends Component{
    render(){
        console.log(this.props.GlobalStore.state === "Loading");
        let imgStyle = (this.props.GlobalStore.state === "Loading")? {visibility: 'block'} : {display: 'none'} ;
        let errorStyle = (this.props.GlobalStore.state === "Error")? {visibility: 'block'} : {display: 'none'} ;
        return(
            <main className="main__content">
                <p className="main__error-label" style={errorStyle}>404 ERROR</p>
                <img className="main__load-image" style={imgStyle} src="./images/cat.gif"></img>
                <div className="main__videolist">
                    <VideoItemList key="1"/>
                </div>
            </main>
        )
    }
}

export default connect(
    state => ({
      GlobalStore: state
    }),
    dispatch => ({ })
  )(Main);