using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

// ReSharper disable CheckNamespace
public static class AssemblyExtensions
// ReSharper restore CheckNamespace
{
    public static string FullLocalPath(this Assembly assembly)
    {
        var codeBase = assembly.CodeBase;
        var uri = new UriBuilder(codeBase);
        var root = Uri.UnescapeDataString(uri.Path);
        root = root.Replace("/", "\\");
        return root;
    }

    public static string GetFileVersion(this Assembly assembly)
    {
        FileVersionInfo fv = FileVersionInfo.GetVersionInfo(assembly.Location);

        return  string.Format("{0}.{1}.{2}.{3}", fv.FileMajorPart, fv.FileMinorPart, fv.FileBuildPart, fv.FilePrivatePart);

    }
}
