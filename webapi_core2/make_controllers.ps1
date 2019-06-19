Get-ChildItem "Models" -Filter *.cs | 
Foreach-Object {
    $scaffoldCmd = 
    'dotnet-aspnet-codegenerator ' + 
    '-p "D:\repos\youtube-app\webapi_core2" ' +
    'controller ' + 
    '-name ' + $_.BaseName + 'Controller ' +
    '-api ' + 
    '-m webapi_core2.Models.' + $_.BaseName + ' ' +
    '-dc myConnection ' +
    '-outDir Controllers ' +
    '-namespace webapi_core2.Controllers -f'

    # List commands for testing:
    $scaffoldCmd

    # Excute commands (uncomment this line):
    iex $scaffoldCmd
}