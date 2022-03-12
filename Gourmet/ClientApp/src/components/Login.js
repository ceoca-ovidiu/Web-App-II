import React, { Component } from "react";
import '../styles/LoginContent.css'
import loginPic from '../images/login.jpeg'
export class Login extends Component {

    render () {
        return (
            <div className="login--container">
                <img src={loginPic} className ="login--image"/>
                <div className="login--window">
                    <h1> LOGIN </h1>
                    <div className="login--window--elements">
                        <h5>Username</h5>
                        <input type="text" placeholder="Type in your username"></input>
                        <h5>Password</h5>
                        <input type="text" placeholder="Type in your password"></input>
                        <div className="login--window--buttons">
                            <button> Login </button>
                            <button> Sign up</button>    
                        </div>
                    </div>

                </div>
            </div>
        );
    }
}