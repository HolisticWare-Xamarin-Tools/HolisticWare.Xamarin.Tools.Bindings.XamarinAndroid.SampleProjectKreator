using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindings.Sample.Project.Kreator.App.Console.Mono
{
    public partial class ProjectData
    {
        static void ConcatARCoreSceneform()
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
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "Animation",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/animation/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/Animation/"
                        ),
                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "AugmentedFaces",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/augmentedfaces/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/AugmentedFaces/"
                        ),
                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "AugmentedImage",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/augmentedimage/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/AugmentedImage/"
                        ),
                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "ChromaKeyVideo",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/chromakeyvideo/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/ChromaKeyVideo/"
                        ),
                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "HelloSceneform",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/hellosceneform/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/HelloSceneform/"
                        ),
                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "SolarSystem",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/solarsystem/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/SolarSystem/"
                        ),
                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "VideoRecording",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-android-sdk-master/samples/videorecording/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/VideoRecording/"
                        ),


                        (
                            GroupName : "Sceneform",
                            FeatureName : "Sceneform",   // Folder
                            ProjectName : "GoogleCodeLabsIntro",    // SubFolder
                            InputFolderPath : $"../../externals/sceneform-intro-master/Completed/app/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/Sceneform/GoogleCodeLabsIntro/"
                        ),





                        (
                            GroupName : "ARCore",
                            FeatureName : "ARCore",   // Folder
                            ProjectName : "AugmentedImage",    // SubFolder
                            InputFolderPath : $"../../externals/arcore-android-sdk-master/samples/augmented_image_java/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/ARCore/AugmentedImage/"
                        ),
                        (
                            GroupName : "ARCore",
                            FeatureName : "ARCore",   // Folder
                            ProjectName : "CloudAnchor",    // SubFolder
                            InputFolderPath : $"../../externals/arcore-android-sdk-master/samples/cloud_anchor_java/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/ARCore/CloudAnchor/"
                        ),
                        (
                            GroupName : "ARCore",
                            FeatureName : "ARCore",   // Folder
                            ProjectName : "ComputerVision",    // SubFolder
                            InputFolderPath : $"../../externals/arcore-android-sdk-master/samples/computervision_java/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/ARCore/ComputerVision/"
                        ),
                        (
                            GroupName : "ARCore",
                            FeatureName : "ARCore",   // Folder
                            ProjectName : "HelloAR",    // SubFolder
                            InputFolderPath : $"../../externals/arcore-android-sdk-master/samples/hello_ar_java/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/ARCore/HelloAR/"
                        ),
                        (
                            GroupName : "ARCore",
                            FeatureName : "ARCore",   // Folder
                            ProjectName : "ComputerVision",    // SubFolder
                            InputFolderPath : $"../../externals/arcore-android-sdk-master/samples/computervision_java/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/ARCore/ComputerVision/"
                        ),
                        (
                            GroupName : "ARCore",
                            FeatureName : "ARCore",   // Folder
                            ProjectName : "SharedCamera",    // SubFolder
                            InputFolderPath : $"../../externals/arcore-android-sdk-master/samples/shared_camera_java/",
                            OutputFolderPath : $"../../../../hw-tools/Xamarin.Android.Samples/samples/ARCore/SharedCamera/"
                        ),

                    }
                ).ToList();

            return;
        }
    }
}
