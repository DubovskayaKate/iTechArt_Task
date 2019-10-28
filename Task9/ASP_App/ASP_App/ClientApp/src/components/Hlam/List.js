import React, { Component } from 'react';

export class List extends Component {
    static displayName = List.name;

    constructor(props) {
        super(props);
        this.state = {
            string1: {}, loading: true };

        /*fetch()
            .then(response => { return response.json() })
            .then(data => {
                this.setState(
                    {
                        string1: data,
                        loading: false
                    })
            })
            .catch(() => console.log("ERROR"));*/
    }

    render() {
        let searchParams = new URLSearchParams(window.location.search);
        let request = {
            name: "NULL",
            surname: "NULL"
        };
        if (searchParams.has("name")) {
            request.name = searchParams.get("name");
        }
        if (searchParams.has("surname")) {
            request.surname = searchParams.get("surname");
        }
        return (
             <div>   
                <h1>{request.name}</h1>
                <h1>{request.surname}</h1>
            </div>
        )    
    }
}