using System;
using System.Management.Instrumentation;
using System.IO;
using System.Collections;

[assembly: WmiConfiguration(@"root\bmf_StringProvider", HostingModel = ManagementHostingModel.Decoupled,IdentifyLevel=false)]

[System.ComponentModel.RunInstaller(true)]

public class TheInstaller : DefaultManagementInstaller
{
}

[ManagementEntity(Name = "BmfString", External = false, Singleton = false)]
public class BmfString
{
    [ManagementKey]
    public string String { get; set; }

    [ManagementProbe]
    public long Size
    {
        get
        {
            return String.Length;
        }
    }

    [ManagementProbe]
    public string Upper
    {
        get
        {
            return String.ToUpper();
        }
    }

    [ManagementProbe]
    public string Lower
    {
        get
        {
            return String.ToLower();
        }
    }

    [ManagementBind()]
    public BmfString(string String)
    {
        this.String = String;
    }

    [ManagementEnumerator]
    public static IEnumerable Enumerate()
    {
        Console.WriteLine("enumerating objects");
        string[] sampleStrings = new string[] { "Roma", "Marat", "Anton" };
        foreach (string s in sampleStrings)
        {
            yield return new BmfString(s);
        }
    }
}

[ManagementEntity(Name = "BmfFile", External = false, Singleton = false)]
public class BmfFile
{
    [ManagementKey]
    public string String { get; set; }

    [ManagementProbe]
    public long Size
    {
        get
        {
            return new FileInfo(String).Length;
        }
    }


    [ManagementBind()]
    public BmfFile(string String)
    {
        this.String = String;
    }

    [ManagementEnumerator]
    public static IEnumerable Enumerate()
    {
        Console.WriteLine("enumerating files");

        DirectoryInfo di = new DirectoryInfo("c:\\temp");

        //System.Collections.Generic.List<BmfFile> res = new System.Collections.Generic.List<BmfFile>();

        foreach (FileInfo fi in di.GetFiles())
        {
             yield return new BmfFile(fi.FullName);
        }

        //return res;
    }
}