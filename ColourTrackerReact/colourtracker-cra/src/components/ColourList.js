import React from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

function ColourList(props) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Brand Id</th>
          <th>Colour Family</th>
        </tr>
      </thead>
      <tbody>
        {props.colours.map((colour) => {
          return (
            <tr key={colour.id}>
              <td>
                <Link to={"/colour/" + colour.id}>{colour.colourName}</Link>
              </td>
              <td>{colour.authorId}</td>
              <td>{colour.colourFamily}</td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

ColourList.propTypes = {
  colours: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      colourName: PropTypes.string.isRequired,
      authorId: PropTypes.number.isRequired,
      colourFamily: PropTypes.string.isRequired,
    })
  ).isRequired,
};

export default ColourList;
