This cheat sheet provides a quick reference for commonly used TypeScript concepts, syntax, and features. TypeScript is a superset of JavaScript that adds static typing and other powerful features.

## Table of Contents
1. [Variables & Types](#variables--types)
2. [Interfaces](#interfaces)
3. [Functions](#functions)
4. [Classes](#classes)
5. [Generics](#generics)
6. [Enums](#enums)
7. [Tuples](#tuples)
8. [Type Assertions](#type-assertions)
9. [Union & Intersection Types](#union--intersection-types)
10. [Modules](#modules)
11. [Promises & Async/Await](#promises--asyncawait)
12. [Decorators](#decorators)

## Variables & Types
TypeScript adds type annotations for better type safety.
```ts
let age: number = 30;
let name: string = "Alice";
let isStudent: boolean = false;
let numbers: number[] = [1, 2, 3];
let person: { name: string; age: number } = { name: "Bob", age: 25 };
```

## Interfaces
Interfaces define the structure of objects.
```ts
interface User {
  name: string;
  age: number;
}

let user: User = { name: "Alice", age: 25 };
```

## Functions
Functions can have typed parameters and return types.
```ts
function greet(name: string): string {
  return `Hello, ${name}!`;
}
```

## Classes
TypeScript supports object-oriented programming with classes.
```ts
class Person {
  constructor(public name: string, private age: number) {}
  greet(): string {
    return `Hello, my name is ${this.name}`;
  }
}
let alice = new Person("Alice", 25);
console.log(alice.greet());
```

## Generics
Generics provide flexibility while maintaining type safety.
```ts
function identity<T>(value: T): T {
  return value;
}
let output = identity<number>(42);
```

## Enums
Enums define a set of named constants.
```ts
enum Color {
  Red,
  Green,
  Blue
}
let color: Color = Color.Green;
```

## Tuples
Tuples allow defining an array with fixed types.
```ts
let tuple: [string, number] = ["Alice", 25];
```

## Type Assertions
Type assertions help override inferred types.
```ts
let someValue: any = "Hello";
let strLength: number = (someValue as string).length;
```

## Union & Intersection Types
Union and intersection types allow more flexible type definitions.
```ts
type Admin = { role: string };
type Employee = { name: string };
type AdminEmployee = Admin & Employee;
let admin: AdminEmployee = { role: "Manager", name: "Alice" };
```

## Modules
TypeScript supports modular programming with import/export syntax.
```ts
// module.ts
export function sayHello(name: string): string {
  return `Hello, ${name}!`;
}

// main.ts
import { sayHello } from "./module";
console.log(sayHello("Alice"));
```

## Promises & Async/Await
Handle asynchronous operations efficiently.
```ts
async function fetchData(): Promise<string> {
  return new Promise((resolve) => setTimeout(() => resolve("Data loaded"), 2000));
}
fetchData().then(data => console.log(data));
```

## Decorators
Decorators add metadata to classes and their members.
```ts
function Log(target: any, propertyKey: string) {
  console.log(`Property ${propertyKey} was accessed`);
}

class Example {
  @Log
  message: string = "Hello";
}
let example = new Example();
console.log(example.message);
