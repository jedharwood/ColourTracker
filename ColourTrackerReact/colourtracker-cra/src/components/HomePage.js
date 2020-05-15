import React from "react";
import { Link } from "react-router-dom";

function HomePage() {
  return (
    <div className="jumbotron">
      <h1>Colour Tracker</h1>
      <p>
        A CRUD app to track pigment expiry dates using a ReactJs front end and
        an ASP.NET MVC back end. Fun, eh?
      </p>
      <Link to="/about" className="btn btn-primary">
        About
      </Link>
    </div>
  );
}

export default HomePage;
