$project = "webapi";

cd $project

& "..\initialization.ps1"
& "..\install_packages.ps1"
& "..\make_models.ps1"

cd ..
# git format -1
# .\apply_patches.ps1 $project
cat patch/0002-autodoc-for-api.patch | patch -p1

# git apply patch/0002-autodoc-for-api.patch

cd $project

& "..\make_controllers.ps1"

cd ..