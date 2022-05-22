import React from "react";
import "../../styles/RecipeCard.css";

export default function Recipe(props) {
    const text = props.text;
    return (
        <div className="card-suggestion">
            <p>
                {text}
            </p>
        </div>
    );
}