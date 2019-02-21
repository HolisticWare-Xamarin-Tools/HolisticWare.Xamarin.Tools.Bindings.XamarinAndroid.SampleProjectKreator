using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                                    "Project Folder/Resources/drawable-ldpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-ldpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable-mdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-mdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable-hdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-hdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable-nodpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-nodpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable-xdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-xdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable-xxdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-xxdpi")
                                );
            ProjectStructureFolders.Add
                                (
                                    "Project Folder/Resources/drawable-xxxdpi",
                                    Path.Combine(ProjectStructureFolders["Project Folder"], "Resources", "drawable-xxxdpi")
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

            path_folder_project = ProjectStructureFolders["Project Folder"];

            //----------------------------------------------------------------------------------------------
            if (!Directory.Exists(path_folder_project))
            {
                Directory.CreateDirectory(path_folder_project);
            }

            path_content_project_csproj = Path.Combine
                                                    (
                                                        new string[]
                                                        {
                                                            "Files",
                                                            "Sample.App.XamarinAndroid",
                                                            "Sample.App.XamarinAndroid.csproj",
                                                        }
                                                    );
            path_output_project_csproj = Path.Combine
                                                    (
                                                        new string[]
                                                        {
                                                            path_folder_project,
                                                            //"Sample.App.XamarinAndroid.csproj",
                                                            $"{ProjectName}.csproj"
                                                        }
                                                    );

            content_project_csproj = File.ReadAllText(path_content_project_csproj);

            File.WriteAllText(path_output_project_csproj, content_project_csproj);
            //----------------------------------------------------------------------------------------------

            InitializaXmlDocument();
            ProcessProject(path_folder_project);

            string content_directory = Path.Combine(working_directory, "Files");
            string[] folders_output = Directory.GetDirectories(content_directory, "*", SearchOption.AllDirectories);
            string[] files_output = Directory.GetFiles(content_directory, "*", SearchOption.AllDirectories);

            string[] fils_input_java = ProcessInputFilesJavaCode(input_folder);
            string[] fils_input_kotlin = ProcessInputFilesKotlinCode(input_folder);
            string[] fils_input_resources = ProcessInputFilesResources(input_folder);

            ProcessInputFilesPackagesConfig();

            return;
        }

        string path_folder_project = null;

        private void InitializaXmlDocument()
        {
            xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(path_output_project_csproj);

            ns = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);
            ns.AddNamespace("msbld", "http://schemas.microsoft.com/developer/msbuild/2003");

            return;
        }

        public string[] ProcessInputFilesJavaCode(string input_folder)
        {
            string path_folder_project = ProjectStructureFolders["Project Folder"];

            //----------------------------------------------------------------------------------------------
            string path_content_main_activity = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "MainActivity.cs",
                                                            }
                                                        );

            string content_main_activity = File.ReadAllText(path_content_main_activity);

            string path_output_main_activity = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project,
                                                                "MainActivity.cs",
                                                            }
                                                        );
            File.WriteAllText(path_output_main_activity, content_main_activity);
            //----------------------------------------------------------------------------------------------

            //if (input_folder.Contains($@"output/repos"))
            //{
            //    input_folder = input_folder.Replace("../../", "");
            //}
            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] files_input = Directory.GetFiles(input_folder, "*.java", SearchOption.AllDirectories);

            string path_common = this.GetFolderCommon(files_input);
            string folder_code_java_csharp = Path.Combine
                                            (
                                                path_folder_project,
                                                "code-csharp-ported-from-java"
                                            );
            if (!Directory.Exists(folder_code_java_csharp))
            {
                Directory.CreateDirectory(folder_code_java_csharp);
            }

            foreach (string fi in files_input)
            {
                bool skip_tests = false;
                switch(fi)
                {
                    case string a when a.Contains ("app/src/androidTest/java"):
                        skip_tests = true;
                        break;
                    case string a when a.Contains ("app/src/androidTest"):
                        skip_tests = true;
                        break;
                    case string a when a.Contains ("src/androidTest"):
                        skip_tests = true;
                        break;
                    case string a when a.Contains ("androidTest"):
                        skip_tests = true;
                        break;
                    default:
                        break;
                }

                if (true == skip_tests)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"      skipping Java code for tests");
                    Console.WriteLine($"            file = {fi}");
                    Console.ResetColor();
                    continue;
                }

                string filename = Path.GetFileName(fi);
                string fo = Path.Combine(folder_code_java_csharp, $"{filename}.cs");
                File.Copy(fi, fo, overwrite: true);

                //----------------------------------------------------------------------------------------------
                string node_to_find =
                    $@"/msbld:Project/msbld:ItemGroup/msbld:Compile[@Include='MainActivity.cs']"
                    ;
                System.Xml.XmlNode node = xmldoc.SelectSingleNode(node_to_find, ns);

                System.Xml.XmlNode node_new = xmldoc.CreateNode
                                                        (
                                                            System.Xml.XmlNodeType.Element,
                                                            "Compile",
                                                            "http://schemas.microsoft.com/developer/msbuild/2003"
                                                        );
                System.Xml.XmlAttribute attribute_compile = xmldoc.CreateAttribute("Include");
                attribute_compile.Value = $@"code-csharp-ported-from-java\{filename}.cs";
                node_new.Attributes.Append(attribute_compile);

                node?.ParentNode.AppendChild(node_new);
                //----------------------------------------------------------------------------------------------

                //Transpile(fo);
            }

            return files_input;
        }

        public string[] ProcessInputFilesKotlinCode(string input_folder)
        {
            string path_folder_project = ProjectStructureFolders["Project Folder"];

            //----------------------------------------------------------------------------------------------
            string path_content_main_activity = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "MainActivity.cs",
                                                            }
                                                        );

            string content_main_activity = File.ReadAllText(path_content_main_activity);

            string path_output_main_activity = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project,
                                                                "MainActivity.cs",
                                                            }
                                                        );
            File.WriteAllText(path_output_main_activity, content_main_activity);
            //----------------------------------------------------------------------------------------------


            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] files_input = Directory.GetFiles(input_folder, "*.kt", SearchOption.AllDirectories);

            string folder_code_java_csharp = Path.Combine
                                            (
                                                path_folder_project,
                                                "code-csharp-ported-from-java"
                                            );
            if (! Directory.Exists(folder_code_java_csharp))
            {
                Directory.CreateDirectory(folder_code_java_csharp);
            }

            foreach (string fi in files_input)
            {
                string filename = Path.GetFileName(fi);
                string fo = Path.Combine(folder_code_java_csharp, $"{filename}.cs");
                File.Copy(fi, fo, overwrite: true);

                //----------------------------------------------------------------------------------------------
                string node_to_find =
                    $@"/msbld:Project/msbld:ItemGroup/msbld:Compile[@Include='MainActivity.cs']"
                    ;
                System.Xml.XmlNode node = xmldoc.SelectSingleNode(node_to_find, ns);

                System.Xml.XmlNode node_new = xmldoc.CreateNode
                                                        (
                                                            System.Xml.XmlNodeType.Element,
                                                            "Compile",
                                                            "http://schemas.microsoft.com/developer/msbuild/2003"
                                                        );
                System.Xml.XmlAttribute attribute_compile = xmldoc.CreateAttribute("Include");
                attribute_compile.Value = $@"code-csharp-ported-from-java\{filename}.cs";
                node_new.Attributes.Append(attribute_compile);

                node?.ParentNode.AppendChild(node_new);
                //----------------------------------------------------------------------------------------------

                //Transpile(fo);
            }

            return files_input;
        }

        public void ProcessInputFilesPackagesConfig()
        {
            string path_folder_project = ProjectStructureFolders["Project Folder"];

            //----------------------------------------------------------------------------------------------
            string path_content_packages_config = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "packages.config",
                                                            }
                                                        );

            string content_packages_config = File.ReadAllText(path_content_packages_config);

            string path_output_packages_config = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project,
                                                                "packages.config",
                                                            }
                                                        );
            File.WriteAllText(path_output_packages_config, content_packages_config);
            //----------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------
            string node_to_remove =
                $@"/msbld:Project/msbld:ItemGroup/msbld:AndroidResource[@Include='\Icon.png']"
                ;
            System.Xml.XmlNode node = xmldoc.SelectSingleNode(node_to_remove, ns);
            node?.ParentNode.RemoveChild(node);
            //----------------------------------------------------------------------------------------------

            return;
        }

        public string[] ProcessInputFilesResources(string input_folder)
        {
            string[] folders_input = Directory.GetDirectories(input_folder, "*", SearchOption.AllDirectories);
            string[] files_input = Directory.GetFiles(input_folder, "*.*", SearchOption.AllDirectories);

            string path_folder_project = ProjectStructureFolders["Project Folder"];

            foreach (string fi in files_input)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Processed::     {fi}");
                Console.ResetColor();

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

            xmldoc.DocumentElement.InnerXml +=
                nodes_compile_java_xml_snippet
                + Environment.NewLine +
                nodes_android_resources_xml_snippet
                + Environment.NewLine +
                "<!-- mc++ moljac -->"
                + Environment.NewLine
                ;

            xmldoc.Save(path_output_project_csproj);

            return files_input;
        }


        System.Xml.XmlDocument xmldoc = null;
        System.Xml.XmlNamespaceManager ns = null;
        System.Xml.XmlNode node_namespace = null;
        System.Xml.XmlNode node_assembly = null;
        System.Xml.XmlNode node_project_guid = null;

        System.Xml.XmlNodeList nodes_compile = null;

        string nodes_compile_java_xml_snippet =
           $"<ItemGroup xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"
                + Environment.NewLine +
            $@"     <!-- <Compile Include=""test.cs"" /> -->"
                + Environment.NewLine +
            $"</ItemGroup>"
            ;

        string nodes_android_resources_xml_snippet =
           $"<ItemGroup xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"
                + Environment.NewLine +
            $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                + Environment.NewLine +
            $"</ItemGroup>"
            ;

        string content_project_csproj = null;

        string path_output_project_csproj = null;

        string path_content_project_csproj = null;

        private void ProcessProject(string path_folder_project)
        {
            //System.Xml.XmlNodeList nodes = xmldoc.SelectNodes("//msbld:RootNamespace", ns);
            node_namespace = xmldoc.SelectSingleNode("//msbld:RootNamespace", ns);
            node_assembly = xmldoc.SelectSingleNode("//msbld:AssemblyName", ns);
            node_project_guid = xmldoc.SelectSingleNode("//msbld:ProjectGuid", ns);

            node_namespace.InnerText = this.ProjectName;

            node_assembly.InnerText = this.ProjectName;

            node_project_guid.InnerText = Guid.NewGuid().ToString();

            nodes_compile = xmldoc.SelectNodes(@"/msbld:Project/msbld:ItemGroup/msbld:Compile", ns);


            return;
        }

        private void ProcessInputFilesAndroidManifest(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: AndroidManifest.xml: {fi}");
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

            //----------------------------------------------------------------------------------------------
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
            //----------------------------------------------------------------------------------------------


            string path_content_assembly_info = Path.Combine
                                                       (
                                                           new string[]
                                                           {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "Properties",
                                                                "AssemblyInfo.cs",
                                                           }
                                                       );

            string content_assembly_info = File.ReadAllText(path_content_assembly_info);

            content_assembly_info = content_assembly_info.Replace("Sample.App.XamarinAndroid", this.ProjectName);

            string path_output_assembly_info = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project_properties01,
                                                                "AssemblyInfo.cs",
                                                            }
                                                        );
            File.WriteAllText(path_output_assembly_info, content_assembly_info);


            string path_content_resources_designer = Path.Combine
                                                       (
                                                           new string[]
                                                           {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "Resources",
                                                                "Resource.designer.cs",
                                                           }
                                                       );

            string content_resources_designer = File.ReadAllText(path_content_resources_designer);

            string path_folder_project_properties03 = ProjectStructureFolders["Project Folder/Resources"];
             string path_output_resources_designer = Path.Combine
                                                        (
                                                            new string[]
                                                            {
                                                                path_folder_project_properties03,
                                                                "Resource.designer.cs",
                                                            }
                                                        );
            File.WriteAllText(path_output_resources_designer, content_resources_designer);


            string path_content_about_resources = Path.Combine
                                                       (
                                                           new string[]
                                                           {
                                                                "Files",
                                                                "Sample.App.XamarinAndroid",
                                                                "Resources",
                                                                "AboutResources.txt",
                                                           }
                                                       );

            string content_about_resources = File.ReadAllText(path_content_about_resources);

            string path_output_about_resources = Path.Combine
                                                       (
                                                           new string[]
                                                           {
                                                                path_folder_project_properties03,
                                                                "AboutResources.txt",
                                                           }
                                                       );
            File.WriteAllText(path_output_about_resources, content_about_resources);


            string node_to_find =
                @"/msbld:Project/msbld:ItemGroup/msbld:None[@Include='Properties\AndroidManifest.xml']"
                ;
            System.Xml.XmlNode node_new = xmldoc.CreateNode
                                                    (
                                                        System.Xml.XmlNodeType.Element, 
                                                        "None",
                                                        "http://schemas.microsoft.com/developer/msbuild/2003"
                                                    );
            System.Xml.XmlAttribute attribute_none = xmldoc.CreateAttribute("Include");
            attribute_none.Value = @"Properties\AndroidManifest.xml.txt";
            node_new.Attributes.Append(attribute_none);

            System.Xml.XmlNode node = xmldoc.SelectSingleNode(node_to_find, ns);
            node?.ParentNode.AppendChild(node_new);

            return;
        }

        private void ProcessInputFilesResourcesLayout(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/layout: {fi}");
            Console.ResetColor();

            string filename = Path.GetFileName(fi).Replace(".xml", ".axml");
            string output_project_folder = ProjectStructureFolders["Project Folder"];
            string fo = Path.Combine
                                (
                                    output_project_folder,
                                    "Resources",
                                    "layout",
                                    filename
                                );
            File.Copy(fi, fo, overwrite: true);

            //----------------------------------------------------------------------------------------------
            string old = 
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            string @new =
                $@"       <AndroidResource Include=""Resources\layout\{filename}"" />"
                + Environment.NewLine +
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            nodes_android_resources_xml_snippet = nodes_android_resources_xml_snippet.Replace(old, @new);
            //----------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------
            string node_to_remove =
                @"/msbld:Project/msbld:ItemGroup/msbld:AndroidResource[@Include='Resources\layout\Main.axml']"
                //@"/Project/ItemGroup/AndroidResource[@Include='Resources\\layout\\Main.axml']"
                ;
            System.Xml.XmlNode node = xmldoc.SelectSingleNode(node_to_remove, ns);
            node?.ParentNode.RemoveChild(node);
            //----------------------------------------------------------------------------------------------

            return;
        }

        private void ProcessInputFilesResourcesValues(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/values: {fi}");
            Console.ResetColor();

            //----------------------------------------------------------------------------------------------
            string filename = Path.GetFileName(fi);
            string output_project_folder = ProjectStructureFolders["Project Folder"];
            string fo = Path.Combine
                                (
                                    output_project_folder,
                                    "Resources",
                                    "values",
                                    filename
                                );
            File.Copy(fi, fo, overwrite: true);
            //----------------------------------------------------------------------------------------------

            string old =
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            string @new =
                $@"       <AndroidResource Include=""Resources\values\{filename}"" />"
                + Environment.NewLine +
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            nodes_android_resources_xml_snippet = nodes_android_resources_xml_snippet.Replace(old, @new);

            return;
        }

        private void ProcessInputFilesResourcesDrawable(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/drawable: {fi}");
            Console.ResetColor();

            string filename = Path.GetFileName(fi);
            string output_project_folder = ProjectStructureFolders["Project Folder"];
            string fo = Path.Combine
                                (
                                    output_project_folder,
                                    "Resources",
                                    "drawable",
                                    filename
                                );
            File.Copy(fi, fo, overwrite: true);

            //----------------------------------------------------------------------------------------------
            string old =
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            string @new =
                $@"       <AndroidResource Include=""Resources\drawable\{filename}"" />"
                + Environment.NewLine +
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            nodes_android_resources_xml_snippet = nodes_android_resources_xml_snippet.Replace(old, @new);
            //----------------------------------------------------------------------------------------------

            return;
        }

        private void ProcessInputFilesResourcesMipMap(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/mipmap: {fi}");
            Console.ResetColor();

            //----------------------------------------------------------------------------------------------
            string filename = Path.GetFileName(fi);
            string[] path_parts = fi.Split(new char[] { '/' });
            string folder = path_parts[path_parts.Length - 2];
            string output_project_folder = ProjectStructureFolders["Project Folder"];
            string output_project_folder_mipmap = Path.Combine
                                                            (
                                                                output_project_folder,
                                                                "Resources",
                                                                folder
                                                            );
            if (! Directory.Exists(output_project_folder_mipmap))
            {
                Directory.CreateDirectory(output_project_folder_mipmap);
            }
            string fo = Path.Combine
                                (
                                    output_project_folder_mipmap,
                                    filename
                                );
            File.Copy(fi, fo, overwrite: true);
            //----------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------
            string old =
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            string @new =
                $@"       <AndroidResource Include=""Resources\{folder}\{filename}"" />"
                + Environment.NewLine +
                $@"     <!-- <AndroidResource Include=""Resources\layout\Main.axml"" /> -->"
                ;

            nodes_android_resources_xml_snippet = nodes_android_resources_xml_snippet.Replace(old, @new);
            //----------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------------
            string node_to_remove =
                $@"/msbld:Project/msbld:ItemGroup/msbld:AndroidResource[@Include='Resources\{folder}\Icon.png']"
                ;
            System.Xml.XmlNode node = xmldoc.SelectSingleNode(node_to_remove, ns);
            node?.ParentNode.RemoveChild(node);
            //----------------------------------------------------------------------------------------------

            return;
        }

        private void ProcessInputFilesResourcesColor(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/color: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesMenu(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/menu: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesAnim(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/anim: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesAnimator(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/animator: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesXML(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/xml: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesRaw(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/raw: {fi}");
            Console.ResetColor();

            return;
        }

        private void ProcessInputFilesResourcesFonts(string fi)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processed:: Resources/font: {fi}");
            Console.ResetColor();

            return;
        }

        private void Transpile(string fo)
        {
            throw new NotImplementedException();
        }

        private string GetFolderCommon(string[] files_input)
        {
            Dictionary < string, (int Length, string[] Parts)> path_parts = null;
            path_parts = new Dictionary<string, (int Length, string[] Parts)>();

            List<string> path_parts_common = new List<string>();
            int length_max = 0;

            string path_common = null;

            for(int i = 0; i < files_input.Length; i++)
            {
                string[] parts = files_input[i].Split
                        (
                            new char[]
                            {
                                Path.PathSeparator,
                                Path.DirectorySeparatorChar
                            },
                            StringSplitOptions.None
                        );
                int l = parts.Length;
                if ( l > length_max)
                {
                    length_max = l;
                }

                path_parts.Add(files_input[i], (Length: l, Parts: parts));
            }

            for (int j = 0; j < length_max; j++)
            {
                bool is_part_equal = false;
                string part = (path_parts.ElementAt(j).Value.Parts[0]);

                for(int i = 1; i < path_parts.Count; i++)
                {
                    string part_next = (path_parts.ElementAt(j).Value.Parts[i]);

                    if (part == part_next)
                    {
                        is_part_equal = true;
                        path_parts_common.Add(part);
                    }
                    else
                    {
                        is_part_equal = false;
                        break;
                    }
                }

            }

            return path_common;
        }


    }
}
