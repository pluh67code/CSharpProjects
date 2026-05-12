bool exited = false;
ShowMenu();

void ShowMenu() {
    Console.WriteLine("File System");
    Console.WriteLine("vf: View Files");
    Console.WriteLine("mf: Make File");
    Console.WriteLine("df: Delete File");
    Console.WriteLine("cfn: Change File Name");
    //Console.WriteLine("");
    //Console.WriteLine("vd: View Directories");
    //Console.WriteLine("md: Make Directory");
    //Console.WriteLine("dd: Delete Directory");
    //Console.WriteLine("cdn: Change Directory Name");
    Console.WriteLine("");
    Console.WriteLine("sm: Show Menu");
    Console.WriteLine("e: Exit File System");
}

void ViewFiles() {
    Console.WriteLine("file");
}

void MakeFile() {
    Console.WriteLine("file");

}

void DeleteFile() {
    Console.WriteLine("file");

}

void ChangeFileName() {
    Console.WriteLine("file");
}

while (!exited) {
    Console.WriteLine("Enter an option:");
    string userInput = Console.ReadLine().ToLower();

    switch (userInput) {
        case "vf":
            ViewFiles();
            break;
        case "mf":
            MakeFile();
            break;
        case "df":
            DeleteFile();
            break;
        case "cfn":
            ChangeFileName();
            break;
        case "sm":
            ShowMenu();
            break;
        case "e":
            exited = true;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

class File {
    public string Name { get; private set; }
    public string Path { get; private set; }
    public string Size { get; private set; }
    public DateTime CreationDate { get; init; }

    public File(string name) {
        Name = name;
        Path = "N/A";
        Size = $"{50}mb";
        CreationDate = DateTime.Now;
    }
}

class FileSystem {
    public List<File> Files { get; private set; }

    public FileSystem(List<File> files) {
        foreach (File file in files) { 
            if (FileSystem.IsValid(file)) {
                Files.Add(file);
            }
        }
    }

    public static bool IsValid(File file) {
        return true;
    }
}