$project = $args[0];

$replace = "webapi_core2";
$to = $project;
$file = "composite_key.patch";
$_file = "__$file";

(Get-Content $file).replace($replace, $to) | Set-Content $_file 

git apply --whitespace=nowarn $_file
# del $_file
