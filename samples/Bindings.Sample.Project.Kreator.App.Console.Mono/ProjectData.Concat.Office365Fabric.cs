using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public partial class ProjectData
    {
        static void ConcatOffice365Fabric()
        {            

            ProjectsDataToConvert = ProjectsDataToConvert.Concat
                (
                    new List<(
                                string GroupName,
                                string FeatureName,
                                string ProjectName,
                                string InputFolderPath,
                                string OutputFolderPath
                            )>
                    {
                        (
                            GroupName : "Office365Fabric",
                            FeatureName : "Office365Fabric",   // Folder
                            ProjectName : "UI",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/animation/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/Animation/"
                        ),
                    }
                ).ToList();

            return;
        }
    }
}
