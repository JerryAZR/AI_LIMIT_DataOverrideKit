using MelonLoader;
using System.Text.Json;
using Tomlet;
using Tomlet.Exceptions;
using Tomlet.Models;

namespace DataOverrideKit.Armor {
    public class ArmorOverrideEntry {
        public float? PhysicsDefense { get; set; }
        public float? FireDefense { get; set; }
        public float? ElectricDefense { get; set; }
        public float? PsychoDefense { get; set; }
        public int? PoisonResistance { get; set; }
        public int? PunctureResistance { get; set; }
        public int? InfectResistance { get; set; }
    }

    public class ArmorOverrideCollection {
        public int Count => Headwares.Count + BodyArmors.Count;
        public Dictionary<int, ArmorOverrideEntry> Headwares { get; set; }
        public Dictionary<int, ArmorOverrideEntry> BodyArmors { get; set; }
    }

    public static class ArmorOverrideLoader {
        public static ArmorOverrideCollection LoadOverrides() {
            Dictionary<int, ArmorOverrideEntry> headOverrides = new();
            Dictionary<int, ArmorOverrideEntry> bodyOverrides = new();
            LoadOverridesJson("UserData/DataOverrideKit/ArmorOverrides.json", ref headOverrides, ref bodyOverrides);
            LoadOverridesToml("UserData/DataOverrideKit/ArmorOverrides.toml", ref headOverrides, ref bodyOverrides);
            MelonLogger.Msg($"Loaded {headOverrides.Count} headware overrides and {bodyOverrides.Count} body armor overrides.");
            return new ArmorOverrideCollection { Headwares = headOverrides, BodyArmors = bodyOverrides };
        }

        public static void LoadOverridesJson(string path, ref Dictionary<int, ArmorOverrideEntry> headOverrides, ref Dictionary<int, ArmorOverrideEntry> bodyOverrides) {
            try {
                if (!File.Exists(path)) {
                    MelonLogger.Msg($"Override file not found: {path}");
                    return;
                }

                var json = File.ReadAllText(path);
                var raw = JsonSerializer.Deserialize<Dictionary<string, ArmorOverrideEntry>>(json);

                foreach (var kvp in raw) {
                    // Expect key format H.<ID> or B.<ID>
                    string[] keySplit = kvp.Key.Split(".");
                    if (keySplit.Length == 2 && int.TryParse(keySplit[1], out int id)) {
                        if (keySplit[0].ToUpper() == "H") {
                            headOverrides[id] = kvp.Value;
                        } else if (keySplit[0].ToUpper() == "B")  {
                            bodyOverrides[id] = kvp.Value;
                        } else {
                            MelonLogger.Warning($"Unknown key type: {kvp.Key}");
                        }
                    } else {
                        MelonLogger.Warning($"Unknown key type: {kvp.Key}");
                    }
                }
            } catch (Exception ex) {
                MelonLogger.Error($"Failed to load armor overrides (json): {ex}");
            }
        }

        public static void LoadOverridesToml(string path, ref Dictionary<int, ArmorOverrideEntry> headOverrides, ref Dictionary<int, ArmorOverrideEntry> bodyOverrides) {
            if (!File.Exists(path)) {
                MelonLogger.Msg($"Override file not found: {path}");
                return;
            }
            TomlDocument doc = TomlParser.ParseFile(path);
            if (doc.ContainsKey("H")) {
                TomlTable headTable = doc.GetSubTable("H");
                foreach (var kvp in headTable) {
                    if (int.TryParse(kvp.Key, out int id)) {
                        try {
                            ArmorOverrideEntry entry = TomletMain.To<ArmorOverrideEntry>(kvp.Value);
                            headOverrides[id] = entry;
                        } catch (TomlException tomlEx) {
                            MelonLogger.Warning($"Exception while parsing {kvp.Value}: {tomlEx}");
                        }
                    } else {
                        MelonLogger.Error($"[ArmorOverrideLoader] Invalid headware ID: {kvp.Key}");
                    }
                }
            }

            if (doc.ContainsKey("B")) {
                TomlTable bodyTable = doc.GetSubTable("B");

                foreach (var kvp in bodyTable) {
                    if (int.TryParse(kvp.Key, out int id)) {
                        try {
                            ArmorOverrideEntry entry = TomletMain.To<ArmorOverrideEntry>(kvp.Value);
                            bodyOverrides[id] = entry;
                        } catch (TomlException tomlEx) {
                            MelonLogger.Warning($"Exception while parsing {kvp.Value}: {tomlEx}");
                        }
                    } else {
                        MelonLogger.Error($"[ArmorOverrideLoader] Invalid body armor ID: {kvp.Key}");
                    }
                }
            }
        }
    }
}
