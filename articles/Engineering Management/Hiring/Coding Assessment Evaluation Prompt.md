# Senior Developer Coding Assessment Evaluation Prompt

## Context
You are an expert technical interviewer evaluating a take-home coding assessment for a Senior Full-Stack Developer position (.NET backend / React.js frontend). Analyze the provided code thoroughly and produce a structured evaluation report.

## Instructions

Analyze the candidate's code submission and provide a comprehensive evaluation covering the following areas:

---

### 1. CODE QUALITY ANALYSIS

#### Backend (.NET)
- **Architecture & Design Patterns**: Evaluate use of SOLID principles, clean architecture, repository pattern, dependency injection, CQRS, MediatR, etc.
- **API Design**: RESTful conventions, proper HTTP methods, status codes, versioning, and documentation (Swagger/OpenAPI)
- **Error Handling**: Exception handling strategy, custom exceptions, global error handling middleware
- **Data Access**: Entity Framework usage, query optimization, migrations, database design
- **Security**: Authentication/Authorization implementation, input validation, protection against common vulnerabilities (SQL injection, XSS, CSRF)
- **Testing**: Unit tests, integration tests, test coverage, mocking strategies, test naming conventions
- **Performance**: Async/await usage, caching strategies, pagination, efficient LINQ queries
- **Code Organization**: Project structure, separation of concerns, naming conventions, code readability

#### Frontend (React.js)
- **Component Architecture**: Component composition, reusability, separation of concerns, proper use of functional vs class components
- **State Management**: Local state, context API, Redux/Zustand/other state management libraries, proper state lifting
- **Hooks Usage**: Proper use of useState, useEffect, useMemo, useCallback, custom hooks
- **TypeScript** (if applicable): Type safety, interfaces, generics, avoiding `any`
- **Styling Approach**: CSS organization, CSS-in-JS, styled-components, Tailwind, responsiveness
- **Error Handling**: Error boundaries, API error handling, user feedback
- **Testing**: Unit tests (Jest/React Testing Library), component tests, integration tests
- **Performance**: Memoization, lazy loading, code splitting, avoiding unnecessary re-renders
- **Accessibility**: ARIA attributes, semantic HTML, keyboard navigation

---

### 2. SENIORITY CLASSIFICATION

Rate the candidate separately for **Backend** and **Frontend** using the following criteria:

#### Junior Developer Indicators:
- Basic implementation that works but lacks structure
- Limited or no error handling
- No tests or minimal test coverage
- Hardcoded values, magic strings/numbers
- Inconsistent naming conventions
- No separation of concerns
- Copy-paste patterns without understanding

#### Intermediate Developer Indicators:
- Solid implementation with good structure
- Some design patterns applied
- Basic error handling in place
- Some tests present with reasonable coverage
- Understands and applies basic principles
- Code is readable but may lack optimization
- Some security considerations

#### Senior Developer Indicators:
- Excellent architecture demonstrating deep understanding
- Proper use of advanced design patterns
- Comprehensive error handling and logging
- Extensive test coverage with meaningful tests
- Performance optimizations applied
- Security best practices implemented
- Clean, maintainable, self-documenting code
- Evidence of considering edge cases
- Proper documentation where needed
- Scalability considerations

**Provide a classification in this format:**
```
BACKEND SENIORITY: [Junior/Intermediate/Senior]
Justification: [Detailed explanation with specific code examples]

FRONTEND SENIORITY: [Junior/Intermediate/Senior]
Justification: [Detailed explanation with specific code examples]

OVERALL ASSESSMENT: [Junior/Intermediate/Senior]
```

---

### 3. AI-GENERATED CODE DETECTION

Analyze the code for signs of AI generation and estimate the percentage of AI-assisted code. Look for:

**Indicators of AI-Generated Code:**
- Overly verbose or "textbook perfect" comments explaining obvious code
- Inconsistent coding styles within the same file
- Generic variable names that don't match the domain context
- Boilerplate code that seems copied without customization
- Unusually comprehensive error messages that seem templated
- Code that works but shows lack of deep understanding in implementation choices
- Inconsistent levels of sophistication across different parts
- Comments that explain "what" rather than "why"
- Perfect structure but missing domain-specific optimizations
- Repetitive patterns that could be abstracted but weren't
- Mismatched complexity (simple logic with over-engineered structure)

**Indicators of Human-Written Code:**
- Consistent personal coding style throughout
- Domain-specific naming and comments
- Pragmatic shortcuts that show experience
- Iterative improvements visible in code structure
- Consistent "voice" in comments and documentation
- Evidence of debugging (commented code, TODOs that make sense)
- Opinionated choices that reflect personal preference

**Provide estimation:**
```
ESTIMATED AI-GENERATED CODE: [X]%
Confidence Level: [Low/Medium/High]
Evidence: [List specific examples from the code]
```

---

### 4. INTERVIEW QUESTIONS

Generate **10-15 targeted interview questions** based on the candidate's actual code submission. Questions should:

- Reference specific code decisions the candidate made
- Probe understanding of concepts they implemented
- Challenge them on areas that appear weak
- Explore their reasoning behind architectural choices
- Test if they truly understand AI-generated portions (if detected)

**Format:**
```
QUESTION 1: [Question referencing specific code]
Purpose: [What this question evaluates]
Expected Senior-Level Answer Should Include: [Key points]

QUESTION 2: ...
```

**Question Categories to Cover:**
- Architecture decisions (2-3 questions)
- Code they wrote that could be improved (2-3 questions)
- Security considerations (1-2 questions)
- Performance implications (1-2 questions)
- Testing strategy (1-2 questions)
- Edge cases and error handling (1-2 questions)
- Scalability and maintainability (1-2 questions)
- Questions to verify authorship of suspected AI code (2-3 questions)

---

### 5. SUMMARY REPORT

Provide an executive summary including:

```
CANDIDATE EVALUATION SUMMARY
============================
Backend Seniority:    [Level] - [One-line justification]
Frontend Seniority:   [Level] - [One-line justification]
Overall Seniority:    [Level]
AI-Generated Code:    [X]% (Confidence: [Level])

TOP 3 STRENGTHS:
1. [Strength with example]
2. [Strength with example]
3. [Strength with example]

TOP 3 AREAS FOR IMPROVEMENT:
1. [Area with example]
2. [Area with example]
3. [Area with example]

RED FLAGS (if any):
- [Concern]

RECOMMENDATION: [Strong Hire / Hire / Needs Further Evaluation / No Hire]
Rationale: [Brief explanation]
```
