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
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "topeka-base",
                            InputFolderPath : $"../../output/repos/Material-diverse/topeka/base",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/topeka-base/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "topeka-quiz",
                            InputFolderPath : $"/output/repos/Material-diverse/topeka/quiz",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/topeka-quiz/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "topeka-categories",
                            InputFolderPath : $"/output/repos/Material-diverse/topeka/categories",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/topeka-categories/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-app",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/app",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/app/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-1-Base",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/1-Base",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/1-Base/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-2-Color",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/2-Color",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/2-Color"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-3-Layout",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/3-Layout",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/3-Layout"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-4-RecyclerView",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/4-RecyclerView",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/4-RecyclerView"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-5-VectorAssets",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/5-VectorAssets",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/5-VectorAssets"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-6-PageElement",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/6-PageElement",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/6-PageElement"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-6-PageElement",
                            InputFolderPath : $"/output/repos/Material-diverse/design-library/6-PageElement",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/6-PageElement"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "HackerNewsReader",
                            InputFolderPath : $"../output/repos/Material-diverse/HackerNewsReader",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/HackerNewsReader/app"
                        ),




                        (
                            GroupName : "AndroidX.Jetpack",
                            FeatureName : "Java",
                            ProjectName : "JetPack-Navigation",
                            InputFolderPath : $"/output/repos/AndroidX.Jetpack/JetPack-Navigation/app",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX.Jetpack/JetPack-Navigation/app"
                        ),
                        (
                            GroupName : "AndroidX.Jetpack",
                            FeatureName : "Java",
                            ProjectName : "Material2",
                            InputFolderPath : $"/output/repos/AndroidX.Jetpack/Material2",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX.Jetpack/JMaterial2/app"
                        ),
                        (
                            GroupName : "AndroidX.Jetpack",
                            FeatureName : "Java",
                            ProjectName : "WAX-Trade-Client",
                            InputFolderPath : $"/output/repos/AndroidX.Jetpack/WAX-Trade-Client",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX.Jetpack/WAX-Trade-Client/app"
                        ),
                        (
                            GroupName : "AndroidX.Jetpack",
                            FeatureName : "Java",
                            ProjectName : "Deadline",
                            InputFolderPath : $"/output/repos/AndroidX.Jetpack/Deadline",
                            OutputFolderPath : $"/Projects/tmp/Xamarin.Android.Samples/output/AndroidX.Jetpack/Deadline/app"
                        ),

                    }
                ).ToList();

            return;
        }
    }
}
