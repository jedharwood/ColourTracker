import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { getColours } from "../api/colourApi";
import ColourList from "./ColourList";

function ColoursPage() {
  const [colours, setColours] = useState([]);

  useEffect(() => {
    getColours().then((_colours) => setColours(_colours));
  }, []);

  return (
    <>
      <h2>Colours</h2>
      <Link className="btn btn-primary" to="/colour">
        Add Colour
      </Link>
      <ColourList colours={colours} />
    </>
  );
}

export default ColoursPage;
