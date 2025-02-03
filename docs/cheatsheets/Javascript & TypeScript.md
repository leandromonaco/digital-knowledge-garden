## Table of Contents

1. [Introduction](#introduction)  
2. [Variables & Data Types](#variables--data-types)  
3. [Operators, Conditionals & Loops](#operators-conditionals--loops)  
4. [Functions](#functions)  
5. [Objects](#objects)  
6. [Arrays](#arrays)  
7. [Classes (ES6+)](#classes-es6)  
8. [Modules](#modules)  
9. [Asynchronous JavaScript](#asynchronous-javascript)  
    - [Callbacks](#callbacks)  
    - [Promises](#promises)  
    - [Async/Await](#asyncawait)  
10. [Error Handling](#error-handling)  
11. [Advanced Topics](#advanced-topics)  
    - [Generators](#generators)  
    - [Proxies & Reflect](#proxies--reflect)  
    - [Decorators (ES Proposal)](#decorators-es-proposal)  
12. [TypeScript Comparison](#typescript-comparison)  
13. [Best Practices & Common Pitfalls](#best-practices--common-pitfalls)  
14. [Resources](#resources)

---

## 1. Introduction

JavaScript (JS) is a dynamic, prototype-based language primarily used for web development. Over the years, the language has evolved significantly, and modern ECMAScript (ES) standards have introduced powerful features such as **arrow functions**, **classes**, **modules**, and **async/await**.

### JavaScript vs. TypeScript

**TypeScript (TS)** is a superset of JavaScript that adds optional static typing and additional tooling benefits. TypeScript code compiles down to JavaScript, meaning all JavaScript is valid TypeScript, but not vice versa.

- **Advantages of TypeScript**:  
  - Catches errors at compile-time instead of runtime.  
  - Enforces type consistency, improving code readability and maintainability.  
  - Provides powerful features like interfaces, generics, and decorators.

- **Drawbacks**:
  - Requires a compilation step and extra tooling.  
  - Slightly steeper learning curve due to the type system.

---

## 2. Variables & Data Types

### Declaring Variables

- **`var`**: Function-scoped, can be redeclared, hoisted to the top of the scope.
- **`let`**: Block-scoped, cannot be redeclared within the same block.
- **`const`**: Block-scoped, read-only references (the value itself can still be mutable if it’s an object).

```js
var x = 10;
let y = 20;
const z = 30;
```

> **Best Practice**: Use `let` for variables that change values and `const` for variables that should not be reassigned.

### Data Types

JavaScript has **seven** primitive data types:
1. **String**  
2. **Number**  
3. **Boolean**  
4. **Null**  
5. **Undefined**  
6. **Symbol** (ES6)  
7. **BigInt** (ES2020)

```js
let str = "Hello World"; // String
let num = 42;           // Number
let bool = true;        // Boolean
let n = null;           // Null
let u;                  // Undefined
let sym = Symbol("id"); // Symbol
let big = 123n;         // BigInt
```

**Type Coercion**: JavaScript automatically converts data types in certain operations, e.g. `"5" * 2` => `10`.

#### TypeScript Example

```ts
let strTS: string = "Hello TypeScript";
let numTS: number = 100;
let boolTS: boolean = false;

// strTS = 123; // Error: Type 'number' is not assignable to type 'string'
```

> In TypeScript, you explicitly declare variable types, catching errors at compile time.

---

## 3. Operators, Conditionals & Loops

### Operators

- **Arithmetic**: `+`, `-`, `*`, `/`, `%`, `**` (exponent)
- **Assignment**: `=`, `+=`, `-=`, `*=`, `/=`, `%=`
- **Comparison**: `==`, `===` (strict equality), `!=`, `!==`, `>`, `<`, `>=`, `<=`
- **Logical**: `&&`, `||`, `!`
- **Ternary**: `condition ? valueIfTrue : valueIfFalse`

```js
let a = 10;
let b = 20;

console.log(a + b);        // 30
console.log(a === b);      // false
```

### Conditionals

```js
if (a > b) {
  console.log("a is greater");
} else if (a === b) {
  console.log("a equals b");
} else {
  console.log("b is greater");
}

// Switch statement
switch (a) {
  case 10:
    console.log("Value is 10");
    break;
  default:
    console.log("Value is something else");
    break;
}
```

### Loops

1. **`for` Loop**  
2. **`while` Loop**  
3. **`do...while` Loop**  
4. **`for...in`** (iterate over object properties)  
5. **`for...of`** (iterate over iterable objects like arrays or strings, ES6+)

```js
// for loop
for (let i = 0; i < 5; i++) {
  console.log(i);
}

// for...in
const obj = { name: "Alice", age: 25 };
for (let key in obj) {
  console.log(key, obj[key]);
}

// for...of
const arr = [10, 20, 30];
for (let value of arr) {
  console.log(value);
}
```

---

## 4. Functions

### Function Declarations & Expressions

```js
// Function declaration
function greet(name) {
  return `Hello, ${name}!`;
}

// Function expression
const greetExpression = function (name) {
  return `Hi, ${name}!`;
};

// Call the functions
console.log(greet("Alice"));            // "Hello, Alice!"
console.log(greetExpression("Bob"));    // "Hi, Bob!"
```

### Arrow Functions (ES6+)

- Lexical `this` binding (no own `this` context).
- Concise syntax.

```js
const add = (x, y) => x + y;
console.log(add(2, 3)); // 5

const sayHello = name => {
  console.log(`Hello, ${name}`);
};
sayHello("Charlie"); // "Hello, Charlie"
```

### Default Parameters & Rest/Spread

```js
function multiply(a, b = 1) {
  return a * b;
}

function sum(...numbers) {
  return numbers.reduce((acc, curr) => acc + curr, 0);
}

const arr1 = [1, 2];
const arr2 = [3, 4];
const combined = [...arr1, ...arr2]; // [1,2,3,4]
```

### Closures

A closure gives access to an outer function’s scope from an inner function, even after the outer function has returned.

```js
function makeCounter() {
  let count = 0;
  return function() {
    count++;
    return count;
  };
}

const counter1 = makeCounter();
console.log(counter1()); // 1
console.log(counter1()); // 2
```

#### TypeScript Example

```ts
function greetTS(name: string): string {
  return `Hello, ${name}!`;
}

const greetArrowTS = (name: string): string => `Hi, ${name}!`;
```

---

## 5. Objects

### Object Literals

```js
const person = {
  name: "Alice",
  age: 25,
  greet: function () {
    console.log(`Hello, I'm ${this.name}`);
  },
};

person.greet(); // "Hello, I'm Alice"
```

### Prototypes

JavaScript uses prototypal inheritance rather than classical inheritance. Objects can inherit properties from a prototype object.

```js
function Animal(name) {
  this.name = name;
}

Animal.prototype.speak = function () {
  console.log(`${this.name} makes a noise`);
};

const dog = new Animal("Buddy");
dog.speak(); // "Buddy makes a noise"
```

### Object Destructuring & Spread (ES6+)

```js
const { name, age } = person; // destructuring
const anotherPerson = { ...person, location: "USA" }; // spread
```

#### TypeScript Interfaces

```ts
interface Person {
  name: string;
  age: number;
}

const bob: Person = {
  name: "Bob",
  age: 30,
};
```

---

## 6. Arrays

### Creating & Accessing Arrays

```js
const nums = [1, 2, 3];
console.log(nums[0]); // 1
```

### Common Array Methods

- **`push()`/`pop()`**: Add/remove from the end  
- **`shift()`/`unshift()`**: Remove/add from the beginning  
- **`slice()`**: Returns a shallow copy of a portion  
- **`splice()`**: Adds or removes elements  
- **`map()`**, **`filter()`**, **`reduce()`**: Functional programming helpers  

```js
const arr = [1, 2, 3, 4];
const doubled = arr.map(x => x * 2);              // [2,4,6,8]
const even = arr.filter(x => x % 2 === 0);       // [2,4]
const sum = arr.reduce((acc, val) => acc + val, 0); // 10
```

#### TypeScript Array Example

```ts
let numArray: number[] = [1, 2, 3];
numArray.push(4); // OK
// numArray.push("5"); // Error in TS
```

---

## 7. Classes (ES6+)

JavaScript introduced class syntax in ES6 as syntactic sugar over prototypes.

```js
class Person {
  constructor(name, age) {
    this.name = name;
    this.age = age;
  }

  greet() {
    console.log(`Hi, I'm ${this.name}, and I'm ${this.age} years old.`);
  }
}

const alice = new Person("Alice", 25);
alice.greet(); // "Hi, I'm Alice, and I'm 25 years old."
```

### Inheritance

```js
class Student extends Person {
  constructor(name, age, grade) {
    super(name, age);
    this.grade = grade;
  }

  study() {
    console.log(`${this.name} is studying in grade ${this.grade}.`);
  }
}

const bob = new Student("Bob", 16, 10);
bob.greet(); // inherits from Person
bob.study(); // "Bob is studying in grade 10."
```

#### TypeScript Class Example

```ts
class PersonTS {
  name: string;
  age: number;

  constructor(name: string, age: number) {
    this.name = name;
    this.age = age;
  }

  greet(): void {
    console.log(`Hi, I'm ${this.name}.`);
  }
}
```

---

## 8. Modules

JavaScript modules allow you to split code into reusable pieces.

### ES6 Modules

- **`import`** and **`export`** keywords.
- Works natively in modern browsers (with `type="module"` in script tags) and is commonly used in build systems (Webpack, Parcel, etc.).

```js
// math.js
export function add(a, b) {
  return a + b;
}

// main.js
import { add } from "./math.js";
console.log(add(2, 3)); // 5
```

### CommonJS (Node.js)

Uses `require` and `module.exports`:

```js
// math.js
module.exports = function add(a, b) {
  return a + b;
};

// main.js
const add = require("./math");
console.log(add(2, 3)); // 5
```

#### TypeScript Modules

- TypeScript also uses ES6 import/export syntax.
- Declarations are type-checked.

```ts
// math.ts
export function addTS(a: number, b: number): number {
  return a + b;
}

// main.ts
import { addTS } from "./math";
console.log(addTS(2, 3)); // 5
```

---

## 9. Asynchronous JavaScript

### 9.1 Callbacks

Classic approach for async operations, can lead to "callback hell."

```js
function fetchData(callback) {
  setTimeout(() => {
    callback("Data fetched");
  }, 1000);
}

fetchData(data => {
  console.log(data); // "Data fetched"
});
```

### 9.2 Promises

Introduced in ES6 to handle async operations more cleanly.

```js
function fetchDataPromise() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Data fetched");
    }, 1000);
  });
}

fetchDataPromise()
  .then(result => {
    console.log(result);
  })
  .catch(error => {
    console.error(error);
  });
```

### 9.3 Async/Await (ES8)

Built on Promises, allows writing async code in a synchronous style.

```js
async function fetchDataAsync() {
  try {
    const data = await fetchDataPromise();
    console.log(data);
  } catch (error) {
    console.error(error);
  }
}

fetchDataAsync(); // "Data fetched"
```

#### TypeScript Example

```ts
async function fetchDataTS(): Promise<string> {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Data fetched from TS");
    }, 1000);
  });
}

async function main() {
  try {
    const data = await fetchDataTS();
    console.log(data);
  } catch (error) {
    console.error(error);
  }
}
```

---

## 10. Error Handling

Use `try...catch` blocks to handle exceptions.

```js
try {
  throw new Error("Something went wrong!");
} catch (error) {
  console.error(error.message);
} finally {
  console.log("Cleanup operations if needed.");
}
```

In modern JS, you can also use `try...catch` without an explicit error parameter in some contexts (ES10+), but it’s less common.

---

## 11. Advanced Topics

### 11.1 Generators

Generators are functions that can be paused and resumed, returning an iterator.

```js
function* idGenerator() {
  let id = 0;
  while (true) {
    yield id++;
  }
}

const gen = idGenerator();
console.log(gen.next().value); // 0
console.log(gen.next().value); // 1
```

### 11.2 Proxies & Reflect

- **Proxies** let you intercept operations on objects (get, set, etc.).
- **Reflect** provides methods for interceptable JavaScript operations.

```js
const target = {};
const handler = {
  get: (obj, prop) => {
    console.log(`Accessing ${prop}`);
    return Reflect.get(obj, prop);
  },
};
const proxy = new Proxy(target, handler);

proxy.test = 123;
console.log(proxy.test);
```

### 11.3 Decorators (ES Proposal)

Decorators are a stage-2 ECMAScript proposal. TypeScript supports them under `"experimentalDecorators": true`.

```ts
function Log(target: any, propertyKey: string, descriptor: PropertyDescriptor) {
  const original = descriptor.value;
  descriptor.value = function (...args: any[]) {
    console.log(`Called ${propertyKey} with `, args);
    return original.apply(this, args);
  };
}

class ExampleTS {
  @Log
  sayHello(name: string) {
    console.log(`Hello, ${name}`);
  }
}
```

---

## 12. TypeScript Comparison

### Key Differences

1. **Static vs. Dynamic**:  
   - JavaScript is dynamically typed, types are checked at runtime.  
   - TypeScript is statically typed, catching errors at compile time.

2. **Tooling**:  
   - JS can run anywhere (browser, Node).  
   - TS requires a compiler (`tsc`), can integrate with Babel, Webpack, etc.

3. **Interfaces & Generics**:
   - Not available in plain JS.  
   - TS offers powerful abstractions for type-checking.

4. **Use Cases**:
   - **JavaScript**: Quick prototyping, smaller scripts, or where a compile step isn’t needed.  
   - **TypeScript**: Large-scale applications, complex codebases, teams needing robust tooling and maintainability.

---

## 13. Best Practices & Common Pitfalls

1. **Use `const` and `let` instead of `var`** to avoid hoisting issues.  
2. **Strict Equality**: Prefer `===` over `==` to avoid type coercion.  
3. **Avoid Polluting the Global Scope**: Use modules or IIFEs (Immediately Invoked Function Expressions).  
4. **Linting**: Use tools like ESLint or TSLint to enforce style and catch errors early.  
5. **Babel & Polyfills**: For older browsers, transpile modern JS.  
6. **Performance**: Minimize DOM manipulation, use efficient data structures, and consider using `requestAnimationFrame` for animations.  
7. **Async Error Handling**: Always handle promise rejections (`.catch()` or `try/catch` in async functions).  
8. **Using TypeScript**:  
   - Keep your type definitions up-to-date.  
   - Enable strict mode in `tsconfig.json` for safer defaults.

---

## 14. Resources

- **MDN Web Docs**: [JavaScript Reference](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference)  
- **ECMAScript Specification**: [TC39 Proposals](https://github.com/tc39/proposals)  
- **TypeScript Documentation**: [Official TS Docs](https://www.typescriptlang.org/docs/)  
- **Node.js**: [Node.js Official](https://nodejs.org/)  
- **Bundlers**: [Webpack](https://webpack.js.org/), [Parcel](https://parceljs.org/), [Vite](https://vitejs.dev/)
