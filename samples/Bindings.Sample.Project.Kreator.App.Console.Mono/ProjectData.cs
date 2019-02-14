using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public partial class ProjectData
    {
        static ProjectData()
        {
            ProjectsDataToConvert =
                new List<(
                            string GroupName,
                            string FeatureName,
                            string ProjectName,
                            string InputFolderPath,
                            string OutputFolderPath
                        )>
                {

                };

            ConcatAndroidSupport();
            ConcatAndroidX();

            return;
        }

        public static List<
                            (
                                string GroupName,
                                string FeatureName,
                                string ProjectName,
                                string InputFolderPath,
                                string OutputFolderPath
                            )
                        > ProjectsDataToConvert
        {
            get;
            set;
        }


    }
}
