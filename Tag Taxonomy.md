# Tag Taxonomy

This document defines the standardized tagging system for organizing notes in the Digital Knowledge Garden.

## Tag Hierarchy Structure

### By Content Type
- `#type/note` - General notes and observations
- `#type/concept` - Core concepts to understand
- `#type/tutorial` - Step-by-step guides and how-tos
- `#type/reference` - Quick lookup information and cheatsheets
- `#type/project` - Project-related notes and documentation
- `#type/fleeting` - Quick captures to process later

### By Status
- `#status/seedling` 🌱 - New, undeveloped ideas
- `#status/growing` 🌿 - Being actively developed
- `#status/evergreen` 🌳 - Mature, well-developed notes

### By Topic
Use nested tags for specificity:

#### Software Engineering
- `#topic/software-engineering`
- `#topic/software-engineering/dotnet`
- `#topic/software-engineering/frontend`
- `#topic/software-engineering/cloud`
- `#topic/software-engineering/cloud/aws`
- `#topic/software-engineering/cloud/azure`
- `#topic/software-engineering/devops`

#### Engineering Management
- `#topic/engineering-management`
- `#topic/engineering-management/hiring`
- `#topic/engineering-management/goal-setting`
- `#topic/engineering-management/team-playbook`

#### Tools
- `#topic/tools`
- `#topic/tools/git`
- `#topic/tools/docker`
- `#topic/tools/vscode`

### By Action
- `#action/todo` - Needs work or completion
- `#action/review` - Needs review or validation
- `#action/archive` - Ready to archive

## Tagging Rules

1. **Every note gets at least 1 `#type/` and 1 `#status/` tag**
   - This ensures consistent classification across the vault

2. **Use nested tags for specificity**
   - Example: `#topic/software-engineering/dotnet` instead of just `#dotnet`
   - This allows for better filtering and organization

3. **Limit to 3-5 tags per note**
   - Avoid tag bloat
   - Focus on the most relevant tags

4. **Place tags at the bottom of the note**
   - Consistent location makes them easy to find
   - Format: `Tags: #tag1 #tag2 #tag3`

## Examples

### Example 1: Tutorial Note
```markdown
# How to Deploy with Docker

[Content...]

---
Tags: #type/tutorial #status/evergreen #topic/tools/docker
```

### Example 2: Concept Note
```markdown
# Microservices Architecture

[Content...]

---
Tags: #type/concept #status/growing #topic/software-engineering #topic/software-engineering/cloud
```

### Example 3: Reference Note
```markdown
# Git Cheatsheet

[Content...]

---
Tags: #type/reference #status/evergreen #topic/tools/git
```

## Maintenance

- Review tags during weekly vault maintenance
- Use Tag Wrangler plugin to rename or merge tags
- Keep this taxonomy document updated as new categories emerge
