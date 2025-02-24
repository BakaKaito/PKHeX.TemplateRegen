using PoGoEncTool.Core;

namespace PKHeX.TemplateRegen;

public class POGOPickler(string PKHeXRepoPath, string PGETJSONPath)
{
    public void Update()
    {
        Console.WriteLine("Creating PGET Pickles");
        var dest = Path.Combine(PKHeXRepoPath, "wild");
        var json = Path.Combine(PGETJSONPath, "data.json");
        DataLoader.SavePickles(dest, json);
    }
}