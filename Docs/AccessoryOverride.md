# Accessory Overrides Format (a.k.a. Nucleus Overrides)

This configuration lets you override the properties of accessories (also called **Nucleus** in-game).

## 📂 File Location

Place your override files in:

```
UserData/DataOverrideKit/AccessoryOverrides.toml
UserData/DataOverrideKit/AccessoryOverrides.json
```

* Both .toml and .json are supported.

* If both are present and contain overlapping entries, the TOML file takes precedence.

## 🧩 Format Description

### Key

Each json entry key (or toml table name) is the accessory ID, as used internally by the game.

| ID  | English Name                           | 中文名               |
|-----|----------------------------------------|----------------------|
| 0   | None                                   | 空                   |
| 1   | Standard Nucleus                       | 标准晶核             |
| 2   | Void Nucleus                           | 虚人的晶核           |
| 3   | Elite Necro's Nucleus                  | 中阶死灵的晶核       |
| 4   | Cleansing Knight's Nucleus             | 明净骑士的晶核       |
| 5   | Clergy's Nucleus                       | 圣职者的晶核         |
| 6   | Persephone's Nucleus                   | 深渊哀后的晶核       |
| 7   | Elite Necro's Fusion Nucleus           | 中阶死灵的融聚核     |
| 8   | Mutant Clergy's Nucleus                | 圣职者的异化核       |
| 9   | Divine Vessel's Nucleus                | 神身容器的晶核       |
| 10  | Guardian's Nucleus                     | 圣树守卫的晶核       |
| 11  | Mutant Blader Nucleus                  | 异变的机兵晶核       |
| 12  | Nucleus on the Child's Tiara           | 圣子冠冕的晶核       |
| 13  | Turbid Nucleus                         | 浑浊晶核             |


### Fields

| Field Name            | Type   | Description                                                                 |
|-----------------------|--------|-----------------------------------------------------------------------------|
| CrystalAbsorptionRate | float  | Crystals gained when defeating an enemy (write `75` for 75%)                |
| CrystalRetentionRate  | float  | Crystals retained after dying (write `90` for 90%)                          |
| EnergyAbsorption      | float  | Energy gain rate: 0.33 = low, 0.66 = medium, 1 = high (in-game display)     |

## 📘 Examples

### JSON

```json
{
  "4": {
    "EnergyAbsorption": 1
  }
}
```
> Changes the energy absorption rate of "Cleansing Knight's Nucleus" to "High"

### TOML

```toml
[2] # Void Nucleus
CrystalAbsorptionRate = 60      # 60% absorption rate
CrystalRetentionRate  = 90      # 90% retention rate
EnergyAbsorption      = 0.66    # Medium energy absorption, same as Standard Nucleus

[10] # Guardian's Nucleus
EnergyAbsorption      = 1       # High energy absorption
```

### Official Specs

If you're unfamiliar with the format or your config isn't working as expected,
refer to the official [JSON specification](https://www.json.org/json-en.html)
or the [TOML specification](https://toml.io/en/).

## 💬 Feedback Welcome

I’d love to hear your thoughts—which format do you prefer, TOML or JSON?
Whichever gets more love will be the default for future mods!
