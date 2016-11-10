#load "tools/MK6.Tools.CakeBuild.Core/core.params.cake"

BuildParams buildParams = BuildParams.GetParams(Context);

// Install addins.

// Include Additional Cake files
#load "tools/MK6.Tools.CakeBuild.Core/core.dotnet.cake" 

Task("Clean")
    .IsDependentOn("CoreClean")
    .Does(() => {

});

Task("RestoreNuGetPackages")
    .IsDependentOn("CoreRestoreNuGetPackages")
    .Does(() =>
{
   
});

Task("Build")
    .IsDependentOn("CoreBuild")
    .Does(() =>
{
    
});

Task("Package")
    .IsDependentOn("CorePackage")
    .Does(() =>
{

});

Task("Publish")
    .IsDependentOn("CorePublish")
    .Does(() =>
{
      
});

Task("UpdateAssemblyInfo")
    .IsDependentOn("CoreUpdateAssemblyInfo")
    .Does(() =>
{
      
});

Task("Default")
  .IsDependentOn("Build")
  .Does(() =>
{

});

RunTarget(buildParams.Target);
