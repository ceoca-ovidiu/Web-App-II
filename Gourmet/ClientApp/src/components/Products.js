import React, { Component } from 'react';
import {Product} from "./Products/Product";

export class Products extends Component {
    constructor(props) {
        super(props);
        this.cost = 5
    }
    render() {
        return (
            <div className="products-container">
                <Product price = {this.cost} />
                <Product price = {this.cost} />
                <Product price = {this.cost} />
                <Product price = {this.cost} />
            </div>
        );
    }
}