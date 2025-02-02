This cheat sheet provides a quick reference for commonly used JavaScript concepts, syntax, and features. Whether you're a beginner or an experienced developer, this guide will help you with essential JavaScript operations.

## Table of Contents
1. [Variables](#variables)
2. [Data Types](#data-types)
3. [Operators](#operators)
4. [Conditional Statements](#conditional-statements)
5. [Loops](#loops)
6. [Functions](#functions)
7. [Objects](#objects)
8. [Arrays](#arrays)
9. [ES6 Features](#es6-features)
10. [Promises & Async/Await](#promises--asyncawait)
11. [DOM Manipulation](#dom-manipulation)
12. [Event Listeners](#event-listeners)
13. [Fetch API](#fetch-api)
14. [Modules](#modules)

## Variables
Variables store data values and can be declared using `let`, `const`, or `var`.
```js
let x = 10;   // Block-scoped variable
const y = 20; // Constant variable
var z = 30;   // Function-scoped variable (not recommended)
```

## Data Types
JavaScript has different data types including numbers, strings, booleans, arrays, and objects.
```js
let num = 42;        // Number
let str = "Hello";   // String
let bool = true;     // Boolean
let arr = [1, 2, 3]; // Array
let obj = { name: "Alice", age: 25 }; // Object
let und;             // Undefined
let n = null;        // Null
```

## Operators
Operators perform operations on variables and values.
```js
let sum = 5 + 3;   // Addition
let diff = 5 - 3;  // Subtraction
let prod = 5 * 3;  // Multiplication
let div = 5 / 3;   // Division
let mod = 5 % 3;   // Modulus
let exp = 5 ** 3;  // Exponentiation
```

## Conditional Statements
Conditional statements execute code blocks based on conditions.
```js
if (x > 10) {
  console.log("x is greater than 10");
} else if (x === 10) {
  console.log("x is 10");
} else {
  console.log("x is less than 10");
}
```

## Loops
Loops execute a block of code multiple times.
```js
// For loop
for (let i = 0; i < 5; i++) {
  console.log(i);
}

// While loop
let i = 0;
while (i < 5) {
  console.log(i);
  i++;
}

// Do-While loop
let j = 0;
do {
  console.log(j);
  j++;
} while (j < 5);
```

## Functions
Functions are reusable blocks of code that perform specific tasks.
```js
// Function declaration
function greet(name) {
  return `Hello, ${name}!`;
}

// Function expression
const greetUser = function(name) {
  return `Hello, ${name}!`;
};

// Arrow function
const greetArrow = (name) => `Hello, ${name}!`;
```

## Objects
Objects store key-value pairs and methods.
```js
const person = {
  name: "Alice",
  age: 25,
  greet: function() {
    console.log(`Hello, my name is ${this.name}`);
  }
};
```

## Arrays
Arrays store multiple values in a single variable.
```js
let numbers = [1, 2, 3, 4, 5];
numbers.push(6);      // Add to end
numbers.pop();        // Remove from end
numbers.shift();      // Remove from start
numbers.unshift(0);   // Add to start
let sliced = numbers.slice(1, 3); // Get sub-array
```

## ES6 Features
Modern JavaScript features introduced in ES6.
```js
// Template literals
let greeting = `Hello, ${name}!`;

// Destructuring
const { name, age } = person;
const [first, second] = numbers;

// Spread Operator
const newArray = [...numbers, 6, 7, 8];
const newPerson = { ...person, city: "New York" };

// Default Parameters
function sayHello(name = "Guest") {
  console.log(`Hello, ${name}!`);
}
```

## Promises & Async/Await
Handle asynchronous operations efficiently.
```js
// Creating a Promise
const fetchData = new Promise((resolve, reject) => {
  setTimeout(() => resolve("Data loaded"), 2000);
});

// Consuming a Promise
fetchData.then(data => console.log(data)).catch(err => console.log(err));

// Async/Await
async function getData() {
  try {
    let response = await fetchData;
    console.log(response);
  } catch (error) {
    console.log(error);
  }
}
getData();
```

## DOM Manipulation
Interact with and modify HTML elements dynamically.
```js
let element = document.getElementById("myElement");
let elements = document.querySelectorAll(".myClass");
element.textContent = "New text";
element.style.color = "blue";
```

## Event Listeners
Listen for and respond to user interactions.
```js
document.getElementById("btn").addEventListener("click", () => {
  console.log("Button clicked!");
});
```

## Fetch API
Retrieve data from an external source asynchronously.
```js
fetch("https://api.example.com/data")
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.log(error));
```

## Modules
Organize JavaScript code into reusable pieces.
```js
// Exporting a function
export function sayHello(name) {
  return `Hello, ${name}!`;
}

// Importing a function
import { sayHello } from "./module.js";
```
