const colours = [
  {
    id: 1,
    colourName: "Crimson",
    authorId: 1,
    colourFamily: "Red",
  },
  {
    id: 2,
    colourName: "Golden Yellow",
    authorId: 1,
    colourFamily: "yellow",
  },
  {
    id: 3,
    colourName: "Olive Green",
    authorId: 1,
    colourFamily: "Green",
  },
  {
    id: 4,
    colourName: "Saddle Brown",
    authorId: 2,
    colourFamily: "Brown",
  },
  {
    id: 5,
    colourName: "Jade Green",
    authorId: 2,
    colourFamily: "Green",
  },
  {
    id: 6,
    colourName: "Coral Pink",
    authorId: 2,
    colourFamily: "pink",
  },
  {
    id: 7,
    colourName: "Turquoise",
    authorId: 3,
    colourFamily: "Blue",
  },
  {
    id: 8,
    colourName: "Medium Blue",
    authorId: 3,
    colourFamily: "Blue",
  },
  {
    id: 9,
    colourName: "Payne's Grey",
    authorId: 3,
    colourFamily: "Career",
  },
  {
    id: 10,
    colourName: "Naval Orange",
    authorId: 3,
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
  authorId: null,
  colourFamily: "",
};

// Using CommonJS style export so we can consume via Node (without using Babel-node)
module.exports = {
  newColour,
  colours,
  brands,
};
