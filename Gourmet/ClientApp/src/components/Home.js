import React, { Fragment, useEffect, useState } from "react";
import Recipe from "./RecipeComponents/Recipe";
import Suggestion from "./RecipeComponents/Suggestion";
import image from "./RecipeComponents/MusacaCartofi.jpg";
import axios from "axios";
import Constants from "../utils/Constants";
import { CardImg } from "reactstrap";

export default function Home(props) {
     /*
     const elements = [
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes",
            text: "Insert text"
        }
    ];
    */
    const [elements, setEelements] = useState([]);

    useEffect(() => {
        axios
            .get(Constants.BASE_URL + Constants.GET_ALL_RECIPES)
            .then((result) => {
                //console.log(result.data);
                setEelements(result.data);
            });
    }, []);

    console.log(elements);

        return (
            <div className="recipes-container">
                {elements.map((element,index) => (
                    <Fragment>
                        <Recipe
                            key={element.recipeID}
                            imageSource={element.recipeImage}
                            name={element.recipeName}
                            text={element.recipeDescription}
                        />
                        <Suggestion
                            text={element.recipeSuggest}
                        />
                    </Fragment>
                ))}
 
            </div>
        );
}
