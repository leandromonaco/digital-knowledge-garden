This cheat sheet provides a quick reference for commonly used HTML elements, attributes, and best practices. HTML (HyperText Markup Language) is the foundation of web development.

## Table of Contents
1. [Basic Structure](#basic-structure)
2. [Headings](#headings)
3. [Paragraphs & Text Formatting](#paragraphs--text-formatting)
4. [Lists](#lists)
5. [Links](#links)
6. [Images](#images)
7. [Tables](#tables)
8. [Forms](#forms)
9. [Buttons](#buttons)
10. [Semantic Elements](#semantic-elements)
11. [Audio & Video](#audio--video)
12. [Meta Tags](#meta-tags)
13. [Comments](#comments)

## Basic Structure
The basic structure of an HTML document.
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document Title</title>
</head>
<body>
    <h1>Welcome to HTML</h1>
</body>
</html>
```

## Headings
HTML provides six levels of headings.
```html
<h1>Main Heading</h1>
<h2>Subheading</h2>
<h3>Sub-subheading</h3>
<h4>...</h4>
<h5>...</h5>
<h6>...</h6>
```

## Paragraphs & Text Formatting
```html
<p>This is a paragraph.</p>
<strong>Bold text</strong>
<em>Italic text</em>
<u>Underlined text</u>
<del>Strikethrough</del>
```

## Lists
### Ordered List
```html
<ol>
    <li>Item 1</li>
    <li>Item 2</li>
</ol>
```
### Unordered List
```html
<ul>
    <li>Item A</li>
    <li>Item B</li>
</ul>
```

## Links
```html
<a href="https://example.com">Visit Example</a>
<a href="#section">Jump to Section</a>
```

## Images
```html
<img src="image.jpg" alt="Description" width="300">
```

## Tables
```html
<table>
    <tr>
        <th>Name</th>
        <th>Age</th>
    </tr>
    <tr>
        <td>Alice</td>
        <td>25</td>
    </tr>
</table>
```

## Forms
```html
<form action="/submit" method="post">
    <label for="name">Name:</label>
    <input type="text" id="name" name="name" required>
    <input type="submit" value="Submit">
</form>
```

## Buttons
```html
<button>Click Me</button>
```

## Semantic Elements
```html
<header>Header Content</header>
<nav>Navigation Menu</nav>
<main>Main Content</main>
<footer>Footer Content</footer>
```

## Audio & Video
```html
<audio controls>
    <source src="audio.mp3" type="audio/mpeg">
</audio>

<video controls width="400">
    <source src="video.mp4" type="video/mp4">
</video>
```

## Meta Tags
```html
<meta name="description" content="This is a sample webpage">
<meta name="keywords" content="HTML, CSS, JavaScript">
```

## Comments
```html
<!-- This is a comment -->
```
