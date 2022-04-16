import React, { Component, useReducer } from "react";
import '../styles/SignUpContent.css'
import signUpPic from '../images/login.jpeg'
import axios from 'axios'

export class SignUp extends Component {

    constructor(props) {
        super(props)
        this.state = {
            username: '',
            email: '',
            password: '',
            confirmPassword: ''

        }
        this.handleChange = this.handleChange.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
        this.sendCredentials = this.sendCredentials.bind(this)

        this.userExistsError = false
        this.emailExistsError = false
        this.passwordMatchError = false
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
        const email = this.state.email;
        const password = this.state.password;
        const confirmPassword = this.state.confirmPassword;

        if (password === confirmPassword) {
            console.log("YOU SUBMITTED")
            console.log(this.state)
            // this.sendCredentials(username, email, password);
            this.passwordMatchError = false
        }
        else {
            this.passwordMatchError = true
        }


    }

    sendCredentials(username, email, password) {
        const apiUrl = "https://localhost:44422/api/signup"
        const data = {
            Username: username,
            UserEmail: email,
            UserPassword: password
        }
        axios.post(apiUrl, data)
            .then((result) => {
                console.log(result)
                switch (result) {
                    case "User exists": {
                        this.userExistsError = true
                        break;
                    }
                    case "Email exists": {
                        this.emailExistsError = true
                        break;
                    }
                    default: {
                        this.userExistsError = false
                        this.emailExistsError = false
                        break;
                        // TODO: Redirect user logged in to Home Page
                    }
                }
            })

    }
    render() {
        return (
            <div className="signup--container">
                <img src={signUpPic} className="signup--image" />
                <div className="signup--window">
                    <h1> SIGN UP </h1>
                    <form>
                        <div className="signup--window--elements">
                            <h5>Username</h5>
                            <input name="username" ref="Username" value={this.state.username} type="text" placeholder="Type in your username" onChange={this.handleChange} required/>
                            {this.userExistsError && <h6 className="signup--error--text">This username is not available!</h6>}
                            <h5>Email</h5>
                            <input name="email" value={this.state.email} type="text" placeholder="Type in your email" onChange={this.handleChange} required/>
                            {this.emailExistsError && <h6 className="signup--error--text">This email is already in use!</h6>}
                            <h5>Password</h5>
                            <input name="password" value={this.state.password} type="password" placeholder="Type in your password" onChange={this.handleChange} required/>
                            <h5>Confirm password</h5>
                            <input name="confirmPassword" value={this.state.confirmPassword} type="password" placeholder="Confrim your password" onChange={this.handleChange} required/>
                            {this.passwordMatchError && <h6 className="signup--error--text">Passwords do not match!</h6>}
                            <div className="signup--window--buttons">
                                <button type="submit" onClick={this.handleSubmit}> Join </button>
                            </div>
                        </div>
                    </form>

                </div>
            </div>
        );
    }
}