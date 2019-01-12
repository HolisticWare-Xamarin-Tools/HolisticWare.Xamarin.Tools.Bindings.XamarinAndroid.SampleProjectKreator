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

            string[] fils_input_java = GetInputFilesJavaCode(input_folder);
            string[] fils_input_resources = GetInputFilesResources(input_folder);

            return;
        }

        public string[] GetInputFilesJavaCode(string input_folder)
        {
            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] fils_input = Directory.GetFiles(input_folder, "*.java", SearchOption.AllDirectories);

            return fils_input;
        }

        public string[] GetInputFilesResources(string input_folder)
        {
            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] fils_input = Directory.GetFiles(input_folder, "*.xml", SearchOption.AllDirectories);

            return fils_input;
        }
    }
}
