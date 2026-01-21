# 🤖 Obsidian Vault Organizer AI Agent

An intelligent automation tool that keeps your Obsidian vault organized and up to date.

## Features

### 🔍 Automated Checks
- **Merge Conflict Detection**: Identifies files with Git merge conflict markers
- **Link Validation**: Detects broken internal wiki links (e.g., links to non-existent files)
- **Stale Content Detection**: Flags files not updated in over 2 years
- **Duplicate Detection**: Finds files with identical content

### ✨ Metadata Enrichment
Automatically adds YAML frontmatter to files that lack it:
```yaml
---
created: 2024-01-15
updated: 2024-03-20
category: articles
tags: [dotnet, cloud, aws]
---
```

## Usage

### Quick Start

Run in dry-run mode (no changes made):
```bash
python vault_organizer.py
```

Apply changes to your vault:
```bash
python vault_organizer.py --apply
```

Specify a custom vault path:
```bash
python vault_organizer.py --vault /path/to/vault --apply
```

### Command Line Options

```
usage: vault_organizer.py [-h] [--vault VAULT] [--apply]

optional arguments:
  -h, --help       show this help message and exit
  --vault VAULT    Path to Obsidian vault (default: current directory)
  --apply          Apply changes (default is dry-run mode)
```

## What It Does

### 1. Merge Conflict Detection
Scans all markdown files for Git conflict markers:
- `<<<<<<< HEAD`
- `=======`
- `>>>>>>> branch`

### 2. Broken Link Detection
Validates all Obsidian wiki-style links to ensure they point to existing files in the vault.

### 3. Stale Content Detection
Identifies files that haven't been modified in over 2 years, which may contain:
- Outdated technical information
- Deprecated best practices
- Old API references

### 4. Duplicate Content Detection
Uses content hashing to find files with identical content, helping you:
- Consolidate duplicate information
- Remove redundant files
- Maintain a cleaner vault structure

### 5. Metadata Enrichment
Adds structured frontmatter to files without it, including:
- **Created date**: From file creation timestamp
- **Updated date**: From file modification timestamp
- **Category**: Inferred from directory structure
- **Tags**: Extracted from inline hashtags in content

## Output

The tool provides a detailed report with:
- 📊 Statistics summary
- 🔴 High priority issues (merge conflicts)
- 🟡 Medium priority issues (broken links, duplicates)
- 🟢 Low priority issues (stale content)

Example output:
```
🌱 Obsidian Vault Organizer AI Agent
📁 Vault path: /path/to/vault
🔍 Mode: DRY RUN (no changes)

Found 150 markdown files

🔍 Checking for merge conflicts...
   Found 1 files with merge conflicts

🔍 Checking for broken links...
   Found 5 broken links

🔍 Checking for stale content (>2 years old)...
   Found 12 potentially stale files

🔍 Checking for duplicate content...
   Found 2 duplicate files

🔍 Enriching metadata (frontmatter)...
   Would update 45 files with metadata

============================================================
📊 VAULT ORGANIZATION REPORT
============================================================

📈 Statistics:
   Files scanned: 150
   Files updated: 45
   Merge conflicts: 1
   Broken links: 5
   Stale files: 12
   Duplicate files: 2

🔴 High Priority Issues (1):
   • articles/Tools/Visual Studio.md: Contains merge conflict markers

🟡 Medium Priority Issues (7):
   • Example: Broken link detected
   • Example: Duplicate content found

🟢 Low Priority Issues (12):
   Found 12 low priority issues (stale content)

============================================================
✅ Dry run complete! No files were modified.
   Run with --apply to make changes.
============================================================
```

## Automation with GitHub Actions

You can automate vault organization by setting up a GitHub Actions workflow. See `.github/workflows/vault-organizer.yml` for an example that:
- Runs weekly on Sundays
- Can be triggered manually
- Creates a report of issues found

## Requirements

- Python 3.7 or higher
- No external dependencies (uses only Python standard library)

## Safety

- **Default mode is dry-run**: No changes are made unless you use `--apply`
- **Preserves existing frontmatter**: Only adds metadata to files that lack it
- **Non-destructive**: Only adds content, doesn't delete or modify existing content
- **Safe for version control**: All changes are tracked by Git

## Contributing

Feel free to open issues or submit pull requests with improvements!

## License

MIT License - see repository license for details
