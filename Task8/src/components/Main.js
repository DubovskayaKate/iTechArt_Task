import React, { Component} from "react";

import VideoItemList from "./VideoItemList";
import "./Main.css";

class Main extends Component{
    render(){
        return(
            <main className="main__content">
                <VideoItemList key="1"/>
            </main>
        )
    }
}

export default (Main);