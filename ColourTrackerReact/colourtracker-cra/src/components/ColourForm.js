import React from "react";
import TextInput from "./common/TextInput";
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

      <div className="form-group">
        <label htmlFor="brand">Brand</label>
        <div className="field">
          <select
            id="brand"
            name="brandId"
            onChange={props.onChange}
            className="form-control"
            value={props.colour.brandId || ""}
          >
            <option value="" />
            <option value={"1"}>Waverly</option>
            <option value="2">Old Gold</option>
            <option value="3">Castle Pigment</option>
          </select>
        </div>
        {props.errors.brandId && (
          <div className="alert alert-danger">{props.errors.brandId}</div>
        )}
      </div>

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
