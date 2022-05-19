import React from "react";
import "../../styles/ProductCard.css";
import image from "./tomato.jpg";

export default function Product(props) {
  const imageSource = props.imageSource;
  const name = props.name;
  const text = props.text;
  const price = props.price;
  const unit = props.unit;

  function onClickHandle() {
    // TODO: Add to cart => create global cart storage
    let productList = sessionStorage.getItem("productList");
    productList === ""
      ? (productList = [])
      : (productList = JSON.parse(productList));
    productList.push(props);
    sessionStorage.setItem("productList", JSON.stringify(productList));
    alert("Item has been added to te cart");
  }

  return (
    <div className="card-container">
      <img className="card-image" src={image} />
      <h5 className="card-subtitle">{name}</h5>
      <h5 className="card-subtitle">Descriprion</h5>
      <p>
        The tomato is the edible berry of the plant Solanum lycopersicum,
        commonly known as a tomato plant. The species originated in western
        South America and Central America. The Mexican Nahuatl word tomatl gave
        rise to the Spanish word tomate, from which the English word tomato
        derived.
      </p>
      <h5 className="card-subtitle">
        Cost: {price} Ron{unit ? "/" + unit : null}
      </h5>
      <button className="card-addButton" onClick={onClickHandle}>
        Add
      </button>
    </div>
  );
}
