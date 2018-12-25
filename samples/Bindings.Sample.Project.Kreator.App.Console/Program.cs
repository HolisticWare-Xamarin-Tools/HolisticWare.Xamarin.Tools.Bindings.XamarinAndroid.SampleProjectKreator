using System;
using System.Collections.Generic;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core;

namespace Bindings.Sample.Project.Kreator.App
{
    class Program
    {
        static string path =
            // "/Projects/hw-tools/Kreator/source/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core.csproj"
            // "/Projects/hw-tools/Kreator/samples/Bindings.Sample.Project.Kreator.App.Console/Bindings.Sample.Project.Kreator.App.Console.csproj"
            "/Projects/hw-tools/SampleProjectKreator/samples/App.XamarinAndroid/App.XamarinAndroid.csproj"
            ;

        static string folder_input_android = null;
        static string folder_input_dotnet = null;
        static bool show_help = false;
        static int verbosity = 0;

        static void Main(string[] args)
        {
            Mono.Options.OptionSet option_set = new Mono.Options.OptionSet()
            {
                // ../../../../../../../X/AndroidSupportComponents-AndroidX-binderate/output/AndroidSupport.api-diff.xml
                {
                    "i|input=",
                    "input folder with Android Support Diff (Metadata.xml, Metadata*.xml)",
                    (string v) =>
                    {
                        folder_input_android = v;
                        return;
                    }
                },
                {
                    "o|output=",
                    "output folder with AndroidX Xamarin.Android Metadata files (Metadata.xml, Metadata*.xml)",
                    (string v) =>
                    {
                        folder_input_dotnet = v;
                        return;
                    }
                },
                {
                    "h|help",
                    "show this message and exit",
                    v => show_help = v != null
                },
            };

            List<string> extra;
            try
            {
                extra = option_set.Parse(args);
            }
            catch (Mono.Options.OptionException e)
            {
                Console.Write("XamarinAndroid.ProjectKreator: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `AndroidX.Migraineator --help' for more information.");
                return;
            }

            if (show_help)
            {
                ShowHelp(option_set);
                return;
            }

            string message = "AndroidX.Migraineator";
            if (extra.Count > 0)
            {
                message = string.Join(" ", extra.ToArray());
                Debug($"Using new message: {message}");
            }
            else
            {
                Debug($"Using default message: {message}");
            }
            ProjectKreator pk = new ProjectKreator();
            pk.Load(path);

            return;
        }

        static void Debug(string format, params object[] args)
        {
            if (verbosity > 0)
            {
                Console.Write("# ");
                Console.WriteLine(format, args);
            }

            return;
        }

        static void ShowHelp(Mono.Options.OptionSet p)
        {
            Console.WriteLine("Usage: greet [OPTIONS]+ message");
            Console.WriteLine("Greet a list of individuals with an optional message.");
            Console.WriteLine("If no message is specified, a generic greeting is used.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);

            return;
        }
    }
}
