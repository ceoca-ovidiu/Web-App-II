import React from "react";
import "../styles/LoginContent.css";
import axios from "axios";
import Cookies from "universal-cookie";
import Constants from "../utils/Constants";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import loginPic from "../images/login.jpeg";
import bcrypt from "bcryptjs";

export default function Login(props) {
  let [stateData, setStateData] = useState({
    username: "",
    password: "",
  });
  let wrongPasswordError = false;
  let noUserError = false;
  let history = useHistory();

  function handleChange(event) {
    let target = event.target;
    let value = target.value;
    let name = target.name;
    setStateData({
      ...stateData,
      [name]: value,
    });
  }

  async function handleSubmit(event) {
    event.preventDefault();
    let username = stateData.username;
    let password = bcrypt.hashSync(stateData.password);
    console.log("YOU SUBMITTED");
    console.log(username + " and " + password);
    // this.sendCredentials(username, password);
    // TODO: send credentials and check for user => get back with a response
    // sessionStorage.clear()
    let userCookie = new Cookies();
    userCookie.set("user", stateData.username, {
      path: "/",
      maxAge: 10, // given in seconds => TO BE MODIFIED
    });
    sessionStorage.setItem("username", stateData.username);
    // sessionStorage.clear();
    props.toggleIsLoggedIn();
    history.push("/");
  }

  function sendCredentials(username, password) {
    let data = {
      username: username,
      password: bcrypt.hashSync(password),
    };
    axios.get(Constants.BASE_URL + Constants.LOGIN, data).then((result) => {
      switch (result) {
        case "Wrong password": {
          wrongPasswordError = true;
          break;
        }
        case "No username": {
          noUserError = true;
          break;
        }
        default: {
          wrongPasswordError = false;
          noUserError = false;
          // TODO: Redirect user to Home Page
          let userCookie = new Cookies();
          userCookie.set("user", data.username, {
            path: "/",
            maxAge: 10, // given in seconds => TO BE MODIFIED
          });
          sessionStorage.setItem("username", data.username);
          break;
        }
      }
    });
  }

  function toSignUp() {
    history.push("/signup");
  }

  return (
    <div className="login--container">
      <img src={loginPic} className="login--image" />
      <div className="login--window">
        <h1> LOGIN </h1>
        <form>
          <div className="login--window--elements">
            <h5>Username</h5>
            <input
              name="username"
              value={stateData.username}
              type="text"
              placeholder="Type in your username"
              onChange={handleChange}
              required
            ></input>
            {noUserError && (
              <h3 className="login--error--text">Username does not exist!</h3>
            )}
            <h5>Password</h5>
            <input
              name="password"
              value={stateData.password}
              type="password"
              placeholder="Type in your password"
              onChange={handleChange}
              required
            ></input>
            {wrongPasswordError && (
              <h6 className="login--error--text">Wrong password!</h6>
            )}
            <div className="login--window--buttons">
              <button type="submit" onClick={handleSubmit}>
                {" "}
                Login{" "}
              </button>
              <button onClick={toSignUp}> Sign up</button>
            </div>
          </div>
        </form>
      </div>
    </div>
  );
}
