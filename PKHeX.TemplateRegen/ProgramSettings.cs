﻿namespace PKHeX.TemplateRegen;

using System.Text.Json.Serialization;

[JsonSerializable(typeof(ProgramSettings))]
public sealed partial class ProgramSettingsContext : JsonSerializerContext;

public class ProgramSettings
{
    public string RepoPathPKHeX { get; set; } = @"C:\Users\BK\source\repos\PKHeX\";
    public string RepoPathEvGal { get; set; } = @"C:\Users\BK\source\repos\EventsGallery";
    public string RepoPathPGET { get; set; } = @"C:\Users\BK\source\repos\PoGoEncTool";
}