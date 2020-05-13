import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.REACT_APP_API_URL + "/colours/";

export function getColours() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function getColourById(id) {
  return fetch(baseUrl + "?id=" + id)
    .then((response) => {
      if (!response.ok) throw new Error("Network response was not ok.");
      return response.json().then((colours) => {
        if (colours.length !== 1) throw new Error("Colour not found: " + id);
        return colours[0]; // should only find one colour for a given Id, so return it.
      });
    })
    .catch(handleError);
}

export function saveColour(colour) {
  return fetch(baseUrl + (colour.id || ""), {
    method: colour.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify({
      ...colour,
      // Parse authorId to a number (in case it was sent as a string).
      authorId: parseInt(colour.authorId, 10),
    }),
  })
    .then(handleResponse)
    .catch(handleError);
}

// export function updateColour(colour) {
//   return fetch(baseUrl + colour.id, {
//     method: "PUT",
//     headers: { "content-type": "application/json" },
//     body: JSON.stringify({
//       ...colour,
//       authorId: parseInt(colour.authorId, 10),
//     }),
//   })
//     .then(handleResponse)
//     .catch(handleError);
// }

// export function saveNewColour(colour) {
//   return fetch(baseUrl, {
//     method: "POST",
//     headers: { "content-type": "application/json" },
//     body: JSON.stringify({
//       ...colour,
//       authorId: parseInt(colour.authorId, 10),
//     }),
//   })
//     .then(handleResponse)
//     .catch(handleError);
// }

export function deleteColour(colourId) {
  return fetch(baseUrl + colourId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
