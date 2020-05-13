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
        <label htmlFor="author">Brand</label>
        <div className="field">
          <select
            id="author"
            name="authorId"
            onChange={props.onChange}
            className="form-control"
            value={props.colour.authorId || ""}
          >
            <option value="" />
            <option value={"1"}>Waverly</option>
            <option value="2">Old Gold</option>
            <option value="3">Castle Pigment</option>
          </select>
        </div>
        {props.errors.authorId && (
          <div className="alert alert-danger">{props.errors.authorId}</div>
        )}
      </div>

      <TextInput
        id="category"
        label="Colour Family"
        name="category"
        onChange={props.onChange}
        value={props.colour.category}
        error={props.errors.category}
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