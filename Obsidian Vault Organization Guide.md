# Obsidian Vault Organization Guide

Welcome to the Digital Knowledge Garden organization guide. This document provides a complete system for maintaining a well-structured, discoverable, and valuable knowledge vault.

---

## 📚 Quick Start

### Today
1. Install **Tag Wrangler** and **Broken Links** plugins
2. Review the [[Tag Taxonomy]] to understand the tagging system
3. Run a broken links check and fix 3-5 links

### This Week
1. Read through this guide completely
2. Apply the [[Note Template]] to 3-5 existing notes
3. Add proper tags to 10 notes following [[Tag Taxonomy]]
4. Review and update one MOC (Map of Content)

### Ongoing
1. Use [[Note Template]] for all new notes
2. Follow [[Vault Maintenance Workflow]] weekly
3. Install additional [[Recommended Plugins]] as needed
4. Review [[Tag Taxonomy]] monthly and adjust as needed

---

## 🏗️ Core Organization System

### 1. File Structure
The vault uses a hierarchical folder structure:

```
/
├── Index.md (Main entry point)
├── articles/
│   ├── Engineering Management/
│   ├── Software Engineering/
│   ├── Tools/
│   ├── How-to/
│   └── cheatsheets/
├── projects/
├── books/
├── papers/
├── images/
└── [Organization files]
    ├── Tag Taxonomy.md
    ├── Note Template.md
    ├── Vault Maintenance Workflow.md
    └── Recommended Plugins.md
```

### 2. Tagging System
See [[Tag Taxonomy]] for the complete system.

**Quick Reference**:
- **Type tags**: `#type/note`, `#type/concept`, `#type/tutorial`, `#type/reference`, `#type/project`, `#type/fleeting`
- **Status tags**: `#status/seedling` 🌱, `#status/growing` 🌿, `#status/evergreen` 🌳
- **Topic tags**: Nested by domain (e.g., `#topic/software-engineering/dotnet`)
- **Action tags**: `#action/todo`, `#action/review`, `#action/archive`

**Tagging Rules**:
1. Every note gets at least 1 `#type/` and 1 `#status/` tag
2. Use nested tags for specificity
3. Limit to 3-5 tags per note
4. Place tags at the bottom of the note

### 3. Cross-Reference System
Build meaningful connections between notes using:

| Method | Syntax | When to Use | Example |
|--------|--------|-------------|---------|
| **Direct Links** | `[[Note]]` | Specific related concept | `[[Docker Compose]]` |
| **MOCs** | `[[Topic/Index]]` | Index notes for broad topics | `[[Software Engineering/Cloud/AWS/Index]]` |
| **Block References** | `[[Note^block]]` | Link to specific paragraphs | `[[API Design^rest-definition]]` |
| **Embeds** | `![[Note]]` | Pull content into current note | `![[Code Snippet]]` |

---

## 🔄 Maintenance Workflow

### Automated Checks
The repository includes a [[GitHub Actions Guide|GitHub Action]] that automatically:
- Checks for broken links on every push
- Validates vault health metrics
- Comments on PRs if issues are found
- See [[GitHub Actions Guide]] for details

### Weekly (15-20 minutes)
Follow the [[Vault Maintenance Workflow]] checklist:
- [ ] Process seedling notes
- [ ] Review action items
- [ ] Check for orphan notes
- [ ] Run dead link check
- [ ] Merge duplicate notes
- [ ] Promote 2-3 notes to evergreen

### Monthly (30-45 minutes)
- [ ] Review and update MOCs
- [ ] Tag audit and cleanup
- [ ] Review fleeting notes
- [ ] Update cross-references
- [ ] Backup verification

---

## 📝 Creating New Notes

### Use the Note Template
Always start with [[Note Template]] which includes:

1. **Summary**: 2-3 sentence overview
2. **Content**: Main information
3. **Related Notes**: Cross-references with explanations
4. **Sources**: References and links
5. **Parent Topics**: Higher-level concepts (MOCs)
6. **Child Topics**: More specific subtopics
7. **Tags**: Proper categorization

### Example Note Structure

```markdown
# Docker Compose

### Summary
Docker Compose is a tool for defining and running multi-container Docker applications using YAML configuration files.

### Content
[Main content here...]

### 🔗 Related Notes
- [[Docker CLI]] - Command-line interface for Docker
- [[DevContainers]] - Development containers configuration

### 📚 Sources
- [Docker Compose Documentation](https://docs.docker.com/compose/)

### ⬆️ Parent Topics
- [[articles/Tools/Docker Desktop]]

### ⬇️ Child Topics
- [Docker Compose networking concepts]
- [Docker Compose volume management]

---
Tags: #type/reference #status/evergreen #topic/tools/docker
```

---

## 🗺️ Maps of Content (MOCs)

### What is a MOC?
A Map of Content is an index note that organizes and links to related notes on a broad topic.

