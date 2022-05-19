import React, { useEffect, useState } from "react";
import "../styles/CartStyle.css";
export default function Cart(props) {
  const [productList, setProductList] = useState([]);
  const [total, setTotal] = useState(0);

  useEffect(() => {
    let list = sessionStorage.getItem("productList");

    if (list === "") {
      setProductList([]);
    } else {
      list = JSON.parse(list);
      setProductList(list);
    }
  }, []);

  useEffect(() => {
    setTotal(calculateTotal);
    let list = JSON.stringify(productList);
    sessionStorage.setItem("productList", list);
  }, [productList]);

  function calculateTotal() {
    let total = 0;
    if (productList.length > 0) {
      productList.forEach((element) => {
        total = total + parseFloat(element.price);
      });
    }
    return total;
  }

  function removeFromList(index) {
    setProductList((old) => old.filter((productList, i) => i !== index));
  }

  function handleBuy() {
    alert("You can not buy anything at this moment");
  }

  return (
    <div class="table-container">
      <h3> This is your cart</h3>
      <div className="table">
        <div className="table-header">
          <div className="header-item">ID</div>
          <div className="header-item">Image</div>
          <div className="header-item">Name</div>
          <div className="header-item">Price</div>
          <div className="header-item">Remove</div>
        </div>
        <div className="table-content">
          {productList.map((element, index) => (
            <div className="table-row">
              <div className="table-data">{index + 1}</div>
              <div className="table-data">
                <img src={element.imageSource}></img>
              </div>
              <div className="table-data">{element.name}</div>
              <div className="table-data">{element.price} RON</div>
              <div className="table-data">
                <div
                  className="table-data-button"
                  onClick={() => removeFromList(index)}
                >
                  X
                </div>
              </div>
            </div>
          ))}
          <div class="table-row">
            <div className="table-data"></div>
            <div className="table-data"></div>
            <div className="table-data"></div>
            <div className="table-data">
              <b>Total: </b>
              {total} RON
            </div>
            <div className="table-data">
              <div className="table-data-button" onClick={handleBuy}>
                Buy
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
