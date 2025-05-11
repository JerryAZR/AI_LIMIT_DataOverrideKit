using DataOverrideKit.Accessory;
using DataOverrideKit.Armor;
using DataOverrideKit.Weapon;
using Il2Cpp;
using MelonLoader;

[assembly: MelonInfo(typeof(DataOverrideKit.DataOverrideKit), "DataOverrideKit", "2.1.0", "Jerry", null)]
[assembly: MelonGame("SenseGames", "AILIMIT")]

namespace DataOverrideKit {
    public class DataOverrideKit : MelonMod {
        public override void OnInitializeMelon() {
            WeaponMod.Initialize(LoggerInstance);
            AccessoryMod.Initialize(LoggerInstance);
            ArmorMod.Initialize(LoggerInstance);
            LoggerInstance.Msg("Initialized.");
        }

        //public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
        //    base.OnSceneWasLoaded(buildIndex, sceneName);

        //    LoggerInstance.Msg("===Accessories===");
        //    foreach (var nuclei in GlobalConfig.ConfigData.Accessories) {
        //        string cs_name = LocalizationManager.Instance.GetLocalByLanguage(nuclei.NameID, UnityEngine.SystemLanguage.ChineseSimplified);
        //        string en_name = LocalizationManager.Instance.GetLocalByLanguage(nuclei.NameID, UnityEngine.SystemLanguage.English);
        //        LoggerInstance.Msg($"{cs_name}/{en_name}:{nuclei.ID}");
        //    }

        //    LoggerInstance.Msg("===Headwears===");
        //    foreach (var item in GlobalConfig.ConfigData.Headwear) {
        //        string cs_name = LocalizationManager.Instance.GetLocalByLanguage(item.NameID, UnityEngine.SystemLanguage.ChineseSimplified);
        //        string en_name = LocalizationManager.Instance.GetLocalByLanguage(item.NameID, UnityEngine.SystemLanguage.English);
        //        LoggerInstance.Msg($"{cs_name}/{en_name}:{item.ID}");
        //    }

        //    LoggerInstance.Msg("===BodyArmors===");
        //    foreach (var item in GlobalConfig.ConfigData.Body) {
        //        string cs_name = LocalizationManager.Instance.GetLocalByLanguage(item.NameID, UnityEngine.SystemLanguage.ChineseSimplified);
        //        string en_name = LocalizationManager.Instance.GetLocalByLanguage(item.NameID, UnityEngine.SystemLanguage.English);
        //        LoggerInstance.Msg($"{cs_name}/{en_name}:{item.ID}");
        //    }
        //}
    }
}