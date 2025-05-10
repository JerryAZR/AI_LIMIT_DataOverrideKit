# AI_LIMIT_DataOverrideKit

A modding utility for overriding various in-game data of *AI LIMIT*, including weapons, skills, and more — with clean, config-based control.

---

## 📦 Installation

1. Install [MelonLoader](https://melonwiki.xyz/#/?id=requirements) if you haven’t already.
2. Download the latest release from [Releases](https://github.com/JerryAZR/AI_LIMIT_DataOverrideKit/releases).
3. Extract and place the `DataOverrideKit.dll` file into your `Mods` folder.
4. Launch the game to initialize the mod.

* If you have used previous versions of this mod, please make sure to delete the old dlls and move/review your configs to prevent mod conflicts.

---

## ⚙️ Usage

All overrides are defined in external JSON files, placed in the `UserData/DataOverrideKit/` folder.

Each file is automatically parsed and applied on game start.

See the documentation for supported formats:

- [Weapon Overrides](./Docs/WeaponOverride.md)
- [Skill Overrides](./Docs/SkillOverride.md)
- [Accessory Overrides](./Docs/AccessoryOverride.md)
- [Armor Overrides](./Docs/ArmorOverride.md) *(planned)*

---

## 🔧 Uninstallation

To fully remove all changes made by this mod:

1. Delete all config files under `UserData\DataOverrideKit\` (e.g. `*.json`).
2. Launch the game **with this mod still enabled**.
3. Confirm that all overridden data has reverted to normal in-game.
4. Save the game.
5. You can now safely remove the mod DLL.

> 💡 If you only want to undo a specific override (e.g. one weapon or item), you can simply remove the corresponding JSON file or entry instead of deleting everything.

---

## ⚠️ Save File Warning

While this mod does **not directly modify** your save file, some override changes may persist into it.
For example, if you override a weapon's skill and save the game, that change may remain even after the mod is removed.

These changes are usually not game-breaking and can often be undone (see the [Uninstallation](#-uninstallation) section), but to be safe:

> **Always back up your save file before enabling or modifying any mod.**
> Mod developers are not responsible for data loss caused by improper use.
