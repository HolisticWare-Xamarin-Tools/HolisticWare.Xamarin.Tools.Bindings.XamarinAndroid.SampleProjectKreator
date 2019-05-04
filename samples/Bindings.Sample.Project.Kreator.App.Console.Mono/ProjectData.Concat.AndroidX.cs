using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public partial class ProjectData
    {
        static void ConcatAndroidX()
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
                            GroupName : "AndroidX-JetPack",
                            FeatureName : "Java",
                            ProjectName : "JetPack-Navigation",
                            InputFolderPath : $"../../output/repos/AndroidX-JetPack-java/JetPack-Navigation/app",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX-JetPack/Java/JetPack-Navigation/app"
                        ),
                        (
                            GroupName : "AndroidX-JetPack",
                            FeatureName : "Java",
                            ProjectName : "Material2",
                            InputFolderPath : $"../../output/repos/AndroidX-JetPack-java/Material2",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX-JetPack/Java/JMaterial2/app"
                        ),
                        (
                            GroupName : "AndroidX-JetPack",
                            FeatureName : "Java",
                            ProjectName : "WAX-Trade-Client",
                            InputFolderPath : $"../../output/repos/AndroidX-JetPack-java/WAX-Trade-Client",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX-JetPack/Java/WAX-Trade-Client/app"
                        ),
                        (
                            GroupName : "AndroidX-JetPack",
                            FeatureName : "Java",
                            ProjectName : "Deadline",
                            InputFolderPath : $"../../output/repos/AndroidX-JetPack-java/Deadline",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX-JetPack/Java/Deadline/app"
                        ),

                    }
                ).ToList();

            return;
        }
    }
}
