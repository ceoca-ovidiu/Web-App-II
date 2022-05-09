import React, { Fragment } from "react";
import Recipe from "./RecipeComponents/Recipe";
import Suggestion from "./RecipeComponents/Suggestion";
import image from "./RecipeComponents/MusacaCartofi.jpg";

export default function Home(props) {
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
    return (
        <div className="recipes-container">
            {elements.map((element) => (
                <Fragment>
                <Recipe
                    imageSource={element.imageSource}
                    name={element.name}
                    text={element.description}
                    />
                    <Suggestion
                        text={element.text}
                        />
                </Fragment>
            ))}
        </div>
    );
}
