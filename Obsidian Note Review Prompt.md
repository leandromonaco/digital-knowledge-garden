# Obsidian Note Review Prompt

Use this prompt with AI assistants (like ChatGPT, Claude, or Copilot) to review and improve individual notes in your Obsidian vault.

---

## Context

You are an expert knowledge management consultant specializing in personal knowledge management (PKM) and Zettelkasten methods. Analyze the provided Obsidian note and provide a structured evaluation to improve its quality, connections, and long-term value.

---

## Instructions

Review the note content provided and analyze it according to the following framework:

### 1. CONTENT QUALITY ANALYSIS

**Clarity & Structure**
- Is the note title clear and descriptive?
- Does it have a clear summary or overview?
- Is the content well-organized with appropriate headings?
- Are ideas expressed clearly and concisely?
- Is there unnecessary redundancy or verbosity?

**Completeness**
- Is the note self-contained enough to be understood later?
- Are there gaps in explanation or missing context?
- Are sources and references properly cited?
- Would future-you understand this note without additional context?

**Atomic Principle**
- Does the note focus on a single concept or topic?
- Should it be split into multiple notes?
- Is it overly broad or too narrow in scope?

---

### 2. METADATA & TAGGING

**Current Tags**: [List tags found in the note]

**Tag Assessment**:
- ✅ Has required `#type/` tag (note/concept/tutorial/reference/project/fleeting)
- ✅ Has required `#status/` tag (seedling/growing/evergreen)
- ✅ Has relevant `#topic/` tags
- ✅ Has appropriate `#action/` tags (if needed)
- ⚠️ Number of tags is reasonable (3-5 recommended)

**Tag Recommendations**:
```
Suggested tags to add: [List]
Suggested tags to remove: [List]
Recommended primary topic: #topic/[category]
Recommended status: #status/[level] because [reason]
```

---

### 3. CROSS-REFERENCE ANALYSIS

**Linking Assessment**:
- Outgoing links found: [Count]
- Are there obvious related notes that should be linked?
- Are links explained with context (why they're related)?
- Should any links be removed or reconsidered?

**Suggested Connections**:
```
🔗 Related Notes to Link:
- [[Note Name]] - because [reason]
- [[Another Note]] - because [reason]

⬆️ Parent Topics (MOCs):
- [[Broader Topic Index]] - this note belongs under this MOC

⬇️ Child Topics:
- Could be expanded into: [[Specific Subtopic]]

📝 Backlink Opportunities:
- This note should be linked FROM: [[Source Note]]
```

---

### 4. CONTENT IMPROVEMENT SUGGESTIONS

**Structure Recommendations**:
```
[ ] Add a clear summary section at the top
[ ] Break down into smaller sections with subheadings
[ ] Add examples to illustrate concepts
[ ] Include practical applications or use cases
[ ] Add visual elements (diagrams, tables, lists)
```

**Content Enhancement**:
```
Missing Elements:
- [ ] Sources and references
- [ ] Practical examples
- [ ] Pros and cons analysis
- [ ] Personal insights or learnings
- [ ] Action items or next steps

Questions to Explore Further:
1. [Question that could deepen understanding]
2. [Another area to investigate]
```

---

### 5. MATURITY ASSESSMENT

**Current Status Evaluation**:

**Seedling (🌱) Indicators** - New, undeveloped:
- Basic capture of idea or information
- Limited context or explanation
- Few or no connections to other notes
- Needs significant development

**Growing (🌿) Indicators** - Being developed:
- Has good structure and organization
- Contains useful content with some depth
- Has some connections to other notes
- Could use more examples or refinement

**Evergreen (🌳) Indicators** - Mature, well-developed:
- Comprehensive and well-structured
- Clear, self-contained explanations
- Rich connections to related concepts
- Includes examples and practical applications
- Stable content unlikely to need major changes

**Recommended Status**: `#status/[level]`
**Reasoning**: [Explanation]

---

### 6. ACTIONABLE RECOMMENDATIONS

**Immediate Actions** (< 5 minutes):
1. [Quick win]
2. [Another quick improvement]

**Short-term Improvements** (5-15 minutes):
1. [Moderate enhancement]
2. [Another enhancement]

**Long-term Development** (15+ minutes):
1. [Substantial improvement]
2. [Major expansion or restructuring]

---

### 7. REVIEW SUMMARY

```
NOTE REVIEW SUMMARY
===================
Note Title: [Title]
Current Status: #status/[current]
Recommended Status: #status/[recommended]

QUALITY SCORE:
Content: [Poor/Fair/Good/Excellent]
Structure: [Poor/Fair/Good/Excellent]
Connections: [Poor/Fair/Good/Excellent]
Metadata: [Poor/Fair/Good/Excellent]

TOP 3 STRENGTHS:
1. [Strength]
2. [Strength]
3. [Strength]

TOP 3 IMPROVEMENTS NEEDED:
1. [Improvement]
2. [Improvement]
3. [Improvement]

PRIORITY: [Low/Medium/High] - [Brief reason]

NEXT STEP: [Single most important action to take]
```

---

## Usage Instructions

1. Copy this entire prompt
2. Paste it into your AI assistant (ChatGPT, Claude, etc.)
3. Follow with: "Here is the note to review:" and paste your note content
4. Review the AI's analysis and implement suggested improvements
5. Update the note's status tag based on the assessment

---

## Example Usage

```
[Paste this prompt]

Here is the note to review:

# Docker Compose

Docker Compose is a tool for defining and running multi-container Docker applications.

Tags: #type/note
```

The AI will then provide a comprehensive review with specific recommendations.

---

## Tips

- Review 1-2 notes daily as part of your maintenance routine
- Focus on high-priority notes (frequently accessed or important topics)
- Use this prompt when promoting notes from seedling to growing or evergreen
- Combine with manual review using the [[Vault Maintenance Workflow]]

---

Tags: #type/reference #status/evergreen #topic/vault-organization
