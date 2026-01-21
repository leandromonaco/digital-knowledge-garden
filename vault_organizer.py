#!/usr/bin/env python3
"""
Obsidian Vault Organizer AI Agent

This agent helps keep the Digital Knowledge Garden Obsidian vault organized and up to date by:
1. Adding/updating frontmatter metadata (dates, tags, status)
2. Detecting broken internal and external links
3. Identifying stale content based on timestamps
4. Finding duplicate or similar content
5. Detecting merge conflict markers
"""

import os
import re
import hashlib
from datetime import datetime
from pathlib import Path
from typing import List, Dict, Set, Tuple
from collections import defaultdict
import argparse


class VaultOrganizer:
    """Main class for organizing Obsidian vault content."""
    
    def __init__(self, vault_path: str, dry_run: bool = False):
        self.vault_path = Path(vault_path)
        self.dry_run = dry_run
        self.issues: List[Dict] = []
        self.stats = {
            'files_scanned': 0,
            'files_updated': 0,
            'broken_links': 0,
            'stale_files': 0,
            'duplicates': 0,
            'merge_conflicts': 0
        }
        
    def run(self):
        """Execute all vault organization tasks."""
        print("🌱 Obsidian Vault Organizer AI Agent")
        print(f"📁 Vault path: {self.vault_path}")
        print(f"🔍 Mode: {'DRY RUN (no changes)' if self.dry_run else 'LIVE (will make changes)'}\n")
        
        # Scan all markdown files
        md_files = self._get_markdown_files()
        print(f"Found {len(md_files)} markdown files\n")
        
        # Run all checks and fixes
        self._check_merge_conflicts(md_files)
        self._check_broken_links(md_files)
        self._check_stale_content(md_files)
        self._check_duplicates(md_files)
        self._enrich_metadata(md_files)
        
        # Report results
        self._print_report()
        
    def _get_markdown_files(self) -> List[Path]:
        """Get all markdown files in the vault, excluding certain directories."""
        exclude_dirs = {'.obsidian', '.git', 'node_modules', 'docs'}
        md_files = []
        
        for root, dirs, files in os.walk(self.vault_path):
            # Remove excluded directories from search
            dirs[:] = [d for d in dirs if d not in exclude_dirs]
            
            for file in files:
                if file.endswith('.md'):
                    md_files.append(Path(root) / file)
                    
        return md_files
    
    def _check_merge_conflicts(self, md_files: List[Path]):
        """Detect merge conflict markers in markdown files."""
        print("🔍 Checking for merge conflicts...")
        conflict_pattern = re.compile(r'^(<{7}|={7}|>{7})', re.MULTILINE)
        
        for file_path in md_files:
            self.stats['files_scanned'] += 1
            try:
                content = file_path.read_text(encoding='utf-8')
                if conflict_pattern.search(content):
                    self.stats['merge_conflicts'] += 1
                    self.issues.append({
                        'type': 'merge_conflict',
                        'severity': 'high',
                        'file': str(file_path.relative_to(self.vault_path)),
                        'message': 'Contains merge conflict markers'
                    })
            except Exception as e:
                print(f"⚠️  Error reading {file_path}: {e}")
        
        print(f"   Found {self.stats['merge_conflicts']} files with merge conflicts\n")
    
    def _check_broken_links(self, md_files: List[Path]):
        """Check for broken internal wiki links."""
        print("🔍 Checking for broken links...")
        
        # Build index of all files (for link validation)
        file_index = {}
        for file_path in md_files:
            file_name = file_path.stem  # filename without extension
            if file_name not in file_index:
                file_index[file_name] = []
            file_index[file_name].append(file_path)
        
        # Pattern for Obsidian wiki links: [[link]] or [[link|alias]]
        link_pattern = re.compile(r'\[\[([^\]|]+)(?:\|[^\]]+)?\]\]')
        
        for file_path in md_files:
            try:
                content = file_path.read_text(encoding='utf-8')
                links = link_pattern.findall(content)
                
                for link in links:
                    # Clean the link (remove anchor #section)
                    clean_link = link.split('#')[0].strip()
                    
                    if clean_link and clean_link not in file_index:
                        self.stats['broken_links'] += 1
                        self.issues.append({
                            'type': 'broken_link',
                            'severity': 'medium',
                            'file': str(file_path.relative_to(self.vault_path)),
                            'message': f'Broken link to: [[{link}]]'
                        })
            except Exception as e:
                print(f"⚠️  Error checking links in {file_path}: {e}")
        
        print(f"   Found {self.stats['broken_links']} broken links\n")
    
    def _check_stale_content(self, md_files: List[Path]):
        """Identify potentially stale content based on file modification time."""
        print("🔍 Checking for stale content (>2 years old)...")
        
        two_years_ago = datetime.now().timestamp() - (2 * 365 * 24 * 60 * 60)
        
        for file_path in md_files:
            try:
                mtime = file_path.stat().st_mtime
                if mtime < two_years_ago:
                    self.stats['stale_files'] += 1
                    mod_date = datetime.fromtimestamp(mtime).strftime('%Y-%m-%d')
                    self.issues.append({
                        'type': 'stale_content',
                        'severity': 'low',
                        'file': str(file_path.relative_to(self.vault_path)),
                        'message': f'Last modified: {mod_date}'
                    })
            except Exception as e:
                print(f"⚠️  Error checking staleness of {file_path}: {e}")
        
        print(f"   Found {self.stats['stale_files']} potentially stale files\n")
    
    def _check_duplicates(self, md_files: List[Path]):
        """Find potential duplicate content based on similarity."""
        print("🔍 Checking for duplicate content...")
        
        # Simple duplicate detection based on content hash
        content_hashes = defaultdict(list)
        
        for file_path in md_files:
            try:
                content = file_path.read_text(encoding='utf-8')
                # Remove frontmatter for comparison
                content_without_frontmatter = re.sub(r'^---\n.*?\n---\n', '', content, flags=re.DOTALL)
                # Normalize whitespace
                normalized = re.sub(r'\s+', ' ', content_without_frontmatter).strip()
                
                if len(normalized) > 100:  # Only check substantial files
                    content_hash = hashlib.md5(normalized.encode()).hexdigest()
                    content_hashes[content_hash].append(file_path)
            except Exception as e:
                print(f"⚠️  Error checking duplicates in {file_path}: {e}")
        
        # Report duplicates
        for hash_value, files in content_hashes.items():
            if len(files) > 1:
                self.stats['duplicates'] += len(files) - 1
                file_list = ', '.join([str(f.relative_to(self.vault_path)) for f in files])
                self.issues.append({
                    'type': 'duplicate',
                    'severity': 'medium',
                    'file': str(files[0].relative_to(self.vault_path)),
                    'message': f'Duplicate content found in: {file_list}'
                })
        
        print(f"   Found {self.stats['duplicates']} duplicate files\n")
    
    def _enrich_metadata(self, md_files: List[Path]):
        """Add or update frontmatter metadata in files that lack it."""
        print("🔍 Enriching metadata (frontmatter)...")
        
        frontmatter_pattern = re.compile(r'^---\n.*?\n---\n', re.DOTALL)
        
        for file_path in md_files:
            try:
                content = file_path.read_text(encoding='utf-8')
                
                # Check if file already has frontmatter
                if frontmatter_pattern.match(content):
                    continue
                
                # Generate frontmatter
                created_time = datetime.fromtimestamp(file_path.stat().st_ctime)
                modified_time = datetime.fromtimestamp(file_path.stat().st_mtime)
                
                # Extract tags from content (look for #tag patterns)
                tags = set(re.findall(r'#([a-zA-Z][a-zA-Z0-9_-]*)', content))
                
                # Determine category based on path
                rel_path = file_path.relative_to(self.vault_path)
                category = str(rel_path.parts[0]) if len(rel_path.parts) > 1 else 'root'
                
                # Build frontmatter
                frontmatter = "---\n"
                frontmatter += f"created: {created_time.strftime('%Y-%m-%d')}\n"
                frontmatter += f"updated: {modified_time.strftime('%Y-%m-%d')}\n"
                frontmatter += f"category: {category}\n"
                if tags:
                    frontmatter += f"tags: [{', '.join(sorted(tags))}]\n"
                frontmatter += "---\n\n"
                
                # Add frontmatter to content
                new_content = frontmatter + content
                
                if not self.dry_run:
                    file_path.write_text(new_content, encoding='utf-8')
                    self.stats['files_updated'] += 1
                else:
                    self.stats['files_updated'] += 1
                    
            except Exception as e:
                print(f"⚠️  Error enriching metadata for {file_path}: {e}")
        
        print(f"   {'Would update' if self.dry_run else 'Updated'} {self.stats['files_updated']} files with metadata\n")
    
    def _print_report(self):
        """Print summary report of all findings."""
        print("\n" + "="*60)
        print("📊 VAULT ORGANIZATION REPORT")
        print("="*60)
        
        print(f"\n📈 Statistics:")
        print(f"   Files scanned: {self.stats['files_scanned']}")
        print(f"   Files updated: {self.stats['files_updated']}")
        print(f"   Merge conflicts: {self.stats['merge_conflicts']}")
        print(f"   Broken links: {self.stats['broken_links']}")
        print(f"   Stale files: {self.stats['stale_files']}")
        print(f"   Duplicate files: {self.stats['duplicates']}")
        
        # Group issues by severity
        high_severity = [i for i in self.issues if i['severity'] == 'high']
        medium_severity = [i for i in self.issues if i['severity'] == 'medium']
        low_severity = [i for i in self.issues if i['severity'] == 'low']
        
        if high_severity:
            print(f"\n🔴 High Priority Issues ({len(high_severity)}):")
            for issue in high_severity[:10]:  # Limit to first 10
                print(f"   • {issue['file']}: {issue['message']}")
            if len(high_severity) > 10:
                print(f"   ... and {len(high_severity) - 10} more")
        
        if medium_severity:
            print(f"\n🟡 Medium Priority Issues ({len(medium_severity)}):")
            for issue in medium_severity[:10]:
                print(f"   • {issue['file']}: {issue['message']}")
            if len(medium_severity) > 10:
                print(f"   ... and {len(medium_severity) - 10} more")
        
        if low_severity:
            print(f"\n🟢 Low Priority Issues ({len(low_severity)}):")
            print(f"   Found {len(low_severity)} low priority issues (stale content)")
        
        print("\n" + "="*60)
        if self.dry_run:
            print("✅ Dry run complete! No files were modified.")
            print("   Run with --apply to make changes.")
        else:
            print("✅ Vault organization complete!")
        print("="*60 + "\n")


def main():
    """Main entry point for the script."""
    parser = argparse.ArgumentParser(
        description='Obsidian Vault Organizer AI Agent',
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog='''
Examples:
  # Dry run (no changes):
  python vault_organizer.py

  # Apply changes:
  python vault_organizer.py --apply

  # Specify vault path:
  python vault_organizer.py --vault /path/to/vault --apply
        '''
    )
    parser.add_argument(
        '--vault',
        default='.',
        help='Path to Obsidian vault (default: current directory)'
    )
    parser.add_argument(
        '--apply',
        action='store_true',
        help='Apply changes (default is dry-run mode)'
    )
    
    args = parser.parse_args()
    
    organizer = VaultOrganizer(
        vault_path=args.vault,
        dry_run=not args.apply
    )
    organizer.run()


if __name__ == '__main__':
    main()
