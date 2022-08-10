## Reset author for ALL commits
```
git filter-branch -f --env-filter "GIT_AUTHOR_NAME='Newname'; GIT_AUTHOR_EMAIL='new@email'; GIT_COMMITTER_NAME='Newname'; GIT_COMMITTER_EMAIL='new@email';" HEAD
git push --force --tags origin 'refs/heads/main'
```

## Read Git Configuration
```
git config --local -l
git config --global -l
```

## Removing sensitive data from a repository
- https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository
- https://rtyley.github.io/bfg-repo-cleaner/

## Troubleshoot git issues

```
set GIT_TRACE=1
set GIT_CURL_VERBOSE=1
```

## Fix .gitignore issues

1. Run ```git rm -r --cached .``` to unstage and remove the path to your files from the Git index.
2. Execute ```git add .``` to re-add all your files back (only the correct files will be updated).
3. Execute ```git commit -m ".gitignore is now working"``` to commit all your files back into the Git index.

## Change last commit message

1. Run ```git commit --amend -m "New and correct message"```

## Delete the most recent commit

without destroying the work you've done:

```git reset --soft HEAD~1```

destroying the work you've done:

```git reset --hard HEAD~1```
