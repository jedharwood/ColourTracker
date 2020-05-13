const colours = [
  {
    id: 1,
    colourName: "Crimson",
    authorId: 1,
    category: "Red",
  },
  {
    id: 2,
    colourName: "Golden Yellow",
    authorId: 1,
    category: "yellow",
  },
  {
    id: 3,
    colourName: "Olive Green",
    authorId: 1,
    category: "Green",
  },
  {
    id: 4,
    colourName: "Saddle Brown",
    authorId: 2,
    category: "Brown",
  },
  {
    id: 5,
    colourName: "Jade Green",
    authorId: 2,
    category: "Green",
  },
  {
    id: 6,
    colourName: "Coral Pink",
    authorId: 2,
    category: "pink",
  },
  {
    id: 7,
    colourName: "Turquoise",
    authorId: 3,
    category: "Blue",
  },
  {
    id: 8,
    colourName: "Medium Blue",
    authorId: 3,
    category: "Blue",
  },
  {
    id: 9,
    colourName: "Payne's Grey",
    authorId: 3,
    category: "Career",
  },
  {
    id: 10,
    colourName: "Naval Orange",
    authorId: 3,
    category: "Orange",
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
  category: "",
};

// Using CommonJS style export so we can consume via Node (without using Babel-node)
module.exports = {
  newColour,
  colours,
  brands,
};