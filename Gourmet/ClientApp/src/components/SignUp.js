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
    phoneNumber: "",
  });

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
    let email = stateData.email;
    let password = stateData.password;
    let confirmPassword = stateData.confirmPassword;
    let phoneNumber = stateData.phoneNumber;
    if (password !== confirmPassword) {
      alert("Passwords do not match");
    } else if (username === "") {
      alert("Username is empty");
    } else if (email === "") {
      alert("Email is empty");
    } else if (password === "") {
      alert("Password is empty");
    } else if (confirmPassword === "") {
      alert("Confirm password is empty");
    } else if (phoneNumber === "") {
      alert("Phone number is empty");
    } else {
      sendCredentials(username, email, password, phoneNumber);
    }
  }

  function sendCredentials(username, email, password, phoneNumber) {
    let data = {
      Username: username,
      Password: password,
      Email: email,
      Phone: phoneNumber,
    };
    console.log(data);
    axios
      .post(Constants.BASE_URL + Constants.SIGNUP, data)
      .then((result) => {
        alert(result.data);
      })
      .catch((error) => {
        console.log(error);
        console.log(error.message);
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
            <h5>Email</h5>
            <input
              name="email"
              value={stateData.email}
              type="text"
              placeholder="Type in your email"
              onChange={handleChange}
              required
            />
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
            <h5>Phone number</h5>
            <input
              name="phoneNumber"
              value={stateData.phoneNumber}
              type="text"
              placeholder="Type in your phone number"
              onChange={handleChange}
              required
            />
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
