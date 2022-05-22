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
    if (productList == null || productList === "") {
      productList = [];
    } else {
      productList = JSON.parse(productList);
    }
    productList.push(props);
    sessionStorage.setItem("productList", JSON.stringify(productList));
    alert("Item has been added to te cart");
  }

  return (
    <div className="card-container">
      <img className="card-image" src={imageSource} />
      <h4 className="card-subtitle">{name}</h4>
      <h5 className="card-subtitle">Descriere</h5>
      <p>{text}</p>
      <h5 className="card-subtitle-price">
        Cost: {price} Ron{unit ? "/" + unit : null}
      </h5>
      <button className="card-addButton" onClick={onClickHandle}>
        Add
      </button>
    </div>
  );
}
