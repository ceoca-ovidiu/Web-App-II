import React, { Component, useReducer } from "react";
import '../styles/SignUpContent.css'
import signUpPic from '../images/login.jpeg'
import axios from 'axios'

export class SignUp extends Component {

    constructor(props){
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
    }

    // this.handleChange = this.handleChange.bind(this);

    handleChange(event){
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
        }
        else {
            alert("Passwords do not match")
        }
        
        
    }

    sendCredentials(username, email, password) {
        const apiUrl = "https://localhost:44422/api/signup"
        const data = {
            username: username,
            email: email,
            password: password
        }
        axios.post(apiUrl, data)
            .then((result) => {
                console.log(result)
            })
        // TODO: send credentials check if username exists => give back response
    }
    render () {
        return (
            <div className="signup--container">
                <img src={signUpPic} className ="signup--image"/>
                <div className="signup--window">
                    <h1> SIGN UP </h1>
                    <form>
                        <div className="signup--window--elements">
                            <h5>Username</h5>
                            <input name = "username" value = {this.state.username} type="text" placeholder="Type in your username" onChange={this.handleChange} required></input>
                            <h5>Email</h5>
                            <input name = "email" value = {this.state.email} type="text" placeholder="Type in your email" onChange={this.handleChange} required></input>
                            <h5>Password</h5>
                            <input name = "password" value = {this.state.password} type="password" placeholder="Type in your password" onChange={this.handleChange} required></input>
                            <h5>Confirm password</h5>
                            <input name = "confirmPassword" value = {this.state.confirmPassword} type="password" placeholder="Confrim your password" onChange={this.handleChange} required></input>

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