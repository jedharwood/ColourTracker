import React from "react";
import TextInput from "./common/TextInput";
import SelectInput from "./common/SelectInput";
import PropTypes from "prop-types";

function ColourForm(props) {
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
        id="brand"
        label="Brand"
        onChange={props.onChange}
        name="brandId"
        error={props.errors.brandId}
        value={props.colour.brandId}
        values={[
          {
            id: 1,
            name: "Waverly",
          },
          {
            id: 2,
            name: "Old Gold",
          },
          {
            id: 3,
            name: "Castle Pigment",
          },
          {
            id: 4,
            name: "Solid",
          },
        ]}
      />

      <TextInput
        id="colourFamily"
        label="Colour Family"
        name="colourFamily"
        onChange={props.onChange}
        value={props.colour.colourFamily}
        error={props.errors.colourFamily}
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
