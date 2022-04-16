import React, {Component} from "react";
import '../../styles/ProductCard.css'
import image from './tomato.jpg'
export class Product extends Component {

    constructor(props) {
        super(props)
        this.imageSource = props.imageSource
        this.text = props.text
        this.price = props.price
        console.log(this.imageSource)
    }

    onClickHandle(){
        // TODO: Add to cart => create global cart storage
        alert("Item has been added to te cart")
    }

    render() {
        return (
            <div className="card-container">
                <img className="card-image" src={image}/>
                <h5 className="card-subtitle">Name</h5>
                <h5 className="card-subtitle">Descriprion</h5>
                <p>The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as a tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.</p>
                <h5 className="card-subtitle">Cost: {this.price} RON</h5>
                <button className="card-addButton" onClick={this.onClickHandle}>Add</button>
            </div>
        )
    }
}