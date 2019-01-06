using System;
using System.IO;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core
{
    public partial class ProjectKreator
    {
        string current_directory = null;

        public void CreateProject()
        {
            current_directory = Environment.CurrentDirectory;

            string output_folder = null;
            if (current_directory.Contains(@"bin\Debug"))
            {
                output_folder =@"..\.." + this.OutputFolderPath;
            }
            string[] directories = Directory.GetDirectories(output_folder);

            return;
        }
    }
}
