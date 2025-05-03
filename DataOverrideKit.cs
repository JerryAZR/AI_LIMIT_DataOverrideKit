using DataOverrideKit.Weapon;
using MelonLoader;

[assembly: MelonInfo(typeof(DataOverrideKit.DataOverrideKit), "DataOverrideKit", "2.0.0", "Jerry", null)]
[assembly: MelonGame("SenseGames", "AILIMIT")]

namespace DataOverrideKit {
    public class DataOverrideKit : MelonMod {
        public override void OnInitializeMelon() {
            WeaponMod.Initialize(LoggerInstance);
            LoggerInstance.Msg("Initialized.");
        }
    }
}