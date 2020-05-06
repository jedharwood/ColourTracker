import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.REACT_APP_API_URL + "/brands/";

export function getBrands() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function saveBrand(brand) {
  return fetch(baseUrl + (brand.id || ""), {
    method: brand.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(brand),
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteBrand(brandId) {
  return fetch(baseUrl + brandId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
