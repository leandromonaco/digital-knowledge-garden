## Table of Contents

1. [Introduction](#introduction)  
2. [Basic HTML Document Structure](#basic-html-document-structure)  
3. [Basic Tags](#basic-tags)  
4. [Semantic HTML (HTML5)](#semantic-html-html5)  
5. [Forms](#forms)  
6. [Media](#media)  
7. [Tables](#tables)  
8. [Accessibility & Best Practices](#accessibility--best-practices)  
9. [Meta Tags & SEO](#meta-tags--seo)  
10. [Advanced Features](#advanced-features)  
11. [Common Pitfalls](#common-pitfalls)  
12. [Resources](#resources)  

---

## 1. Introduction

- **HyperText Markup Language (HTML)** is the standard markup language for creating web pages.
- Modern HTML has evolved significantly with HTML5 and beyond, introducing **semantic elements**, **multimedia tags**, and improved **form features**.
- Proper HTML is essential for:
  - **SEO** (Search Engine Optimization)
  - **Accessibility** for screen readers and assistive technologies
  - **Maintainability** of large codebases
  - **Collaboration** across teams (front-end, back-end, designers, etc.)

---

## 2. Basic HTML Document Structure

A minimal, valid HTML5 page typically looks like this:

```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>My HTML Page</title>
</head>
<body>
  <h1>Hello, World!</h1>
  <p>This is a basic HTML document.</p>
</body>
</html>
````

### Explanation

- **`<!DOCTYPE html>`**: Informs the browser that this is an HTML5 document.
- **`<html lang="en">`**: Sets the page language to English (helpful for accessibility and SEO).
- **`<head>`**: Contains metadata (e.g., `<meta charset="UTF-8">`) and the page title.
- **`<body>`**: Contains the visible page content.

**Best Practice**: Always declare the `lang` attribute for accessibility and use UTF-8 character encoding (`<meta charset="UTF-8">`).

---

## 3. Basic Tags

HTML offers various basic tags to structure and format your text and images.

### Headings

Use headings to create a hierarchical structure. `<h1>` is the top-level heading, followed by `<h2>`, `<h3>`, and so on.

```html
<h1>Main Title</h1>
<h2>Subheading</h2>
<h3>Sub-subheading</h3>
```

### Paragraphs & Text Formatting

```html
<p>This is a paragraph of text.</p>
<p><strong>Bold text</strong> or <em>italic text</em>.</p>
```

- **`<strong>`** indicates strong emphasis (commonly renders as bold).
- **`<em>`** indicates emphasis (commonly renders as italics).

### Lists

```html
<ul>
  <li>Unordered list item</li>
  <li>Another item</li>
</ul>

<ol>
  <li>Ordered list item</li>
  <li>Another item</li>
</ol>
```

### Links

```html
<a href="https://www.example.com">Visit Example.com</a>
```

- **Target Attribute**:
    
    ```html
    <a href="https://www.example.com" target="_blank">Open in new tab</a>
    ```
    

### Images

```html
<img src="images/photo.jpg" alt="Descriptive text for the image">
```

- **`alt`** provides alternative text for accessibility and SEO.
- **`width`** and **`height`** attributes can control image size, but consider using CSS for styling.

---

## 4. Semantic HTML (HTML5)

HTML5 introduced many **semantic** elements that convey meaning about the content:

```html
<header>
  <h1>Site Header</h1>
</header>

<nav>
  <ul>
    <li><a href="#home">Home</a></li>
    <li><a href="#about">About</a></li>
  </ul>
</nav>

<main>
  <article>
    <h2>Article Title</h2>
    <p>Article content goes here.</p>
  </article>
  <section>
    <h3>Section Title</h3>
    <p>Section content goes here.</p>
  </section>
</main>

<footer>
  <p>Footer Content &copy; 2025</p>
</footer>
```

**Common Semantic Tags**:

- **`<main>`**: Main content of the document (unique, one per page).
- **`<article>`**: Self-contained, independent content (e.g., blog post).
- **`<section>`**: Thematic grouping of content.
- **`<nav>`**: Navigation links.
- **`<header>`**: Introductory content or navigational aids.
- **`<footer>`**: Footer content, author info, legal notes.
- **`<aside>`**: Content indirectly related to the main content (like a sidebar).

---

## 5. Forms

HTML forms allow users to input and submit data.

### Basic Structure

```html
<form action="/submit" method="POST">
  <label for="username">Username:</label>
  <input type="text" id="username" name="username" required>

  <label for="age">Age:</label>
  <input type="number" id="age" name="age">

  <button type="submit">Submit</button>
</form>
```

### Modern Input Types & Attributes

- **HTML5 Input Types**: `email`, `tel`, `url`, `date`, `color`, `range`, etc.
- **Attributes**:
    - `required`: Makes an input mandatory.
    - `placeholder`: Placeholder text in input.
    - `autofocus`: Automatically focuses the field.
    - `pattern`: Regex pattern for validation.

Example with HTML5 features:

```html
<input type="email" name="user_email" placeholder="you@example.com" required>
<input type="date" name="dob" required>
```

### Form Validation

Modern browsers handle basic validation automatically when using HTML5 attributes (`required`, `pattern`, `type="email"`, etc.). JavaScript can further enhance or customize this.

---

## 6. Media

HTML5 makes embedding media straightforward:

### Images

Covered above in [Basic Tags](https://chatgpt.com/c/67a00877-fcf4-8012-8948-3230183047f1#basic-tags).

### Audio

```html
<audio controls>
  <source src="audio/song.mp3" type="audio/mpeg">
  Your browser does not support the audio element.
</audio>
```

### Video

```html
<video controls width="640">
  <source src="video/clip.mp4" type="video/mp4">
  Your browser does not support the video tag.
</video>
```

### Canvas

Used for drawing graphics via JavaScript APIs:

```html
<canvas id="myCanvas" width="400" height="400"></canvas>
```

```js
const canvas = document.getElementById('myCanvas');
const ctx = canvas.getContext('2d');
ctx.fillStyle = 'blue';
ctx.fillRect(20, 20, 100, 100);
```

---

## 7. Tables

Use tables for **tabular data**, not for layout. Properly structured tables help with accessibility.

```html
<table>
  <thead>
    <tr>
      <th>Product</th>
      <th>Price</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Apple</td>
      <td>$1.00</td>
    </tr>
    <tr>
      <td>Banana</td>
      <td>$0.50</td>
    </tr>
  </tbody>
</table>
```

- **`<thead>`**: Table header rows.
- **`<tbody>`**: Table body rows.
- **`<tfoot>`** (optional): Table footer rows.
- **`<th>`**: Table header cell (often bold and centered by default).
- **`<td>`**: Table data cell.

---

## 8. Accessibility & Best Practices

Accessibility ensures your site is usable by everyone, including those with disabilities.

1. **ALT Text** on Images:
    
    ```html
    <img src="logo.png" alt="Company Logo">
    ```
    
2. **Semantic Tags**: Use `<header>`, `<footer>`, `<nav>`, etc., so screen readers understand structure.
3. **ARIA (Accessible Rich Internet Applications)**:
    - E.g., `role="navigation"` for navigation elements if needed.
4. **Heading Hierarchy**: Maintain logical `<h1>` -> `<h2>` -> `<h3>` structure.
5. **Color Contrast**: Ensure text is readable against background.
6. **Keyboard Navigation**: Elements like `<button>` are inherently focusable; custom controls might need `tabindex` and event handlers.

**Performance & Maintainability**:

- Keep markup semantic and minimal.
- Avoid inline styles; use CSS instead.
- Use external scripts for maintainability.

---

## 9. Meta Tags & SEO

Common `<meta>` tags go in the `<head>`:

```html
<meta name="description" content="Page description for search engines">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta name="keywords" content="HTML, cheatsheet, tutorial">
```

- **`<meta charset="UTF-8">`**: Defines character encoding, typically UTF-8.
- **`<meta name="viewport" content="width=device-width, initial-scale=1.0">`**: Ensures responsive design on mobile.
- **SEO**:
    - Descriptive `<title>` tag.
    - Meaningful headings and content structure.
    - Use relevant keywords in natural language, but don’t keyword stuff.

---

## 10. Advanced Features

### `<template>` Element

Holds HTML that is not rendered until activated via JavaScript, useful for client-side templating.

```html
<template id="cardTemplate">
  <div class="card">
    <h2>Title</h2>
    <p>Content goes here.</p>
  </div>
</template>

<script>
  const template = document.querySelector('#cardTemplate');
  const clone = template.content.cloneNode(true);
  document.body.appendChild(clone);
</script>
```

### Microdata & Structured Data

Add metadata to help search engines parse your content:

```html
<div itemscope itemtype="https://schema.org/Person">
  <span itemprop="name">John Doe</span>
  <img itemprop="image" src="john.jpg" alt="John Doe">
</div>
```

### Custom Data Attributes (`data-*`)

Store extra information within elements:

```html
<div id="product" data-product-id="12345" data-category="books">Book Title</div>
```

Accessible via JavaScript:

```js
const product = document.getElementById('product');
console.log(product.dataset.productId); // "12345"
```

### New & Less Common Elements

- **`<dialog>`** (experimental support in some browsers) for modal dialogs.
- **`<picture>`** for responsive images.
- **`<source>`** for `<video>` / `<audio>` / `<picture>`.

---

## 11. Common Pitfalls

1. **Missing Doctype**
    - Omitting `<!DOCTYPE html>` can cause browsers to switch to “quirks mode.”
2. **Improper Nesting**
    - Example: Don’t open `<p>` then open `<div>` without closing `<p>`.
3. **Using Tables for Layout**
    - Modern practice uses CSS and semantic tags for layout, not `<table>`.
4. **Inline vs Block Elements**
    - Inline: `<span>`, `<a>`, `<strong>`
    - Block: `<div>`, `<p>`, `<section>`
    - Mixing them incorrectly can break layout or accessibility.
5. **Forgetting Accessibility**
    - Missing `alt` attributes on images, unclear link text (e.g., “Click here”), etc.
6. **Excessive `<div>` Usage**
    - Use semantic elements `<header>`, `<main>`, `<article>` instead of just `<div>` for everything.

**Performance Tips**:

- Minimize inline JavaScript or CSS; use external files.
- Avoid large, uncompressed images.
- Use HTML validators (like the [W3C Validator](https://validator.w3.org/)) to check for errors.

---

## 12. Resources

- **MDN Web Docs (Mozilla)**  
    [https://developer.mozilla.org/en-US/docs/Web/HTML](https://developer.mozilla.org/en-US/docs/Web/HTML)  
    Comprehensive documentation for HTML elements and features.
    
- **WHATWG HTML Living Standard**  
    [https://html.spec.whatwg.org/](https://html.spec.whatwg.org/)  
    The living standard for the HTML spec.
    
- **W3C Validator**  
    [https://validator.w3.org/](https://validator.w3.org/)  
    Validate your HTML for errors and best practices.
    
- **HTML5 Doctor**  
    [http://html5doctor.com/](http://html5doctor.com/)  
    Articles and tips on HTML5 usage and semantics.
    
