import React from "react";
import "../styles/SignUpContent.css";
import signUpPic from "../images/login.jpeg";
import axios from "axios";
import { useState } from "react";
import Constants from "../utils/Constants";
import bcrypt from "bcryptjs";

export default function SignUp(props) {
  let [stateData, setStateData] = useState({
    username: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  let userExistsError = false;
  let emailExistsError = false;
  let passwordMatchError = false;

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
    let salt = bcrypt.genSalt(10);
    let username = stateData.username;
    let email = stateData.email;
    let password = stateData.password;
    let confirmPassword = stateData.confirmPassword;
    if (password === confirmPassword) {
      // this.sendCredentials(username, email, bcrypt.hashSync(password));
      passwordMatchError = false;
      console.log(bcrypt.hashSync(password));
    } else {
      passwordMatchError = true;
    }
  }

  function sendCredentials(username, email, password) {
    let data = {
      Username: username,
      UserEmail: email,
      UserPassword: password,
    };
    axios.post(Constants.BASE_URL + Constants.SIGNUP, data).then((result) => {
      console.log(result);
      switch (result) {
        case "User exists": {
          userExistsError = true;
          break;
        }
        case "Email exists": {
          emailExistsError = true;
          break;
        }
        default: {
          userExistsError = false;
          emailExistsError = false;
          break;
          // TODO: Redirect user logged in to Home Page
        }
      }
    });
  }

  return (
    <div className="signup--container">
      <img src={signUpPic} className="signup--image" />
      <div className="signup--window">
        <h1> SIGN UP </h1>
        <form>
          <div className="signup--window--elements">
            <h5>Username</h5>
            <input
              name="username"
              value={stateData.username}
              type="text"
              placeholder="Type in your username"
              onChange={handleChange}
              required
            />
            {userExistsError && (
              <h6 className="signup--error--text">
                This username is not available!
              </h6>
            )}
            <h5>Email</h5>
            <input
              name="email"
              value={stateData.email}
              type="text"
              placeholder="Type in your email"
              onChange={handleChange}
              required
            />
            {emailExistsError && (
              <h6 className="signup--error--text">
                This email is already in use!
              </h6>
            )}
            <h5>Password</h5>
            <input
              name="password"
              value={stateData.password}
              type="password"
              placeholder="Type in your password"
              onChange={handleChange}
              required
            />
            <h5>Confirm password</h5>
            <input
              name="confirmPassword"
              value={stateData.confirmPassword}
              type="password"
              placeholder="Confrim your password"
              onChange={handleChange}
              required
            />
            {passwordMatchError && (
              <h6 className="signup--error--text">Passwords do not match!</h6>
            )}
            <div className="signup--window--buttons">
              <button type="submit" onClick={handleSubmit}>
                Join
              </button>
            </div>
          </div>
        </form>
      </div>
    </div>
  );
}
