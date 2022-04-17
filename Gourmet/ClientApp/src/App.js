import React from "react";
import Layout from "./components/Layout";
import { Route, Switch } from "react-router";
import Home from "./components/Home";
import Login from "./components/Login";
import Cart from "./components/Cart";
import SignUp from "./components/SignUp";
import Products from "./components/Products";

export default function App(props) {
  return (
    <Layout>
      <Switch>
        <Route exact path="/" render={(props) => <Home />} />
        <Route path="/products" render={(props) => <Products />} />
        <Route path="/cart" render={(props) => <Cart />} />
        <Route path="/login" render={(props) => <Login />} />
        <Route path="/signup" render={(props) => <SignUp />} />
        {/* <Route path="/user" component={UserInfo} /> */}
      </Switch>
    </Layout>
  );
}
