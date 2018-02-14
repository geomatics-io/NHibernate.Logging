#tool nuget:?package=NUnit.Runners&version=2.6.4
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/NHibernate.Logging.CommonLogging/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./src/NHibernate.Logging.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild("./src/NHibernate.Logging.sln", settings =>
        settings.SetConfiguration(configuration));
    }
    else
    {
      // Use XBuild
      XBuild("./src/NHibernate.Logging.sln", settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnitSettings {
        NoResults = true, X86 = true
        });
});

Task("BuildPackages")
    .IsDependentOn("Run-Unit-Tests")
    .Does(() =>
{
    var nuGetPackSettings = new NuGetPackSettings
    {
        OutputDirectory = "./artifacts",
        IncludeReferencedProjects = true,
        Properties = new Dictionary<string, string>
        {
            { "Configuration", "Release" }
        }
    };

    MSBuild("./src/Logging.Tests/Logging.Tests.csproj", new MSBuildSettings().SetConfiguration("Release").SetMSBuildPlatform(MSBuildPlatform.x86));

    MSBuild("./src/NHibernate.Logging.CommonLogging/NHibernate.Logging.CommonLogging.csproj", new MSBuildSettings().SetConfiguration("Release"));
    NuGetPack("./src/NHibernate.Logging.CommonLogging/NHibernate.Logging.CommonLogging.csproj", nuGetPackSettings);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("BuildPackages");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
