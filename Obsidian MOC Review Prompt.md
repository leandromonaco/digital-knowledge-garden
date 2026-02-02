# Obsidian MOC Review Prompt

Use this prompt with AI assistants to review and optimize your Maps of Content (MOCs) - the index notes that organize and link related content in your vault.

---

## Context

You are an expert in information architecture and knowledge management. Analyze the provided Map of Content (MOC) note and evaluate its effectiveness as a navigation hub and organizational tool within the Obsidian vault.

---

## What is a MOC?

A **Map of Content (MOC)** is an index note that:
- Serves as a central hub for a specific topic or domain
- Organizes and links to related notes
- Provides structure and navigation
- Helps discover connections between ideas
- Acts as an entry point to explore a subject

Examples: `Cloud Computing MOC`, `Project Management Index`, `Python Programming Hub`

---

## Instructions

Review the MOC provided and analyze according to the following framework:

### 1. MOC PURPOSE & SCOPE

**Clarity Assessment**:
- Is the MOC's purpose immediately clear from the title and description?
- Is the scope well-defined (not too broad or too narrow)?
- Does it have a clear audience or use case?

**Scope Evaluation**:
```
Current Scope: [Description]

✅ Appropriate scope because: [Reason]
OR
⚠️ Scope issues:
- [ ] Too broad - should be split into: [Suggestions]
- [ ] Too narrow - could be merged with: [Other MOC]
- [ ] Overlaps with: [Other MOC] - needs clarification
```

---

### 2. STRUCTURE & ORGANIZATION

**Current Organization Pattern**:
```
Analyze the structure:
- [ ] Flat list of links
- [ ] Grouped by categories/sections
- [ ] Hierarchical (with sub-MOCs)
- [ ] Timeline/sequential
- [ ] Alphabetical
- [ ] By importance/priority
- [ ] Mixed/unclear pattern
```

**Structural Assessment**:
```
STRENGTHS:
- [What works well in the organization]
- [Another strength]

WEAKNESSES:
- [Organizational issue]
- [Another issue]

RECOMMENDED STRUCTURE:
[Provide an improved outline/hierarchy]

Example:
## Core Concepts
- [[Concept 1]]
- [[Concept 2]]

## Practical Guides
- [[Tutorial 1]]
- [[Tutorial 2]]

## Reference Materials
- [[Cheatsheet 1]]
- [[Reference 1]]

## Related MOCs
- [[Parent MOC]]
- [[Related MOC]]
```

---

### 3. COVERAGE ANALYSIS

**Content Coverage**:
```
Essential topics covered:
✅ [Topic] - [[Note Name]]
✅ [Topic] - [[Note Name]]

Missing topics that should be included:
❌ [Topic] - Needs creation or linking
❌ [Topic] - Exists but not linked: [[Note Name]]

Questionable inclusions (may not belong):
⚠️ [[Note Name]] - Might be better in [[Other MOC]]
```

