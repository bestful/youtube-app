# Regex matchall ps1 
# https://stackoverflow.com/questions/3141851/how-to-capture-multiple-regex-matches-from-a-single-line-into-the-matches-mag

# TODO Through git rev-list

# Settings
$log = git log --reverse
$git_arguments = "--minimal --output-directory patch"

# Regex match
Select-String "commit ([^ \n]*)[ \n]" -input $log -AllMatches | ForEach-Object {
  $string = $_;
}

# Save patches in patches directory
$n = 0
$string.Matches | ForEach-Object {
  $n++
  $commit = $_.Groups[1].Value
  git format-patch --minimal --output-directory patch --start-number $n -1 $commit
}

# Filter
# For this purpose we delete big patch files
$Dir = "patch"
$bias = 0.1 #MB

Get-ChildItem -Path $Dir -Recurse | Where { $_.Length / 1MB -gt $bias } | Remove-Item -Force