import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Cart } from './components/Cart';
import { Products } from './components/Products';
import { Login } from './components/Login'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/products' component={Products} />
        <Route path='/cart' component={Cart} />
        <Route path='/login' component={Login} />
      </Layout>
    );
  }
}
