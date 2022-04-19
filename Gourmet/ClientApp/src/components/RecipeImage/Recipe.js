import React from "react";
import "../../styles/RecipeCard.css";
import image from "./MusacaCartofi.jpg";

export default function Recipe(props) {
    const imageSource = props.imageSource;
    const name = props.name;
    const text = props.text;
    return (
        <div className="card-container">
            <img className="card-image" src={image} />
            <h5 className="card-subtitle">{name}</h5>
            <h5 className="card-subtitle">Rețeta</h5>
            <p>
                Ingrediente (20 bucăți)
                300 g Carne tocată de vită
                1 Cartof
                1 Ou
                Ulei de măsline
                Mărar tocat
                1 Ceapă
                Piper
                Sare

                Sosul:
                250 ml Suc de roșii
                250 ml Apă
                50 ml Ulei
                5 ml Oțet
                1 Frunză de dafin
                1 Lingură făină
                Sare

                Preparare
                1
                Se fierbe cartoful și se pasează. Se curăță ceapa și se toacă mărunt. Se amestecă carnea cu oul, cartoful, ceapa, mărarul, sarea și piperul. Se formează chifteluțe și se prăjesc în ulei încins.

                2
                Pentru sos, se încinge uleiul și se prăjește făina timp de 30 secunde. Se adaugă apa, sucul de roșii, frunza de dafin, oțetul și sarea.

                3
                Se fierb 10 minute pe foc mic, după care se adaugă chifteluțele prăjite. Se fierb încă 10 minute. Se servesc fierbinți.

            </p>
        </div>
    );
}