### Existing MOCs
- [[Index]] - Main vault entry point
- [[articles/Software Engineering/Cloud/AWS/Index]] - AWS resources
- [[articles/Software Engineering/Cloud/Azure/Index]] - Azure resources
- [[articles/Software Engineering/Frontend/Index]] - Frontend development
- [[articles/Engineering Management/Goal Setting/Goal Setting - Index]] - Goal setting resources

### Creating a New MOC

```markdown
# [Topic] - Index

## Overview
[Brief description of this topic area]

## Core Concepts
- [[Fundamental Concept 1]]
- [[Fundamental Concept 2]]

## Tutorials & Guides
- [[Step-by-Step Guide 1]]
- [[How-to Guide 2]]

## Reference Materials
- [[Cheatsheet 1]]
- [[Quick Reference 2]]

## Related Topics
- [[Related Topic MOC 1]]
- [[Related Topic MOC 2]]

---
Tags: #type/reference #status/evergreen #topic/[your-topic]
```

---

## 🔍 Finding Information

### By Tag
Use tag search to find notes by category:
- `tag:#type/tutorial` - All tutorials
- `tag:#status/seedling` - New ideas to develop
- `tag:#topic/software-engineering/dotnet` - .NET related notes

### By Link
Use backlinks to see:
- What notes link to the current note
- Unlinked mentions of the current note

### By Search
- Use Cmd/Ctrl + O for quick note switching
- Use Cmd/Ctrl + Shift + F for full-text search

### Using Dataview (if installed)
```dataview
LIST
FROM #type/tutorial
WHERE contains(file.tags, "#topic/tools")
SORT file.mtime DESC
LIMIT 10
```

---

## 🛠️ Essential Tools

### Required Plugins
Install these first (see [[Recommended Plugins]]):
1. **Tag Wrangler** - Manage tags efficiently
2. **Broken Links** - Find and fix dead links
3. **Dataview** - Query notes dynamically
4. **Linter** - Enforce consistent formatting

### Already Installed ✅
- Table of Contents
- Table Editor
- Obsidian Git (for backup)
- Webpage HTML Export

---

## 📊 Vault Health Metrics

Track these metrics monthly:

| Metric | Target | Status |
|--------|--------|--------|
| Broken Links | 0 | 🔴 Needs fixing |
| Orphan Notes | < 5% | ⚠️ Check Graph View |
| Seedling Notes | < 20% | ℹ️ Monitor |
| Notes with Tags | 100% | ⚠️ Add tags |
| Avg Links/Note | > 3 | ℹ️ Add cross-refs |

---

## 🎯 Best Practices

### Linking
1. **Link early, link often**: Create links as you write
2. **Use descriptive context**: Explain why notes are connected
3. **Create bidirectional links**: Link back to important references
4. **Update MOCs**: Keep index notes current

### Tagging
1. **Be consistent**: Follow [[Tag Taxonomy]]
2. **Start broad, get specific**: Use nested tags
3. **Avoid tag bloat**: Limit to 3-5 tags per note
4. **Review regularly**: Clean up tags monthly

### Note-Taking
1. **Write for your future self**: Assume you'll forget context
2. **Add sources**: Always cite references
3. **Keep it atomic**: One concept per note when possible
4. **Regular review**: Update notes as you learn more

### Maintenance
1. **Weekly routine**: Follow [[Vault Maintenance Workflow]]
2. **Process fleeting notes**: Don't let quick captures accumulate
3. **Promote quality notes**: Move growing notes to evergreen status
4. **Clean up**: Delete notes that are no longer valuable

---

## 🚀 Next Steps

### Immediate Actions
1. [ ] Install Tag Wrangler and Broken Links plugins
2. [ ] Run broken links check and create fix list
3. [ ] Read [[Tag Taxonomy]] thoroughly
4. [ ] Bookmark [[Vault Maintenance Workflow]] for weekly use

### This Week
1. [ ] Fix all identified broken links
2. [ ] Add tags to 20 existing notes
3. [ ] Apply [[Note Template]] to 5 important notes
4. [ ] Update [[Index]] to link to organization guides

### This Month
1. [ ] Apply [[Note Template]] to all frequently-accessed notes
2. [ ] Complete tag migration to new taxonomy
3. [ ] Update all MOCs with recent notes
4. [ ] Install and configure additional [[Recommended Plugins]]

---

## 📖 Related Documentation

- [[Tag Taxonomy]] - Complete tagging system
- [[Note Template]] - Template for new notes
- [[Vault Maintenance Workflow]] - Regular maintenance tasks
- [[Recommended Plugins]] - Plugin installation guide

---

## 📝 Feedback & Iteration

This organization system should evolve with your needs:
- Review this guide quarterly
- Adjust [[Tag Taxonomy]] based on usage patterns
- Update [[Note Template]] based on what works
- Modify [[Vault Maintenance Workflow]] to fit your schedule

---

Tags: #type/reference #status/evergreen #topic/vault-organization
