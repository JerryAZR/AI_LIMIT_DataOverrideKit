using HarmonyLib;
using Il2CppGameDef;
using Il2Cpptabtoy;
using MelonLoader;

namespace DataOverrideKit.Accessory {
    public static class AccessoryMod {

        internal static Dictionary<int, AccessoryOverrideEntry> AccessoryOverrides; // Maps weapon family id to skillslot
        internal static MelonLogger.Instance Logger;

        public static void Initialize(MelonLogger.Instance logger) {
            Logger = logger;
            logger.Msg("[AccessoryMod] Loading AccessoryOverrides...");
            AccessoryOverrides = AccessoryOverrideLoader.LoadOverrides();
        }

        [HarmonyPatch(typeof(Config), "Deserialize", new System.Type[] { typeof(AccessoriesDefine), typeof(DataReader) })]
        static class AccessoryPatch {
            static void Postfix (ref AccessoriesDefine ins) {
                if (AccessoryOverrides.TryGetValue(ins.ID, out AccessoryOverrideEntry entry)) {
                    if (entry.CrystalRetentionRate.HasValue) ins.KeepRate = entry.CrystalRetentionRate.Value;
                    if (entry.CrystalAbsorptionRate.HasValue) ins.AbsorbRate = entry.CrystalAbsorptionRate.Value;
                    if (entry.EnergyAbsorption.HasValue) ins.ConfidencePlunderFix = entry.EnergyAbsorption.Value;
                }
            }
        }
    }
}
