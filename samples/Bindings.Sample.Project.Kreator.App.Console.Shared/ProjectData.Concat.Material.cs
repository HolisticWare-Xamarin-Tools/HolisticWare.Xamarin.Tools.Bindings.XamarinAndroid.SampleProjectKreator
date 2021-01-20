using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public partial class ProjectData
    {
        static void ConcatMaterial()
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
                            FeatureName : "Material",   // Folder
                            ProjectName : "diverse",    // SubFolder
                            InputFolderPath : $"../../output/repos/Material-diverse/topeka/base",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material/diverse/topeka-base/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "diverse",    // SubFolder
                            InputFolderPath : $"../../output/repos/Material-diverse/topeka/quiz",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material/diverse/topeka-quiz/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "diverse",    // SubFolder
                            InputFolderPath : $"../../output/repos/Material-diverse/topeka/categories",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/topeka-categories/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "diverse",    // SubFolder
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/app",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/app/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/1-Base",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/1-Base/"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/2-Color",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/2-Color"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/3-Layout",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/3-Layout"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/4-RecyclerView",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/4-RecyclerView"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/5-VectorAssets",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/5-VectorAssets"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material-diverse",
                            ProjectName : "design-library-6-PageElement",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/6-PageElement",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/6-PageElement"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/design-library/6-PageElement",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/design-library/6-PageElement"
                        ),
                        (
                            GroupName : "Material",
                            FeatureName : "Material",   // Folder
                            ProjectName : "design-library",
                            InputFolderPath : $"../../output/repos/Material-diverse/HackerNewsReader",
                            OutputFolderPath : $"/Users/Shared/Projects/tmp/Xamarin.Android.Samples/output/Material-diverse/HackerNewsReader/app"
                        ),

                    }
                ).ToList();

            return;
        }
    }
}
