﻿using HarmonyLib;
using Il2Cpp;
using Il2CppArchiveDef;
using Il2CppGameDef;
using Il2Cpptabtoy;
using MelonLoader;

namespace DataOverrideKit.Weapon {
    public static class WeaponMod {

        internal static Dictionary<ActionType, ActionGroupOverrideEntry> ActionGroupOverrides;
        internal static Dictionary<string, WeaponOverrideEntry> WeaponOverrides;
        internal static Dictionary<string, WeaponReference> WeaponReferences;
        internal static Dictionary<int, int> SkillSwapById; // Maps skill id to skill id
        internal static Dictionary<int, SkillInfo> SkillInfoByDefineId;
        internal static MelonLogger.Instance Logger;

        public static void Initialize(MelonLogger.Instance logger) {
            Logger = logger;
            logger.Msg("[WeaponMod] Loading ActionGroupOverrides...");
            ActionGroupOverrides = ActionGroupOverrideLoader.LoadOverrides("UserData/DataOverrideKit/ActionGroupOverrides.json");
            logger.Msg("[WeaponMod] Loading WeaponOverrides...");
            WeaponOverrides = WeaponOverrideLoader.LoadOverrides("UserData/DataOverrideKit/WeaponOverrides.json");
            WeaponReferences = WeaponOverrideLoader.LoadReferences("DataOverrideKit.Weapon.WeaponReferences.json");

            SkillSwapById = new();
            SkillInfoByDefineId = new();
        }

        [HarmonyPatch(typeof(Config), "Deserialize", new System.Type[] { typeof(ActionGroupDefine), typeof(DataReader) })]
        static class ActionGroupPatch {
            static void Postfix(ref ActionGroupDefine ins) {
                if (ActionGroupOverrides.TryGetValue(ins.Type, out ActionGroupOverrideEntry entry)) {
                    if (entry.ConfidenceCosts != null) {
                        int numIters = Math.Min(entry.ConfidenceCosts.Count, ins.ConfidenceCostInfos.Count);
                        for (int i = 0; i < numIters; i++) {
                            ins.ConfidenceCostInfos[i].ConfidenceCost = entry.ConfidenceCosts[i];
                        }
                        Logger.Msg($"Patched {numIters} ConfidenceConst(s) of {ins.Type}");
                    }
                }
            }
        }

        [HarmonyPatch(typeof(Config), "Deserialize", new System.Type[] { typeof(WeaponDefine), typeof(DataReader) })]
        static class WeaponPatch {
            static void Postfix(ref WeaponDefine ins) {
                if (WeaponOverrides.TryGetValue(ins.Resource, out WeaponOverrideEntry entry)) {
                    WeaponReference original = WeaponReferences.GetValueOrDefault(ins.Resource, null);
                    WeaponReference replacement = WeaponReferences.GetValueOrDefault(entry.SkillReplacement, null);

                    if (original == null || replacement == null) {
                        Logger.Warning($"Unrecognized entry {ins.Resource} -> {entry.SkillReplacement}");
                        return;
                    }
                    // Check for compatibility
                    if (ins.ActionGroup == replacement.ActionGroup) {
                        // SkillId links to the skill description in game
                        SkillSwapById[ins.SkillId] = replacement.SkillId;
                        ins.SkillId = replacement.SkillId;
                    } else {
                        Logger.Warning(
                            $"Ignoring incompatible Skill override: {ins.Resource}({ins.ActionGroup}) -> {entry.SkillReplacement}({replacement.ActionGroup})");
                    }
                }
            }
        }

        [HarmonyPatch(typeof(BackPackManager), "Init")]
        static class BackPackLoadSkillPatch {
            static void Postfix(ref BackPackManager __instance) {
                Logger.Msg($"Post BackPackManager::Init, SkillDic.Count={__instance.SkillDic.Count}");
                Logger.Msg($"Post BackPackManager::Init, WeaponDic.Count={__instance.WeaponDic.Count}");

                foreach (SkillInfo skill in __instance.SkillDic.Values) {
                    SkillInfoByDefineId[skill.DefineID] = skill;
                }
                // Fix incorrectly swapped skills
                foreach (WeaponInfo weapon in __instance.WeaponDic.Values) {
                    int skillID = SkillSwapById.GetValueOrDefault(weapon.Define.SkillId, weapon.Define.SkillId);
                    if (SkillInfoByDefineId.TryGetValue(skillID, out SkillInfo skillInfo)) {
                        weapon.SpecialSkillSlot = skillInfo.UniqueID;
                    }
                }
            }
        }
    }
}
