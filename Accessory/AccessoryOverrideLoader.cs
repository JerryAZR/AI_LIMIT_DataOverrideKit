using MelonLoader;
using System.Text.Json;
using Tomlet;
using Tomlet.Exceptions;
using Tomlet.Models;

namespace DataOverrideKit.Accessory {
    public class AccessoryOverrideEntry {
        public float? CrystalAbsorptionRate { get; set; }
        public float? CrystalRetentionRate { get; set; }
        public float? EnergyAbsorption { get; set; }
    }
    public static class AccessoryOverrideLoader {
        public static Dictionary<int, AccessoryOverrideEntry> LoadOverrides() {
            Dictionary<int, AccessoryOverrideEntry> overrides = new();
            LoadOverridesJson("UserData/DataOverrideKit/AccessoryOverrides.json", ref overrides);
            LoadOverridesToml("UserData/DataOverrideKit/AccessoryOverrides.toml", ref overrides);
            MelonLogger.Msg($"Loaded {overrides.Count} Accessory overrides.");
            return overrides;
        }

        public static void LoadOverridesJson(string path, ref Dictionary<int, AccessoryOverrideEntry> overrides) {
            try {
                if (!File.Exists(path)) {
                    MelonLogger.Msg($"Override file not found: {path}");
                    return;
                }

                var json = File.ReadAllText(path);
                var raw = JsonSerializer.Deserialize<Dictionary<string, AccessoryOverrideEntry>>(json);

                foreach (var kvp in raw) {
                    if (int.TryParse(kvp.Key, out int id)) {
                        overrides[id] = kvp.Value;
                    } else {
                        MelonLogger.Warning($"Unknown key type: {kvp.Key}");
                    }
                }
            } catch (Exception ex) {
                MelonLogger.Error($"Failed to load Accessory overrides (json): {ex}");
            }
        }

        public static void LoadOverridesToml(string path, ref Dictionary<int, AccessoryOverrideEntry> overrides) {
            if (!File.Exists(path)) {
                MelonLogger.Msg($"Override file not found: {path}");
                return;
            }
            TomlDocument doc = TomlParser.ParseFile(path);

            foreach (var kvp in doc) {
                if (int.TryParse(kvp.Key, out int id)) {
                    try {
                        AccessoryOverrideEntry entry = TomletMain.To<AccessoryOverrideEntry>(kvp.Value);
                        overrides[id] = entry;
                    } catch (TomlException tomlEx) {
                        MelonLogger.Warning($"Exception while parsing {kvp.Value}: {tomlEx}");
                    }
                } else {
                    MelonLogger.Error($"[AccessoryOverrideLoader] Invalid ID: {kvp.Key}");
                }
            }
        }
    }
}