using System;
using System.Collections.Generic;
using global::HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    class MainClass
    {
        static bool show_help = false;

        static string path =
            // "/Projects/hw-tools/Kreator/source/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core.csproj"
            // "/Projects/hw-tools/Kreator/samples/Bindings.Sample.Project.Kreator.App.Console/Bindings.Sample.Project.Kreator.App.Console.csproj"
            "/Projects/hw-tools/SampleProjectKreator/samples/App.XamarinAndroid/App.XamarinAndroid.csproj"
            ;

        static List<(
                        string GroupName,
                        string FeatureName,
                        string ProjectName,
                        string InputFolderPath,
                        string OutputFolderPath
                    )> ProjectsDataToConvert;
        static List<ProjectKreator> ProjectKreators;

        static ProjectKreator project_kreator = null;

        static void Main(string[] args)
        {
            //Test_Microsoft_Build_Evaluation();

            ProjectsDataToConvert = new List<(
                                                string GroupName,
                                                string FeatureName,
                                                string ProjectName,
                                                string InputFolderPath,
                                                string OutputFolderPath
                                            )>
            {
                (
                    GroupName : "Android.Support",
                    FeatureName : "CoordinatorLayout",
                    ProjectName : "HeroBarry",
                    InputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-HeroBarry/",
                    OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Android.Support/CoordinatorLayout/"
                ),
                (
                    GroupName : "Android.Support",
                    FeatureName : "CoordinatorLayout",
                    ProjectName : "vitovalov",
                    InputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-vitovalov/",
                    OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Android.Support/CoordinatorLayout/"
                ),
                (
                    GroupName : "Android.Support",
                    FeatureName : "CoordinatorLayout",
                    ProjectName : "cstew",
                    InputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-cstew/",
                    OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Android.Support/CoordinatorLayout/"
                ),
                (
                    GroupName : "Android.Support",
                    FeatureName : "CoordinatorLayout",
                    ProjectName : "romainz",
                    InputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-romainz/",
                    OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Android.Support/CoordinatorLayout/"
                ),
                (
                    GroupName : "Android.Support",
                    FeatureName : "CoordinatorLayout",
                    ProjectName : "ttymsd",
                    InputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-ttymsd/",
                    OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Android.Support/CoordinatorLayout/"
                ),
            };

            foreach
                (
                    (
                        string GroupName,
                        string FeatureName,
                        string ProjectName,
                        string InputFolderPath,
                        string OutputFolderPath
                    ) p in ProjectsDataToConvert
                )
            {
                project_kreator = new ProjectKreator()
                {
                    GroupName = p.GroupName,
                    FeatureName = p.FeatureName,
                    ProjectName = p.ProjectName,
                    InputFolderPath = p.InputFolderPath,
                    OutputFolderPath = p.OutputFolderPath
                };

                project_kreator.CreateProject();
            }

            List<string> extra;
            try
            {
                extra = project_kreator.OptionSet.Parse(args);
            }
            catch (global::Mono.Options.OptionException e)
            {
                System.Console.Write("XamarinAndroid.ProjectKreator: ");
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try `XamarinAndroid.ProjectKreator --help' for more information.");
                return;
            }

            if (show_help)
            {
                project_kreator.ShowHelp(project_kreator.OptionSet);
                return;
            }

            string message = "XamarinAndroid.ProjectKreator";
            if (extra.Count > 0)
            {
                message = string.Join(" ", extra.ToArray());
                project_kreator.Debug($"Using new message: {message}");
            }
            else
            {
                project_kreator.Debug($"Using default message: {message}");
            }

            //project_kreator.Load(path);

            return;
        }

        private static void Test_Microsoft_Build_Evaluation()
        {
            var p = new Microsoft.Build.Evaluation.Project
            (
                //"/Projects/hw-tools/SampleProjectKreator/samples/App.XamarinAndroid/App.XamarinAndroid.csproj"
                "/Projects/hw-tools/SampleProjectKreator/samples/Bindings.Sample.Project.Kreator.App.Console.Mono/Bindings.Sample.Project.Kreator.App.Console.Mono.csproj"
            );
            p.AddItem("Compile", @"C:\folder\file.cs");
            p.Save();
        }
    }
}
