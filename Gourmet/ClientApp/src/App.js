import React from "react";
import Layout from "./components/Layout";
import { Route, Switch } from "react-router";
import Home from "./components/Home";
import Login from "./components/Login";
import Cart from "./components/Cart";
import SignUp from "./components/SignUp";
import Products from "./components/Products";
import User from "./components/User";
import { useState } from "react";

export default function App(props) {
  let [isLoggedIn, setIsLoggedIn] = useState(
    sessionStorage.getItem("username") == null ? false : true
  );
  function toggleIsLoggedIn() {
    setIsLoggedIn(sessionStorage.getItem("username") == null ? false : true);
  }

  return (
    <Layout isLoggedIn={isLoggedIn}>
      <Switch>
        <Route exact path="/" render={(props) => <Home />} />
        <Route path="/products" render={(props) => <Products />} />
        <Route path="/cart" render={(props) => <Cart />} />
        <Route
          path="/login"
          render={(props) => <Login toggleIsLoggedIn={toggleIsLoggedIn} />}
        />
        <Route
          path="/signup"
          render={(props) => <SignUp toggleIsLoggedIn={toggleIsLoggedIn} />}
        />
        <Route path="/user" render={(porps) => <User />} />
      </Switch>
    </Layout>
  );
}
