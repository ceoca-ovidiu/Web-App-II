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
/*
  function _base64ToArrayBuffer(base64) {
    var binary_string = window.atob(base64);
    var len = binary_string.length;
    var bytes = new Uint8Array(len);
    for (var i = 0; i < len; i++) {
      bytes[i] = binary_string.charCodeAt(i);
    }
    return bytes.buffer;
  }
  */
  return (
    <div className="card-container">
          <img className="card-image" src={imageSource} />
      <h5 className="card-subtitle">{name}</h5>
      <h6 className="card-subtitle">Descriere</h6>
      <p>{text}</p>
      <h5 className="card-subtitle">
        Cost: {price} Ron{unit ? "/" + unit : null}
      </h5>
      <button className="card-addButton" onClick={onClickHandle}>
        Add
      </button>
    </div>
  );
}
