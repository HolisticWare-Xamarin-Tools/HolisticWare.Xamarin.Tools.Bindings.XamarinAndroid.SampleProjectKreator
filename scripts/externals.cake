#addin nuget:?package=Cake.Git

#load "./nuget-restore.cake""

Dictionary<string, Dictionary<string, string> > Repositories = null;

#load "./externals/repos-AndroidSupport.cake"
#load "./externals/repos-AndroidX.cake"
#load "./externals/repos-Android_UI.cake"
#load "./externals/repos-Awsome_Android_UI.cake"
#load "./externals/repos-Card_Based_UI.cake"
#load "./externals/repos-Firebase.cake"
#load "./externals/repos-Google.Play.Services.cake"
#load "./externals/repos-GooglePlayServices-AdMob.cake"
#load "./externals/repos-Material.cake"
#load "./externals/repos-Office365-Fabric.cake"

#load "./externals-download-code.cake"

string path_output_repos = System.IO.Path.Combine
                                            (
                                                new string[]
                                                {
                                                    "output",
                                                    "repos",
                                                }
                                            );



//-------------------------------------------------------------------------------------------------
IEnumerable<string> redirectedStandardOutput;
int exitCodeWithArgument;

exitCodeWithArgument =
                        StartProcess
                        (
                            "git",
                            new ProcessSettings
                            {
                                Arguments = "config user.name",
                                RedirectStandardOutput = true
                            },
                            out redirectedStandardOutput
                        );

string git_user = redirectedStandardOutput.LastOrDefault();
Information($"git user: {git_user}");

exitCodeWithArgument =
                        StartProcess
                        (
                            "git",
                            new ProcessSettings
                            {
                                Arguments = "config user.email",
                                RedirectStandardOutput = true
                            },
                            out redirectedStandardOutput
                        );

string git_email = redirectedStandardOutput.LastOrDefault();
Information($"git email: {git_email}");
//-------------------------------------------------------------------------------------------------


Task ("externals")
    .IsDependentOn("externals-download-code")
    .IsDependentOn("externals-update-git-repos")
    .Does
    (
        () =>
        {
            Information("externals ...");

            string [] folders = new string[]
            {
                "./externals/",
                "./externals/results/",
                "./externals/results/unit-tests/",
            };

            foreach(string folder in folders)
            {
                Information($"    creating ...{folder}");
                if (!DirectoryExists (folder))
                {
                    CreateDirectory (folder);
                }
            }

            return;
        }
    );

Task("externals-build")
    .IsDependentOn ("nuget-restore")
    .Does
    (
        () =>
        {
            FilePathCollection files = GetFiles("./external*/**/build.cake");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                CakeExecuteScript
                    (
                        file,
                        new CakeSettings
                        {
                            Verbosity = Verbosity.Diagnostic,
                            Arguments = new Dictionary<string, string>()
                            {
                                //{"verbosity",   "diagnostic"},
                                {"target",      "libs"},
                            },
                        }
                    );
            }

            return;
        }
    );

RunTarget("externals");