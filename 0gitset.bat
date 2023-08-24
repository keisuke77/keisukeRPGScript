git init
@echo off
set /p remote_url="Enter the remote URL: "
git remote add origin %remote_url%
set /p commit_message="Commit message: "
git add .
git commit -m "%commit_message%"
git push origin main
pause
