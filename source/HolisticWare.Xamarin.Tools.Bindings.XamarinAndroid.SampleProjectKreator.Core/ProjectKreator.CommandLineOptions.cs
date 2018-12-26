using System;
using System.Collections.Generic;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core
{

    public partial class ProjectKreator
    {
        /// 
        /// 
        /// 
        /// https://tirania.org/blog/archive/2008/Oct-14.html
        /// http://geekswithblogs.net/robz/archive/2009/11/22/command-line-parsing-with-mono.options.aspx
        /// https://github.com/mono/mono/blob/master/mcs/class/Mono.Options/Mono.Options/Options.cs
        /// https://github.com/mono/mono/blob/master/mcs/class/Mono.Options/Mono.Options/Options.cs
        /// 

        string folder_input_android = null;
        string folder_input_dotnet = null;
        bool show_help = false;
        int verbosity = 0;

        public Mono.Options.OptionSet Options()
        {
            Mono.Options.OptionSet options = null;

            options = new Mono.Options.OptionSet()
            {
                // ../../../../../../../X/AndroidSupportComponents-AndroidX-binderate/output/AndroidSupport.api-diff.xml
                {
                    "n|name",
                    "Name of the project",
                    (string v) =>
                    {
                        folder_input_android = v;
                        return;
                    }
                },
                {
                    "i|input=",
                    "input folder with Android App gradle project",
                    (string v) =>
                    {
                        folder_input_android = v;
                        return;
                    }
                },
                {
                    "o|output=",
                    "output folder with Xamarin.Android Sample App project",
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

            return OptionSet;
        }

        public void Debug(string format, params object[] args)
        {
            if (verbosity > 0)
            {
                Console.Write("# ");
                Console.WriteLine(format, args);
            }

            return;
        }

        public void ShowHelp(Mono.Options.OptionSet p)
        {
            Console.WriteLine("Usage: XamarinAndroidSampleKreator -i= ");
            Console.WriteLine("Create Xamarin.Android Sample (App Project) from gradle project.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);

            return;
        }
    }
}
