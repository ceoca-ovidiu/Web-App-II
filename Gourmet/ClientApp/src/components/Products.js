import React from "react";
import Product from "./ProductComponents/Product";
import image from "./ProductComponents/tomato.jpg";

export default function Products(props) {
  const cost = 5;
  const elements = [
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: "kg",
    },
    {
      imageSource: image,
      name: "Tomato",
      description:
        "The tomato is the edible berry of the plant Solanum lycopersicum, commonly known as the tomato plant. The species originated in western South America and Central America. The Mexican Nahuatl word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.",
      price: 5,
      unit: null,
    },
  ];

  return (
    <div className="products-container">
      {elements.map((element) => (
        <Product
          imageSource={element.imageSource}
          name={element.name}
          text={element.description}
          price={element.price}
          unit={element.unit}
        />
      ))}
    </div>
  );
}
