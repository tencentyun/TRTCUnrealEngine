// Copyright Epic Games, Inc. All Rights Reserved.
using System.IO;
using UnrealBuildTool;

public class TRTC_Demo : ModuleRules
{
    private string _TRTCSDKPath
    {
        get
        {
            return Path.GetFullPath(Path.Combine(ModuleDirectory, "TRTCSDK"));
        }
    }
    private string _DebugPath
    {
        get
        {
            return Path.GetFullPath(Path.Combine(ModuleDirectory, "debug"));
        }
    }
	public TRTC_Demo(ReadOnlyTargetRules Target) : base(Target)
	{
        bEnableUndefinedIdentifierWarnings = false;
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });
        // //添加系统Framework和库
		//PrivateDependencyModuleNames.AddRange(new string[] { "TencentPlugin" });
		// Uncomment if you are using Slate UI
		PrivateDependencyModuleNames.AddRange(new string[] {"UMG", "Slate", "SlateCore"});
        
        if (Target.Platform == UnrealTargetPlatform.Android)
        {
            
        }else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            // 添加插件的包含路径
            PublicIncludePaths.Add(Path.Combine(_DebugPath, "include"));
            PublicAdditionalLibraries.Add(Path.Combine(_DebugPath, "ios", "libTXLiteAVTestUserSig.a"));
            //PublicAdditionalFrameworks.Add(new UEBuildFramework( "TXLiteAVTestUserSig",_DebugPath+"/ios/TXLiteAVTestUserSig.framework.zip", ""));

            PublicIncludePaths.Add(Path.Combine(_TRTCSDKPath, "include/iOS"));
            PublicAdditionalLibraries.AddRange(new string[] {
                "resolv",
                "z",
                "c++",
            });
            PublicFrameworks.AddRange(
                new string[] {
                    "CoreML",
                    "VideoToolbox",
                    "Accelerate",
                    "CFNetwork",
                    "OpenGLES",
                    "AVFoundation",
                    "CoreTelephony"
                }
            );
            // PublicAdditionalFrameworks.Add(new Framework( "TXLiteAVSDK_TRTC",Path.Combine(_TRTCSDKPath, "iOS","TXLiteAVSDK_TRTC.framework.zip"), "", true));
            PublicAdditionalFrameworks.Add(new UEBuildFramework( "TXLiteAVSDK_TRTC",_TRTCSDKPath+"/ios/TXLiteAVSDK_TRTC.framework.zip", ""));
        }else if(Target.Platform == UnrealTargetPlatform.Mac)
        {
            // 添加插件的包含路径
            PublicIncludePaths.Add(Path.Combine(_DebugPath, "include"));
            PublicFrameworks.Add(Path.Combine(_DebugPath, "Mac", "Release","TXLiteAVTestUserSig.framework"));

            PublicIncludePaths.Add(Path.Combine(_TRTCSDKPath, "include/Mac"));
            PublicAdditionalLibraries.AddRange(new string[] {
                "resolv",
                "z",
                "c++",
                "bz2",
            });
            PublicFrameworks.AddRange(
                new string[] {
                    "AppKit",
                    "IOKit",
                    "CoreVideo",
                    "CFNetwork",
                    "OpenGl",
                    "CoreGraphics",
                    "Accelerate",
                    "CoreFoundation",
                    "SystemConfiguration",
                    "AudioToolbox",
                    "VideoToolbox",
                    "CoreTelephony",
                    "CoreWLAN",
                    "AVFoundation",
                    "CoreMedia",
                    "CoreAudio",
                    "AudioUnit",
                    "Accelerate",
                });
            PublicFrameworks.Add(Path.Combine(_TRTCSDKPath, "Mac", "Release","TXLiteAVSDK_TRTC_Mac.framework"));
        }else if (Target.Platform == UnrealTargetPlatform.Win64)
        {
	        PublicIncludePaths.Add(Path.Combine(_DebugPath, "include"));
            PublicFrameworks.Add(Path.Combine(_DebugPath, "win64", "Release","TXLiteAVTestUserSig.dll"));
            PublicAdditionalLibraries.Add(Path.Combine(_DebugPath, "win64", "Release","TXLiteAVTestUserSig.lib"));
            RuntimeDependencies.Add("$(BinaryOutputDir)/TXLiteAVTestUserSig.dll", Path.Combine(_DebugPath, "win64", "Release", "TXLiteAVTestUserSig.dll"));

            PublicIncludePaths.Add(Path.Combine(_TRTCSDKPath, "include/win64"));
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(_TRTCSDKPath, "win64", "Release","liteav.lib"));

            // Delay-load the DLL, so we can load it from the right place first
            PublicDelayLoadDLLs.Add(Path.Combine(_TRTCSDKPath, "win64", "Release", "liteav.dll"));
            PublicDelayLoadDLLs.Add(Path.Combine(_TRTCSDKPath, "win64", "Release", "LiteAvAudioHook.dll"));
            PublicDelayLoadDLLs.Add(Path.Combine(_TRTCSDKPath, "win64", "Release", "LiteAvAudioHookService.dll"));
            PublicDelayLoadDLLs.Add(Path.Combine(_TRTCSDKPath, "win64", "Release", "openh264.dll"));
            PublicDelayLoadDLLs.Add(Path.Combine(_TRTCSDKPath, "win64", "Release", "TRAE.dll"));

            ////PublicAdditionalLibraries.Add(Path.Combine(_DebugPath, "win64", "Release","zlib.lib"));
            RuntimeDependencies.Add("$(BinaryOutputDir)/liteav.dll", Path.Combine(_TRTCSDKPath, "win64", "Release", "liteav.dll"));
            RuntimeDependencies.Add("$(BinaryOutputDir)/LiteAvAudioHook.dll", Path.Combine(_TRTCSDKPath, "win64", "Release", "LiteAvAudioHook.dll"));
            RuntimeDependencies.Add("$(BinaryOutputDir)/LiteAvAudioHookService.dll", Path.Combine(_TRTCSDKPath, "win64", "Release", "LiteAvAudioHookService.dll"));
            RuntimeDependencies.Add("$(BinaryOutputDir)/openh264.dll", Path.Combine(_TRTCSDKPath, "win64", "Release", "openh264.dll"));
            RuntimeDependencies.Add("$(BinaryOutputDir)/TRAE.dll", Path.Combine(_TRTCSDKPath, "win64", "Release", "TRAE.dll"));
        }
        
		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
   
}
