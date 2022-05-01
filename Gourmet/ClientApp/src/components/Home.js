import React from "react";
import Recipe from "./RecipeImage/Recipe";
import image from "./RecipeImage/MusacaCartofi.jpg";

export default function Home(props) {
    const elements = [
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        },
        {
            imageSource: image,
            name: "Musaca Cartofi",
            description: "Insert recipes"
        }
    ];
    return (
        <div className="recipes-container">
            {elements.map((element) => (
                <Recipe
                    imageSource={element.imageSource}
                    name={element.name}
                    text={element.description}
                />
            ))}
        </div>
    );
}
