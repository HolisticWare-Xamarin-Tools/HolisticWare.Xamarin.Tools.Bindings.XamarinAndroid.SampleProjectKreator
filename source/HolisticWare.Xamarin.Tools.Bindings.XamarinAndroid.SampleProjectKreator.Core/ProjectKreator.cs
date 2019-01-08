using System;
using System.Collections.Generic;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core
{
    public partial class ProjectKreator
    {
        public ProjectKreator()
        {
            OptionSet = this.Options();

            return;
        }

        public Mono.Options.OptionSet OptionSet
        {
            get;
            set;
        }

        public string InputFolderPath
        {
            get;
            set;
        }

        public string OutputFolderPath
        {
            get;
            set;
        }


        public string ProjectName
        {
            get;
            set;
        }

        public void Load(string path_project)
        {
            //BuildResult result = null;

            using (ProjectCollection collection = new ProjectCollection())
            {
                /*
                result = BuildManager.DefaultBuildManager.Build(
                        new BuildParameters(pc) { Loggers = new[] { new ConsoleLogger() } },
                        // Change this path to your .sln file instead of the .csproj.
                        // (It won't work with the .csproj.)
                        new BuildRequestData(@"c:\projects\Sample.sln",
                            // Change the parameters as you need them,
                            // e.g. if you want to just Build the Debug (not Rebuild the Release).
                            new Dictionary<string, string>
                            {
                { "Configuration", "Release" },
                { "Platform", "Any CPU" }
                            }, null, new[] { "Rebuild" }, null));

                if (result.OverallResult == BuildResultCode.Failure)
                { 
                }
                */
                /*
                collection.
                Microsoft.Build.Evaluation.Project proj = collection.LoadProject(path_project); // <-- exception

                proj.Build("Build");
                */
                collection.DefaultToolsVersion = "15.0";
                Microsoft.Build.Evaluation.Project p = null;

                Microsoft.Build.Construction.ProjectRootElement pre = null; 
                pre = Microsoft.Build.Construction.ProjectRootElement.Open(path_project);

                //p = collection.LoadProject
                //(
                //    path_project, 
                //    new Dictionary<string, string>(), 
                //    "15.0", 
                //    new ProjectCollection()
                //);
                p = new Microsoft.Build.Evaluation.Project(pre);
                                                        //(
                                                        //    path_project, 
                                                        //    new Dictionary<string, string>(), 
                                                        //    "15.0", 
                                                        //    new ProjectCollection()
                                                        //);
                p.ProjectCollection.RegisterLogger(new ConsoleLogger());
                p.ProjectCollection.SetGlobalProperty("EnableNuGetPackageRestore", "true");
                p.Build();

                if (!p.Build())
                {
                    Console.ReadLine();
                }


                //MsBuildProject 

                return;
            }
        }
    }
}
