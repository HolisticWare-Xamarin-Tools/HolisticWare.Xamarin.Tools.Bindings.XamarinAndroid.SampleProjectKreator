#!/bin/bash

dotnet build \
    --project ./HolisticWare.Xamarin.Tools.AndroidSampleProjectKreator.dotnet-tool/HolisticWare.Xamarin.Tools.AndroidSampleProjectKreator.dotnet-tool.csproj  \

dotnet run \
    --project ./HolisticWare.Xamarin.Tools.AndroidSampleProjectKreator.dotnet-tool/HolisticWare.Xamarin.Tools.AndroidSampleProjectKreator.dotnet-tool.csproj  \
    --framework net5.0 \
    -- \
    search