﻿using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if !WINDOWS_UWP
using System.Windows.Markup;
#endif

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyCopyright("Copyright © SunnyCase 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//将 ComVisible 设置为 false 将使此程序集中的类型
//对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

//若要开始生成可本地化的应用程序，请
//<PropertyGroup> 中的 .csproj 文件中
//例如，如果您在源文件中使用的是美国英语，
//使用的是美国英语，请将 <UICulture> 设置为 en-US。  然后取消
//对以下 NeutralResourceLanguage 特性的注释。  更新
//以下行中的“en-US”以匹配项目文件中的 UICulture 设置。

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: :
// [assembly: AssemblyVersion("1.0.*")]

#if !WINDOWS_UWP
[assembly: XmlnsDefinition("http://schemas.sunnycase.moe/2008/xaml/presentation", "Tomato.Mvvm.Controls", AssemblyName = "Tomato.Mvvm.Xaml")]
[assembly: XmlnsDefinition("http://schemas.sunnycase.moe/2008/xaml/presentation", "Tomato.Mvvm.Converters", AssemblyName = "Tomato.Mvvm.Xaml")]
[assembly: XmlnsDefinition("http://schemas.sunnycase.moe/2008/xaml/presentation", "Tomato.Mvvm.Behaviors", AssemblyName = "Tomato.Mvvm.Xaml")]
#endif