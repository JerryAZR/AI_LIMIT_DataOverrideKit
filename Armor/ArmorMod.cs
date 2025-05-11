using HarmonyLib;
using Il2CppGameDef;
using Il2Cpptabtoy;
using MelonLoader;

namespace DataOverrideKit.Armor {
    public static class ArmorMod {
        internal static ArmorOverrideCollection ArmorOverrides;
        internal static MelonLogger.Instance Logger;

        public static void Initialize(MelonLogger.Instance logger) {
            Logger = logger;
            logger.Msg("[ArmorMod] Loading ArmorOverrides...");
            ArmorOverrides = ArmorOverrideLoader.LoadOverrides();
        }

        [HarmonyPatch(typeof(Config), "Deserialize", new System.Type[] { typeof(HeadwearDefine), typeof(DataReader) })]
        static class HeadwearPatch {
            static void Postfix(ref HeadwearDefine ins) {
                if (ArmorOverrides.Headwears.TryGetValue(ins.ID, out ArmorOverrideEntry entry)) {
                    if (entry.PhysicsDefense.HasValue) ins.nPhysicsDefenseRate = entry.PhysicsDefense.Value;
                    if (entry.FireDefense.HasValue) ins.nFireDefenseRate = entry.FireDefense.Value;
                    if (entry.ElectricDefense.HasValue) ins.nElectricDefenseRate = entry.ElectricDefense.Value;
                    if (entry.PsychoDefense.HasValue) ins.nPsychoDefenseRate = entry.PsychoDefense.Value;

                    if (entry.InfectResistance.HasValue) ins.InfectResistance = entry.InfectResistance.Value;
                    if (entry.PunctureResistance.HasValue) ins.PunctureResistance = entry.PunctureResistance.Value;
                    if (entry.PoisonResistance.HasValue) ins.PoisonResistance = entry.PoisonResistance.Value;
                }
            }
        }

        [HarmonyPatch(typeof(Config), "Deserialize", new System.Type[] { typeof(BodyDefine), typeof(DataReader) })]
        static class BodyArmorPatch {
            static void Postfix(ref BodyDefine ins) {
                if (ArmorOverrides.BodyArmors.TryGetValue(ins.ID, out ArmorOverrideEntry entry)) {
                    if (entry.PhysicsDefense.HasValue) ins.nPhysicsDefenseRate = entry.PhysicsDefense.Value;
                    if (entry.FireDefense.HasValue) ins.nFireDefenseRate = entry.FireDefense.Value;
                    if (entry.ElectricDefense.HasValue) ins.nElectricDefenseRate = entry.ElectricDefense.Value;
                    if (entry.PsychoDefense.HasValue) ins.nPsychoDefenseRate = entry.PsychoDefense.Value;

                    if (entry.InfectResistance.HasValue) ins.InfectResistance = entry.InfectResistance.Value;
                    if (entry.PunctureResistance.HasValue) ins.PunctureResistance = entry.PunctureResistance.Value;
                    if (entry.PoisonResistance.HasValue) ins.PoisonResistance = entry.PoisonResistance.Value;
                }
            }
        }
    }
}
