import React, { useState, useEffect } from "react";
import { getBrands } from "../api/brandApi";
import { getColourFamilies } from "../api/colourFamilyApi";
import TextInput from "./common/TextInput";
import SelectInput from "./common/SelectInput";
import PropTypes from "prop-types";

function ColourForm(props) {
  const [brands, setBrands] = useState([]);

  useEffect(() => {
    getBrands().then((_brands) => setBrands(_brands));
  }, []);

  const [colourFamilies, setColourFamilies] = useState([]);

  useEffect(() => {
    getColourFamilies().then((_colourFamilies) =>
      setColourFamilies(_colourFamilies)
    );
  }, []);

  return (
    <form onSubmit={props.onSubmit}>
      <TextInput
        id="colourName"
        label="Name"
        onChange={props.onChange}
        name="colourName"
        value={props.colour.colourName}
        error={props.errors.colourName}
      />

      <SelectInput
        id="brandId"
        label="Brand"
        onChange={props.onChange}
        name="brandId"
        error={props.errors.brandId}
        value={props.colour.brandId}
        values={brands}
      />

      <SelectInput
        id="colourFamilyId"
        label="Colour Family"
        onChange={props.onChange}
        name="colourFamilyId"
        error={props.errors.colourFamilyId}
        value={props.colour.colourFamilyId}
        values={colourFamilies}
      />

      <TextInput
        id="serialNumber"
        label="Serial #"
        onChange={props.onChange}
        name="serialNumber"
        value={props.colour.serialNumber}
        error={props.errors.serialNumber}
      />

      <TextInput
        id="expiry"
        label="Expiry"
        onChange={props.onChange}
        name="expiry"
        value={props.colour.expiry}
        error={props.errors.expiry}
      />

      <input type="submit" value="Save" className="btn btn-primary" />
    </form>
  );
}

ColourForm.propTypes = {
  colour: PropTypes.object.isRequired,
  onSubmit: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  errors: PropTypes.object.isRequired,
};

export default ColourForm;
