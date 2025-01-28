using System.Runtime.InteropServices;

namespace Search;

class Program
{
    [DllImport("LevelDBSearch.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void search_all_drives(
        [MarshalAs(UnmanagedType.LPWStr)] string folder_name,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] excluded_paths,
        int excluded_paths_count);

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        string folderName = "leveldb";
        string[] excludedPaths = [@"C:\Windows", @"C:\Program Files", @"C:\Program Files (x86)"];

        Console.WriteLine("Searching a specific directory:");
        search_all_drives(folderName, excludedPaths, excludedPaths.Length);
        Console.WriteLine("\nPress any key to exit..."); _ = Console.ReadKey();
    }
}