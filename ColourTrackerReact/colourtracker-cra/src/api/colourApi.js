import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.REACT_APP_API_URL + "/colours/";

export function getColours() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function getColourById(id) {
  // return fetch(baseUrl + "?id=" + id)
  return (
    fetch(baseUrl + id)
      // .then((response) => {
      //   if (!response.ok) throw new Error("Network response was not ok.");
      //   return response.json().then((colours) => {
      //     if (colours.length !== 1) throw new Error("Colour not found: " + id);
      //     return colours[0]; // should only find one colour for a given Id, so return it.
      //   });
      // })
      .then(handleResponse)
      .catch(handleError)
  );
}

// export function saveColour(colour) {
//   return fetch(baseUrl + (colour.id || "new"), {
//     method: colour.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
//     headers: { "content-type": "application/json" },
//     body: JSON.stringify({
//       ...colour,
//       // Parse brandId to a number (in case it was sent as a string).
//       brandId: parseInt(colour.brandId, 10),
//     }),
//   })
//     .then(handleResponse)
//     .catch(handleError);
// }

export function saveColour(colour) {
  colour.id = 1;
  colour.colourFamily = "Red";
  colour.brandName = "Eternal";
  colour.dateAdded = null;
  colour.dateDeleted = null;
  colour.dateModified = null;
  colour.brandId = parseInt(colour.brandId, 10);
  colour.colourFamilyId = parseInt(colour.colourFamilyId, 10);
  const payload = JSON.stringify(colour);
  return fetch(baseUrl + "new", {
    method: "POST",
    headers: { "content-type": "application/json" },
    body: payload,
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteColour(colourId) {
  return fetch(baseUrl + colourId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
