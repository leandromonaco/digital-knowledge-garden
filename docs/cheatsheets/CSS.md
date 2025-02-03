## Table of Contents

1. [Introduction](#introduction)  
2. [CSS Syntax & Selectors](#css-syntax--selectors)  
3. [Box Model](#box-model)  
4. [Basic Layout](#basic-layout)  
5. [Text & Fonts](#text--fonts)  
6. [Intermediate Layout & Techniques](#intermediate-layout--techniques)  
   - [Flexbox](#flexbox)  
   - [CSS Grid](#css-grid)  
   - [Pseudo-classes & Pseudo-elements](#pseudo-classes--pseudo-elements)  
   - [Responsive Design](#responsive-design)  
7. [Advanced/Dynamic CSS](#advanceddynamic-css)  
   - [CSS Variables](#css-variables)  
   - [Transitions & Animations](#transitions--animations)  
   - [Transforms](#transforms)  
   - [Advanced Selectors](#advanced-selectors)  
   - [CSS Preprocessors](#css-preprocessors-optional)  
   - [Performance & Best Practices](#performance--best-practices)  
8. [Best Practices & Common Pitfalls](#best-practices--common-pitfalls)  
9. [Resources](#resources)

---

## 1. Introduction

**CSS (Cascading Style Sheets)** is used to style and layout HTML documents. With CSS, you control:

- **Colors** and **fonts**  
- **Layout** (e.g., grid, flexbox)  
- **Responsive design** for different devices  
- **Animations** and **transitions**  
- **Dynamic styling** (using variables, transitions, or preprocessor tools)

### Why CSS Is Important

- Separates **content** (HTML) from **presentation** (style).
- Enhances user experience with intuitive and responsive layouts.
- Provides consistent styling across large projects.

---

## 2. CSS Syntax & Selectors

### Basic Syntax

```css
selector {
  property: value;
  /* Example:
  background-color: #fafafa;
  */
}
````

- **Selectors**: Determine which elements the rules apply to (e.g., `p`, `.class`, `#id`).
- **Properties**: Control the style aspects (e.g., `color`, `margin`, `padding`).

### Common Selectors

1. **Element Selector**
    
    ```css
    p {
      font-size: 16px;
    }
    ```
    
2. **Class Selector**
    
    ```css
    .highlight {
      background-color: yellow;
    }
    ```
    
3. **ID Selector**
    
    ```css
    #unique-title {
      color: red;
    }
    ```
    
4. **Combinators**
    - **Descendant**: `div p` (all `p` inside `div`)
    - **Child**: `ul > li` (direct children)
    - **Adjacent Sibling**: `h2 + p` (the first `p` after `h2`)
    - **General Sibling**: `h2 ~ p` (all `p` siblings after `h2`)

### Specificity

- **Inline styles** (highest specificity)
- **ID selectors** (`#id`)
- **Class selectors** (`.class`), pseudo-classes
- **Element selectors** (`p`, `h1`)
- **Universal selector** (`*`), inherited styles (lowest specificity)

A higher specificity rule overrides a lower specificity rule if they conflict.

---

## 3. Box Model

Every element in CSS is represented as a **box** comprising:

1. **Content**: The content area (e.g., text, images).
2. **Padding**: Space between content and border.
3. **Border**: Surrounds padding and content.
4. **Margin**: Space outside the border.

```css
.box {
  width: 200px;
  padding: 10px;
  border: 2px solid #ccc;
  margin: 20px;
  box-sizing: border-box; /* Ensures width includes padding & border */
}
```

- **`box-sizing: content-box`** (default) => total width = width + padding + border
- **`box-sizing: border-box`** => total width = width (including padding & border)

---

## 4. Basic Layout

### Display Property

- **`display: block;`** Element takes full width.
- **`display: inline;`** Element lays out inline, without a line break.
- **`display: inline-block;`** Like inline, but can set width/height.
- **`display: none;`** Hides the element (not rendered).

### Float

_(Older technique, less commonly used with modern flexbox and grid)_

```css
.image-left {
  float: left;
  margin-right: 10px;
}
```

### Position

1. **static** (default)
2. **relative**
    
    ```css
    .relative-box {
      position: relative;
      top: 10px; /* Moves 10px down from its normal position */
    }
    ```
    
3. **absolute** (removed from normal flow, positioned relative to nearest positioned ancestor)
4. **fixed** (positioned relative to the viewport)

---

## 5. Text & Fonts

### Font Properties

```css
.text-example {
  font-family: "Arial", sans-serif;
  font-size: 16px;
  line-height: 1.5;
  font-weight: bold; /* normal, bold, 100-900 */
  color: #333;
}
```

### Sizing Units

- **px**: Absolute pixel size.
- **em**: Relative to the parent’s font size.
- **rem**: Relative to the root (html) font size.
- **%**: Percentage of the parent element’s size.

### Text Formatting

```css
.text-center {
  text-align: center;
}
.uppercase {
  text-transform: uppercase;
}
.underline {
  text-decoration: underline;
}
```

---

## 6. Intermediate Layout & Techniques

### Flexbox

A modern way to create layouts. Define a **flex container**:

```css
.container {
  display: flex;
  flex-direction: row; /* row | column */
  justify-content: center; /* flex-start, center, space-between, etc. */
  align-items: center;     /* stretch, center, flex-start, etc. */
}
```

Then child items:

```css
.item {
  flex: 1; /* grows to fill space */
}
```

**Key Properties**

- **Container**: `flex-direction`, `justify-content`, `align-items`, `flex-wrap`
- **Items**: `flex`, `align-self`, `order`

### CSS Grid

Powerful 2D layout system:

```css
.grid-container {
  display: grid;
  grid-template-columns: 1fr 2fr; /* Two columns: one fraction, two fractions */
  grid-gap: 20px;
}
.grid-item {
  background: #f0f0f0;
  padding: 10px;
}
```

**Key Properties**

- `grid-template-rows`, `grid-template-columns`
- `grid-gap` or `row-gap` / `column-gap`
- `grid-area`, `grid-template-areas`

### Pseudo-classes & Pseudo-elements

- **Pseudo-classes**: `:hover`, `:active`, `:focus`, `:nth-child()`
    
    ```css
    a:hover {
      color: red;
    }
    li:nth-child(2) {
      background: yellow;
    }
    ```
    
- **Pseudo-elements**: `::before`, `::after`
    
    ```css
    .box::before {
      content: "Prefix - ";
      color: blue;
    }
    ```
    

### Responsive Design

Use **media queries** to adapt layouts across screen sizes:

```css
@media (max-width: 600px) {
  .container {
    flex-direction: column;
  }
}
```

**Mobile-first approach**:

- Design for small screens first, then add media queries for larger screens.

---

## 7. Advanced/Dynamic CSS

### CSS Variables

Define variables in a rule (often `:root` for global scope), then use `var()`:

```css
:root {
  --main-color: #3498db;
  --padding-size: 10px;
}

.dynamic-box {
  background-color: var(--main-color);
  padding: var(--padding-size);
}
```

- You can override variables in child selectors or media queries.

### Transitions & Animations

#### Transitions

Smoothly change property values over time:

```css
.button {
  background-color: #3498db;
  transition: background-color 0.3s ease;
}
.button:hover {
  background-color: #2980b9;
}
```

#### Animations

Use `@keyframes` to define animation steps:

```css
@keyframes pulse {
  0% {
    transform: scale(1);
    background-color: #3498db;
  }
  50% {
    transform: scale(1.1);
    background-color: #ff3333;
  }
  100% {
    transform: scale(1);
    background-color: #3498db;
  }
}

.animated-box {
  animation: pulse 2s infinite;
}
```

### Transforms

```css
.transform-box {
  transform: translate(50px, 0) rotate(15deg) scale(1.2);
  transition: transform 0.5s ease;
}
.transform-box:hover {
  transform: translate(0, 0) rotate(0deg) scale(1);
}
```

### Advanced Selectors

- **Attribute Selector**
    
    ```css
    input[type="text"] {
      border: 1px solid #ccc;
    }
    ```
    
- **`:not()`**
    
    ```css
    /* Style all <button> except those with .primary class */
    button:not(.primary) {
      background: #eee;
    }
    ```
    
- **`:nth-last-child()`, `:nth-of-type()`, etc.** for advanced patterns.

### CSS Preprocessors (Optional)

- **SASS/SCSS** or **LESS** let you use variables, nesting, mixins, and functions:
    
    ```scss
    $main-color: #3498db;
    .box {
      background-color: $main-color;
      &:hover {
        background-color: lighten($main-color, 10%);
      }
    }
    ```
    

Compile SCSS to regular CSS for browser usage.

### Performance & Best Practices

- **Minimize reflows**: Avoid heavy layout changes in quick succession (e.g., repeated DOM changes).
- Use **hardware acceleration** for animations with `transform: translateZ(0)` if needed.
- Keep CSS rules short, and **organize** them logically (e.g., by sections or components).

---

## 8. Best Practices & Common Pitfalls

1. **Misuse of Float**: Floats used for layout can be brittle. Prefer Flexbox or Grid.
2. **Specificity Wars**: Overusing `!important` or IDs can cause conflicts. Use classes and a strategy (like BEM) for naming.
3. **Large Unorganized CSS Files**: Split into multiple files (or partials with preprocessor) for maintainability.
4. **Hard-Coding Values**: Use relative units (`em`, `rem`, `%`) and CSS variables for consistency.
5. **Naming Conventions**:
    - **BEM (Block, Element, Modifier)**: `block__element--modifier`
    - OOCSS, SMACSS, etc.
6. **DRY Principle**: Don’t repeat yourself. Reuse classes, leverage variables, and mixins (with preprocessors).

---

## 9. Resources

- **MDN Web Docs** (Mozilla)  
    [https://developer.mozilla.org/en-US/docs/Web/CSS](https://developer.mozilla.org/en-US/docs/Web/CSS)
    
- **W3C CSS Specifications**  
    [https://www.w3.org/Style/CSS/](https://www.w3.org/Style/CSS/)
    
- **CSS Tricks**  
    [https://css-tricks.com/](https://css-tricks.com/)  
    Articles and detailed explanations of various CSS features.
    
- **Can I Use**  
    [https://caniuse.com/](https://caniuse.com/)  
    Check browser support for CSS features.
    
- **Sass Official Site**  
    [https://sass-lang.com/](https://sass-lang.com/)