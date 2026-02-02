# Obsidian Vault Health Review Prompt

Use this prompt with AI assistants to perform a comprehensive health check of your entire Obsidian vault, identifying systemic issues and optimization opportunities.

---

## Context

You are an expert in knowledge management systems, Obsidian vault optimization, and information architecture. Analyze the provided vault statistics and sample content to identify patterns, issues, and opportunities for improvement across the entire vault.

---

## Instructions

Review the vault data provided and analyze according to the following framework:

### 1. VAULT STATISTICS OVERVIEW

**Basic Metrics** (User will provide these):
```
Total notes: [X]
Total wiki links: [X]
Broken links: [X]
Orphan notes: [X]
Notes with #type/ tags: [X] ([%])
Notes with #status/ tags: [X] ([%])
Notes with #topic/ tags: [X] ([%])
Seedling notes: [X] ([%])
Growing notes: [X] ([%])
Evergreen notes: [X] ([%])
Average links per note: [X]
Largest note: [Name] ([X] words)
Oldest unmodified note: [Name] ([X] days)
```

**Health Indicators Analysis**:

| Metric | Current | Target | Status | Priority |
|--------|---------|--------|--------|----------|
| Broken links | [X] | 0 | [🔴/🟡/🟢] | [High/Med/Low] |
| Orphan notes % | [X]% | <5% | [🔴/🟡/🟢] | [High/Med/Low] |
| Notes with type tags | [X]% | 100% | [🔴/🟡/🟢] | [High/Med/Low] |
| Notes with status tags | [X]% | 100% | [🔴/🟡/🟢] | [High/Med/Low] |
| Seedling notes % | [X]% | <20% | [🔴/🟡/🟢] | [High/Med/Low] |
| Avg links per note | [X] | >3 | [🔴/🟡/🟢] | [High/Med/Low] |

**Overall Vault Health Score**: [0-100]

---

### 2. STRUCTURAL ANALYSIS

**Information Architecture**:
- Are notes logically organized into folders/MOCs?
- Is there a clear hierarchy and navigation structure?
- Are MOCs (Maps of Content) being utilized effectively?
- Is the folder structure too deep or too flat?

**Naming Conventions**:
- Are note titles consistent and descriptive?
- Are there naming conflicts or duplicates?
- Do titles follow a clear convention?

**Organization Patterns**:
```
Observations:
- [Pattern observed]
- [Issue identified]
- [Strength noted]

Recommendations:
- [Improvement suggestion]
- [Reorganization idea]
```

---

### 3. TAGGING SYSTEM EVALUATION

**Tag Distribution Analysis**:
```
Top 10 Most Used Tags:
1. #[tag] - [X] notes
2. #[tag] - [X] notes
...

Tag Categories:
- Type tags: [distribution]
- Status tags: [distribution]
- Topic tags: [distribution]
- Action tags: [distribution]
```

