import React from "react";
import "../../styles/RecipeCard.css";
import image from "./MusacaCartofi.jpg";

export default function Recipe(props) {
  const imageSource = props.imageSource;
  const name = props.name;
  const text = props.text;
  //console.log(text);
  return (
    <div className="card-container">
          <img className="card-image" src={imageSource} />
      <h5 className="card-subtitle">{name}</h5>
      <h5 className="card-subtitle">Rețeta</h5>
      <p>{text}</p>
    </div>
  );
}
