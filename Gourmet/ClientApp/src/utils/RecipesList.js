import React, { Component } from "react";
import axios from "axios";
import Constants from "../utils/Constants";

export default class RecipesList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            recipes: []
        }
    }
    componentDidMount() {
        axios.get(Constants.BASE_URL + Constants.GET_ALL_RECIPES).then(result => {
            console.log(result.data);
            const recipes = res.data.results.map(obj => [obj.id, obj.name]);
            this.setState({ recipes });
        });
    }

    render() {
        return (
            <ul>
                {this.state.recipes.map(function (recipe, index) {
                    return (
                        <div key={index}>
                            <h1>{recipe.id}</h1>
                            <p>{recipe.name}</p>
                        </div>
                    )
                }
                )}
            </ul>
        );

    }
}