# Vault Maintenance Workflow

This document outlines the regular maintenance tasks to keep the Digital Knowledge Garden healthy and well-organized.

---

## 🔄 Weekly Vault Maintenance (15-20 minutes)

Complete these tasks once per week to maintain vault health:

- [ ] **Process Seedling Notes**
  - Review all notes tagged with `#status/seedling`
  - Either develop them further or delete if no longer relevant
  - Move valuable seedlings to `#status/growing`

- [ ] **Review Action Items**
  - Check all notes tagged with `#action/todo`
  - Complete pending tasks or update status
  - Archive completed items with `#action/archive`

- [ ] **Check for Orphan Notes**
  - Use Graph View to identify notes with no connections
  - Add relevant links to connect orphaned notes
  - Consider if orphaned notes should be deleted

- [ ] **Run Dead Link Check**
  - Use the Broken Links plugin to scan vault
  - Fix or remove broken internal links
  - Update links that point to renamed files

- [ ] **Merge Duplicate Notes**
  - Identify notes covering the same topic
  - Consolidate content into a single note
  - Update all links to point to the consolidated note

- [ ] **Promote Growing Notes**
  - Review notes tagged with `#status/growing`
  - Update 2-3 well-developed notes to `#status/evergreen`
  - Ensure evergreen notes have proper cross-references

---

## 📅 Monthly Vault Review (30-45 minutes)

Complete these tasks once per month for deeper organization:

- [ ] **Review and Update MOCs**
  - Check all Maps of Content (Index files)
  - Add new notes to relevant MOCs
  - Remove outdated or deleted notes from MOCs
  - Ensure MOC structure is logical and helpful

- [ ] **Tag Audit**
  - Review tag usage across vault
  - Identify and merge duplicate or similar tags
  - Check for tags that violate the Tag Taxonomy
  - Use Tag Wrangler plugin to rename tags if needed

- [ ] **Review Fleeting Notes**
  - Process all notes tagged with `#type/fleeting`
  - Convert valuable fleeting notes to permanent notes
  - Delete fleeting notes that are no longer relevant

- [ ] **Update Cross-References**
  - Review recently created/updated notes
  - Add missing related notes links
  - Ensure bidirectional linking where appropriate

- [ ] **Backup Vault**
  - Ensure Git backup is up to date
  - Verify GitHub sync is working
  - Consider additional backup if needed

---

## 🔍 Vault Health Metrics

Track these metrics to assess vault health:

| Metric | Target | How to Check |
|--------|--------|--------------|
| **Orphan Notes** | < 5% | Graph View - look for isolated nodes |
| **Broken Links** | 0 | Broken Links plugin |
| **Seedling Notes** | < 20% | Search for `#status/seedling` |
| **Notes without Tags** | 0 | Search for notes without `#type/` or `#status/` |
| **Average Links per Note** | > 3 | Graph Analysis plugin |

---

## 🛠️ Maintenance Tools

### Required Plugins
- **Broken Links**: Find and fix dead internal links
- **Tag Wrangler**: Rename and merge tags efficiently
- **Graph Analysis**: Identify weakly connected notes

### Optional but Recommended
- **Dataview**: Query and display notes by tags/metadata
- **Linter**: Enforce consistent formatting
- **Obsidian Git**: Automated Git backup

---

## 📝 Maintenance Log Template

Keep a simple log of maintenance activities:

```markdown
## [Date] - Weekly Maintenance

- Processed X seedling notes
- Fixed X broken links
- Merged X duplicate notes
- Promoted X notes to evergreen
- Notes: [Any observations or improvements needed]
```

---

## Quick Wins

Tasks you can do anytime you have a few minutes:

1. **Add one cross-reference** to a note you're reading
2. **Promote one seedling** note that has enough content
3. **Fix one broken link** when you encounter it
4. **Add tags** to an untagged note
5. **Update one MOC** with a recently created note

---

Tags: #type/reference #status/evergreen #topic/vault-organization
