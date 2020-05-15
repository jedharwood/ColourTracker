import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.REACT_APP_API_URL + "/colourfamilies/";

export function getColourFamilies() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}
