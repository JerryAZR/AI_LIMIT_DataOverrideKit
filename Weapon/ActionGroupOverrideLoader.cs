using Il2CppGameDef;
using MelonLoader;
using System.Text.Json;

namespace DataOverrideKit.Weapon {
    public class ActionGroupOverrideEntry {
        public List<int> ConfidenceCosts { get; set; } = new List<int>();
    }

    public static class ActionGroupOverrideLoader {

        public static Dictionary<ActionType, ActionGroupOverrideEntry> LoadOverrides(string path) {
            Dictionary<ActionType, ActionGroupOverrideEntry> overrides = new();
            try {
                if (!File.Exists(path)) {
                    MelonLogger.Msg($"Override file not found: {path}");
                    return overrides;
                }

                var json = File.ReadAllText(path);
                var raw = JsonSerializer.Deserialize<Dictionary<string, ActionGroupOverrideEntry>>(json);

                foreach (var kvp in raw) {
                    if (Enum.TryParse<ActionType>(kvp.Key, out var actionType)) {
                        overrides[actionType] = kvp.Value;
                    } else {
                        MelonLogger.Warning($"Unknown ActionType: {kvp.Key}");
                    }
                }

                MelonLogger.Msg($"Loaded {overrides.Count} ActionGroup overrides.");
            } catch (Exception ex) {
                MelonLogger.Error($"Failed to load ActionGroup overrides: {ex}");
            }

            return overrides;
        }
    }
}
