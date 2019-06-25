echo $project;
# $project = $args[0];

Get-ChildItem "Models" -Filter *.cs | 
Foreach-Object {
    $scaffoldCmd = 
    'dotnet-aspnet-codegenerator ' + 
    ' ' +
    'controller ' + 
    '-name ' + $_.BaseName + 'Controller ' +
    '-api ' + 
    "-m $project.Models." + $_.BaseName + ' ' +
    '-dc youtubeappContext ' +
    '-outDir Controllers ' +
    "-namespace $project.Controllers -f"

    # List commands for testing:
    $scaffoldCmd

    # Excute commands (uncomment this line):
    iex $scaffoldCmd
}