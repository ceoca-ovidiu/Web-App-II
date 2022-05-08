import React from "react";
import "../../styles/RecipeCard.css";

export default function Recipe(props) {
    const text = props.text;
    return (
        <div className="card-suggestion">
            <p>
                Te-ai întrebat vreodată care sunt originile îndrăgitului preparat numit musaca? Delicioasă şi apetisantă, musacaua este o marcă a bucătăriei greceşti.
                Musacaua este o mâncare preparată din carne tocată şi felii de vinete, aşezate în straturi alternative, acoperite cu un strat gros de sos béchamel, care este coaptă în cuptor şi astfel devine crocantă şi rumenită frumos.
            </p>
        </div>
    );
}