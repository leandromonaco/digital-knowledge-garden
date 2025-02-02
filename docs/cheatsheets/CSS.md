This cheat sheet provides a quick reference for commonly used CSS properties, selectors, and best practices. CSS (Cascading Style Sheets) is used to style and layout web pages.

## Table of Contents
1. [Basic Syntax](#basic-syntax)
2. [Selectors](#selectors)
3. [Box Model](#box-model)
4. [Positioning](#positioning)
5. [Flexbox](#flexbox)
6. [Grid](#grid)
7. [Typography](#typography)
8. [Colors & Backgrounds](#colors--backgrounds)
9. [Borders & Shadows](#borders--shadows)
10. [Transitions & Animations](#transitions--animations)
11. [Media Queries](#media-queries)
12. [Pseudo-classes & Pseudo-elements](#pseudo-classes--pseudo-elements)

## Basic Syntax
CSS consists of selectors and declaration blocks.
```css
selector {
    property: value;
}
```

## Selectors
```css
/* Element Selector */
p { color: blue; }

/* Class Selector */
.my-class { font-size: 16px; }

/* ID Selector */
#my-id { background-color: yellow; }

/* Grouping Selectors */
h1, h2, h3 { margin: 10px; }
```

## Box Model
```css
.box {
    width: 200px;
    height: 100px;
    padding: 10px;
    border: 2px solid black;
    margin: 20px;
}
```

## Positioning
```css
.static { position: static; }
.relative { position: relative; top: 10px; left: 10px; }
.absolute { position: absolute; top: 50px; left: 50px; }
.fixed { position: fixed; bottom: 0; right: 0; }
.sticky { position: sticky; top: 0; }
```

## Flexbox
```css
.flex-container {
    display: flex;
    justify-content: center;
    align-items: center;
}
```

## Grid
```css
.grid-container {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    gap: 10px;
}
```

## Typography
```css
body {
    font-family: Arial, sans-serif;
    font-size: 16px;
    line-height: 1.5;
}
```

## Colors & Backgrounds
```css
.bg-example {
    background-color: lightblue;
    background-image: url('image.jpg');
    background-size: cover;
}
```

## Borders & Shadows
```css
.border-example {
    border: 2px solid black;
    border-radius: 10px;
    box-shadow: 2px 2px 5px gray;
}
```

## Transitions & Animations
```css
/* Transition */
.button {
    transition: background-color 0.3s ease;
}
.button:hover {
    background-color: red;
}

/* Animation */
@keyframes move {
    0% { transform: translateX(0); }
    100% { transform: translateX(100px); }
}
.animated {
    animation: move 2s infinite alternate;
}
```

## Media Queries
```css
@media (max-width: 768px) {
    body {
        background-color: lightgray;
    }
}
```

## Pseudo-classes & Pseudo-elements
```css
/* Pseudo-class */
button:hover {
    background-color: blue;
}

/* Pseudo-element */
p::first-letter {
    font-size: 2em;
    color: red;
}
```