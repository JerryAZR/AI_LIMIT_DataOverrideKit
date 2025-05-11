using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace DataOverrideKit.Weapon {
    public class WeaponOverrideEntry {
        public string SkillReplacement { get; set; }
        // Add more fields later as needed
    }

    public class WeaponReference {
        public string ActionGroup { get; set; }
        public int FamilyID { get; set; }
        public int SkillId { get; set; }

        public override string ToString() {
            return $"{ActionGroup}, SkillId={SkillId}";
        }
    }

    public static class WeaponOverrideLoader {

        public static Dictionary<string, WeaponReference> LoadReferences(string resource) {
            Dictionary<string, WeaponReference> refs = new();

            try {
                var assembly = Assembly.GetExecutingAssembly();
                StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(resource));
                string json = reader.ReadToEnd();
                refs = JsonSerializer.Deserialize<Dictionary<string, WeaponReference>>(json);
            } catch (Exception ex) {
                MelonLogger.Error($"Failed to load weapon references from {resource}:\n{ex}");
            }

            return refs;
        }

        public static Dictionary<string, WeaponOverrideEntry> LoadOverrides(string path) {
            Dictionary<string, WeaponOverrideEntry> overrides = new();

            try {
                if (!File.Exists(path)) {
                    MelonLogger.Warning($"Weapon override config not found: {path}");
                    return overrides;
                }

                var json = File.ReadAllText(path);
                overrides = JsonSerializer.Deserialize<Dictionary<string, WeaponOverrideEntry>>(json);

                MelonLogger.Msg($"Loaded {overrides.Count} weapon overrides from config.");
            } catch (Exception ex) {
                MelonLogger.Error($"Failed to load weapon overrides from {path}:\n{ex}");
            }

            return overrides;
        }
    }
}