**Completeness Score**: [0-100]
**Gap Analysis**: [What's missing and why it matters]

---

### 4. LINK QUALITY ASSESSMENT

**Link Analysis**:
```
Total links in MOC: [X]
Links with context/description: [X]
Bare links (no context): [X]

Link Quality Issues:
- [ ] Too many bare links (unclear why they're related)
- [ ] Missing descriptions (what each link contains)
- [ ] No prioritization (all links equal weight)
- [ ] Broken links
- [ ] Outdated links (point to old/superseded notes)
```

**Link Enhancement Recommendations**:
```
Upgrade links from:
- [[Note Name]]

To:
- [[Note Name]] - Brief description of what this covers and why it's here

Examples:
❌ - [[Docker Compose]]
✅ - [[Docker Compose]] - Define multi-container applications with YAML
```

---

### 5. NAVIGATION & USABILITY

**User Experience**:
```
Ease of Navigation: [Poor/Fair/Good/Excellent]

Navigation Strengths:
- [What makes it easy to use]

Navigation Issues:
- [ ] Too long (overwhelming)
- [ ] Too short (insufficient guidance)
- [ ] No clear entry points for beginners
- [ ] Missing "see also" or related MOCs
- [ ] No visual hierarchy (everything looks the same)
- [ ] Difficult to find specific content
```

**Improvement Suggestions**:
```
Quick Wins:
1. [Simple improvement]
2. [Another simple fix]

Structural Improvements:
1. [Moderate change]
2. [Another enhancement]

Advanced Enhancements:
1. [Significant improvement]
2. [Major restructuring]
```

---

### 6. METADATA & CONNECTIONS

**MOC Metadata**:
```
Current Metadata:
- Title: [Title]
- Tags: [List current tags]
- Parent MOC: [If applicable]
- Child MOCs: [If applicable]
- Last updated: [Date if available]

Recommended Metadata:
Title: [Suggested improvement if needed]
Tags: #type/reference #status/[level] #topic/[category]
Parent MOC: [[Broader MOC]] - Links upward
Child MOCs: [[Specific Sub-MOC]] - Links downward
Related MOCs: [[Adjacent MOC]] - Links sideways
```

**Hierarchical Positioning**:
```
Position in vault hierarchy:
Level: [Top-level / Mid-level / Specialized]

Connections:
⬆️ Should link UP to: [[Parent MOC]]
⬇️ Should link DOWN to: [[Child MOC 1]], [[Child MOC 2]]
↔️ Should link ACROSS to: [[Related MOC 1]], [[Related MOC 2]]

Current issues:
- [ ] Orphaned (no parent MOC)
- [ ] No clear hierarchy
- [ ] Missing peer MOCs
```

---

### 7. CONTENT TYPES BALANCE

**Content Type Distribution**:
```
Analyze what types of notes are linked:

Concepts/Definitions: [X] notes ([X]%)
Tutorials/How-tos: [X] notes ([X]%)
Reference/Cheatsheets: [X] notes ([X]%)
Examples/Case Studies: [X] notes ([X]%)
Projects: [X] notes ([X]%)
Other MOCs: [X] notes ([X]%)

Balance Assessment:
- [ ] Good mix of content types
- [ ] Too heavy on [type] - needs more [type]
- [ ] Missing practical applications
- [ ] Missing conceptual foundations
```

**Recommended Balance**:
```
For this topic, ideal distribution:
- [X]% Core concepts
- [X]% Practical guides
- [X]% Reference materials
- [X]% Examples
- [X]% Sub-MOCs

Action items:
- Create: [X] notes of type [type]
- Link existing: [X] notes of type [type]
```

---

### 8. DISCOVERY & EXPLORATION

**Pathways Assessment**:
```
Learning paths visible:
- [ ] Beginner → Intermediate → Advanced progression
- [ ] Problem → Solution pathways
- [ ] Theory → Practice connections
- [ ] Related concepts clearly linked

Discovery features:
- [ ] "Start here" guidance for newcomers
- [ ] Highlighted key/essential notes
- [ ] "Deep dive" paths for experts
- [ ] Cross-references to related domains
```

**Exploration Enhancements**:
```
Add sections:
- [ ] 🌱 Start Here - For beginners to this topic
- [ ] ⭐ Essential Reading - Must-know notes
- [ ] 🔧 Practical Projects - Hands-on applications
- [ ] 📚 Further Reading - Advanced/adjacent topics
- [ ] 🔗 Related Areas - Connected MOCs
```

---

### 9. MAINTENANCE & SUSTAINABILITY

**MOC Health**:
```
Maintenance indicators:
- Last updated: [Date]
- Activity level: [High/Medium/Low]
- Growth trajectory: [Growing/Stable/Stagnant]

Health issues:
- [ ] Outdated (needs review)
- [ ] Missing recent notes
- [ ] Contains dead links
- [ ] Structure needs refreshing
- [ ] Too manual to maintain
```

**Automation Opportunities**:
```
Consider automating with Dataview:

Current manual links:
[List of sections that could be automated]

Suggested Dataview queries:
```dataview
LIST
FROM #topic/[category]
WHERE status = "evergreen"
SORT file.name ASC
\```

Benefits:
- Auto-includes new notes with correct tags
- Always up to date
- Reduces manual maintenance
```

---

### 10. MOC REVIEW SUMMARY

```
MOC REVIEW SUMMARY
==================
MOC Name: [Name]
Topic Coverage: [Poor/Fair/Good/Excellent]
Organization: [Poor/Fair/Good/Excellent]
Navigation: [Poor/Fair/Good/Excellent]
Completeness: [X]/100

STATUS ASSESSMENT:
Current: #status/[current]
Recommended: #status/[recommended]
Reasoning: [Brief explanation]

TOP 3 STRENGTHS:
1. [Strength]
2. [Strength]
3. [Strength]

TOP 3 IMPROVEMENTS NEEDED:
1. [Critical improvement]
2. [Important enhancement]
3. [Nice to have]

PRIORITY: [Low/Medium/High/Critical]
Reasoning: [Why this priority level]

IMMEDIATE ACTIONS:
1. [Most important next step] - [5/15/30 min]
2. [Second priority] - [5/15/30 min]
3. [Third priority] - [5/15/30 min]

NEXT REVIEW DATE: [Suggested date based on activity]
```

---

## Usage Instructions

### Step 1: Identify MOC to Review

Review MOCs that are:
- Frequently used (high-traffic hubs)
- Recently created (ensure good structure early)
- Growing rapidly (may need reorganization)
- Stagnant (may need revitalization)
- Problematic (user feedback or confusion)

### Step 2: Gather Context

Before review:
- Note the MOC's current state
- List all linked notes
- Identify parent/child/peer MOCs
- Note recent changes or additions

### Step 3: Use the Prompt

1. Copy this entire prompt
2. Paste into your AI assistant
3. Follow with: "Here is the MOC to review:" and paste the MOC content
4. Review the detailed analysis
5. Implement recommendations

### Step 4: Iterate

After implementing changes:
- Use the prompt again to verify improvements
- Compare before/after structure
- Get feedback from users (if collaborative vault)

---

## MOC Review Schedule

**Frequency recommendations**:
- **Weekly**: Active MOCs (frequently updated)
- **Monthly**: Stable MOCs (mature, occasional changes)
- **Quarterly**: Archive MOCs (historical, rarely updated)
- **Ad-hoc**: When adding 5+ new notes to a topic area

---

## Example Usage

```
[Paste this prompt]

Here is the MOC to review:

# Cloud Computing MOC

Overview of cloud computing resources and technologies.

## Services
- [[AWS]]
- [[Azure]]
- [[GCP]]

## Concepts
- [[IaaS]]
- [[PaaS]]
- [[SaaS]]

Tags: #type/reference
```

The AI will provide comprehensive analysis and specific recommendations.

---

## MOC Templates

After review, consider using these templates:

**Simple MOC Template**:
```markdown
# [Topic] MOC

## Overview
[Brief description of this topic area]

## Core Concepts
- [[Concept 1]] - Description
- [[Concept 2]] - Description

## Guides & Tutorials
- [[Guide 1]] - Description
- [[Tutorial 1]] - Description

## Reference
- [[Cheatsheet]] - Description
- [[Quick Reference]] - Description

## Related
- [[Parent MOC]] (broader)
- [[Related MOC]] (adjacent)

---
Tags: #type/reference #status/evergreen #topic/[category]
```

**Advanced MOC Template**:
```markdown
# [Topic] MOC

> [One-line overview of this knowledge area]

## 🌱 Start Here
New to this topic? Begin with these:
- [[Introduction to Topic]]
- [[Key Concepts Overview]]

## 📚 Core Knowledge

### Fundamentals
- [[Fundamental Concept 1]]
- [[Fundamental Concept 2]]

### Advanced Concepts
- [[Advanced Topic 1]]
- [[Advanced Topic 2]]

## 🔧 Practical Applications
- [[Tutorial 1]]
- [[Project Example]]
- [[Use Case]]

## 📖 Reference Materials
- [[Cheatsheet]]
- [[Quick Reference]]
- [[Best Practices]]

## 🗺️ Related Areas
- [[Parent MOC]] ⬆️ (broader context)
- [[Related MOC 1]] ↔️ (adjacent topic)
- [[Child MOC]] ⬇️ (specific subtopic)

## 📊 Statistics
- Total notes: `= length(filter([[#topic/your-topic]]))` (Dataview)
- Last updated: [Date]

---
Tags: #type/reference #status/evergreen #topic/[category]
```

---

## Related Resources

- [[Vault Maintenance Workflow]] - Regular MOC review schedule
- [[Obsidian Note Review Prompt]] - Individual note review
- [[Obsidian Vault Health Review Prompt]] - Vault-wide analysis
- [[Note Template]] - Template for new notes

---

Tags: #type/reference #status/evergreen #topic/vault-organization
