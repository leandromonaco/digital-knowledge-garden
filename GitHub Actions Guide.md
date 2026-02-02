# GitHub Actions for Vault Maintenance

This repository includes automated GitHub Actions workflows to help maintain vault health and catch issues early.

## Vault Maintenance Check

**Workflow File:** `.github/workflows/vault-maintenance.yml`

### What It Does

This automated workflow runs every time markdown files are changed and performs:

1. **Broken Link Detection**
   - Scans all markdown files for wiki-style links (`[[Link]]`)
   - Checks if linked files actually exist in the vault
   - Excludes template/documentation files that contain example links
   - Excludes generated HTML files in the `docs/` folder

2. **Vault Health Metrics**
   - Counts files with type tags (`#type/`)
   - Counts files with status tags (`#status/`)
   - Tracks seedling, growing, and evergreen note counts
   - Provides recommendations for improvement

### When It Runs

The workflow triggers on:
- **Push to main/master branch** when `.md` files change
- **Pull requests** when `.md` files change

### What Happens

#### On Success ✅
- Workflow passes with green checkmark
- Shows vault health metrics in the logs
- Displays "No Broken Links Found" message

#### On Failure ⚠️
- Workflow fails with red X
- Shows broken links in a table format
- For PRs: Automatically adds a comment with the broken link count
- Prevents accidental merging of broken links

### Example Output

```
## 🔍 Vault Maintenance Report

**Total markdown files**: 116
**Total wiki links**: 81
**Broken links**: 0

### ✅ No Broken Links Found

All wiki-style links point to existing files.

## 📊 Vault Health Metrics

| Metric | Value | Target | Status |
|--------|-------|--------|--------|
| Files with type tags | 5/116 (4.3%) | 100% | ⚠️ |
| Files with status tags | 5/116 (4.3%) | 100% | ⚠️ |
| Seedling notes | 0 (0.0%) | < 20% | ✅ |
| Growing notes | 2 | - | ℹ️ |
| Evergreen notes | 3 | - | ℹ️ |

### 📝 Recommendations

- Add type tags to 111 files
- Add status tags to 111 files
```

### Excluded Files

The following files are excluded from broken link checking because they contain example/template links:
- `Note Template.md`
- `Obsidian Vault Organization Guide.md`
- `Tag Taxonomy.md`

### Known Limitations

1. **Self-referencing links**: Links like `[[Professional Development Plan]]` within the file `Professional Development Plan.md` are flagged as broken (they reference the current file)

2. **Section links**: Links with sections (e.g., `[[File#Section]]`) are checked for the base file only

3. **Aliases**: Links with aliases (e.g., `[[File|Display Name]]`) check the file part only

4. **Image embeds**: Image links (`.png`, `.jpg`, `.jpeg`) are skipped

### Viewing Workflow Results

1. Go to the **Actions** tab in GitHub
2. Click on the latest workflow run
3. Expand the job steps to see detailed output
4. Look for:
   - "Check for broken wiki links" - Shows broken link report
   - "Check vault health metrics" - Shows tagging statistics

### Customizing the Workflow

To adjust the workflow behavior, edit `.github/workflows/vault-maintenance.yml`:

**Change when it runs:**
```yaml
on:
  push:
    branches:
      - main
      - develop  # Add more branches
```

**Exclude additional files:**
```python
exclude_files = ['Note Template.md', 'Your File.md']
```

**Adjust vault health thresholds:**
```python
seedling_percent < 20  # Change threshold
```

### Troubleshooting

**Q: Why is my PR failing?**
A: The workflow detected broken links. Check the workflow logs to see which links are broken and fix them.

**Q: How do I fix a broken link?**
1. Find the broken link in the workflow output
2. Either create the missing file or update the link to point to an existing file
3. Push the fix - the workflow will run again

**Q: Can I bypass the check?**
A: Yes, but not recommended. The workflow only fails on broken links - it won't block your PR for missing tags or other metrics.

**Q: A link works in Obsidian but fails in the workflow**
A: Make sure you're using the full path for links outside the current directory:
- ❌ `[[WinGet]]`
- ✅ `[[articles/Tools/WinGet]]`

### Manual Testing

You can run the same checks locally before pushing:

```bash
# Test broken link detection
python3 << 'EOF'
import os
import re
import glob

md_files = []
exclude_files = ['Note Template.md', 'Obsidian Vault Organization Guide.md', 'Tag Taxonomy.md']
for pattern in ['**/*.md']:
    for file in glob.glob(pattern, recursive=True):
        if not file.startswith('docs/') and os.path.basename(file) not in exclude_files:
            md_files.append(file)

wiki_link_pattern = r'\[\[([^\]]+)\]\]'
broken_links = []

for md_file in md_files:
    with open(md_file, 'r', encoding='utf-8') as f:
        content = f.read()
        links = re.findall(wiki_link_pattern, content)
        
        for link in links:
            link_target = link.split('#')[0].split('|')[0].strip()
            
            if link_target.endswith(('.png', '.jpg', '.jpeg')):
                continue
            
            found = False
            if link_target.startswith('articles/') or link_target.startswith('projects/'):
                if os.path.exists(f"{link_target}.md"):
                    found = True
            else:
                for root, dirs, files in os.walk('.'):
                    if root.startswith('./docs'):
                        continue
                    if f"{link_target}.md" in files:
                        found = True
                        break
            
            if not found:
                broken_links.append(f"{md_file}: [[{link}]]")

if broken_links:
    print("⚠️ Broken links found:")
    for link in broken_links:
        print(f"  - {link}")
else:
    print("✅ No broken links found!")
EOF
```

### Related Documentation

- [[Vault Maintenance Workflow]] - Manual maintenance checklist
- [[Obsidian Vault Organization Guide]] - Complete organization system
- [[Tag Taxonomy]] - Tagging guidelines

---

Tags: #type/reference #status/evergreen #topic/vault-organization
