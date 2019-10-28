import React, { Component } from 'react';

export class AddForm extends Component {
    render() {
        return (
            <form action="api/Dress/Create" method="post" enctype="multipart/form-data">
                <label for="name">Description</label>
                <input type="text" name="description" />
                <input type="submit" value="Submit"/>
            </form>
        )
    }
}