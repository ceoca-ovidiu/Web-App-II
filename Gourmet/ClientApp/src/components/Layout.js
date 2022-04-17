import React from "react";
import NavMenu from "./NavMenu";
import { Container } from "reactstrap";

export default function Layout(props) {
  return (
    <div>
      <NavMenu />
      <Container className="container mh-100 mw-90">{props.children}</Container>
    </div>
  );
}
