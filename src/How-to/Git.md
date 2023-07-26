### Clean Repository

`git clean -fdx` is a command used in Git to remove untracked files and directories from the working tree.

- `-f` flag stands for "force", which allows the command to execute without prompting the user for confirmation. 
- `-d` flag is used to also remove untracked directories. 
- `-x` flag is used to also remove ignored files.

### Git Clone with Submodules
  
  `git clone git@github.com:leandromonaco/leandromonaco.github.io.git C:\Dev\Repo --recurse-submodules`
  
### Start a new change
  
  ```
  git checkout main
  git fetch
  git pull
  git branch branch_name
  git checkout branch_name
  ```
  
### Commit Changes
```
git status --short
git add myfile.txt
git commit -m "Made changes to myfile.txt"
```

### Push changes
```
git push --set-upstream origin branch_name
git push
```

### Reset author for ALL commits
  
  ```
  git filter-branch -f --env-filter "GIT_AUTHOR_NAME='Newname'; GIT_AUTHOR_EMAIL='new@email'; GIT_COMMITTER_NAME='Newname'; GIT_COMMITTER_EMAIL='new@email';" HEAD
  git push --force --tags origin 'refs/heads/main'
  ```

### Change last commit message

Run ``git commit --amend -m "New and correct message"``

### Delete the most recent commit
without destroying the work you've done: ``git reset --soft HEAD~1``
destroying the work you've done: ``git reset --hard HEAD~1``

### Fix .gitignore issues
1. Run ``git rm -r --cached .`` to unstage and remove the path to your files from the Git index.
2. Execute ``git add .`` to re-add all your files back (only the correct files will be updated).
3. Execute ``git commit -m ".gitignore is now working"`` to commit all your files back into the Git index.

## Configuration

### Read All Configuration
```
git config --local -l
git config --global -l
```

### Read specific values
```
git config --global user.name
git config --global user.email
```

Make sure that local git config does not override the global configuration
```
git config --local user.name
git config --local user.email
```

### Change values
```
git config --global user.name [username]
git config --global user.email [email address]
```

## Removing sensitive data from a repository
- [Removing sensitive data from a repository](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository)
- [BFG Repo-Cleaner](https://rtyley.github.io/bfg-repo-cleaner/)
- [BFG GitHub Repo](https://github.com/rtyley/bfg-repo-cleaner)

**Example**
1. ```winget install -e --id Oracle.JavaRuntimeEnvironment```
2. ```java -jar bfg.jar --delete-folders ReleasePlanning```
3. ```git push --force```
- if dealing with protected commits add ```--no-blob-protection``` parameter
- 
## Troubleshooting

```
set GIT_TRACE=1
set GIT_CURL_VERBOSE=1
```
