import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddForm } from './components/AddForm';
import { Dress } from './components/Dress';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/dress' component={Dress} />
            <Route path='/add' component={AddForm} />
        </Layout>
        );
}
}
