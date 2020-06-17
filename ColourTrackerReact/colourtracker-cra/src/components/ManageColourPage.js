import React, { useState, useEffect } from "react";
import ColourForm from "./ColourForm";
import * as colourApi from "../api/colourApi";
import { toast } from "react-toastify";

const ManageColourPage = (props) => {
  const [errors, setErrors] = useState({});
  const [colour, setColour] = useState({
    id: null,
    colourName: "",
    brandId: null,
    colourFamilyId: null,
  });

  useEffect(() => {
    const id = props.match.params.id;
    if (id) {
      colourApi.getColourById(id).then((_colour) => setColour(_colour));
    }
  }, [props.match.params.id]);

  function handleChange({ target }) {
    const updatedColour = {
      ...colour,
      [target.name]: target.value,
    };
    setColour(updatedColour);
  }

  function formIsValid() {
    const _errors = {};

    if (!colour.colourName) _errors.colourName = "Colour Name is required";

    setErrors(_errors);

    return Object.keys(_errors).length === 0;
  }

  function handleSubmit(event) {
    event.preventDefault();
    if (!formIsValid()) return;
    colourApi.saveColour(colour).then(() => {
      props.history.push("/colours");
      toast.success("Colour saved.");
    });
  }

  function EditColourLegend() {
    return <h2>Edit Colour</h2>;
  }

  function AddColourLegend() {
    return <h2>Add Colour</h2>;
  }

  function PageLegend(props) {
    if (props.colour.id === null) {
      return <AddColourLegend />;
    } else {
      return <EditColourLegend />;
    }
  }

  return (
    <>
      <PageLegend colour={colour} />
      <ColourForm
        errors={errors}
        colour={colour}
        onChange={handleChange}
        onSubmit={handleSubmit}
      />
    </>
  );
};

export default ManageColourPage;
