import React, { useState } from "react";
import userImage from "../images/user.png";
import "../styles/UserStyle.css";
import CookieCheck from "../utils/CookieCheck";
import { useHistory } from "react-router-dom";
import axios from "axios";
import Constants from "../utils/Constants";
import { useEffect } from "react";
import Cookies from "universal-cookie";
import bcrypt from "bcryptjs";

export default function User(props) {
  let history = useHistory();
  let userData = {
    username: "",
    passwprd: "",
    email: "",
    phone: "",
  };
  let [userFound, setUserFound] = useState(false);
  let [activeData, setActiveData] = useState({
    passwordChange: true,
    emailChange: false,
    phoneChange: false,
  });
  let [formData, setFromData] = useState({
    oldPassword: "",
    newPassword: "",
    confirmPassword: "",
    oldEmail: "",
    newEmail: "",
    confirmEmail: "",
    oldPhone: "",
    newPhone: "",
    confirmPhone: "",
  });

  let [errors, setErrors] = useState({
    passwordMatchError: false,
    passwordOldMatchError: false,
    emailMatchError: false,
    emailOldMatchError: false,
    phoneMatchError: false,
    phoneOldMatchError: false,
  });
  const salt = bcrypt.genSalt(10);
  // useEffect(() => {
  //   let user = CookieCheck();
  //   if (user === null) {
  //     sessionStorage.clear("username");
  //     alert("Your session has expired, please log in again");
  //     history.push("/login");
  //   } else {
  //     let data = {
  //       Username: user,
  //     };
  //     axios.get(Constants.BASE_URL + Constants.USER, data).then((response) => {
  //       if (response != "No user found") {
  //         userData.username = user;
  //         userData.password = response.UserPassword;
  //         userData.email = response.UserEmail;
  //         userData.phone = response.UserPhoneNumber;
  //       }
  //     });
  //   }
  // }, []);

  function handleChange(event) {
    let target = event.target;
    let value = target.value;
    let name = target.name;
    setFromData({
      ...formData,
      [name]: value,
    });
  }

  function handleSubmit(event) {
    event.preventDefault();
    let user = CookieCheck();
    if (user == null) {
      sessionStorage.clear("username");
      alert("Your session has expired, please log in again");
      history.push("/login");
    } else {
      let data = {};
      let url = "";

      if (activeData.passwordChange) {
        // console.log("here");

        setFromData({
          ...formData,
          oldPassword: bcrypt.hashSync(formData.oldPassword),
          newPassword: bcrypt.hashSync(formData.newPassword),
          confirmPassword: bcrypt.hash(formData.confirmPassword, salt),
        });
        if (formData.newPassword !== formData.confirmPassword) {
          setErrors({
            ...errors,
            passwordMatchError: true,
          });
        } else if (formData.oldPassword !== userData.passwprd) {
          setErrors({
            ...errors,
            passwordOldMatchError: true,
          });
        } else {
          setErrors({
            ...errors,
            passwordMatchError: false,
            passwordOldMatchError: false,
          });

          data = {
            UserPassword: formData.newPassword,
          };
          url = Constants.BASE_URL + Constants.CHANGE_PASSWORD;
        }
      } else if (activeData.emailChange) {
        if (formData.newEmail !== formData.confirmEmail) {
          setErrors({
            ...errors,
            emailMatchError: true,
          });
        } else if (formData.oldEmail !== userData.email) {
          setErrors({
            ...errors,
            emailOldMatchError: true,
          });
        } else {
          setErrors({
            ...errors,
            emailMatchError: false,
            emailOldMatchError: false,
          });
          data = {
            UserEmail: formData.newEmail,
          };
          url = Constants.BASE_URL + Constants.CHANGE_EMAIL;
        }
      } else {
        console.log(formData);
        if (formData.newPhone !== formData.confirmPhone) {
          setErrors({
            ...errors,
            phoneMatchError: true,
          });
        } else if (formData.oldPhone !== userData.phone) {
          setErrors({
            ...errors,
            phoneOldMatchError: true,
          });
        } else {
          setErrors({
            ...errors,
            phoneMatchError: false,
            phoneOldMatchError: false,
          });

          data = {
            UserPhoneNumber: formData.newPhone,
          };
          url = Constants.BASE_URL + Constants.CHANGE_PHONE;
        }
      }
      console.log(data);
      console.log(url);
      // if (data && url !== "") {
      //   axios.put(url, data).then((result) => {
      //     if (result === "Succes") {
      //       alert("Changes had been made!");
      //     } else {
      //       alert("Something went wrong, please try again later!");
      //     }
      //   });
      // }
    }
  }
  return (
    <div className="main-container">
      <div className="user-data">
        <img className="user-image" src={userImage} />
        <h5>Erovajn</h5>
        <h5>enyedi.eervin@gmail.com</h5>
        <h5>0738979714</h5>
      </div>
      <div className="active-data">
        <form>
          {activeData.passwordChange && (
            <>
              <h5>Old password</h5>
              <input
                name="oldPassword"
                type="text"
                placeholder="Type in your old password"
                onChange={handleChange}
              />
              <h5>New password</h5>
              <input
                name="newPassword"
                type="text"
                placeholder="Type in your new password"
                onChange={handleChange}
              />
              <h5>Confirm new password</h5>
              <input
                name="confirmPassword"
                type="text"
                placeholder="Confirm your old password"
                onChange={handleChange}
              />
            </>
          )}
          {activeData.emailChange && (
            <>
              <h5>Old email adress</h5>
              <input
                name="oldEmail"
                type="text"
                placeholder="Type in your old email adress"
                onChange={handleChange}
              />

              <h5>New email adress</h5>
              <input
                name="newEmail"
                type="text"
                placeholder="Type in your new email adress"
                onChange={handleChange}
              />

              <h5>Confirm new email adress</h5>
              <input
                name="confirmEmail"
                type="text"
                placeholder="Confirm your new email adress"
                onChange={handleChange}
              />
            </>
          )}
          {activeData.phoneChange && (
            <>
              <h5>Old phone number</h5>
              <input
                name="oldPhone"
                type="text"
                placeholder="Type in your old phone number"
                onChange={handleChange}
              />

              <h5>New phone number</h5>
              <input
                name="newPhone"
                type="text"
                placeholder="Type in your new phone number"
                onChange={handleChange}
              />

              <h5>Confirm new phone number</h5>
              <input
                name="confirmPhone"
                type="text"
                placeholder="Confirm your new phone number"
                onChange={handleChange}
              />
            </>
          )}
          <br />
          <button
            type="submit"
            className="submit-button"
            onClick={handleSubmit}
          >
            Submit
          </button>
        </form>
      </div>
      <div className="option-panel">
        <ul>
          <li
            onClick={() => {
              setActiveData({
                passwordChange: true,
                emailChange: false,
                phoneChange: false,
              });
            }}
          >
            Change your password
          </li>
          <li
            onClick={() => {
              setActiveData({
                passwordChange: false,
                emailChange: true,
                phoneChange: false,
              });
            }}
          >
            Change your email adress
          </li>
          <li
            onClick={() => {
              setActiveData({
                passwordChange: false,
                emailChange: false,
                phoneChange: true,
              });
            }}
          >
            Change your phone number
          </li>
        </ul>
      </div>
    </div>
  );
}
