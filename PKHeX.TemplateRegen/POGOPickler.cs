using PoGoEncTool.Core;
using System;
using System.IO;

namespace PKHeX.TemplateRegen;

public class POGOPickler(string PKHeXRepoPath, string PGETJSONPath)
{
    public void Update()
    {
        Console.WriteLine("Creating PGET Pickles");
        var dest = Path.Combine(PKHeXRepoPath, @"PKHeX.Core\Resources\legality\wild");
        var json = Path.Combine(PGETJSONPath, @"Resources\data.json");
        DataLoader.SavePickles(dest, json);
    }
}