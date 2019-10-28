import React, { Component } from 'react';
import {Container} from 'reactstrap';



export class Dress extends Component {
    constructor() {
        super();
        this.state = { dresses: [], loading: true, dress: [] };

        fetch('api/Dress')
            .then(response => response.json())
            .then(data => {
                this.setState({ dresses: data, loading: false });
            });

    }

    load = (id) => {
        this.setState({loading: false });
        fetch(`api/Dress/Details?id=${id}`)
            .then(response => response.json() )
            .then(data => {
                console.log(data);
                this.setState({ dress: data, loading: false });
            });
    }

    render() {
        console.log("render");

        return (
            <Container>
                <h3> { this.state.dress.id } </h3>
                <h3>{this.state.dress.description}</h3>

                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Description</th>
                            <th>Show more info</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.dresses.map(dress =>
                            <tr key={dress.id}>
                                <td>{dress.id}</td>
                                <td>{dress.description}</td>
                                <td><button onClick={() => { this.load(dress.id)}}>Show</button></td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </Container>
        )
    }
}


