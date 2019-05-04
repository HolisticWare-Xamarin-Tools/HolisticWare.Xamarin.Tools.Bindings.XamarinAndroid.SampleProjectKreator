using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public partial class ProjectData
    {
        static void ConcatGooglePlayServicesAdMob()
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
                            GroupName : "GooglePlayServices",
                            FeatureName : "GooglePlayServices",   // Folder
                            ProjectName : "AdMob",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/GooglePlayServices/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/GooglePlayServices/AdMob/"
                        ),

                    }
                ).ToList();

            return;
        }
    }
}
