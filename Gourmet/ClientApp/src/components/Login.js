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
  const [errors, setErrors] = useState({
    wrongPasswordError: false,
    noUserError: false,
  });
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
    let password = stateData.password;
    console.log("YOU SUBMITTED");
    console.log(username + " and " + password);

    // TODO: send credentials and check for user => get back with a response
    sessionStorage.clear();
    sendCredentials(username, password);
    // let userCookie = new Cookies();
    // userCookie.set("user", stateData.username, {
    //   path: "/",
    //   maxAge: 60, // given in seconds => TO BE MODIFIED
    // });
    // sessionStorage.setItem("username", stateData.username);
    // sessionStorage.setItem("productList", []);
    // sessionStorage.clear();
  }

  function sendCredentials(username, password) {
    let data = {
      Username: username,
      Password: password,
    };
    axios
      .post(Constants.BASE_URL + Constants.LOGIN, data)
      .then((result) => {
        result = result.data;
        console.log(result);
        switch (result) {
          case "Wrong password": {
            setErrors((old) => ({
              noUserError: false,
              wrongPasswordError: true,
            }));
            break;
          }
          case "No user found": {
            setErrors((old) => ({
              wrongPasswordError: false,
              noUserError: true,
            }));
            break;
          }
          default: {
            setErrors((old) => ({
              noUserError: true,
              wrongPasswordError: true,
            }));
            // TODO: Redirect user to Home Page
            let userCookie = new Cookies();
            userCookie.set("username", result.username, {
              path: "/",
              maxAge: 60, // given in seconds => TO BE MODIFIED
            });
            sessionStorage.setItem("username", result.username);
            props.toggleIsLoggedIn();
            history.push("/");
            break;
          }
        }
      })
      .catch((error) => {
        console.log(error);
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
            {errors.noUserError && (
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
            {errors.wrongPasswordError && (
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
