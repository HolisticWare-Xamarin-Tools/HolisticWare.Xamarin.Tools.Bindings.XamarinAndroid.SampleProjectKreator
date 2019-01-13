using System;
using System.Collections.Generic;
using System.IO;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core
{
    public partial class ProjectKreator
    {
        string working_directory = null;
        string runtime_framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;

        Dictionary<string, string> ProjectStructureFolders
        {
            get;
            set;
        }  = new Dictionary<string, string>();

        public void CreateProject()
        {
            working_directory = Environment.CurrentDirectory;

            string output_folder = null;
            string input_folder = null;
            if
               (
                    working_directory.Contains(@"Debug")
                    ||
                    working_directory.Contains(@"Release")
               )
            {
                // IDE Debugging under netfx
                output_folder = Path.Combine(@"..", "..", this.OutputFolderPath);
                input_folder = Path.Combine(@"..", "..", this.InputFolderPath);
            }
            else if (runtime_framework.Contains(".NET Core"))
            {

            }


            ProjectStructureFolders.Add
                                (
                                    "Project Folder", 
                                    Path.Combine(output_folder, ProjectName)
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Assets", 
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Assets")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Properties",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Properties")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/layout",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "layout")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/mipmap-hdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "mipmap-hdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/mipmap-mdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "mipmap-mdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/mipmap-xhdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "mipmap-xhdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/mipmap-xxhdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "mipmap-xxhdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/mipmap-xxxhdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "mipmap-xxxhdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/values",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "values")
                                );

            foreach (KeyValuePair<string, string> kvp in ProjectStructureFolders)
            {
                string folder = kvp.Value;
                if (! Directory.Exists(folder))
                {
                    Console.WriteLine($"Creating Folder: {folder}");
                    Directory.CreateDirectory(folder); 
                }
            }

            string content_directory = Path.Combine(working_directory, "Files");
            string[] folders_output = Directory.GetDirectories(content_directory, "*", SearchOption.AllDirectories);
            string[] files_output = Directory.GetFiles(content_directory, "*", SearchOption.AllDirectories);

            string[] fils_input_java = ProcessInputFilesJavaCode(input_folder);
            string[] fils_input_resources = ProcessInputFilesResources(input_folder);

            return;
        }

        public string[] ProcessInputFilesJavaCode(string input_folder)
        {
            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] files_input = Directory.GetFiles(input_folder, "*.java", SearchOption.AllDirectories);

            return files_input;
        }

        public string[] ProcessInputFilesResources(string input_folder)
        {
            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] files_input = Directory.GetFiles(input_folder, "*.xml", SearchOption.AllDirectories);

            string path_folder_project = ProjectStructureFolders["Project Folder"];
            ProcessProject(path_folder_project);

            foreach (string fi in files_input)
            {
                // https://developer.android.com/guide/topics/resources/providing-resources
                switch (fi)
                {
                    case string a when a.Contains("AndroidManifest.xml"):
                        ProcessInputFilesAndroidManifest(fi);
                        break;
                    case string a when a.Contains("res/layout"):
                        ProcessInputFilesResourcesLayout(fi);
                        break;
                    case string b when b.Contains("res/values"):
                        ProcessInputFilesResourcesValues(fi);
                        break;
                    case string b when b.Contains("res/drawable"):
                        ProcessInputFilesResourcesDrawable(fi);
                        break;
                    case string b when b.Contains("res/mipmap"):
                        ProcessInputFilesResourcesMipMap(fi);
                        break;
                    case string b when b.Contains("res/menu"):
                        ProcessInputFilesResourcesMenu(fi);
                        break;
                    case string b when b.Contains("res/color"):
                        ProcessInputFilesResourcesColor(fi);
                        break;
                    case string b when b.Contains("res/animator"):
                        ProcessInputFilesResourcesAnimator(fi);
                        break;
                    case string b when b.Contains("res/anim"):
                        ProcessInputFilesResourcesAnim(fi);
                        break;
                    case string b when b.Contains("res/raw"):
                        ProcessInputFilesResourcesRaw(fi);
                        break;
                    case string b when b.Contains("res/xml"):
                        ProcessInputFilesResourcesXML(fi);
                        break;
                    case string b when b.Contains("res/font"):
                        ProcessInputFilesResourcesFonts(fi);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Not used: {fi}");
                        Console.ResetColor();
                        break;
                }

            }

            return files_input;
        }

        private void ProcessProject(string path_folder_project)
        {
            if (!Directory.Exists(path_folder_project))
            {
                Directory.CreateDirectory(path_folder_project);
            }
            string path_content_android_manifest = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "Sample.App.XamarinAndroid.csproj",
                                                            }
                                                        );

            string content_android_manifest = File.ReadAllText(path_content_android_manifest);

            string path_output_android_manifest = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project,
                                                                "Sample.App.XamarinAndroid.csproj",
                                                            }
                                                        );
            File.WriteAllText(path_output_android_manifest, content_android_manifest);

            return;
        }

        private void ProcessInputFilesAndroidManifest(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: AndroidManifest.xml: {fi}");
            Console.ResetColor();

            string path_folder_project01 = ProjectStructureFolders["Project Folder"];
            if (!Directory.Exists(path_folder_project01))
            {
                Directory.CreateDirectory(path_folder_project01);
            }

            string path_folder_project_properties01 = ProjectStructureFolders["Project Folder/Properties"];
            string path_folder_project_properties02 = Path.Combine(path_folder_project01, "Properties");
            if (!Directory.Exists(path_folder_project_properties01))
            {
                Directory.CreateDirectory(path_folder_project_properties01); 
            }

            string path_file = Path.Combine(path_folder_project_properties01, "AndroidManifest.xml.txt");

            File.Copy(fi, path_file, overwrite: true);

            string path_content_android_manifest = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "Properties",
                                                                "AndroidManifest.xml",
                                                            }
                                                        );

            string content_android_manifest = File.ReadAllText(path_content_android_manifest);

            string path_output_android_manifest = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project_properties01,
                                                                "AndroidManifest.xml",
                                                            }
                                                        );
            File.WriteAllText(path_output_android_manifest, content_android_manifest);

            return;
        }

        private void ProcessInputFilesResourcesLayout(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/layout: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesValues(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/values: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesDrawable(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/drawable: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesMipMap(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/mipmap: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesColor(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/color: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesMenu(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/menu: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesAnim(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/anim: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesAnimator(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/animator: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesXML(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/xml: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesRaw(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/raw: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesFonts(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Porcessed: Resources/font: {fi}");
            Console.ResetColor();

            return;
        }

    }
}
