# ActionGroupOverrides.json Format

This file allows you to override properties of specific weapon skills (also known as Action Groups).

If you are trying to change the skill of a weapon, please visit [WeaponOverride.md](WeaponOverride.md)

## 📄 Location & File Name

* Place the file in: `UserData/DataOverrideKit/`

* The filename must be exactly `ActionGroupOverrides.json.`

## 📂 Example

See: [ActionGroupOverrides.json](../ExampleConfigs/ActionGroupOverrides.json)

```json
{
    "P_Tachi_SkillAttack4_2": {
        "ConfidenceCosts": [0, -5, -5, -5]
    }
}
```

## 🧩 Format Description

Each key in the JSON object refers to the internal name of a move (usually tied to a specific skill). The value is an object containing the fields to override.

Currently supported override fields:

* `ConfidenceCosts` — an array of integers that defines the confidence (sync-rate) cost per hit in a multi-hit skill.

The example config changes the cost pattern of the skill P_Tachi_SkillAttack4_2 (Materialism-Eureka) to [0, -5, -5, -5].

## 🔍 How to Find Internal Skill Names

You have two main options:

### Check the [GameDataDumps](../GameDataDumps) Directory

This folder includes dumped skill data where you can find skills and costs associated with each weapon

### Use UnityExplorer or HarmonyLib Hooking

For a more direct approach while the game is running, hook into the method
`Config.GetSpecialSkillBySkillActionType(ActionType skillActionType, ...)`. The `skillActionType` parameter corresponds to the skill currently being used and directly maps to the name expected in this JSON config.
