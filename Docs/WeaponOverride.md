# WeaponOverrides.json Format

This file allows you to override the special skill assigned to a specific weapon.

## 📄 Location & File Name

* The override config must be placed in: `UserData/DataOverrideKit/`

* The filename must exactly be `WeaponOverrides.json`.

## 📂 Example

See: [WeaponOverrides.json](../ExampleConfigs/WeaponOverrides.json)

```json
{
    "Tachi_Materialism": {
        "SkillReplacement": "Tachi_Mercy"
    },
    "Weapon_to_modify_1": {
        "SkillReplacement": "Weapon_skill_provider_1"
    },
    "Weapon_to_modify_2": {
        "SkillReplacement": "Weapon_skill_provider_2"
    }
}
```

## 🧩 Format Description

Each key in the JSON object is the internal name of a weapon to override. The value must be an object with the following field:

* `SkillReplacement` — the internal name of another weapon whose skill should be used instead.

### Example Explained

```json
"Tachi_Materialism": {
    "SkillReplacement": "Tachi_Mercy"
}
```

This line overrides Tachi_Materialism so that it uses the same special skill as Tachi_Mercy.

## 🔍 How to Find Internal Weapon Names

There are two main ways to determine internal weapon names:

### Check the [GameDataDumps](../GameDataDumps) Directory

This directory contains data dumped from the game and often includes internal weapon names like "Tachi_Materialism" or "DoubleSwords_Blader".

### Use UnityExplorer or HarmonyLib Hooking

Hook into the function `Player.ChangeWeapon(Weapon newWeapon, ...)` and inspect the value of:

```
newWeapon.WeaponDefine.Resource
```

This property reveals the internal name of the weapon currently being equipped.

## ⚠️ Known Limitations

Not all skill overrides are guaranteed to work.

For example, trying to assign the skill of "DoubleSwords_Reaper" to "DoubleSwords_Blader" results in unexpected behavior: when the skill button is pressed, the player performs a dodge instead of activating the skill.

The root cause of this issue is not yet known — it may involve internal constraints or requirements (such as animation compatibility or missing bindings) that aren't exposed in the dumped data.

There may be other unsupported combinations that result in similar failures. If a skill override doesn't seem to work, you can try reverting that specific change by removing the corresponding entry in the config file.