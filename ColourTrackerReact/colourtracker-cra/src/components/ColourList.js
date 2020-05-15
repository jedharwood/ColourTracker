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
          <th>Serial #</th>
          <th>Expiry</th>
        </tr>
      </thead>
      <tbody>
        {props.colours.map((colour) => {
          return (
            <tr key={colour.id}>
              <td>
                <Link to={"/colour/" + colour.id}>{colour.colourName}</Link>
              </td>
              <td>{colour.brandId}</td>
              <td>{colour.colourFamily}</td>
              <td>{colour.serialNumber}</td>
              <td>{colour.expiry}</td>
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
      brandId: PropTypes.number,
      colourFamily: PropTypes.number,
      expiry: PropTypes.string,
      serialNumber: PropTypes.string,
    })
  ).isRequired,
};

export default ColourList;