**Tag System Issues**:
- [ ] Missing required tags on notes
- [ ] Inconsistent tag naming (e.g., #DotNet vs #dotnet vs #topic/dotnet)
- [ ] Tag sprawl (too many similar tags)
- [ ] Insufficient topic hierarchy
- [ ] Abandoned or rarely used tags

**Tag Consolidation Opportunities**:
```
Merge candidates:
- #[tag1], #[tag2] → #[unified-tag]
- #[tag3], #[tag4] → #[unified-tag]

Recommended tag hierarchy improvements:
- Create: #topic/[category]/[subcategory]
- Deprecate: #[old-tag]
```

---

### 4. CONNECTIVITY ANALYSIS

**Link Patterns**:
- Are notes well-connected or mostly isolated?
- Which notes are hub nodes (highly connected)?
- Which notes are isolated (no connections)?
- Are connections meaningful and bidirectional?

**Graph Structure Assessment**:
```
Hub Notes (most linked):
1. [[Note Name]] - [X] connections
2. [[Note Name]] - [X] connections
3. [[Note Name]] - [X] connections

Isolated Notes (zero connections):
- [[Note Name]]
- [[Note Name]]
- [[Note Name]]

Weakly Connected Notes (1-2 connections):
- [[Note Name]]
- [[Note Name]]
```

**Connection Recommendations**:
```
Missing MOCs for:
- [Topic area lacking an index]
- [Cluster of related notes without hub]

Potential link opportunities:
- [[Note A]] ↔ [[Note B]] because [reason]
- [[Note C]] should link to [[Note D]] because [reason]
```

---

### 5. CONTENT MATURITY ASSESSMENT

**Status Distribution Analysis**:
```
Seedlings (🌱): [X] notes ([X]%)
- [Issue if >20%]: Too many undeveloped notes
- [Recommendation]: Review and either develop or delete

Growing (🌿): [X] notes ([X]%)
- [Assessment]: Healthy work-in-progress pipeline
- [Action]: Identify candidates for promotion to evergreen

Evergreen (🌳): [X] notes ([X]%)
- [Assessment]: Core stable knowledge base
- [Goal]: Continuously promote quality growing notes
```

**Content Lifecycle Issues**:
- [ ] Stale seedlings (>90 days old, still undeveloped)
- [ ] Stagnant growing notes (not progressing)
- [ ] Evergreen notes that need updating
- [ ] Fleeting notes not being processed

**Age Distribution**:
```
Recently modified (< 7 days): [X] notes
Modified this month: [X] notes
Modified this year: [X] notes
Stale (> 1 year): [X] notes

Stale notes needing review:
- [[Note Name]] - [X] days old
- [[Note Name]] - [X] days old
```

---

### 6. QUALITY HOTSPOTS

**High-Priority Notes** (frequently accessed, core concepts):
```
[List of important notes that need quality review]
- [[Note Name]] - Status: [current] - Issues: [list]
```

**Problematic Patterns**:
```
Common issues found:
- [Pattern]: Found in [X] notes - [Example: [[Note Name]]]
- [Pattern]: Found in [X] notes - [Example: [[Note Name]]]

Quality concerns:
- Notes without summaries: [X] notes
- Very short notes (<100 words): [X] notes
- Very long notes (>2000 words): [X] notes
- Notes without sources: [X] notes
```

---

### 7. MAINTENANCE BACKLOG

**Immediate Priorities** (This week):
```
🔴 Critical Issues:
1. [Issue] - [X] affected notes - [Quick fix suggestion]
2. [Issue] - [X] affected notes - [Quick fix suggestion]

🟡 Important Issues:
1. [Issue] - [X] affected notes
2. [Issue] - [X] affected notes
```

**Short-term Goals** (This month):
```
1. [Goal] - Expected effort: [X] hours
2. [Goal] - Expected effort: [X] hours
3. [Goal] - Expected effort: [X] hours
```

**Long-term Improvements** (This quarter):
```
1. [Strategic improvement]
2. [Structural change]
3. [System enhancement]
```

---

### 8. AUTOMATION OPPORTUNITIES

**Repetitive Tasks to Automate**:
```
- [Task] - Could be automated with: [Solution]
- [Task] - Could be automated with: [Solution]

Dataview Queries to Create:
- [Query purpose]: Show [X]
- [Query purpose]: Track [X]

Template Opportunities:
- [Note type] needs a template
- [Note type] needs a template
```

---

### 9. CUSTOM RECOMMENDATIONS

**Based on Vault Type**:
- [ ] Personal knowledge management
- [ ] Professional/work knowledge base
- [ ] Research/academic notes
- [ ] Creative/writing projects
- [ ] Mixed purpose

**Tailored Suggestions**:
```
For your vault type, consider:
1. [Specific recommendation]
2. [Specific recommendation]
3. [Specific recommendation]

Plugins to explore:
- [Plugin name]: For [benefit]
- [Plugin name]: For [benefit]
```

---

### 10. COMPREHENSIVE SUMMARY

```
VAULT HEALTH REVIEW SUMMARY
============================
Overall Health Score: [X]/100

HEALTH STATUS: [Critical/Needs Work/Good/Excellent]

CRITICAL ISSUES (Fix Immediately):
1. [Issue] - Affects [X] notes
2. [Issue] - Affects [X] notes

TOP 5 STRENGTHS:
1. [Strength]
2. [Strength]
3. [Strength]
4. [Strength]
5. [Strength]

TOP 5 AREAS FOR IMPROVEMENT:
1. [Area] - Impact: [High/Medium/Low]
2. [Area] - Impact: [High/Medium/Low]
3. [Area] - Impact: [High/Medium/Low]
4. [Area] - Impact: [High/Medium/Low]
5. [Area] - Impact: [High/Medium/Low]

MAINTENANCE TIME ESTIMATE:
- Weekly: [X] hours to address critical issues
- Monthly: [X] hours for improvements
- Quarterly: [X] hours for major enhancements

NEXT 3 ACTIONS:
1. [Most important next step]
2. [Second priority]
3. [Third priority]
```

---

## Usage Instructions

### Step 1: Gather Vault Statistics

Run these checks in your vault:

**Option A: Using the GitHub Action** (if set up):
- Check the latest workflow run for vault statistics

**Option B: Manual Collection**:
- Use Obsidian's Graph View for visual analysis
- Use Dataview plugin to query statistics
- Check the Tag Pane for tag distribution
- Use Find/Replace to count patterns

**Option C: Using Python Script** (provided in [[GitHub Actions Guide]]):
```bash
# Run the vault health check script
python3 vault-health-check.py
```

### Step 2: Prepare Sample Data

Gather:
- Vault statistics (from Step 1)
- List of broken links
- List of orphan notes
- Tag distribution data
- Sample problematic notes

### Step 3: Use the Prompt

1. Copy this entire prompt
2. Paste into your AI assistant
3. Follow with: "Here are my vault statistics:" and paste your data
4. Review the comprehensive analysis
5. Create action items from recommendations

### Step 4: Create Action Plan

Use the output to:
- Update your [[Vault Maintenance Workflow]]
- Create issues/tasks for major improvements
- Schedule maintenance sessions
- Track progress over time

---

## Recommended Frequency

- **Monthly**: Full vault health review
- **Quarterly**: Deep analysis with comparison to previous quarter
- **Yearly**: Strategic review and major restructuring

---

## Example Usage

```
[Paste this prompt]

Here are my vault statistics:

Total notes: 120
Broken links: 15
Orphan notes: 8 (6.7%)
Notes with type tags: 25 (20.8%)
Notes with status tags: 22 (18.3%)
Seedling notes: 35 (29.2%)
Average links per note: 2.1

[Additional data as needed]
```

---

## Related Resources

- [[Vault Maintenance Workflow]] - Regular maintenance checklist
- [[Obsidian Note Review Prompt]] - Individual note review
- [[GitHub Actions Guide]] - Automated health checks
- [[Tag Taxonomy]] - Tagging guidelines

---

Tags: #type/reference #status/evergreen #topic/vault-organization
