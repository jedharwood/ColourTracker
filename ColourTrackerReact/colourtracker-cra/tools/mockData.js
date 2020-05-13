const colours = [
  {
    id: 1,
    colourName: "Crimson",
    brandId: 1,
    colourFamily: "Red",
  },
  {
    id: 2,
    colourName: "Golden Yellow",
    brandId: 1,
    colourFamily: "yellow",
  },
  {
    id: 3,
    colourName: "Olive Green",
    brandId: 1,
    colourFamily: "Green",
  },
  {
    id: 4,
    colourName: "Saddle Brown",
    brandId: 2,
    colourFamily: "Brown",
  },
  {
    id: 5,
    colourName: "Jade Green",
    brandId: 2,
    colourFamily: "Green",
  },
  {
    id: 6,
    colourName: "Coral Pink",
    brandId: 2,
    colourFamily: "pink",
  },
  {
    id: 7,
    colourName: "Turquoise",
    brandId: 3,
    colourFamily: "Blue",
  },
  {
    id: 8,
    colourName: "Medium Blue",
    brandId: 3,
    colourFamily: "Blue",
  },
  {
    id: 9,
    colourName: "Payne's Grey",
    brandId: 3,
    colourFamily: "Career",
  },
  {
    id: 10,
    colourName: "Naval Orange",
    brandId: 3,
    colourFamily: "Orange",
  },
];

const brands = [
  { id: 1, name: "Waverly" },
  { id: 2, name: "Old Gold" },
  { id: 3, name: "Castle Pigment" },
];

const newColour = {
  id: null,
  colourName: "",
  brandId: null,
  colourFamily: "",
};

// Using CommonJS style export so we can consume via Node (without using Babel-node)
module.exports = {
  newColour,
  colours,
  brands,
};
