using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public class ProjectData
    {
        static void ConcatAndroidX()
        {
            ProjectsDataToConvert.Concat
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
                            GroupName : "AndroidX",
                            FeatureName : "CoordinatorLayout",
                            ProjectName : "HeroBarry",
                            InputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/externals/CoordinatorLayout-HeroBarry/",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Android.Support/CoordinatorLayout/"
                        ),
                    }
                );

            return;
        }
    }
}
