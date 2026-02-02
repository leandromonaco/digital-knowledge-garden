# Recommended Obsidian Plugins

This document lists recommended plugins for maintaining and organizing the Digital Knowledge Garden.

---

## Essential Plugins

### 1. Dataview
**Purpose**: Query and display notes by tags, metadata, and other properties

**Use Cases**:
- Create dynamic lists of notes by tag
- Build custom dashboards showing note statistics
- Auto-generate lists of related notes

**Example Query**:
```dataview
TABLE status, tags
FROM #type/tutorial
WHERE status = "growing"
SORT file.mtime DESC
```

**Installation**: `obsidian://show-plugin?id=dataview`

---

### 2. Tag Wrangler
**Purpose**: Rename, merge, and manage tags across the entire vault

**Use Cases**:
- Rename tags globally (e.g., `#DotNet` → `#topic/software-engineering/dotnet`)
- Merge duplicate tags
- See tag hierarchy in the sidebar

**Installation**: Search for "Tag Wrangler" in Community Plugins

---

### 3. Broken Links
**Purpose**: Find and fix dead internal links

**Use Cases**:
- Scan vault for links to non-existent notes
- Identify renamed files that broke existing links
- Find typos in link names

**Installation**: Search for "Broken Links" or "Link Checker" in Community Plugins

---

### 4. Obsidian Git
**Purpose**: Automated Git backup and version control

**Use Cases**:
- Automatic commits at regular intervals
- Push changes to GitHub
- Version history for all notes

**Configuration**:
- Auto-commit interval: 30 minutes
- Auto-push interval: 1 hour
- .gitignore configured to exclude workspace files

**Installation**: `obsidian://show-plugin?id=obsidian-git`

**Status**: ✅ Already installed

---

### 5. Webpage HTML Export
**Purpose**: Export vault to static HTML for GitHub Pages

**Use Cases**:
- Generate website from vault
- Share knowledge publicly
- Create searchable documentation

**Installation**: `obsidian://show-plugin?id=webpage-html-export`

**Status**: ✅ Already installed

---

## Recommended Plugins

### 6. Linter
**Purpose**: Enforce consistent formatting across all notes

**Use Cases**:
- Standardize heading formats
- Ensure consistent spacing
- Auto-format YAML frontmatter
- Enforce tag placement

**Configuration Recommendations**:
- Format tags at bottom of notes
- Consistent heading capitalization
- Remove trailing whitespace

**Installation**: Search for "Linter" in Community Plugins

---

### 7. Graph Analysis
**Purpose**: Find weakly connected notes and improve vault structure

**Use Cases**:
- Identify orphan notes
- Find notes with few connections
- Suggest potential links between notes

**Installation**: Search for "Graph Analysis" in Community Plugins

---

### 8. Table of Contents (TOC)
**Purpose**: Generate table of contents for long notes

**Installation**: `obsidian://show-plugin?id=obsidian-plugin-toc`

**Status**: ✅ Already installed

---

### 9. Table Editor
**Purpose**: Improve markdown table editing experience

**Installation**: `obsidian://show-plugin?id=table-editor-obsidian`

**Status**: ✅ Already installed

---

## Optional Advanced Plugins

### 10. Templater
**Purpose**: Advanced template support with variables and scripts

**Use Cases**:
- Auto-populate note metadata
- Create dynamic templates
- Auto-generate file names

---

### 11. Kanban
**Purpose**: Create Kanban boards for task management

**Use Cases**:
- Track note development status
- Manage article writing pipeline
- Organize learning goals

---

### 12. Excalidraw
**Purpose**: Draw diagrams directly in Obsidian

**Use Cases**:
- Create architecture diagrams
- Sketch concepts
- Visual note-taking

---

## Installation Guide

### For Essential Plugins:

1. Open Obsidian Settings (Ctrl/Cmd + ,)
2. Navigate to "Community plugins"
3. Click "Browse" 
4. Search for plugin name
5. Click "Install"
6. Enable the plugin

### Plugin Priority Order

Install plugins in this order for best results:

1. **Week 1**: Tag Wrangler + Broken Links
   - Focus: Fix existing organizational issues

2. **Week 2**: Dataview + Linter
   - Focus: Add structure and consistency

3. **Week 3**: Graph Analysis
   - Focus: Improve connections

4. **Later**: Advanced plugins as needed

---

## Plugin Configuration Tips

### Dataview
- Enable JavaScript queries for advanced features
- Enable inline queries

### Obsidian Git
- Set up .gitignore to exclude `.obsidian/workspace.json`
- Configure commit message template
- Enable auto-pull before push

### Linter
- Enable "Remove trailing whitespace"
- Configure tag format (bottom of note)
- Set heading format preferences

---

## Current Plugin Status

### Already Installed ✅
1. obsidian-plugin-toc
2. table-editor-obsidian
3. obsidian-git
4. webpage-html-export

### Recommended to Install 📥
1. Dataview
2. Tag Wrangler
3. Broken Links
4. Linter
5. Graph Analysis

---

## Maintenance

- Review plugin updates monthly
- Disable unused plugins to improve performance
- Check plugin compatibility after Obsidian updates

---

Tags: #type/reference #status/evergreen #topic/vault-organization #topic/tools
