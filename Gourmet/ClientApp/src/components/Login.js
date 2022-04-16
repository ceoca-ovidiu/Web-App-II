import React, { Component, useReducer } from "react";
import '../styles/LoginContent.css'
import loginPic from '../images/login.jpeg'
import axios from 'axios'
import { Link, useHistory } from "react-router-dom";

export class Login extends Component {

    constructor(props) {
        super(props)
        this.state = {
            username: '',
            password: ''
        }
        this.handleChange = this.handleChange.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
        this.sendCredentials = this.sendCredentials.bind(this)
        this.toSignUp = this.toSignUp.bind(this)
        this.noUserError = false
        this.wrongPasswordError = false
    }

    // this.handleChange = this.handleChange.bind(this);

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        this.setState({
            [name]: value
        })
    }

    handleSubmit(event) {
        event.preventDefault();
        const username = this.state.username;
        const password = this.state.password;
        console.log("YOU SUBMITTED")
        console.log(username + 'and' + password)
        // this.sendCredentials(username, password);
        // TODO: send credentials and check for user => get back with a response
    }

    sendCredentials(username, password) {
        const apiUrl = "https://localhost:44422/api/login"
        const data = {
            username: username,
            password: password
        }
        axios.post(apiUrl, data)
            .then((result) => {
                switch (result) {
                    case "Wrong password": {
                        this.wrongPasswordError = true;
                        break;
                    }
                    case "No username": {
                        this.noUserError = true;
                        break;
                    }
                    default: {
                        this.wrongPasswordError = false;
                        this.noUserError = false;
                        // TODO: Redirect user to Home Page
                        break;
                    }
                }
            })
    }

    toSignUp() {
        this.props.history.push('/signup')
    }
    render() {
        return (
            <div className="login--container">
                <img src={loginPic} className="login--image" />
                <div className="login--window">
                    <h1> LOGIN </h1>
                    <form>
                        <div className="login--window--elements">
                            <h5>Username</h5>
                            <input name="username" value={this.state.username} type="text" placeholder="Type in your username" onChange={this.handleChange} required></input>
                            {this.noUserError && <h3 className="login--error--text">Username does not exist!</h3>}
                            <h5>Password</h5>
                            <input name="password" value={this.state.password} type="password" placeholder="Type in your password" onChange={this.handleChange} required></input>
                            {this.wrongPasswordError && <h6 className="login--error--text">Wrong password!</h6>}
                            <div className="login--window--buttons">
                                <button type="submit" onClick={this.handleSubmit}> Login </button>
                                <button onClick={this.toSignUp}> Sign up</button>
                            </div>
                        </div>
                    </form>


                </div>
            </div>
        );
    }
}