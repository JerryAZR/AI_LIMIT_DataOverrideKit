# Accessory Overrides Format (a.k.a. Nucleus Overrides)

This configuration lets you override the properties of Headwares and Body Armors.

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

Each json entry key (or toml table name) is `H.<ID>` for headware, `B.<ID>` for body armor.

| ID  | English Name              | Chinese Name     |
|-----|---------------------------|------------------|
| 0   | None                      | 空               |
| 1   | Blader Visor              | 机兵面甲         |
| 2   | Iron Pot                  | 铁锅头           |
| 3   | Thorny Headgear           | 腐刺头套         |
| 4   | Blader Huntress Mask      | 狩猎机兵面罩     |
| 5   | Clergy Headwear           | 圣职者头饰       |
| 6   | Ponytail                  | 马尾辫           |
| 7   | Goggles                   | 护目镜           |
| 8   | Osprey Hat                | 鱼鹰斗笠         |
| 9   | Buddha Hat                | 佛陀斗笠         |
| 10  | Takamagahara Hat          | 高天原斗笠       |
| 11  | Twisted Braid             | 麻花辫           |
| 12  | Chlorostil Mask           | 翠蜂面罩         |
| 13  | Osprey Ponytail           | 鱼鹰马尾         |
| 14  | Hunter's Helmet           | 猎人头盔         |
| 15  | Listener Guild Hood       | 听者会头罩       |
| 16  | Rabbit Ears               | 兔耳头饰         |
| 17  | Maid Hairband             | 花边头带         |
| 18  | Corrupted Blader Visor    | 侵蚀机兵面甲     |
| 19  | Frame Glasses             | 方框眼镜         |
| 20  | Bandage                   | 绷带             |
| 21  | Monitor Hood              | 显示器头套       |
| 22  | White Sparrow's Mask      | 白雀面罩         |
| 23  | Guardian Helmet           | 圣树守卫头盔     |
| 24  | The Child's Tiara         | 圣子冠冕         |
| 25  | Long Hair                 | 长发             |
| 26  | Ragged Hood               | 破布兜帽         |

| ID  | English Name                 | Chinese Name       |
|-----|------------------------------|--------------------|
| 0   | None                         | 空                 |
| 1   | Ragged Clothes               | 破布短衣           |
| 2   | Casual Blader Suit           | 机兵简装           |
| 3   | Blader Armor                 | 机兵轻甲           |
| 4   | Enterprise Investigator      | 企业调查者         |
| 5   | Traveler's Coat              | 旅行者风衣         |
| 6   | Scavenger's Clothing         | 拾荒衣             |
| 7   | Guardian Armor               | 圣树守卫铠甲       |
| 8   | Blader Huntress Attire       | 狩猎机兵套装       |
| 9   | The Child's Attire           | 圣子礼装           |
| 10  | Traveler's Outfit            | 旅行轻装           |
| 11  | Clergy Robe                  | 圣职者长袍         |
| 12  | Raincoat                     | 雨衣               |
| 13  | Fisherman's Suit             | 城市渔夫套装       |
| 14  | Hunter's Armor               | 猎人轻甲           |
| 15  | Listener Guild Uniform       | 听者会制服         |
| 16  | Rabbit Set                   | 兔爪套装           |
| 17  | Maid Outfit                  | 黑白裙装           |
| 18  | Corrupted Blader Armor       | 侵蚀机兵套装       |
| 19  | Researcher's Robe            | 研究者长袍         |
| 20  | Patient's Clothing           | 病号服             |
| 44  | White Sparrow's Coat         | 白雀风衣           |

### Fields

| Field Name           | Type   | Description                                         |
|----------------------|--------|-----------------------------------------------------|
| PhysicsDefense       | float  | Base physical defense stat.                         |
| FireDefense          | float  | Resistance to fire attacks.                         |
| ElectricDefense      | float  | Resistance to electric attacks.                     |
| PsychoDefense        | float  | Resistance to shatter attacks.                      |
| PoisonResistance     | int    | Status resistance to poison effects.                |
| PunctureResistance   | int    | Status resistance to piercing effects.              |
| InfectResistance     | int    | Status resistance to infection effects.             |

## 📘 Examples

### JSON

```json
{
    "B.8": {
        "InfectResistance": 40
    }
}
```

### TOML

```toml
[B.20] # Patient's Clothing
PhysicsDefense=70
FireDefense=70
ElectricDefense=70
PunctureResistance=30
InfectResistance=30

[H.25] # Long Hair
FireDefense=30
ElectricDefense=40
```

### Official Specs

If you're unfamiliar with the format or your config isn't working as expected,
refer to the official [JSON specification](https://www.json.org/json-en.html)
or the [TOML specification](https://toml.io/en/).

## 💬 Feedback Welcome

I’d love to hear your thoughts—which format do you prefer, TOML or JSON?
Whichever gets more love will be the default for future mods!
