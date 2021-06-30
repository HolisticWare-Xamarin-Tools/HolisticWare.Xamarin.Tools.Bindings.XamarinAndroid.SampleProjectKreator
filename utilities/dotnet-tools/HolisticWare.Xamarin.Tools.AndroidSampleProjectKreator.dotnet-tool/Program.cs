using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using Spectre.Console;
using System.CommandLine.IO;
using System.Threading.Tasks;

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.CLI;
using System.Reflection;

namespace HolisticWare.Xamarin.Tools.AndroidSampleProjectKreator
{
    static class Program
    {
        static ProjectKreator project_kreator = null;

        public async static Task<int> Main(string[] args)
        {
            AnsiConsole.Render
                (
                    new FigletText("Android-Sample-Kreator")
                            .Color(new Color(89, 48, 1))
                );
            // Create a root command with some options
            RootCommand root_commamd = null;
            root_commamd = new RootCommand
            {
                Name = "Android-Sample-Kreator",
                Description = "Android Sample Project Kreator"
            };

            root_commamd.AddCommand(Create());

            // Parse the incoming args and invoke the handler
            return await root_commamd.InvokeAsync(args);
        }

        private static Command Create()
        {
            Command cmd = new Command("create", "create Android sample app project");

            cmd.AddOption
                (
                    new Option
                            (
                                aliases: new[] { "--input-folder", "--input", "-i" },
                                description: "Input folder (Maven/Gradle)",
                                argumentType: typeof(DirectoryInfo),
                                getDefaultValue: null,
                                arity: ArgumentArity.ExactlyOne
                            )
                );
            cmd.AddOption
                (
                    new Option
                            (
                                aliases: new[] { "--output", "-o" },
                                description: "Output folder (Xamarin.Android .NET)",
                                argumentType: typeof(DirectoryInfo),
                                getDefaultValue: null,
                                arity: ArgumentArity.ExactlyOne
                            )
                );
            cmd.AddOption
                (
                    new Option
                            (
                                aliases: new[] { "--name", "-n" },
                                description: "Project name (Xamarin.Android .NET)",
                                argumentType: typeof(string),
                                getDefaultValue: null,
                                arity: ArgumentArity.ExactlyOne
                            )
                );

            cmd.WithHandler(nameof(HandleCreate));

            return cmd;
        }

        private static int HandleCreate(DirectoryInfo inputFolder, DirectoryInfo output, string name, IConsole console)
        {
            if (inputFolder == null)
            {
                console.Out.WriteLine("Required option input missing");
                return 1;
            }

            if (output == null)
            {
                console.Out.WriteLine("Required option output missing");
                return 1;
            }

            project_kreator = new ProjectKreator()
            {
                InputFolderPath = inputFolder.ToString(),
                OutputFolderPath = output.ToString(),
                ProjectName = name
            };

            project_kreator.CreateProject();

            return 0;
        }
        private static Command WithHandler(this Command command, string methodName)
        {
            MethodInfo? method = typeof(Program).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            ICommandHandler handler = CommandHandler.Create(method!);
            command.Handler = handler;
            return command;
        }
    }
}
