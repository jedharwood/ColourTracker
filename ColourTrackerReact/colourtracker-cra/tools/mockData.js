// const colours = [
//   {
//     id: 1,
//     colourName: "Crimson",
//     brandId: 1,
//     colourFamily: 4,
//     expiry: "01/21",
//     serialNumber: "123a",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 2,
//     colourName: "Golden Yellow",
//     brandId: 1,
//     colourFamily: 6,
//     expiry: "02/21",
//     serialNumber: "123b",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 3,
//     colourName: "Olive Green",
//     brandId: 1,
//     colourFamily: 7,
//     expiry: "03/21",
//     serialNumber: "123c",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 4,
//     colourName: "Saddle Brown",
//     brandId: 2,
//     colourFamily: 11,
//     expiry: "04/21",
//     serialNumber: "123d",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 5,
//     colourName: "Jade Green",
//     brandId: 2,
//     colourFamily: 7,
//     expiry: "05/21",
//     serialNumber: "123e",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 6,
//     colourName: "Coral Pink",
//     brandId: 2,
//     colourFamily: 10,
//     expiry: "06/21",
//     serialNumber: "123f",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 7,
//     colourName: "Turquoise",
//     brandId: 3,
//     colourFamily: 8,
//     expiry: "07/21",
//     serialNumber: "123g",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 8,
//     colourName: "Medium Blue",
//     brandId: 3,
//     colourFamily: 9,
//     expiry: "08/21",
//     serialNumber: "123h",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 9,
//     colourName: "Payne's Grey",
//     brandId: 3,
//     colourFamily: 3,
//     expiry: "09/21",
//     serialNumber: "123i",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
//   {
//     id: 10,
//     colourName: "Naval Orange",
//     brandId: 3,
//     colourFamily: 5,
//     expiry: "10/21",
//     serialNumber: "123j",
//     dateAdded: null,
//     dateDeleted: null,
//     dateModified: null,
//   },
// ];

// const brands = [
//   { id: 1, name: "Waverly" },
//   { id: 2, name: "Old Gold" },
//   { id: 3, name: "Castle Pigment" },
//   { id: 4, name: "Solid Colour" },
// ];

// const colourFamilies = [
//   { id: 1, name: "Black" },
//   { id: 2, name: "Grey Wash" },
//   { id: 3, name: "Opaque Grey" },
//   { id: 4, name: "Red" },
//   { id: 5, name: "Orange" },
//   { id: 6, name: "Yellow" },
//   { id: 7, name: "Green" },
//   { id: 8, name: "Turquoise" },
//   { id: 9, name: "Blue" },
//   { id: 10, name: "Pink" },
//   { id: 11, name: "Brown" },
//   { id: 12, name: "Flesh Tone" },
//   { id: 13, name: "White" },
//   { id: 14, name: "Purple" },
// ];

const newColour = {
  id: null,
  colourName: "",
  brandId: null,
  colourFamilyId: null,
  expiry: "",
  serialNumber: "",
  dateAdded: null,
  dateDeleted: null,
  dateModified: null,
};

// Using CommonJS style export so we can consume via Node (without using Babel-node)
module.exports = {
  newColour,
  // colours,
  // brands,
  // colourFamilies,
};
