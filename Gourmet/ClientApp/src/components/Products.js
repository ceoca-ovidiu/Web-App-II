import axios from "axios";
import React, { useEffect, useState } from "react";
import Constants from "../utils/Constants";
import Product from "./ProductComponents/Product";
import image from "./ProductComponents/tomato.jpg";

export default function Products(props) {
  const cost = 5;
  const [elements, setEelements] = useState([]);

  useEffect(() => {
    axios
      .get(Constants.BASE_URL + Constants.GET_ALL_PRODUCTS)
      .then((result) => {
         //console.log(result.data);
        setEelements(result.data);
      });
  }, []);

  console.log(elements);
  return (
    <div className="products-container">
      {elements.map((element, index) => (
        <Product
          key={element.productId}
          imageSource={element.productImage}
          name={element.productName}
          text={element.productDescription}
          price={element.productPrice}
          unit={element.unit}
        />
      ))}
    </div>
  );
}
