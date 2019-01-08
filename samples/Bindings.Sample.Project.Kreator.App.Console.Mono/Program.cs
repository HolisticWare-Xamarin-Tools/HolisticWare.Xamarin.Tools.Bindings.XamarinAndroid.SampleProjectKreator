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

        static ProjectKreator project_kreator = null;

        static void Main(string[] args)
        {
            project_kreator = new ProjectKreator()
            {
                ProjectName = "HeroBarry",
                InputFolderPath = "../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-HeroBarry/",
                OutputFolderPath = "../../../../hw-tools/Xamarin.Android.Samples/samples/Android.Support/CoordinatorLayout/"
            };

            project_kreator.CreateProject();


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
            project_kreator.Load(path);

            return;
        }
    }
}
