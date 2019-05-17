using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace D2AbilityCreator2
{
    public partial class Form1 : Form
    {
        string[] AbilityBehaviorSelectedList =
        {
            "DOTA_ABILITY_BEHAVIOR_NONE",
            "DOTA_ABILITY_BEHAVIOR_HIDDEN",
            "DOTA_ABILITY_BEHAVIOR_PASSIVE",
            "DOTA_ABILITY_BEHAVIOR_NO_TARGET",
            "DOTA_ABILITY_BEHAVIOR_UNIT_TARGET",
            "DOTA_ABILITY_BEHAVIOR_POINT",
            "DOTA_ABILITY_BEHAVIOR_AOE",
            "DOTA_ABILITY_BEHAVIOR_NOT_LEARNABLE",
            "DOTA_ABILITY_BEHAVIOR_CHANNELLED",
            "DOTA_ABILITY_BEHAVIOR_ITEM",
            "DOTA_ABILITY_BEHAVIOR_TOGGLE",
            "DOTA_ABILITY_BEHAVIOR_DIRECTIONAL",
            "DOTA_ABILITY_BEHAVIOR_IMMEDIATE",
            "DOTA_ABILITY_BEHAVIOR_AUTOCAST",
            "DOTA_ABILITY_BEHAVIOR_OPTIONAL_UNIT_TARGET",
            "DOTA_ABILITY_BEHAVIOR_OPTIONAL_POINT",
            "DOTA_ABILITY_BEHAVIOR_OPTIONAL_NO_TARGET",
            "DOTA_ABILITY_BEHAVIOR_AURA",
            "DOTA_ABILITY_BEHAVIOR_ATTACK",
            "DOTA_ABILITY_BEHAVIOR_DONT_RESUME_MOVEMENT",
            "DOTA_ABILITY_BEHAVIOR_ROOT_DISABLES",
            "DOTA_ABILITY_BEHAVIOR_UNRESTRICTED",
            "DOTA_ABILITY_BEHAVIOR_IGNORE_PSEUDO_QUEUE",
            "DOTA_ABILITY_BEHAVIOR_IGNORE_CHANNEL",
            "DOTA_ABILITY_BEHAVIOR_DONT_CANCEL_MOVEMENT",
            "DOTA_ABILITY_BEHAVIOR_DONT_ALERT_TARGET",
            "DOTA_ABILITY_BEHAVIOR_DONT_RESUME_ATTACK",
            "DOTA_ABILITY_BEHAVIOR_NORMAL_WHEN_STOLEN",
            "DOTA_ABILITY_BEHAVIOR_IGNORE_BACKSWING",
            "DOTA_ABILITY_BEHAVIOR_RUNE_TARGET",
            "DOTA_ABILITY_BEHAVIOR_DONT_CANCEL_CHANNEL",
            "DOTA_ABILITY_LAST_BEHAVIOR",
        };
        string[] AbilityTypeSelectedList =
        {
            "DOTA_ABILITY_TYPE_ATTRIBUTES",
            "DOTA_ABILITY_TYPE_BASIC",
            "DOTA_ABILITY_TYPE_HIDDEN",
            "DOTA_ABILITY_TYPE_ULTIMATE",
        };
        string[] UnitTargetTypeSelectedList =
        {
            "DOTA_UNIT_TARGET_HERO",
            "DOTA_UNIT_TARGET_CREEP",
            "DOTA_UNIT_TARGET_BUILDING",
            "DOTA_UNIT_TARGET_MECHANICAL",
            "DOTA_UNIT_TARGET_COURIER",
            "DOTA_UNIT_TARGET_TREE",
            "DOTA_UNIT_TARGET_CUSTOM",
            "DOTA_UNIT_TARGET_ALL",
            "DOTA_UNIT_TARGET_BASIC",
            "DOTA_UNIT_TARGET_NONE",
            "DOTA_UNIT_TARGET_OTHER",
        };
        string[] TeamsList =
        {
            "DOTA_UNIT_TARGET_TEAM_FRIENDLY",
            "DOTA_UNIT_TARGET_TEAM_ENEMY",
            "DOTA_UNIT_TARGET_TEAM_CUSTOM",
            "DOTA_UNIT_TARGET_TEAM_BOTH",
            "DOTA_UNIT_TARGET_TEAM_NONE",
        };
        string[] DamageTypeSelectedList =
        {
            "DAMAGE_TYPE_COMPOSITE",
            "DAMAGE_TYPE_HP_REMOVAL",
            "DAMAGE_TYPE_MAGICAL",
            "DAMAGE_TYPE_PHYSICAL",
            "DAMAGE_TYPE_PURE",
        };
        string[] Properties =
        {
            "MODIFIER_PROPERTY_PREATTACK_BONUS_DAMAGE",
            "MODIFIER_PROPERTY_PREATTACK_BONUS_DAMAGE_PROC",
            "MODIFIER_PROPERTY_PREATTACK_BONUS_DAMAGE_POST_CRIT",
            "MODIFIER_PROPERTY_BASEATTACK_BONUSDAMAGE",
            "MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_PHYSICAL",
            "MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_MAGICAL",
            "MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_PURE",
            "MODIFIER_PROPERTY_PROCATTACK_FEEDBACK",
            "MODIFIER_PROPERTY_PRE_ATTACK",
            "MODIFIER_PROPERTY_INVISIBILITY_LEVEL",
            "MODIFIER_PROPERTY_PERSISTENT_INVISIBILITY",
            "MODIFIER_PROPERTY_MOVESPEED_BONUS_CONSTANT",
            "MODIFIER_PROPERTY_MOVESPEED_BASE_OVERRIDE",
            "MODIFIER_PROPERTY_MOVESPEED_BONUS_PERCENTAGE",
            "MODIFIER_PROPERTY_MOVESPEED_BONUS_PERCENTAGE_UNIQUE",
            "MODIFIER_PROPERTY_MOVESPEED_BONUS_PERCENTAGE_UNIQUE_2",
            "MODIFIER_PROPERTY_MOVESPEED_BONUS_UNIQUE",
            "MODIFIER_PROPERTY_MOVESPEED_BONUS_UNIQUE_2",
            "MODIFIER_PROPERTY_MOVESPEED_ABSOLUTE",
            "MODIFIER_PROPERTY_MOVESPEED_ABSOLUTE_MIN",
            "MODIFIER_PROPERTY_MOVESPEED_LIMIT",
            "MODIFIER_PROPERTY_MOVESPEED_MAX",
            "MODIFIER_PROPERTY_ATTACKSPEED_BASE_OVERRIDE",
            "MODIFIER_PROPERTY_FIXED_ATTACK_RATE",
            "MODIFIER_PROPERTY_ATTACKSPEED_BONUS_CONSTANT",
            "MODIFIER_PROPERTY_COOLDOWN_REDUCTION_CONSTANT",
            "MODIFIER_PROPERTY_BASE_ATTACK_TIME_CONSTANT",
            "MODIFIER_PROPERTY_ATTACK_POINT_CONSTANT",
            "MODIFIER_PROPERTY_DAMAGEOUTGOING_PERCENTAGE",
            "MODIFIER_PROPERTY_DAMAGEOUTGOING_PERCENTAGE_ILLUSION",
            "MODIFIER_PROPERTY_TOTALDAMAGEOUTGOING_PERCENTAGE",
            "MODIFIER_PROPERTY_SPELL_AMPLIFY_PERCENTAGE",
            "MODIFIER_PROPERTY_HP_REGEN_AMPLIFY_PERCENTAGE",
            "MODIFIER_PROPERTY_MAGICDAMAGEOUTGOING_PERCENTAGE",
            "MODIFIER_PROPERTY_BASEDAMAGEOUTGOING_PERCENTAGE",
            "MODIFIER_PROPERTY_BASEDAMAGEOUTGOING_PERCENTAGE_UNIQUE",
            "MODIFIER_PROPERTY_INCOMING_DAMAGE_PERCENTAGE",
            "MODIFIER_PROPERTY_INCOMING_PHYSICAL_DAMAGE_PERCENTAGE",
            "MODIFIER_PROPERTY_INCOMING_PHYSICAL_DAMAGE_CONSTANT",
            "MODIFIER_PROPERTY_INCOMING_SPELL_DAMAGE_CONSTANT",
            "MODIFIER_PROPERTY_EVASION_CONSTANT",
            "MODIFIER_PROPERTY_NEGATIVE_EVASION_CONSTANT",
            "MODIFIER_PROPERTY_AVOID_DAMAGE",
            "MODIFIER_PROPERTY_AVOID_SPELL",
            "MODIFIER_PROPERTY_MISS_PERCENTAGE",
            "MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS",
            "MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS_UNIQUE",
            "MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS_UNIQUE_ACTIVE",
            "MODIFIER_PROPERTY_IGNORE_PHYSICAL_ARMOR",
            "MODIFIER_PROPERTY_MAGICAL_RESISTANCE_DIRECT_MODIFICATION",
            "MODIFIER_PROPERTY_MAGICAL_RESISTANCE_BONUS",
            "MODIFIER_PROPERTY_MAGICAL_RESISTANCE_DECREPIFY_UNIQUE",
            "MODIFIER_PROPERTY_BASE_MANA_REGEN",
            "MODIFIER_PROPERTY_MANA_REGEN_CONSTANT",
            "MODIFIER_PROPERTY_MANA_REGEN_CONSTANT_UNIQUE",
            "MODIFIER_PROPERTY_MANA_REGEN_PERCENTAGE",
            "MODIFIER_PROPERTY_MANA_REGEN_TOTAL_PERCENTAGE",
            "MODIFIER_PROPERTY_HEALTH_REGEN_CONSTANT",
            "MODIFIER_PROPERTY_HEALTH_REGEN_PERCENTAGE",
            "MODIFIER_PROPERTY_HEALTH_BONUS",
            "MODIFIER_PROPERTY_MANA_BONUS",
            "MODIFIER_PROPERTY_EXTRA_STRENGTH_BONUS",
            "MODIFIER_PROPERTY_EXTRA_HEALTH_BONUS",
            "MODIFIER_PROPERTY_EXTRA_MANA_BONUS",
            "MODIFIER_PROPERTY_EXTRA_HEALTH_PERCENTAGE",
            "MODIFIER_PROPERTY_STATS_STRENGTH_BONUS",
            "MODIFIER_PROPERTY_STATS_AGILITY_BONUS",
            "MODIFIER_PROPERTY_STATS_INTELLECT_BONUS",
            "MODIFIER_PROPERTY_CAST_RANGE_BONUS",
            "MODIFIER_PROPERTY_CAST_RANGE_BONUS_STACKING",
            "MODIFIER_PROPERTY_ATTACK_RANGE_BONUS",
            "MODIFIER_PROPERTY_ATTACK_RANGE_BONUS_UNIQUE",
            "MODIFIER_PROPERTY_MAX_ATTACK_RANGE",
            "MODIFIER_PROPERTY_PROJECTILE_SPEED_BONUS",
            "MODIFIER_PROPERTY_REINCARNATION",
            "MODIFIER_PROPERTY_RESPAWNTIME",
            "MODIFIER_PROPERTY_RESPAWNTIME_PERCENTAGE",
            "MODIFIER_PROPERTY_RESPAWNTIME_STACKING",
            "MODIFIER_PROPERTY_COOLDOWN_PERCENTAGE",
            "MODIFIER_PROPERTY_COOLDOWN_PERCENTAGE_STACKING",
            "MODIFIER_PROPERTY_CASTTIME_PERCENTAGE",
            "MODIFIER_PROPERTY_MANACOST_PERCENTAGE",
            "MODIFIER_PROPERTY_DEATHGOLDCOST",
            "MODIFIER_PROPERTY_EXP_RATE_BOOST",
            "MODIFIER_PROPERTY_PREATTACK_CRITICALSTRIKE",
            "MODIFIER_PROPERTY_PREATTACK_TARGET_CRITICALSTRIKE",
            "MODIFIER_PROPERTY_MAGICAL_CONSTANT_BLOCK",
            "MODIFIER_PROPERTY_PHYSICAL_CONSTANT_BLOCK",
            "MODIFIER_PROPERTY_PHYSICAL_CONSTANT_BLOCK_SPECIAL",
            "MODIFIER_PROPERTY_TOTAL_CONSTANT_BLOCK_UNAVOIDABLE_PRE_ARMOR",
            "MODIFIER_PROPERTY_TOTAL_CONSTANT_BLOCK",
            "MODIFIER_PROPERTY_OVERRIDE_ANIMATION",
            "MODIFIER_PROPERTY_OVERRIDE_ANIMATION_WEIGHT",
            "MODIFIER_PROPERTY_OVERRIDE_ANIMATION_RATE",
            "MODIFIER_PROPERTY_ABSORB_SPELL",
            "MODIFIER_PROPERTY_REFLECT_SPELL",
            "MODIFIER_PROPERTY_DISABLE_AUTOATTACK",
            "MODIFIER_PROPERTY_BONUS_DAY_VISION",
            "MODIFIER_PROPERTY_BONUS_NIGHT_VISION",
            "MODIFIER_PROPERTY_BONUS_NIGHT_VISION_UNIQUE",
            "MODIFIER_PROPERTY_BONUS_VISION_PERCENTAGE",
            "MODIFIER_PROPERTY_FIXED_DAY_VISION",
            "MODIFIER_PROPERTY_FIXED_NIGHT_VISION",
            "MODIFIER_PROPERTY_MIN_HEALTH",
            "MODIFIER_PROPERTY_ABSOLUTE_NO_DAMAGE_PHYSICAL",
            "MODIFIER_PROPERTY_ABSOLUTE_NO_DAMAGE_MAGICAL",
            "MODIFIER_PROPERTY_ABSOLUTE_NO_DAMAGE_PURE",
            "MODIFIER_PROPERTY_IS_ILLUSION",
            "MODIFIER_PROPERTY_ILLUSION_LABEL",
            "MODIFIER_PROPERTY_SUPER_ILLUSION",
            "MODIFIER_PROPERTY_SUPER_ILLUSION_WITH_ULTIMATE",
            "MODIFIER_PROPERTY_TURN_RATE_PERCENTAGE",
            "MODIFIER_PROPERTY_DISABLE_HEALING",
            "MODIFIER_PROPERTY_ALWAYS_ALLOW_ATTACK",
            "MODIFIER_PROPERTY_OVERRIDE_ATTACK_MAGICAL",
            "MODIFIER_PROPERTY_UNIT_STATS_NEEDS_REFRESH",
            "MODIFIER_PROPERTY_BOUNTY_CREEP_MULTIPLIER",
            "MODIFIER_PROPERTY_BOUNTY_OTHER_MULTIPLIER",
            "MODIFIER_PROPERTY_TOOLTIP",
            "MODIFIER_PROPERTY_MODEL_CHANGE",
            "MODIFIER_PROPERTY_MODEL_SCALE",
            "MODIFIER_PROPERTY_IS_SCEPTER",
            "MODIFIER_PROPERTY_TRANSLATE_ACTIVITY_MODIFIERS",
            "MODIFIER_PROPERTY_TRANSLATE_ATTACK_SOUND",
            "MODIFIER_PROPERTY_LIFETIME_FRACTION",
            "MODIFIER_PROPERTY_PROVIDES_FOW_POSITION",
            "MODIFIER_PROPERTY_SPELLS_REQUIRE_HP",
            "MODIFIER_PROPERTY_FORCE_DRAW_MINIMAP",
            "MODIFIER_PROPERTY_DISABLE_TURNING",
            "MODIFIER_PROPERTY_IGNORE_CAST_ANGLE",
            "MODIFIER_PROPERTY_CHANGE_ABILITY_VALUE",
            "MODIFIER_PROPERTY_ABILITY_LAYOUT",
            "MODIFIER_PROPERTY_TEMPEST_DOUBLE",
            "MODIFIER_PROPERTY_PRESERVE_PARTICLES_ON_MODEL_CHANGE",
            "MODIFIER_PROPERTY_IGNORE_COOLDOWN",
            "MODIFIER_PROPERTY_CAN_ATTACK_TREES",
            "MODIFIER_PROPERTY_VISUAL_Z_DELTA",
            "MODIFIER_PROPERTY_INCOMING_DAMAGE_ILLUSION",
        };
        string[] States =
        {
            "MODIFIER_STATE_ROOTED",
            "MODIFIER_STATE_DISARMED",
            "MODIFIER_STATE_ATTACK_IMMUNE",
            "MODIFIER_STATE_SILENCED",
            "MODIFIER_STATE_MUTED",
            "MODIFIER_STATE_STUNNED",
            "MODIFIER_STATE_HEXED",
            "MODIFIER_STATE_INVISIBLE",
            "MODIFIER_STATE_INVULNERABLE",
            "MODIFIER_STATE_MAGIC_IMMUNE",
            "MODIFIER_STATE_PROVIDES_VISION",
            "MODIFIER_STATE_NIGHTMARED",
            "MODIFIER_STATE_BLOCK_DISABLED",
            "MODIFIER_STATE_EVADE_DISABLED",
            "MODIFIER_STATE_UNSELECTABLE",
            "MODIFIER_STATE_CANNOT_MISS",
            "MODIFIER_STATE_SPECIALLY_DENIABLE",
            "MODIFIER_STATE_FROZEN",
            "MODIFIER_STATE_COMMAND_RESTRICTED",
            "MODIFIER_STATE_NOT_ON_MINIMAP",
            "MODIFIER_STATE_NOT_ON_MINIMAP_FOR_ENEMIES",
            "MODIFIER_STATE_LOW_ATTACK_PRIORITY",
            "MODIFIER_STATE_NO_HEALTH_BAR",
            "MODIFIER_STATE_FLYING",
            "MODIFIER_STATE_NO_UNIT_COLLISION",
            "MODIFIER_STATE_NO_TEAM_MOVE_TO",
            "MODIFIER_STATE_NO_TEAM_SELECT",
            "MODIFIER_STATE_PASSIVES_DISABLED",
            "MODIFIER_STATE_DOMINATED",
            "MODIFIER_STATE_BLIND",
            "MODIFIER_STATE_OUT_OF_GAME",
            "MODIFIER_STATE_FAKE_ALLY",
            "MODIFIER_STATE_FLYING_FOR_PATHING_PURPOSES_ONLY",
            "MODIFIER_STATE_TRUESIGHT_IMMUNE",
            "MODIFIER_STATE_LAST",
        };
        string[] StatesValues =
        {
            "MODIFIER_STATE_VALUE_DISABLED",
            "MODIFIER_STATE_VALUE_ENABLED",
            "MODIFIER_STATE_VALUE_NO_ACTION",
        };
        string[] SpellImmunityTypeList =
        {
            "SPELL_IMMUNITY_ENEMIES_NO",
            "SPELL_IMMUNITY_ENEMIES_YES"
        };
        string[] AbilityCastAnimationList =
        {
            "ACT_DOTA_IDLE",
            "ACT_DOTA_IDLE_RARE",
            "ACT_DOTA_RUN",
            "ACT_DOTA_ATTACK",
            "ACT_DOTA_ATTACK2",
            "ACT_DOTA_ATTACK_EVENT",
            "ACT_DOTA_DIE",
            "ACT_DOTA_FLINCH",
            "ACT_DOTA_FLAIL",
            "ACT_DOTA_DISABLED",
            "ACT_DOTA_CAST_ABILITY_1",
            "ACT_DOTA_CAST_ABILITY_2",
            "ACT_DOTA_CAST_ABILITY_3",
            "ACT_DOTA_CAST_ABILITY_4",
            "ACT_DOTA_CAST_ABILITY_5",
            "ACT_DOTA_CAST_ABILITY_6",
            "ACT_DOTA_OVERRIDE_ABILITY_1",
            "ACT_DOTA_OVERRIDE_ABILITY_2",
            "ACT_DOTA_OVERRIDE_ABILITY_3",
            "ACT_DOTA_OVERRIDE_ABILITY_4",
            "ACT_DOTA_CHANNEL_ABILITY_1",
            "ACT_DOTA_CHANNEL_ABILITY_2",
            "ACT_DOTA_CHANNEL_ABILITY_3",
            "ACT_DOTA_CHANNEL_ABILITY_4",
            "ACT_DOTA_CHANNEL_ABILITY_5",
            "ACT_DOTA_CHANNEL_ABILITY_6",
            "ACT_DOTA_CHANNEL_END_ABILITY_1",
            "ACT_DOTA_CHANNEL_END_ABILITY_2",
            "ACT_DOTA_CHANNEL_END_ABILITY_3",
            "ACT_DOTA_CHANNEL_END_ABILITY_4",
            "ACT_DOTA_CHANNEL_END_ABILITY_5",
            "ACT_DOTA_CHANNEL_END_ABILITY_6",
            "ACT_DOTA_CONSTANT_LAYER",
            "ACT_DOTA_CAPTURE",
            "ACT_DOTA_SPAWN",
            "ACT_DOTA_KILLTAUNT",
            "ACT_DOTA_TAUNT",
            "ACT_DOTA_THIRST",
            "ACT_DOTA_CAST_DRAGONBREATH",
            "ACT_DOTA_ECHO_SLAM",
            "ACT_DOTA_CAST_ABILITY_1_END",
            "ACT_DOTA_CAST_ABILITY_2_END",
            "ACT_DOTA_CAST_ABILITY_3_END",
            "ACT_DOTA_CAST_ABILITY_4_END",
            "ACT_MIRANA_LEAP_END",
            "ACT_WAVEFORM_START",
            "ACT_WAVEFORM_END",
            "ACT_DOTA_CAST_ABILITY_ROT",
            "ACT_DOTA_DIE_SPECIAL",
            "ACT_DOTA_RATTLETRAP_BATTERYASSAULT",
            "ACT_DOTA_RATTLETRAP_POWERCOGS",
            "ACT_DOTA_RATTLETRAP_HOOKSHOT_START",
            "ACT_DOTA_RATTLETRAP_HOOKSHOT_LOOP",
            "ACT_DOTA_RATTLETRAP_HOOKSHOT_END",
            "ACT_STORM_SPIRIT_OVERLOAD_RUN_OVERRIDE",
            "ACT_DOTA_TINKER_REARM1",
            "ACT_DOTA_TINKER_REARM2",
            "ACT_DOTA_TINKER_REARM3",
            "ACT_TINY_AVALANCHE",
            "ACT_TINY_TOSS",
            "ACT_TINY_GROWL",
            "ACT_DOTA_WEAVERBUG_ATTACH",
            "ACT_DOTA_CAST_WILD_AXES_END",
            "ACT_DOTA_CAST_LIFE_BREAK_START",
            "ACT_DOTA_CAST_LIFE_BREAK_END",
            "ACT_DOTA_NIGHTSTALKER_TRANSITION",
            "ACT_DOTA_LIFESTEALER_RAGE",
            "ACT_DOTA_LIFESTEALER_OPEN_WOUNDS",
            "ACT_DOTA_SAND_KING_BURROW_IN",
            "ACT_DOTA_SAND_KING_BURROW_OUT",
            "ACT_DOTA_EARTHSHAKER_TOTEM_ATTACK",
            "ACT_DOTA_WHEEL_LAYER",
            "ACT_DOTA_ALCHEMIST_CHEMICAL_RAGE_START",
            "ACT_DOTA_ALCHEMIST_CONCOCTION",
            "ACT_DOTA_JAKIRO_LIQUIDFIRE_START",
            "ACT_DOTA_JAKIRO_LIQUIDFIRE_LOOP",
            "ACT_DOTA_LIFESTEALER_INFEST",
            "ACT_DOTA_LIFESTEALER_INFEST_END",
            "ACT_DOTA_LASSO_LOOP",
            "ACT_DOTA_ALCHEMIST_CONCOCTION_THROW",
            "ACT_DOTA_ALCHEMIST_CHEMICAL_RAGE_END",
            "ACT_DOTA_CAST_COLD_SNAP",
            "ACT_DOTA_CAST_GHOST_WALK",
            "ACT_DOTA_CAST_TORNADO",
            "ACT_DOTA_CAST_EMP",
            "ACT_DOTA_CAST_ALACRITY",
            "ACT_DOTA_CAST_CHAOS_METEOR",
            "ACT_DOTA_CAST_SUN_STRIKE",
            "ACT_DOTA_CAST_FORGE_SPIRIT",
            "ACT_DOTA_CAST_ICE_WALL",
            "ACT_DOTA_CAST_DEAFENING_BLAST",
            "ACT_DOTA_VICTORY",
            "ACT_DOTA_DEFEAT",
            "ACT_DOTA_SPIRIT_BREAKER_CHARGE_POSE",
            "ACT_DOTA_SPIRIT_BREAKER_CHARGE_END",
            "ACT_DOTA_TELEPORT",
            "ACT_DOTA_TELEPORT_END",
            "ACT_DOTA_CAST_REFRACTION",
            "ACT_DOTA_CAST_ABILITY_7",
            "ACT_DOTA_CANCEL_SIREN_SONG",
            "ACT_DOTA_CHANNEL_ABILITY_7",
            "ACT_DOTA_LOADOUT",
            "ACT_DOTA_FORCESTAFF_END",
            "ACT_DOTA_POOF_END",
            "ACT_DOTA_SLARK_POUNCE",
            "ACT_DOTA_MAGNUS_SKEWER_START",
            "ACT_DOTA_MAGNUS_SKEWER_END",
            "ACT_DOTA_MEDUSA_STONE_GAZE",
            "ACT_DOTA_RELAX_START",
            "ACT_DOTA_RELAX_LOOP",
            "ACT_DOTA_RELAX_END",
            "ACT_DOTA_CENTAUR_STAMPEDE",
            "ACT_DOTA_BELLYACHE_START",
            "ACT_DOTA_BELLYACHE_LOOP",
            "ACT_DOTA_BELLYACHE_END",
            "ACT_DOTA_ROQUELAIRE_LAND",
            "ACT_DOTA_ROQUELAIRE_LAND_IDLE",
            "ACT_DOTA_GREEVIL_CAST",
            "ACT_DOTA_GREEVIL_OVERRIDE_ABILITY",
            "ACT_DOTA_GREEVIL_HOOK_START",
            "ACT_DOTA_GREEVIL_HOOK_END",
            "ACT_DOTA_GREEVIL_BLINK_BONE",
            "ACT_DOTA_IDLE_SLEEPING",
            "ACT_DOTA_INTRO",
            "ACT_DOTA_GESTURE_POINT",
            "ACT_DOTA_GESTURE_ACCENT",
            "ACT_DOTA_SLEEPING_END",
            "ACT_DOTA_AMBUSH",
            "ACT_DOTA_ITEM_LOOK",
            "ACT_DOTA_STARTLE",
            "ACT_DOTA_FRUSTRATION",
            "ACT_DOTA_TELEPORT_REACT",
            "ACT_DOTA_TELEPORT_END_REACT",
            "ACT_DOTA_SHRUG",
            "ACT_DOTA_RELAX_LOOP_END",
            "ACT_DOTA_PRESENT_ITEM",
            "ACT_DOTA_IDLE_IMPATIENT",
            "ACT_DOTA_SHARPEN_WEAPON",
            "ACT_DOTA_SHARPEN_WEAPON_OUT",
            "ACT_DOTA_IDLE_SLEEPING_END",
            "ACT_DOTA_BRIDGE_DESTROY",
            "ACT_DOTA_TAUNT_SNIPER",
            "ACT_DOTA_DEATH_BY_SNIPER",
            "ACT_DOTA_LOOK_AROUND",
            "ACT_DOTA_CAGED_CREEP_RAGE",
            "ACT_DOTA_CAGED_CREEP_RAGE_OUT",
            "ACT_DOTA_CAGED_CREEP_SMASH",
            "ACT_DOTA_CAGED_CREEP_SMASH_OUT",
            "ACT_DOTA_IDLE_IMPATIENT_SWORD_TAP",
            "ACT_DOTA_INTRO_LOOP",
            "ACT_DOTA_BRIDGE_THREAT",
            "ACT_DOTA_DAGON",
            "ACT_DOTA_CAST_ABILITY_2_ES_ROLL_START",
            "ACT_DOTA_CAST_ABILITY_2_ES_ROLL",
            "ACT_DOTA_CAST_ABILITY_2_ES_ROLL_END",
            "ACT_DOTA_NIAN_PIN_START",
            "ACT_DOTA_NIAN_PIN_LOOP",
            "ACT_DOTA_NIAN_PIN_END",
            "ACT_DOTA_LEAP_STUN",
            "ACT_DOTA_LEAP_SWIPE",
            "ACT_DOTA_NIAN_INTRO_LEAP",
            "ACT_DOTA_AREA_DENY",
            "ACT_DOTA_NIAN_PIN_TO_STUN",
            "ACT_DOTA_RAZE_1",
            "ACT_DOTA_RAZE_2",
            "ACT_DOTA_RAZE_3",
            "ACT_DOTA_UNDYING_DECAY",
            "ACT_DOTA_UNDYING_SOUL_RIP",
            "ACT_DOTA_UNDYING_TOMBSTONE",
            "ACT_DOTA_WHIRLING_AXES_RANGED",
            "ACT_DOTA_SHALLOW_GRAVE",
            "ACT_DOTA_COLD_FEET",
            "ACT_DOTA_ICE_VORTEX",
            "ACT_DOTA_CHILLING_TOUCH",
            "ACT_DOTA_ENFEEBLE",
            "ACT_DOTA_FATAL_BONDS",
            "ACT_DOTA_MIDNIGHT_PULSE",
            "ACT_DOTA_ANCESTRAL_SPIRIT",
            "ACT_DOTA_THUNDER_STRIKE",
            "ACT_DOTA_KINETIC_FIELD",
            "ACT_DOTA_STATIC_STORM",
            "ACT_DOTA_MINI_TAUNT",
            "ACT_DOTA_ARCTIC_BURN_END",
            "ACT_DOTA_LOADOUT_RARE",
            "ACT_DOTA_SWIM",
            "ACT_DOTA_FLEE",
            "ACT_DOTA_TROT",
            "ACT_DOTA_SHAKE",
            "ACT_DOTA_SWIM_IDLE",
            "ACT_DOTA_WAIT_IDLE",
            "ACT_DOTA_GREET",
            "ACT_DOTA_TELEPORT_COOP_START",
            "ACT_DOTA_TELEPORT_COOP_WAIT",
            "ACT_DOTA_TELEPORT_COOP_END",
            "ACT_DOTA_TELEPORT_COOP_EXIT",
            "ACT_DOTA_SHOPKEEPER_PET_INTERACT",
            "ACT_DOTA_ITEM_PICKUP",
            "ACT_DOTA_ITEM_DROP",
            "ACT_DOTA_CAPTURE_PET",
            "ACT_DOTA_PET_WARD_OBSERVER",
            "ACT_DOTA_PET_WARD_SENTRY",
            "ACT_DOTA_PET_LEVEL",
            "ACT_DOTA_CAST_BURROW_END",
            "ACT_DOTA_LIFESTEALER_ASSIMILATE",
            "ACT_DOTA_LIFESTEALER_EJECT",
            "ACT_DOTA_ATTACK_EVENT_BASH",
            "ACT_DOTA_CAPTURE_RARE",
            "ACT_DOTA_AW_MAGNETIC_FIELD",
            "ACT_DOTA_CAST_GHOST_SHIP",
        };
        string[] VarTypes =
        {
            "FIELD_INTEGER",
            "FIELD_FLOAT"
        };
        string[] AttributeList =
        {
            "MODIFIER_ATTRIBUTE_IGNORE_INVULNERABLE",
            "MODIFIER_ATTRIBUTE_MULTIPLE",
            "MODIFIER_ATTRIBUTE_NONE",
            "MODIFIER_ATTRIBUTE_PERMANENT",
        };
        string[] EffectAttachTypeList =
        {
            "follow_origin",
            "follow_overhead",
            "start_at_customorigin",
            "world_origin",
            "attach_origin",
            "attach_hitloc"
        };
        string[] FlagList =
        {
            "DOTA_UNIT_TARGET_FLAG_NONE",
            "DOTA_UNIT_TARGET_FLAG_RANGED_ONLY",
            "DOTA_UNIT_TARGET_FLAG_MELEE_ONLY",
            "DOTA_UNIT_TARGET_FLAG_DEAD",
            "DOTA_UNIT_TARGET_FLAG_MAGIC_IMMUNE_ENEMIES",
            "DOTA_UNIT_TARGET_FLAG_NOT_MAGIC_IMMUNE_ALLIES",
            "DOTA_UNIT_TARGET_FLAG_INVULNERABLE",
            "DOTA_UNIT_TARGET_FLAG_FOW_VISIBLE",
            "DOTA_UNIT_TARGET_FLAG_NO_INVIS",
            "DOTA_UNIT_TARGET_FLAG_NOT_ANCIENTS",
            "DOTA_UNIT_TARGET_FLAG_PLAYER_CONTROLLED",
            "DOTA_UNIT_TARGET_FLAG_NOT_DOMINATED",
            "DOTA_UNIT_TARGET_FLAG_NOT_SUMMONED",
            "DOTA_UNIT_TARGET_FLAG_NOT_ILLUSIONS",
            "DOTA_UNIT_TARGET_FLAG_NOT_ATTACK_IMMUNE",
            "DOTA_UNIT_TARGET_FLAG_MANA_ONLY",
            "DOTA_UNIT_TARGET_FLAG_CHECK_DISABLE_HELP",
            "DOTA_UNIT_TARGET_FLAG_NOT_CREEP_HERO",
            "DOTA_UNIT_TARGET_FLAG_OUT_OF_WORLD",
            "DOTA_UNIT_TARGET_FLAG_NOT_NIGHTMARED",
        };
        string[] TargetList =
        {
            "CASTER",
            "TARGET",
            "POINT",
            "ATTACKER",
            "UNIT"
        };
        string[] EventList = new string[] { "OnSpellStart", "OnChannelFinish", "OnChannelInterrupted", "OnChannelSucceeded", "OnOwnerDied", "OnOwnerSpawned", "OnProjectileFinish", "OnProjectileHitUnit", "OnToggleOff", "OnToggleOn", "OnUpgrade", "OnAbilityEndChannel", "OnAbilityStart", "OnAttack", "OnAttackAllied", "OnAttackFailed", "OnCreated", "OnEquip", "OnHealReceived", "OnHealthGained", "OnHeroKilled", "OnManaGained", "OnOrder", "OnProjectileDodge", "OnRespawn", "OnSpentMana", "OnStateChanged", "OnTeleported", "OnTeleporting", "OnUnitMoved" };
        string[] ActionList = new string[] {
            "AddAbility",
            "ActOnTargets",
            "ApplyModifier",
            "ApplyMotionController",
            "AttachEffect",
            "Blink",
            "CleaveAttack",
            "CreateBonusAttack",
            "CreateThinker",
            "CreateThinkerWall",
            "CreateItem",
            "Damage",
            "DelayedAction",
            "DestroyTrees",
            "FireEffect",
            "FireSound",
            "Heal",
            "IsCasterAlive",
            "Knockback",
            "LevelUpAbility",
            "Lifesteal",
            "LinearProjectile",
            "MoveUnit",
            "Random",
            "RemoveAbility",
            "RemoveModifier",
            "RemoveUnit",
            "RunScript",
            "SpendCharge",
            "SpawnUnit",
            "Stun",
            "SpendMana",
            "TrackingProjectile"
        };
        object[] ActionPropertiesList = new object[] {
            new string[]{ "Target", "AbilityName" },
            new string[]{"Action"},
            new string[]{ "Target", "ModifierName"},
            new string[]{ "Target", "ScriptFile", "HorizontalControlFunction", "VerticalControlFunction", "TestGravityFunc"},
            new string[]{ "EffectName", "EffectAttachType", "Target", "ControlPoints", "TargetPoint", "EffectRadius", "EffectDurationScale", "EffectLifeDurationScale", "EffectColorA", "EffectColorB", "EffectAlphaScale"},
            new string[]{"Target"},
            new string[]{ "CleavePercent", "CleaveRadius"},
            new string[]{ "Target"},
            new string[]{ "Target", "ModifierName"},
            new string[]{ "Target", "ModifierName", "Width", "Length", "Rotation"},
            new string[]{ "Target", "ItemName", "ItemCount", "ItemChargeCount", "SpawnRadius", "LaunchHeight", "LaunchDistance", "LaunchDuration"},
            new string[]{ "Target", "Type", "MinDamage", "MaxDamage", "Damage", "CurrentHealthPercentBasedDamage", "MaxHealthPercentBasedDamage"},
            new string[]{ "Delay", "Action"},
            new string[]{ "Target", "Radius"},
            new string[]{ "EffectName", "EffectAttachType", "Target", "ControlPoints", "TargetPoint", "EffectRadius", "EffectDurationScale", "EffectLifeDurationScale", "EffectColorA", "EffectColorB", "EffectAlphaScale"},
            new string[]{ "EffectName", "Target"},
            new string[]{ "HealAmount", "Target"},
            new string[]{ },
            new string[]{ "Target", "Center", "Duration", "Distance", "Height", "IsFixedDistance", "ShouldStun"},
            new string[]{ "Target", "AbilityName"},
            new string[]{ "Target", "LifestealPercent"},
            new string[]{ "Target", "EffectName", "MoveSpeed", "StartRadius", "EndRadius", "FixedDistance", "StartPosition", "TargetTeams", "TargetTypes", "TargetFlags", "HasFrontalCone", "ProvidesVision", "VisionRadius"},
            new string[]{ "Target", "MoveToTarget"},
            new string[]{ "Chance", "PseudoRandom", "OnSuccess", "OnFailure"},
            new string[]{ "Target", "AbilityName"},
            new string[]{ "Target", "ModifierName"},
            new string[]{ "Target"},
            new string[]{ "Target", "ScriptFile", "Function"},
            new string[]{ },
            new string[]{ "UnitName", "UnitCount", "UnitLimit", "SpawnRadius", "Duration", "Target", "GrantsGold", "GrantsXP"},
            new string[]{ "Target", "Duration"},
            new string[]{ "Mana"},
            new string[]{ "Target", "EffectName", "Dodgeable", "ProvidesVision", "VisionRadius", "MoveSpeed", "SourceAttachment" }
        };
        string[] ModifierEventList = new string[]
        {
            "OnIntervalThink",
            "OnAbilityExecuted",
            "OnAttacked",
            "OnAttackLanded",
            "OnAttackStart",
            "OnCreated",
            "OnDealDamage",
            "OnDeath",
            "OnDestroy",
            "OnKill",
            "OnHeroKilled",
            "OnOrbFire",
            "OnOrbImpact",
            "OnTakeDamage",
            "Orb",
        };
        string[] DeclarationList =
        {
            "DECLARE_PURCHASES_IN_SPEECH",
            "DECLARE_PURCHASES_TO_SPECTATORS",
            "DECLARE_PURCHASES_TO_TEAMMATES"
        };
        string[] ShareabilityList =
        {
            "ITEM_NOT_SHAREABLE",
            "ITEM_PARTIALLY_SHAREABLE",
            "ITEM_FULLY_SHAREABLE",
            "ITEM_FULLY_SHAREABLE_STACKING"
        };
        string[] QualityList =
        {
            "artifact",
            "epic",
            "rare",
            "common",
            "component",
            "consumable"
        };
        string[] DisassembleRuleList =
        {
            "DOTA_ITEM_DISASSEMBLE_ALWAYS",
            "DOTA_ITEM_DISASSEMBLE_NEVER"
        };

        //[0] == name
        //[1] == type
        //types:
        //

        int nodenum = 0;
        string selectednode = null;

        public Form1()
        {
            InitializeComponent();
        }

        public string RemovePath(string str)
        {
            return str.Substring(str.LastIndexOf(@"\") + 1);
        }

        public void SaveNodeChanges()
        {
            if (selectednode != null)
            {
                TreeNode[] neednode = treeView1.Nodes.Find(selectednode, true);
                object[] data = (object[])neednode[0].Tag;
                object[] elementsdata = (object[])splitContainer1.Panel2.Tag;
                for (int i = 2; i < data.Length; i++)
                {
                    object[] elementdata = (object[])elementsdata[i - 2];
                    if (data[i].GetType() == typeof(MyCheckbox))
                    {
                        MyCheckbox thisdata = (MyCheckbox)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        thisdata.check = mycheck.Checked;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxString)) 
                    {
                        MyCheckboxString thisdata = (MyCheckboxString)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        thisdata.check = mycheck.Checked;
                        thisdata.str = mytextbox.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringOpen))
                    {
                        MyCheckboxStringOpen thisdata = (MyCheckboxStringOpen)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        thisdata.check = mycheck.Checked;
                        thisdata.str = mytextbox.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyString))
                    {
                        MyString thisdata = (MyString)data[i];
                        TextBox mytextbox = (TextBox)elementdata[0];
                        thisdata.str = mytextbox.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyStringSelect))
                    {
                        MyStringSelect thisdata = (MyStringSelect)data[i];
                        TextBox mytextbox = (TextBox)elementdata[0];
                        thisdata.str = mytextbox.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringSelect))
                    {
                        MyCheckboxStringSelect thisdata = (MyCheckboxStringSelect)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        thisdata.check = mycheck.Checked;
                        thisdata.str = mytextbox.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringString))
                    {
                        MyCheckboxStringString thisdata = (MyCheckboxStringString)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        TextBox mytextbox2 = (TextBox)elementdata[2];
                        thisdata.check = mycheck.Checked;
                        thisdata.str1 = mytextbox.Text;
                        thisdata.str2 = mytextbox2.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringStringSelect))
                    {
                        MyCheckboxStringStringSelect thisdata = (MyCheckboxStringStringSelect)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        TextBox mytextbox2 = (TextBox)elementdata[2];
                        thisdata.check = mycheck.Checked;
                        thisdata.str1 = mytextbox.Text;
                        thisdata.str2 = mytextbox2.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringSelectString))
                    {
                        MyCheckboxStringSelectString thisdata = (MyCheckboxStringSelectString)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        TextBox mytextbox2 = (TextBox)elementdata[2];
                        thisdata.check = mycheck.Checked;
                        thisdata.str1 = mytextbox.Text;
                        thisdata.str2 = mytextbox2.Text;
                        data[i] = thisdata;
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringSelectStringSelect))
                    {
                        MyCheckboxStringSelectStringSelect thisdata = (MyCheckboxStringSelectStringSelect)data[i];
                        CheckBox mycheck = (CheckBox)elementdata[0];
                        TextBox mytextbox = (TextBox)elementdata[1];
                        TextBox mytextbox2 = (TextBox)elementdata[2];
                        thisdata.check = mycheck.Checked;
                        thisdata.str1 = mytextbox.Text;
                        thisdata.str2 = mytextbox2.Text;
                        data[i] = thisdata;
                    }
                }

                neednode[0].Tag = data;
                selectednode = null;
            }
        }

        public void LoadFileInfo(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            TreeNode thisnode = (TreeNode)thisb.Tag;
            object[] data = (object[])thisnode.Tag;
            string line = "";
            string filetext = "";
            StreamReader file = new StreamReader((string)data[0]);
            while ((line = file.ReadLine()) != null)
            {
                if (line.IndexOf(@"//") != -1)
                {
                    filetext = filetext + line.Substring(0, line.IndexOf(@"//"));
                }
                else
                {
                    filetext = filetext + line;
                }
            }
            file.Close();
            //Debug.WriteLine(filetext);
            MyNodeData alldata = new MyNodeData();
            alldata.name = thisnode.Text.Substring(0,thisnode.Text.Length - 4);
            alldata.childs = new List<MyNodeData>();
            alldata.data = new Dictionary<string, string>();
            int level = 0;
            string locstr = "";
            bool writemode = false;
            string locstr2 = "";
            bool writed = false;
            for (int i = 0; filetext.Length > i; i++)
            {
                if (writemode == true)
                {
                    if (filetext[i] == '"')
                    {
                        writemode = false;
                        if (writed == false)
                        {
                            locstr2 = locstr;
                            writed = true;
                            locstr = "";
                        }
                        else
                        {
                            alldata.AddStringStringData(locstr2,locstr,level);
                            locstr2 = "";
                            locstr = "";
                            writed = false;
                        }
                    }
                    else
                    {
                        locstr = locstr + filetext[i];
                    }
                }
                else
                {
                    if (filetext[i] == '"')
                    {
                        if (writemode == false)
                        {
                            writemode = true;
                        }
                    }
                    else if (filetext[i] == '{')
                    {
                        alldata.CreateChield(locstr2,level);
                        writed = false;
                        level++;
                        locstr = "";
                        locstr2 = "";
                    }
                    else if (filetext[i] == '}')
                    {
                        level--;
                    }
                }
            }
            level = 0;
            string[] nodes = new string[1];
            nodes[0] = thisnode.Name;
            CreateNodes(alldata, nodes, level);
            //ClearPanels();
        }

        public void CreateNodes(MyNodeData nowselected, string[] nodes, int level)
        {
            if (nowselected.data.TryGetValue("BaseClass", out _))
            {
                string value = "";
                nowselected.data.TryGetValue("BaseClass", out value);
                if (value == "ability_datadriven")
                {
                    Array.Resize(ref nodes, nodes.Length + 1);
                    nodes[level + 1] = CreateAbility(nowselected.name, nowselected.data, nodes[level]);
                }
                else if (value == "item_datadriven")
                {
                    Array.Resize(ref nodes, nodes.Length + 1);
                    nodes[level + 1] = CreateItem(nowselected.name, nowselected.data, nodes[level]);
                }
                else
                {
                    Array.Resize(ref nodes, nodes.Length + 1);
                    nodes[level + 1] = AddAbilityDataByObject(nowselected, nodes[level]);
                }
            }
            else
            {
                    Array.Resize(ref nodes, nodes.Length + 1);
                    nodes[level + 1] = AddAbilityDataByObject(nowselected, nodes[level]);
            }
            for (int i = 0; nowselected.childs.Count > i; i++)
            {
                CreateNodes(nowselected.childs[i], nodes, level+1);
            }
        }

        public class MyNodeData
        {
            public string name { get; set; }
            public List<MyNodeData> childs { get; set; }
            public Dictionary<string, string> data { get; set; }
            public int level { get; set; }

            public void AddStringStringData(string str1, string str2,int level)
            {
                if (level > this.level)
                {
                    childs[childs.Count - 1].AddStringStringData(str1, str2, level);
                }
                else
                {
                    data[str1] = str2;
                }
            }

            public void CreateChield(string name, int level)
            {
                if (level > this.level)
                {
                    childs[childs.Count - 1].CreateChield(name, level);
                }
                else
                {
                    MyNodeData newcield = new MyNodeData();
                    newcield.name = name;
                    newcield.level = this.level + 1;
                    newcield.childs = new List<MyNodeData>();
                    newcield.data = new Dictionary<string, string>();
                    childs.Add(newcield);
                }
            }

            public MyNodeData GetChield(int level)
            {
                if (level > this.level)
                {
                    return childs[0];
                }
                else
                {
                    return childs[0].GetChield(level);
                }
            }
        }

        public void OpenFile(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            Process.Start((string)thisb.Tag);
        }

        public void DeleteNode(object sender, EventArgs e)
        {
            ClearPanels();
            Button thisb = (Button)sender;
            treeView1.Nodes.Remove((TreeNode)thisb.Tag);
        }

        public void LoadFiles(string nodekey, string[] files)
        {
            for (int i = 0; files.Length > i; i++)
            {
                if (files[i].Substring(files[i].Length - 4) == ".txt")
                {
                    TreeNode newnode = new TreeNode();
                    if (nodekey != null)
                    {
                        TreeNode[] neednodes = treeView1.Nodes.Find(nodekey, true);
                        newnode = neednodes[0].Nodes.Add(RemovePath(files[i]));
                    }
                    else
                    {
                        newnode = treeView1.Nodes.Add(RemovePath(files[i]));
                    }
                    newnode.Name = "node" + nodenum;
                    nodenum++;
                    newnode.Tag = new object[]
                    {
                        files[i],
                        "file.txt"
                    };
                }
                else if (files[i].Substring(files[i].Length - 4) == ".lua")
                {
                    TreeNode newnode = new TreeNode();
                    if (nodekey != null)
                    {
                        TreeNode[] neednodes = treeView1.Nodes.Find(nodekey, true);
                        newnode = neednodes[0].Nodes.Add(RemovePath(files[i]));
                    }
                    else
                    {
                        newnode = treeView1.Nodes.Add(RemovePath(files[i]));
                    }
                    if (files[i].IndexOf("vscripts") != -1)
                    {
                        newnode.Name = files[i].Substring(files[i].IndexOf("vscripts") + 9);
                    }
                    else
                    {
                        newnode.Name = RemovePath(files[i]);
                    }
                    //Debug.WriteLine(newnode.Name);
                    newnode.Tag = new object[]
                    {
                        files[i],
                        "file.lua"
                    };
                }
            }
        }

        public void LoadFolders(string nodekey, string[] folders)
        {
            for (int i = 0; folders.Length > i; i++)
            {
                TreeNode[] neednode = treeView1.Nodes.Find(nodekey, true);
                TreeNode newnode = neednode[0].Nodes.Add(RemovePath(folders[i]));
                newnode.Name = "node" + nodenum;
                nodenum++;
                newnode.Tag = new object[]
                {
                        folders[i],
                        "folder"
                };
                string[] files = Directory.GetFiles(folders[i]);
                string[] newfolders = Directory.GetDirectories(folders[i]);
                LoadFolders(newnode.Name, newfolders);
                LoadFiles(newnode.Name, files);
            }
        }

        public void ClearPanels()
        {
            SaveNodeChanges();
            splitContainer1.Panel1.Tag = null;
            splitContainer1.Panel2.Tag = null;
            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel2.Controls.Clear();
            object[] menutag = (object[])menuStrip2.Tag;
            if (menutag != null)
            for (int i = 0; menutag.Length > i; i++)
            {
                ToolStripItem item = (ToolStripItem)menutag[i];
                item.Dispose();
            }
        }

        public void AddString(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            object[] objlist = (object[])thisb.Tag;
            ListBox listbox = (ListBox)objlist[0];
            TextBox textbox = (TextBox)objlist[1];
            if (listbox.SelectedItem != null)
            {
                if (textbox.Text == "")
                {
                    textbox.Text = listbox.SelectedItem.ToString();
                }
                else
                {
                    textbox.Text = textbox.Text + " | " + listbox.SelectedItem.ToString();
                }
            }
        }

        public void OpenLuaFile(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            object[] objlist = (object[])thisb.Tag;
            TextBox textbox = (TextBox)objlist[0];
            TreeNode[] neednodes = treeView1.Nodes.Find(textbox.Text.Replace(@"/", @"\"), true);
            if (neednodes.Length > 0)
            {
                object[] nodetag = (object[])neednodes[0].Tag;
                string path = (string)nodetag[0];
                Process.Start(path.Replace(@"/",@"\"));
            }
            else
            {
                MessageBox.Show("Lua file not found!", "Error");
            }
        }

        public void SelectModeOn(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            menuStrip2.Visible = false;
            //treeView1.Visible = false;
            splitContainer2.Visible = false;
            Button thisb = (Button)sender;
            object[] objlist = (object[])thisb.Tag;
            TextBox oldtextbox = (TextBox)objlist[0];
            TextBox newtextbox = new TextBox();
            newtextbox.Text = oldtextbox.Text;
            newtextbox.Location = new Point(20, 20);
            newtextbox.Size = new Size(700, 24);
            Controls.Add(newtextbox);
            newtextbox.BringToFront();
            Label newlabel = new Label();
            newlabel.Text = "Search:";
            newlabel.Location = new Point(20, 54);
            newlabel.Size = new Size(60, 24);
            Controls.Add(newlabel);
            newlabel.BringToFront();
            ListBox newlistbox = new ListBox();
            string[] strlist = (string[])objlist[1];
            newlistbox.Items.AddRange(strlist);
            newlistbox.Tag = strlist;
            newlistbox.Location = new Point(20, 85);
            newlistbox.Size = new Size(500, 400);
            Controls.Add(newlistbox);
            newlistbox.BringToFront();
            TextBox newtextbox2 = new TextBox();
            newtextbox2.Location = new Point(70, 50);
            newtextbox2.Size = new Size(320, 24);
            newtextbox2.TextChanged += FindChanged;
            newtextbox2.Tag = newlistbox;
            Controls.Add(newtextbox2);
            newtextbox2.BringToFront();
            Button newbutton = new Button();
            //newbutton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            newbutton.Location = new Point(530, 93);
            newbutton.Size = new Size(80, 23);
            newbutton.Text = "Add";
            newbutton.Tag = new object[] { newlistbox, newtextbox };
            newbutton.Click += AddString;
            Controls.Add(newbutton);
            newbutton.BringToFront();
            Button newbutton2 = new Button();
            //newbutton2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            newbutton2.Location = new Point(530, 123);
            newbutton2.Size = new Size(80, 23);
            newbutton2.Text = "Back";
            newbutton2.Tag = new object[] { oldtextbox, newtextbox, newlistbox, newbutton, newtextbox2, newlabel };
            newbutton2.Click += SelectModeOff;
            Controls.Add(newbutton2);
            newbutton2.BringToFront();
        }

        public void FindChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            ListBox newlistbox = (ListBox)textbox.Tag;
            string[] items = (string[])newlistbox.Tag;
            newlistbox.Items.Clear();
            if (textbox.Text != "")
            {
                string[] items1 = new string[0];
                string[] items2 = new string[0];
                for (int i = 0; items.Length > i; i++ )
                {
                    if (items[i].ToLower().IndexOf(textbox.Text.ToLower()) != -1)
                    {
                        Array.Resize(ref items1, items1.Length + 1);
                        items1[items1.Length - 1] = items[i];
                    }
                    else
                    {
                        Array.Resize(ref items2, items2.Length + 1);
                        items2[items2.Length - 1] = items[i];
                    }
                }
                newlistbox.Items.AddRange(items1);
                newlistbox.Items.AddRange(items2);
            }
            else
            {
                newlistbox.Items.AddRange(items);
            }
        }

        public void SelectModeOff(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            object[] objlist = (object[])thisb.Tag;
            TextBox oldtextbox = (TextBox)objlist[0];
            TextBox newtextbox = (TextBox)objlist[1];
            ListBox newlistbox = (ListBox)objlist[2];
            Button newbutton = (Button)objlist[3];
            TextBox newtextbox2 = (TextBox)objlist[4];
            Label newlabel = (Label)objlist[5];
            oldtextbox.Text = newtextbox.Text;
            thisb.Dispose();
            newtextbox.Dispose();
            newlistbox.Dispose();
            newbutton.Dispose();
            newtextbox2.Dispose();
            newlabel.Dispose();
            menuStrip1.Visible = true;
            menuStrip2.Visible = true;
            //treeView1.Visible = true;
            splitContainer2.Visible = true;
        }

        public void CreateAbilityButtonClick(object sender, EventArgs e)
        {
            TextBox namebox = (TextBox)splitContainer1.Panel2.Tag;
            if (namebox.Text != "")
            {
                TreeNode[] neednode = treeView1.Nodes.Find(CreateAbility(namebox.Text, new Dictionary<string, string>(), null), true);
                treeView1.SelectedNode = neednode[0];
            }
            else
            {
                MessageBox.Show("Invalid name!", "Error");
            }
        }

        public string CreateAbility(string name, Dictionary<string, string> data, string nodename)
        {
            TreeNode newnode = new TreeNode();
            if (nodename != null)
            {
                TreeNode[] neednode = treeView1.Nodes.Find(nodename, true);
                newnode = neednode[0].Nodes.Add(name);
                if (!neednode[0].IsExpanded)
                    neednode[0].Toggle();
            }
            else
            {
                newnode = treeView1.Nodes.Add(name);
            }
            newnode.Name = "node" + nodenum;
            nodenum++;
            string[] ThisEventList = new string[2 + EventList.Length];
            new string[] { "AbilitySpecial", "Modifiers" }.CopyTo(ThisEventList, 0);
            EventList.CopyTo(ThisEventList, 2);
            object[] tagobj = new object[] {
                    name,
                    "ability",
                    new MyCheckboxString(){ name = "ID", check = data.TryGetValue("ID", out _), str = MyMiniF(data,"ID") ?? "" },
                    new MyStringSelect(){ name = "AbilityBehavior", str = MyMiniF(data,"AbilityBehavior") ?? "", selectlist = AbilityBehaviorSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityType", check = data.TryGetValue("AbilityType", out _), str = MyMiniF(data,"AbilityType") ?? "", selectlist = AbilityTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetType", check = data.TryGetValue("AbilityUnitTargetType", out _), str = MyMiniF(data,"AbilityUnitTargetType") ?? "", selectlist = UnitTargetTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetTeam", check = data.TryGetValue("AbilityUnitTargetTeam", out _), str = MyMiniF(data,"AbilityUnitTargetTeam") ?? "", selectlist = TeamsList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitDamageType", check = data.TryGetValue("AbilityUnitDamageType", out _), str = MyMiniF(data,"AbilityUnitDamageType") ?? "", selectlist = DamageTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "SpellImmunityType", check = data.TryGetValue("SpellImmunityType", out _), str = MyMiniF(data,"SpellImmunityType") ?? "", selectlist = SpellImmunityTypeList },
                    new MyCheckboxString(){ name = "CastFilterRejectCaster", check = data.TryGetValue("CastFilterRejectCaster", out _), str = MyMiniF(data,"CastFilterRejectCaster") ?? "1" },
                    new MyCheckboxString(){ name = "IsCastableWhileHidden", check = data.TryGetValue("IsCastableWhileHidden", out _), str = MyMiniF(data,"IsCastableWhileHidden") ?? "1" },
                    new MyCheckboxString(){ name = "IsOnCastBar", check = data.TryGetValue("IsOnCastBar", out _), str = MyMiniF(data,"IsOnCastBar") ?? "1" },
                    new MyCheckboxString(){ name = "IsOnLearnbar", check = data.TryGetValue("IsOnLearnbar", out _), str = MyMiniF(data,"IsOnLearnbar") ?? "1" },
                    new MyCheckboxString(){ name = "AbilityTextureName", check = data.TryGetValue("AbilityTextureName", out _), str = MyMiniF(data,"AbilityTextureName") ?? "" },
                    new MyCheckboxString(){ name = "MaxLevel", check = data.TryGetValue("MaxLevel", out _), str = MyMiniF(data,"MaxLevel") ?? "1" },
                    new MyCheckboxString(){ name = "RequiredLevel", check = data.TryGetValue("RequiredLevel", out _), str = MyMiniF(data,"RequiredLevel") ?? "" },
                    new MyCheckboxString(){ name = "LevelsBetweenUpgrades", check = data.TryGetValue("LevelsBetweenUpgrades", out _), str = MyMiniF(data,"LevelsBetweenUpgrades") ?? "" },
                    new MyCheckboxStringSelect(){ name = "AbilityCastAnimation", check = data.TryGetValue("AbilityCastAnimation", out _), str = MyMiniF(data,"AbilityCastAnimation") ?? "", selectlist = AbilityCastAnimationList },
                    new MyCheckboxString(){ name = "AnimationPlaybackRate", check = data.TryGetValue("AnimationPlaybackRate", out _), str = MyMiniF(data,"AnimationPlaybackRate") ?? "1" },
                    new MyCheckboxString(){ name = "AnimationIgnoresModelScale", check = data.TryGetValue("AnimationIgnoresModelScale", out _), str = MyMiniF(data,"AnimationIgnoresModelScale") ?? "1" },
                    new MyCheckboxString(){ name = "AbilityCastRange", check = data.TryGetValue("AbilityCastRange", out _), str = MyMiniF(data,"AbilityCastRange") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityCastRangeBuffer", check = data.TryGetValue("AbilityCastRangeBuffer", out _), str = MyMiniF(data,"AbilityCastRangeBuffer") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityCastMinimumRange", check = data.TryGetValue("AbilityCastMinimumRange", out _), str = MyMiniF(data,"AbilityCastMinimumRange") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityChannelTime", check = data.TryGetValue("AbilityChannelTime", out _), str = MyMiniF(data,"AbilityChannelTime") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityChannelledManaCostPerSecond", check = data.TryGetValue("AbilityChannelledManaCostPerSecond", out _), str = MyMiniF(data,"AbilityChannelledManaCostPerSecond") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityDuration", check = data.TryGetValue("AbilityDuration", out _), str = MyMiniF(data,"AbilityDuration") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityCastPoint", check = data.TryGetValue("AbilityCastPoint", out _), str = MyMiniF(data,"AbilityCastPoint") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityCooldown", check = data.TryGetValue("AbilityCooldown", out _), str = MyMiniF(data,"AbilityCooldown") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityManaCost", check = data.TryGetValue("AbilityManaCost", out _), str = MyMiniF(data,"AbilityManaCost") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityGoldCost", check = data.TryGetValue("AbilityGoldCost", out _), str = MyMiniF(data,"AbilityGoldCost") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityUpgradeGoldCost", check = data.TryGetValue("AbilityUpgradeGoldCost", out _), str = MyMiniF(data,"AbilityUpgradeGoldCost") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityDamage", check = data.TryGetValue("AbilityDamage", out _), str = MyMiniF(data,"AbilityDamage") ?? "0" },
                    new MyCheckboxString(){ name = "AOERadius", check = data.TryGetValue("AOERadius", out _), str = MyMiniF(data,"AOERadius") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityProcsMagicStick", check = data.TryGetValue("AbilityProcsMagicStick", out _), str = MyMiniF(data,"AbilityProcsMagicStick") ?? "1" },
                    new MyCheckboxString(){ name = "HotKeyOverride", check = data.TryGetValue("HotKeyOverride", out _), str = MyMiniF(data,"HotKeyOverride") ?? "" },
                    new MyCheckboxString(){ name = "DisplayAdditionalHeroes", check = data.TryGetValue("DisplayAdditionalHeroes", out _), str = MyMiniF(data,"DisplayAdditionalHeroes") ?? "1" },
                };
            data = DeleteItems(data, new string[] {
                "BaseClass",
                "ID",
                "AbilityBehavior",
                "AbilityType",
                "AbilityUnitTargetType",
                "AbilityUnitTargetTeam",
                "AbilityUnitDamageType",
                "SpellImmunityType",
                "CastFilterRejectCaster",
                "IsCastableWhileHidden",
                "IsOnCastBar",
                "IsOnLearnbar",
                "AbilityTextureName",
                "MaxLevel",
                "RequiredLevel",
                "LevelsBetweenUpgrades",
                "AbilityCastAnimation",
                "AnimationPlaybackRate",
                "AnimationIgnoresModelScale",
                "AbilityCastRange",
                "AbilityCastRangeBuffer",
                "AbilityCastMinimumRange",
                "AbilityChannelTime",
                "AbilityChannelledManaCostPerSecond",
                "AbilityDuration",
                "AbilityCastPoint",
                "AbilityCooldown",
                "AbilityManaCost",
                "AbilityGoldCost",
                "AbilityUpgradeGoldCost",
                "AbilityDamage",
                "AOERadius",
                "AbilityProcsMagicStick",
                "HotKeyOverride",
                "DisplayAdditionalHeroes"
            });
            Array.Resize(ref tagobj, tagobj.Length + data.Count + 1);
            if (data.Count > 0)
            {
                for (int i = 0; data.Count > i; i++)
                {
                    tagobj[tagobj.Length+i-(data.Count+1)] = new MyCheckboxString() { name = data.ElementAt(i).Key, check = true, str = data.ElementAt(i).Value };
                }
            }
            tagobj[tagobj.Length - 1] = new MyAddNodes() { items = ThisEventList };
            newnode.Tag = tagobj;
            return newnode.Name;
        }

        public Dictionary<string, string> DeleteItems(Dictionary<string, string> data, string[] deletelist)
        {
            for (int i = 0; deletelist.Length > i; i++)
            {
                data.Remove(deletelist[i]);
            }
            return data;
        }

        public string CreateItem(string name, Dictionary<string, string> data, string nodename)
        {
            TreeNode newnode = new TreeNode();
            if (nodename != null)
            {
                TreeNode[] neednode = treeView1.Nodes.Find(nodename, true);
                newnode = neednode[0].Nodes.Add(name);
                if (!neednode[0].IsExpanded)
                    neednode[0].Toggle();
            }
            else
            {
                newnode = treeView1.Nodes.Add(name);
            }
            newnode.Name = "node" + nodenum;
            nodenum++;
            string[] ThisEventList = new string[3 + EventList.Length];
            new string[] { "ItemRequirements", "AbilitySpecial", "Modifiers" }.CopyTo(ThisEventList, 0);
            EventList.CopyTo(ThisEventList, 3);
            object[] tagobj = new object[] {
                    name,
                    "item",
                    new MyCheckboxString(){ name = "ID", check = data.TryGetValue("ID", out _), str = MyMiniF(data,"ID") ?? "" },
                    new MyCheckboxString(){ name = "ItemRecipe", check = data.TryGetValue("ItemRecipe", out _), str = MyMiniF(data,"ItemRecipe") ?? "0" },
                    new MyCheckboxString(){ name = "ItemResult", check = data.TryGetValue("ItemResult", out _), str = MyMiniF(data,"ItemResult") ?? "" },
                    new MyCheckboxString(){ name = "AbilityName", check = data.TryGetValue("AbilityName", out _), str = MyMiniF(data,"AbilityName") ?? "" },
                    new MyStringSelect(){ name = "AbilityBehavior", str = MyMiniF(data,"AbilityBehavior") ?? "", selectlist = AbilityBehaviorSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityType", check = data.TryGetValue("AbilityType", out _), str = MyMiniF(data,"AbilityType") ?? "", selectlist = AbilityTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetType", check = data.TryGetValue("AbilityUnitTargetType", out _), str = MyMiniF(data,"AbilityUnitTargetType") ?? "", selectlist = UnitTargetTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetTeam", check = data.TryGetValue("AbilityUnitTargetTeam", out _), str = MyMiniF(data,"AbilityUnitTargetTeam") ?? "", selectlist = TeamsList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitDamageType", check = data.TryGetValue("AbilityUnitDamageType", out _), str = MyMiniF(data,"AbilityUnitDamageType") ?? "", selectlist = DamageTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "SpellImmunityType", check = data.TryGetValue("SpellImmunityType", out _), str = MyMiniF(data,"SpellImmunityType") ?? "", selectlist = SpellImmunityTypeList },
                    new MyCheckboxString(){ name = "CastFilterRejectCaster", check = data.TryGetValue("CastFilterRejectCaster", out _), str = MyMiniF(data,"CastFilterRejectCaster") ?? "" },
                    new MyCheckboxString(){ name = "Model", check = data.TryGetValue("Model", out _), str = MyMiniF(data,"Model") ?? "" },
                    new MyCheckboxString(){ name = "Effect", check = data.TryGetValue("Effect", out _), str = MyMiniF(data,"Effect") ?? "" },
                    new MyCheckboxString(){ name = "AbilityTextureName", check = data.TryGetValue("AbilityTextureName", out _), str = MyMiniF(data,"AbilityTextureName") ?? "" },
                    new MyCheckboxString(){ name = "MaxUpgradeLevel", check = data.TryGetValue("MaxUpgradeLevel", out _), str = MyMiniF(data,"MaxUpgradeLevel") ?? "1" },
                    new MyCheckboxString(){ name = "ItemBaseLevel", check = data.TryGetValue("ItemBaseLevel", out _), str = MyMiniF(data,"ItemBaseLevel") ?? "1" },
                    new MyCheckboxStringSelect(){ name = "AbilityCastAnimation", check = data.TryGetValue("AbilityCastAnimation", out _), str = MyMiniF(data,"AbilityCastAnimation") ?? "", selectlist = AbilityCastAnimationList },
                    new MyCheckboxString(){ name = "AbilityCastRange", check = data.TryGetValue("AbilityCastRange", out _), str = MyMiniF(data,"AbilityCastRange") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityCastPoint", check = data.TryGetValue("AbilityCastPoint", out _), str = MyMiniF(data,"AbilityCastPoint") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityCooldown", check = data.TryGetValue("AbilityCooldown", out _), str = MyMiniF(data,"AbilityCooldown") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityManaCost", check = data.TryGetValue("AbilityManaCost", out _), str = MyMiniF(data,"AbilityManaCost") ?? "0" },
                    new MyCheckboxString(){ name = "AbilityDamage", check = data.TryGetValue("AbilityDamage", out _), str = MyMiniF(data,"AbilityDamage") ?? "0" },
                    new MyCheckboxString(){ name = "AOERadius", check = data.TryGetValue("AOERadius", out _), str = MyMiniF(data,"AOERadius") ?? "0" },
                    new MyCheckboxStringSelect(){ name = "ItemDeclarations", check = data.TryGetValue("ItemDeclarations", out _), str = MyMiniF(data,"ItemDeclarations") ?? "0", selectlist = DeclarationList },
                    new MyCheckboxString(){ name = "ItemPurchasable", check = data.TryGetValue("ItemPurchasable", out _), str = MyMiniF(data,"ItemPurchasable") ?? "0" },
                    new MyCheckboxString(){ name = "ItemKillable", check = data.TryGetValue("ItemKillable", out _), str = MyMiniF(data,"ItemKillable") ?? "0" },
                    new MyCheckboxString(){ name = "ItemSellable", check = data.TryGetValue("ItemSellable", out _), str = MyMiniF(data,"ItemSellable") ?? "0" },
                    new MyCheckboxString(){ name = "ItemDroppable", check = data.TryGetValue("ItemDroppable", out _), str = MyMiniF(data,"ItemDroppable") ?? "0" },
                    new MyCheckboxString(){ name = "ItemStackable", check = data.TryGetValue("ItemStackable", out _), str = MyMiniF(data,"ItemStackable") ?? "0" },
                    new MyCheckboxString(){ name = "ItemPermanent", check = data.TryGetValue("ItemPermanent", out _), str = MyMiniF(data,"ItemPermanent") ?? "0" },
                    new MyCheckboxStringSelect(){ name = "ItemShareability", check = data.TryGetValue("ItemShareability", out _), str = MyMiniF(data,"ItemShareability") ?? "", selectlist = ShareabilityList },
                    new MyCheckboxStringSelect(){ name = "ItemQuality", check = data.TryGetValue("ItemQuality", out _), str = MyMiniF(data,"ItemQuality") ?? "", selectlist = QualityList },
                    new MyCheckboxStringSelect(){ name = "ItemDisassembleRule", check = data.TryGetValue("ItemDisassembleRule", out _), str = MyMiniF(data,"ItemDisassembleRule") ?? "", selectlist = DisassembleRuleList },
                    new MyCheckboxString(){ name = "ItemShopTags", check = data.TryGetValue("ItemShopTags", out _), str = MyMiniF(data,"ItemShopTags") ?? "" },
                    new MyCheckboxString(){ name = "ItemAliases", check = data.TryGetValue("ItemAliases", out _), str = MyMiniF(data,"ItemAliases") ?? "" },
                    new MyCheckboxString(){ name = "InvalidHeroes", check = data.TryGetValue("InvalidHeroes", out _), str = MyMiniF(data,"InvalidHeroes") ?? "" },
                    new MyCheckboxString(){ name = "ItemCost", check = data.TryGetValue("ItemCost", out _), str = MyMiniF(data,"ItemCost") ?? "0" },
                    new MyCheckboxString(){ name = "ItemStockMax", check = data.TryGetValue("ItemStockMax", out _), str = MyMiniF(data,"ItemStockMax") ?? "0" },
                    new MyCheckboxString(){ name = "ItemStockTime", check = data.TryGetValue("ItemStockTime", out _), str = MyMiniF(data,"ItemStockTime") ?? "0" },
                    new MyCheckboxString(){ name = "ItemStockInitial", check = data.TryGetValue("ItemStockInitial", out _), str = MyMiniF(data,"ItemStockInitial") ?? "0" },
                    new MyCheckboxString(){ name = "ItemInitialCharges", check = data.TryGetValue("ItemInitialCharges", out _), str = MyMiniF(data,"ItemInitialCharges") ?? "0" },
                    new MyCheckboxString(){ name = "ItemDisplayCharges", check = data.TryGetValue("ItemDisplayCharges", out _), str = MyMiniF(data,"ItemDisplayCharges") ?? "0" },
                    new MyCheckboxString(){ name = "ItemRequiresCharges", check = data.TryGetValue("ItemRequiresCharges", out _), str = MyMiniF(data,"ItemRequiresCharges") ?? "0" },
                    new MyCheckboxString(){ name = "ItemAlertable", check = data.TryGetValue("ItemAlertable", out _), str = MyMiniF(data,"ItemAlertable") ?? "0" },
                    new MyCheckboxString(){ name = "ItemCastOnPickup", check = data.TryGetValue("ItemCastOnPickup", out _), str = MyMiniF(data,"ItemCastOnPickup") ?? "0" },
                    new MyCheckboxString(){ name = "SideShop", check = data.TryGetValue("SideShop", out _), str = MyMiniF(data,"SideShop") ?? "0" },
                    new MyCheckboxString(){ name = "SecretShop", check = data.TryGetValue("SecretShop", out _), str = MyMiniF(data,"SecretShop") ?? "0" },
                    new MyCheckboxString(){ name = "UIPickupSound", check = data.TryGetValue("UIPickupSound", out _), str = MyMiniF(data,"UIPickupSound") ?? "" },
                    new MyCheckboxString(){ name = "UIDropSound", check = data.TryGetValue("UIDropSound", out _), str = MyMiniF(data,"UIDropSound") ?? "" },
                    new MyCheckboxString(){ name = "WorldDropSound", check = data.TryGetValue("WorldDropSound", out _), str = MyMiniF(data,"WorldDropSound") ?? "" },
                    new MyCheckboxString(){ name = "PingOverrideText", check = data.TryGetValue("PingOverrideText", out _), str = MyMiniF(data,"PingOverrideText") ?? "" },
                };
            data = DeleteItems(data, new string[] {
                "BaseClass",
                "ID",
                "ItemRecipe",
                "ItemResult",
                "AbilityName",
                "AbilityBehavior",
                "AbilityType",
                "AbilityUnitTargetType",
                "AbilityUnitTargetTeam",
                "AbilityUnitDamageType",
                "SpellImmunityType",
                "CastFilterRejectCaster",
                "Model",
                "Effect",
                "AbilityTextureName",
                "MaxUpgradeLevel",
                "ItemBaseLevel",
                "AbilityCastAnimation",
                "AbilityCastRange",
                "AbilityCastPoint",
                "AbilityCooldown",
                "AbilityManaCost",
                "AbilityDamage",
                "AOERadius",
                "ItemDeclarations",
                "ItemPurchasable",
                "ItemKillable",
                "ItemSellable",
                "ItemDroppable",
                "ItemStackable",
                "ItemPermanent",
                "ItemShareability",
                "ItemQuality",
                "ItemDisassembleRule",
                "ItemShopTags",
                "ItemAliases",
                "InvalidHeroes",
                "ItemCost",
                "ItemStockMax",
                "ItemStockTime",
                "ItemStockInitial",
                "ItemInitialCharges",
                "ItemDisplayCharges",
                "ItemRequiresCharges",
                "ItemAlertable",
                "ItemCastOnPickup",
                "SideShop",
                "SecretShop",
                "UIPickupSound",
                "UIDropSound",
                "WorldDropSound",
                "PingOverrideText"
            });
            Array.Resize(ref tagobj, tagobj.Length + data.Count + 1);
            if (data.Count > 0)
            {
                for (int i = 0; data.Count > i; i++)
                {
                    tagobj[tagobj.Length + i - (data.Count + 1)] = new MyCheckboxString() { name = data.ElementAt(i).Key, check = true, str = data.ElementAt(i).Value };
                }
            }
            tagobj[tagobj.Length - 1] = new MyAddNodes() { items = ThisEventList };
            newnode.Tag = tagobj;
            return newnode.Name;
        }

        public string AddAbilityDataByObject(MyNodeData data, string nodename)
        {
            TreeNode[] neednode = treeView1.Nodes.Find(nodename, true);
            TreeNode newnode = neednode[0].Nodes.Add(data.name);
            object[] nodetag = (object[])neednode[0].Tag;
            newnode.Name = "node" + nodenum;
            object[] tagdata = new object[] {
                data.name,
                "abilitydata"
            };
            nodenum++;
            if (!neednode[0].IsExpanded)
                neednode[0].Toggle();
            if ((string)nodetag[0] == "Modifiers")
            {
                string[] ThisEventList = new string[2 + ModifierEventList.Length];
                new string[] { "Properties", "States" }.CopyTo(ThisEventList, 0);
                ModifierEventList.CopyTo(ThisEventList, 2);
                tagdata = new object[] {
                    data.name,
                    "modifier",
                    new MyCheckbox(){ name = "Passive", check = MyMiniF2(data.data,"Passive") },
                    new MyCheckbox(){ name = "IsBuff", check = MyMiniF2(data.data,"IsBuff") },
                    new MyCheckbox(){ name = "IsDebuff", check = MyMiniF2(data.data,"IsDebuff") },
                    new MyCheckbox(){ name = "IsHidden", check = MyMiniF2(data.data,"IsHidden") },
                    new MyCheckbox(){ name = "IsPurgable", check = MyMiniF2(data.data,"IsPurgable") },
                    new MyCheckboxStringSelect(){ name = "OverrideAnimation", check = data.data.TryGetValue("OverrideAnimation", out _), str = MyMiniF(data.data,"OverrideAnimation") ?? "", selectlist = AbilityCastAnimationList },
                    new MyCheckboxString(){ name = "Duration", check = data.data.TryGetValue("Duration", out _), str = MyMiniF(data.data,"Duration") ?? "" },
                    new MyCheckboxStringSelect(){ name = "Attributes", check = data.data.TryGetValue("Attributes", out _), str = MyMiniF(data.data,"Attributes") ?? "", selectlist = AttributeList },
                    new MyCheckboxString(){ name = "TextureName", check = data.data.TryGetValue("TextureName", out _), str = MyMiniF(data.data,"TextureName") ?? "" },
                    new MyCheckboxString(){ name = "EffectName", check = data.data.TryGetValue("EffectName", out _), str = MyMiniF(data.data,"EffectName") ?? "" },
                    new MyCheckboxStringSelect(){ name = "EffectAttachType", check = data.data.TryGetValue("EffectAttachType", out _), str = MyMiniF(data.data,"EffectAttachType") ?? "", selectlist = EffectAttachTypeList },
                    new MyCheckboxString(){ name = "ModelName", check = data.data.TryGetValue("ModelName", out _), str = MyMiniF(data.data,"ModelName") ?? "" },
                    new MyCheckboxString(){ name = "Aura", check = data.data.TryGetValue("Aura", out _), str = MyMiniF(data.data,"Aura") ?? "" },
                    new MyCheckboxString(){ name = "Aura_Radius", check = data.data.TryGetValue("Aura_Radius", out _), str = MyMiniF(data.data,"Aura_Radius") ?? "" },
                    new MyCheckboxStringSelect(){ name = "Aura_Teams", check = data.data.TryGetValue("Aura_Teams", out _), str = MyMiniF(data.data,"Aura_Teams") ?? "", selectlist = TeamsList },
                    new MyCheckboxStringSelect(){ name = "Aura_Types", check = data.data.TryGetValue("Aura_Types", out _), str = MyMiniF(data.data,"Aura_Types") ?? "", selectlist = UnitTargetTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "Aura_Flags", check = data.data.TryGetValue("Aura_Flags", out _), str = MyMiniF(data.data,"Aura_Flags") ?? "", selectlist = FlagList },
                    new MyCheckboxString(){ name = "Aura_ApplyToCaster", check = data.data.TryGetValue("Aura_ApplyToCaster", out _), str = MyMiniF(data.data,"Aura_ApplyToCaster") ?? "1" },
                    new MyCheckboxString(){ name = "ThinkInterval", check = data.data.TryGetValue("ThinkInterval", out _), str = MyMiniF(data.data,"ThinkInterval") ?? "" },
                };
                data.data = DeleteItems(data.data, new string[] {
                    "Passive",
                    "IsBuff",
                    "IsDebuff",
                    "IsHidden",
                    "IsPurgable",
                    "OverrideAnimation",
                    "Duration",
                    "Attributes",
                    "TextureName",
                    "EffectName",
                    "EffectAttachType",
                    "ModelName",
                    "Aura",
                    "Aura_Radius",
                    "Aura_Teams",
                    "Aura_Types",
                    "Aura_Flags",
                    "Aura_ApplyToCaster",
                    "ThinkInterval"
                });
                Array.Resize(ref tagdata, tagdata.Length + data.data.Count + 1);
                if (data.data.Count > 0)
                {
                    for (int i = 0; data.data.Count > i; i++)
                    {
                        tagdata[tagdata.Length + i - (data.data.Count + 1)] = new MyCheckboxString() { name = data.data.ElementAt(i).Key, check = true, str = data.data.ElementAt(i).Value };
                    }
                }
                tagdata[tagdata.Length - 1] = new MyAddNodes() { items = ThisEventList };
            }
            else if(data.name == "Modifiers")
            {
                tagdata = new object[] {
                    data.name,
                    "abilitydata",
                    new MyAddCusttomNode(){ },
                };
            }
            else
            {
                bool nextno = false;
                for (int i = 0; data.data.Count > i; i++)
                {
                    Array.Resize(ref tagdata, tagdata.Length + 1);
                    if (nextno == true)
                    {
                        tagdata[tagdata.Length - 1] = new MyCheckboxStringString() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value };
                    }
                    else if (data.name == "Properties")
                    {
                        tagdata[tagdata.Length - 1] = new MyCheckboxStringSelectString() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value, selectlist = Properties };
                    }
                    else if (data.name == "States")
                    {
                        tagdata[tagdata.Length - 1] = new MyCheckboxStringSelectStringSelect() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value, selectlist1 = States, selectlist2 = StatesValues };
                    }
                    else
                    {
                        if (data.data.ElementAt(i).Key == "Action")
                        {
                            tagdata[tagdata.Length - 1] = new MyAddActionNode();
                        }
                        else if (data.data.ElementAt(i).Key == "AbilityName" || data.data.ElementAt(i).Key == "ModifierName" || data.data.ElementAt(i).Key == "EffectName" || data.data.ElementAt(i).Key == "ControlPoints" || data.data.ElementAt(i).Key == "TargetPoint" || data.data.ElementAt(i).Key == "EffectRadius" || data.data.ElementAt(i).Key == "EffectDurationScale" || data.data.ElementAt(i).Key == "EffectLifeDurationScale" || data.data.ElementAt(i).Key == "EffectColorA" || data.data.ElementAt(i).Key == "EffectColorB" || data.data.ElementAt(i).Key == "EffectAlphaScale" || data.data.ElementAt(i).Key == "CleavePercent" || data.data.ElementAt(i).Key == "CleaveRadius" || data.data.ElementAt(i).Key == "ModifierName" || data.data.ElementAt(i).Key == "MinDamage" || data.data.ElementAt(i).Key == "MaxDamage" || data.data.ElementAt(i).Key == "Damage" || data.data.ElementAt(i).Key == "CurrentHealthPercentBasedDamage" || data.data.ElementAt(i).Key == "MaxHealthPercentBasedDamage" || data.data.ElementAt(i).Key == "HealAmount" || data.data.ElementAt(i).Key == "Duration" || data.data.ElementAt(i).Key == "Distance" || data.data.ElementAt(i).Key == "Height" || data.data.ElementAt(i).Key == "IsFixedDistance" || data.data.ElementAt(i).Key == "ShouldStun" || data.data.ElementAt(i).Key == "LifestealPercent" || data.data.ElementAt(i).Key == "MoveSpeed" || data.data.ElementAt(i).Key == "StartRadius" || data.data.ElementAt(i).Key == "EndRadius" || data.data.ElementAt(i).Key == "FixedDistance" || data.data.ElementAt(i).Key == "StartPosition" || data.data.ElementAt(i).Key == "HasFrontalCone" || data.data.ElementAt(i).Key == "ProvidesVision" || data.data.ElementAt(i).Key == "VisionRadius" || data.data.ElementAt(i).Key == "Chance" || data.data.ElementAt(i).Key == "PseudoRandom" || data.data.ElementAt(i).Key == "Function" || data.data.ElementAt(i).Key == "UnitName" || data.data.ElementAt(i).Key == "UnitCount" || data.data.ElementAt(i).Key == "UnitLimit" || data.data.ElementAt(i).Key == "SpawnRadius" || data.data.ElementAt(i).Key == "GrantsGold" || data.data.ElementAt(i).Key == "GrantsXP" || data.data.ElementAt(i).Key == "Dodgeable" || data.data.ElementAt(i).Key == "SourceAttachment")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxString() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value };
                        }
                        else if (data.data.ElementAt(i).Key == "TargetTeams" || data.data.ElementAt(i).Key == "Teams")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = TeamsList };
                        }
                        else if (data.data.ElementAt(i).Key == "TargetTypes" || data.data.ElementAt(i).Key == "Types" || data.data.ElementAt(i).Key == "ExcludeTypes")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = AbilityTypeSelectedList };
                        }
                        else if (data.data.ElementAt(i).Key == "TargetFlags" || data.data.ElementAt(i).Key == "Flags" || data.data.ElementAt(i).Key == "ExcludeFlags" || data.data.ElementAt(i).Key == "Flag")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = FlagList };
                        }
                        else if (data.data.ElementAt(i).Key == "EffectAttachType")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = EffectAttachTypeList };
                        }
                        else if (data.data.ElementAt(i).Key == "Target" || data.data.ElementAt(i).Key == "Center")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = TargetList };
                        }
                        else if (data.data.ElementAt(i).Key == "ScriptFile")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringOpen() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value };
                        }
                        else if (data.data.ElementAt(i).Key == "Type")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = DamageTypeSelectedList };
                        }
                        else if (data.data.ElementAt(i).Key == "var_type")
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringSelect() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value, selectlist = VarTypes };
                            nextno = true;
                        }
                        else
                        {
                            tagdata[tagdata.Length - 1] = new MyCheckboxStringString() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value };
                        }
                    }
                }
            }
            //post
            if (data.name == "States" || data.name == "Properties")
            {
                Array.Resize(ref tagdata, tagdata.Length + 1);
                tagdata[tagdata.Length - 1] = new MyAddStatesOrPropertiesNode() { name = data.name };
            }
            if (data.name == "ItemRequirements")
            {
                Array.Resize(ref tagdata, tagdata.Length + 1);
                tagdata[tagdata.Length - 1] = new MyAddItemRequirementsNode();
            }
            if (data.name == "AbilitySpecial")
            {
                Array.Resize(ref tagdata, tagdata.Length + 1);
                tagdata[tagdata.Length - 1] = new MyAddAbilitySpecialNode();
            }
            if (data.name == "Action")
            {
                Array.Resize(ref tagdata, tagdata.Length + 1);
                tagdata[tagdata.Length - 1] = new MyAddActionNode();
            }
            if (Array.IndexOf(EventList, data.name) >= 0 || Array.IndexOf(ModifierEventList, data.name) >= 0)
            {
                Array.Resize(ref tagdata, tagdata.Length + 1);
                tagdata[tagdata.Length - 1] = new MyAddActionNode();
            }
            //Debug.WriteLine("Count in " + data.name + " = " + data.data.Count + ", writed = " + tagdata.Length);
            newnode.Tag = tagdata;
            return newnode.Name;
        }

        public string MyMiniF(Dictionary<string, string> data, string needname)
        {
            string result = "";
            if (data.TryGetValue(needname, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool MyMiniF2(Dictionary<string, string> data, string needname)
        {
            string result = "";
            if (data.TryGetValue(needname, out result))
                if (result == "1")
                    return true;
            return false;
        }

        public void AddLine(object sender, EventArgs e)
        {
            ClearPanels();
            TreeNode selnode = treeView1.SelectedNode;
            object[] nodetag = (object[])selnode.Tag;
            Array.Resize(ref nodetag, nodetag.Length + 1);
            nodetag[nodetag.Length-1] = new MyCheckboxStringString() { check = false, name = "", str1 = "", str2 = "" };
            selnode.Tag = nodetag;
            treeView1.SelectedNode = null;
            treeView1.SelectedNode = selnode;
        }

        public void AddModifier(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            TextBox textbox = (TextBox)thisb.Tag;
            //ToolStripMenuItem thisb = (ToolStripMenuItem)sender;
            //ToolStripTextBox textbox = (ToolStripTextBox)thisb.Tag;
            if (textbox.Text != "")
            {
                MyNodeData newnode = new MyNodeData();
                newnode.name = textbox.Text;
                newnode.data = new Dictionary<string, string>();
                AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
                //TreeNode[] neednode = treeView1.Nodes.Find(AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name), true);
                //treeView1.SelectedNode = neednode[0];
            }
        }

        public void AddAbilitySpecial(object sender, EventArgs e)
        {
            MyNodeData newnode = new MyNodeData();
            int nodecount = treeView1.SelectedNode.Nodes.Count;
            nodecount++;
            if (nodecount < 10)
            {
                newnode.name = "0"+nodecount;
            }
            else
            {
                newnode.name = nodecount.ToString();
            }
            newnode.data = new Dictionary<string, string>();
            newnode.data["var_type"] = "";
            newnode.data[""] = "";
            AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
        }

        public void AddItemRequirements(object sender, EventArgs e)
        {
            ClearPanels();
            TreeNode selnode = treeView1.SelectedNode;
            object[] nodetag = (object[])selnode.Tag;
            Array.Resize(ref nodetag, nodetag.Length + 1);
            nodetag[nodetag.Length - 1] = nodetag[nodetag.Length - 2];
            string col = "";
            if (nodetag.Length - 2 < 10)
            {
                col = "0" + (nodetag.Length - 2);
            }
            else
            {
                col = (nodetag.Length - 2).ToString();
            }
            nodetag[nodetag.Length - 2] = new MyCheckboxStringString() { check = false, name = "", str1 = col, str2 = "" };
            selnode.Tag = nodetag;
            treeView1.SelectedNode = null;
            treeView1.SelectedNode = selnode;
        }

        public void AddStateOrPropertie(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            string sorp = (string)thisb.Tag;
            ClearPanels();
            TreeNode selnode = treeView1.SelectedNode;
            object[] nodetag = (object[])selnode.Tag;
            Array.Resize(ref nodetag, nodetag.Length + 1);
            nodetag[nodetag.Length - 1] = nodetag[nodetag.Length - 2];
            if (sorp == "States") nodetag[nodetag.Length - 2] = new MyCheckboxStringSelectStringSelect() { check = false, name = "", str1 = "", str2 = "", selectlist1 = States, selectlist2 = StatesValues };
            else nodetag[nodetag.Length - 2] = new MyCheckboxStringSelectString() { check = false, name = "", str1 = "", str2 = "", selectlist = Properties };
            selnode.Tag = nodetag;
            treeView1.SelectedNode = null;
            treeView1.SelectedNode = selnode;
        }

        public void AddMyActionNode(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            ComboBox combbox = (ComboBox)thisb.Tag;
            if (combbox.Text != "")
            {
                int num = Array.IndexOf(ActionList, combbox.Text);
                MyNodeData newnode = new MyNodeData();
                newnode.name = combbox.Text;
                newnode.data = new Dictionary<string, string>();
                if (combbox.Text == "ActOnTargets")
                {
                    string newnodename = AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
                    MyNodeData newnode2 = new MyNodeData();
                    newnode2.name = "Target";
                    newnode2.data = new Dictionary<string, string>();
                    newnode2.data["Center"] = "";
                    newnode2.data["Radius"] = "";
                    newnode2.data["Teams"] = "";
                    newnode2.data["Flags"] = "";
                    newnode2.data["ExcludeFlags"] = "";
                    newnode2.data["Types"] = "";
                    newnode2.data["ExcludeTypes"] = "";
                    newnode2.data["MaxTargets"] = "";
                    newnode2.data["Random"] = "";
                    MyNodeData newnode3 = new MyNodeData();
                    newnode3.name = "Action";
                    newnode3.data = new Dictionary<string, string>();
                    AddAbilityDataByObject(newnode2, newnodename);
                    AddAbilityDataByObject(newnode3, newnodename);
                }
                else if (combbox.Text == "DelayedAction")
                {
                    newnode.data["Delay"] = "";
                    MyNodeData newnode2 = new MyNodeData();
                    newnode2.name = "Action";
                    newnode2.data = new Dictionary<string, string>();
                    AddAbilityDataByObject(newnode2,AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name));
                }
                else if(combbox.Text == "Random")
                {
                    newnode.data["Chance"] = "";
                    newnode.data["PseudoRandom"] = "";
                    string newnodename = AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
                    MyNodeData newnode2 = new MyNodeData();
                    newnode2.name = "OnSuccess";
                    newnode2.data = new Dictionary<string, string>();
                    newnode2.data["Action"] = "";
                    MyNodeData newnode3 = new MyNodeData();
                    newnode3.name = "OnFailure";
                    newnode3.data = new Dictionary<string, string>();
                    newnode3.data["Action"] = "";
                    AddAbilityDataByObject(newnode2, newnodename);
                    AddAbilityDataByObject(newnode3, newnodename);
                }
                else if (combbox.Text == "IsCasterAlive")
                {
                    string newnodename = AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
                    MyNodeData newnode2 = new MyNodeData();
                    newnode2.name = "OnSuccess";
                    newnode2.data = new Dictionary<string, string>();
                    newnode2.data["Action"] = "";
                    MyNodeData newnode3 = new MyNodeData();
                    newnode3.name = "OnFailure";
                    newnode3.data = new Dictionary<string, string>();
                    newnode3.data["Action"] = "";
                    AddAbilityDataByObject(newnode2, newnodename);
                    AddAbilityDataByObject(newnode3, newnodename);
                }
                else
                {
                    string[] actprop = (string[])ActionPropertiesList[num];
                    for (int i = 0; actprop.Length > i;i++)
                    {
                        newnode.data[actprop[i]] = "";
                    }
                    AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
                }
            }
        }

        public void AddMyNode(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            ComboBox combbox = (ComboBox)thisb.Tag;
            //ToolStripMenuItem thisb = (ToolStripMenuItem)sender;
            // ToolStripComboBox combbox = (ToolStripComboBox)thisb.Tag;
            if (combbox.Text != "")
            {
                MyNodeData newnode = new MyNodeData();
                newnode.name = combbox.Text;
                newnode.data = new Dictionary<string, string>();
                AddAbilityDataByObject(newnode, treeView1.SelectedNode.Name);
                //TreeNode[] neednode = treeView1.Nodes.Find(AddAbilityDataByObject(newnode,treeView1.SelectedNode.Name), true);
                //treeView1.SelectedNode = neednode[0];
            }
        }

        public void CreateItemButtonClick(object sender, EventArgs e)
        {
            TextBox namebox = (TextBox)splitContainer1.Panel2.Tag;
            if (namebox.Text != "")
            {
                if (namebox.Text.IndexOf("item_") == 0)
                {
                    TreeNode[] neednode = treeView1.Nodes.Find(CreateItem(namebox.Text, new Dictionary<string, string>(), null), true);
                    treeView1.SelectedNode = neednode[0];
                }
                else
                {
                    //MessageBox.Show("Invalid name!\r\nAt the beginning of the item name should be 'item_'", "Error");
                    DialogResult dialogResult = MessageBox.Show("Invalid name!\r\nAt the beginning of the item name should be 'item_'\r\nAdd?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TreeNode[] neednode = treeView1.Nodes.Find(CreateItem("item_"+namebox.Text, new Dictionary<string, string>(), null), true);
                        treeView1.SelectedNode = neednode[0];
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid name!", "Error");
            }
        }

        public void CreateText(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            ToolStripMenuItem thisb = (ToolStripMenuItem)sender;
            TreeNode node = (TreeNode)thisb.Tag;
            string text = GetTextByNode(node, 0);
            RichTextBox newrtb = new RichTextBox();
            newrtb.WordWrap = false;
            newrtb.Parent = splitContainer1.Panel2;
            newrtb.Dock = DockStyle.Fill;
            newrtb.Text = text;
        }

        public string GetTextByNode(TreeNode node,int level)
        {
            object[] data = (object[])node.Tag;
            string miniotstup = "";
            string otstup = "\t";
            for (int i = 0; level > i; i++)
            {
                otstup = otstup + "\t";
                miniotstup = miniotstup + "\t";
            }
            string readytext = miniotstup+'"' +(string)data[0]+'"'+ "\r\n"+ miniotstup + "{";
            if (level == 0)
            {
                readytext = readytext + "\r\n" + otstup + "//Created by D2AbilityCreator 2.0";
            }
            if ((string)data[1] == "ability")
                readytext = readytext + "\r\n" + otstup + '"'+ "BaseClass" + '"'+ "\t\t" + '"' + "ability_datadriven" + '"';
            else if ((string)data[1] == "item")
                readytext = readytext + "\r\n" + otstup + '"' + "BaseClass" + '"' + "\t\t" + '"' + "item_datadriven" + '"';
            for (int i = 2; data.Length > i; i++)
            {
                if (data[i].GetType() == typeof(MyCheckbox))
                {
                    MyCheckbox thisdata = (MyCheckbox)data[i];
                    string value = "0";
                    if (thisdata.check)
                        value = "1";
                    readytext = readytext + "\r\n" + otstup + '"' + thisdata.name + '"' + "\t\t" + '"' + value + '"';
                }
                if (data[i].GetType() == typeof(MyCheckboxString))
                {
                    MyCheckboxString thisdata = (MyCheckboxString)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.name + '"' + "\t\t" + '"' + thisdata.str + '"';
                    }
                }
                if (data[i].GetType() == typeof(MyCheckboxStringOpen))
                {
                    MyCheckboxStringOpen thisdata = (MyCheckboxStringOpen)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.name + '"' + "\t\t" + '"' + thisdata.str + '"';
                    }
                }
                if (data[i].GetType() == typeof(MyString))
                {
                    MyString thisdata = (MyString)data[i];
                    readytext = readytext + "\r\n" + otstup + '"' + thisdata.name + '"' + "\t\t" + '"' + thisdata.str + '"';
                }
                if (data[i].GetType() == typeof(MyStringSelect))
                {
                    MyStringSelect thisdata = (MyStringSelect)data[i];
                    readytext = readytext + "\r\n" + otstup + '"' + thisdata.name + '"' + "\t\t" + '"' + thisdata.str + '"';
                }
                if (data[i].GetType() == typeof(MyCheckboxStringSelect))
                {
                    MyCheckboxStringSelect thisdata = (MyCheckboxStringSelect)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.name + '"' + "\t\t" + '"' + thisdata.str + '"';
                    }
                }
                if (data[i].GetType() == typeof(MyCheckboxStringString))
                {
                    MyCheckboxStringString thisdata = (MyCheckboxStringString)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.str1 + '"' + "\t\t" + '"' + thisdata.str2 + '"';
                    }
                }
                if (data[i].GetType() == typeof(MyCheckboxStringStringSelect))
                {
                    MyCheckboxStringStringSelect thisdata = (MyCheckboxStringStringSelect)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.str1 + '"' + "\t\t" + '"' + thisdata.str2 + '"';
                    }
                }
                if (data[i].GetType() == typeof(MyCheckboxStringSelectString))
                {
                    MyCheckboxStringSelectString thisdata = (MyCheckboxStringSelectString)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.str1 + '"' + "\t\t" + '"' + thisdata.str2 + '"';
                    }
                }
                if (data[i].GetType() == typeof(MyCheckboxStringSelectStringSelect))
                {
                    MyCheckboxStringSelectStringSelect thisdata = (MyCheckboxStringSelectStringSelect)data[i];
                    if (thisdata.check)
                    {
                        readytext = readytext + "\r\n" + otstup + '"' + thisdata.str1 + '"' + "\t\t" + '"' + thisdata.str2 + '"';
                    }
                }
            }
            for (int i = 0; node.Nodes.Count > i;i++)
            {
                readytext = readytext + "\r\n" + GetTextByNode(node.Nodes[i],level+1);
            }
            readytext = readytext + "\r\n"+ miniotstup + "}";
            return readytext;
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Txt, lua files (*.txt;*.lua)|*.txt;*.lua";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                LoadFiles(null, new string[] { fdlg.FileName });
            }
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //Debug.WriteLine(fbd.SelectedPath);
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    string[] folders = Directory.GetDirectories(fbd.SelectedPath);
                    TreeNode newnode = treeView1.Nodes.Add(RemovePath(fbd.SelectedPath));
                    newnode.Name = "node" + nodenum;
                    nodenum++;
                    newnode.Tag = new object[]
                    {
                        fbd.SelectedPath,
                        "folder"
                    };
                    //Debug.WriteLine(newnode.FullPath);
                    //Debug.WriteLine(newnode.Index);
                    LoadFiles(newnode.Name, files);
                    LoadFolders(newnode.Name, folders);
                    //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
            //open folder
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            //treeView1.Visible = false;
            //splitContainer1.Visible = false;
            //ListBox newlistbox = new ListBox();
            Label namelbl = new Label();
            namelbl.Text = "Ability/Item name:";
            namelbl.Location = new Point(10, 7);
            namelbl.AutoSize = true;
            namelbl.Parent = splitContainer1.Panel1;
            TextBox newtextbox = new TextBox();
            newtextbox.Location = new Point(10, 3);
            newtextbox.Size = new Size(220, 20);
            newtextbox.Parent = splitContainer1.Panel2;
            splitContainer1.Panel2.Tag = newtextbox;
            Button newbutton1 = new Button();
            newbutton1.BackColor = Color.LightGray;
            newbutton1.Location = new Point(240, 3);
            newbutton1.Size = new Size(100, 24);
            newbutton1.Text = "Create ability";
            newbutton1.Click += CreateAbilityButtonClick;
            newbutton1.Parent = splitContainer1.Panel2;
            Button newbutton2 = new Button();
            newbutton2.BackColor = Color.LightGray;
            newbutton2.Location = new Point(350, 3);
            newbutton2.Size = new Size(100, 24);
            newbutton2.Text = "Create item";
            newbutton2.Click += CreateItemButtonClick;
            newbutton2.Parent = splitContainer1.Panel2;
            //splitContainer1.Panel1.
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearPanels();
            selectednode = null;
            //Debug.WriteLine(sender);
            //Debug.WriteLine(e.Node.Tag);
            object[] data = (object[])e.Node.Tag;
            Label namelbl = new Label();
            namelbl.Text = (string)data[0];
            namelbl.Location = new Point(10, 7);
            namelbl.AutoSize = true;
            namelbl.Parent = splitContainer1.Panel1;
            Button newbutton = new Button();
            newbutton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            newbutton.Location = new Point(splitContainer1.Size.Width - 110, 3);
            newbutton.Size = new Size(80, 23);
            newbutton.Text = "Delete";
            newbutton.Tag = e.Node;
            newbutton.Click += DeleteNode;
            newbutton.Parent = splitContainer1.Panel1;
            if ((string)data[1] == "file.lua")
            {
                Button newbutton2 = new Button();
                newbutton2.BackColor = Color.LightGray;
                newbutton2.Location = new Point(10, 3);
                newbutton2.Size = new Size(100, 23);
                newbutton2.Text = "Open file";
                newbutton2.Tag = (string)data[0];
                newbutton2.Click += OpenFile;
                newbutton2.Parent = splitContainer1.Panel2;
            }
            else if ((string)data[1] == "file.txt")
            {
                Button newbutton1 = new Button();
                newbutton1.BackColor = Color.LightGray;
                newbutton1.Location = new Point(10, 3);
                newbutton1.Size = new Size(100, 23);
                newbutton1.Text = "Open file";
                newbutton1.Tag = (string)data[0];
                newbutton1.Click += OpenFile;
                newbutton1.Parent = splitContainer1.Panel2;
                Button newbutton2 = new Button();
                newbutton2.BackColor = Color.LightGray;
                newbutton2.Location = new Point(120, 3);
                newbutton2.Size = new Size(100, 23);
                newbutton2.Text = "Load file";
                newbutton2.Tag = e.Node;
                newbutton2.Click += LoadFileInfo;
                newbutton2.Parent = splitContainer1.Panel2;
            }
            else if ((string)data[1] == "ability" || (string)data[1] == "item" || (string)data[1] == "abilitydata" || (string)data[1] == "modifier")
            {
                selectednode = e.Node.Name;
                object[] newdata = new object[0];
                object[] menutag = new object[0] {};
                if((string)data[1] == "ability" || (string)data[1] == "item" || (string)data[1] == "abilitydata")
                {
                    ToolStripItem newitem2 = menuStrip2.Items.Add("Create");
                    newitem2.Alignment = ToolStripItemAlignment.Right;
                    newitem2.Tag = e.Node;
                    newitem2.Click += CreateText;
                    Array.Resize(ref menutag, menutag.Length + 1);
                    menutag[menutag.Length - 1] = newitem2;
                }
                ToolStripItem newitem = menuStrip2.Items.Add("Add Line");
                newitem.Alignment = ToolStripItemAlignment.Right;
                newitem.Click += AddLine;
                Array.Resize(ref menutag, menutag.Length + 1);
                menutag[menutag.Length - 1] = newitem;
                //Debug.WriteLine("Length = " + data.Length);
                for (int i = 2; i < data.Length; i++)
                {
                    //Debug.WriteLine("Load " + i);
                    if (data[i].GetType() == typeof(MyCheckbox))
                    {
                        MyCheckbox thisdata = (MyCheckbox)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(250, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        Label mynamelbl = new Label();
                        mynamelbl.Text = thisdata.name;
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck };
                    }
                    if (data[i].GetType() == typeof(MyCheckboxString))
                    {
                        MyCheckboxString thisdata = (MyCheckboxString)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        Label mynamelbl = new Label();
                        mynamelbl.Text = thisdata.name;
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str;
                        mytextbox.Location = new Point(250, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox };
                    }
                    if (data[i].GetType() == typeof(MyString))
                    {
                        MyString thisdata = (MyString)data[i];
                        Label mynamelbl = new Label();
                        mynamelbl.Text = thisdata.name;
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str;
                        mytextbox.Location = new Point(250, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mytextbox };
                    }
                    if (data[i].GetType() == typeof(MyStringSelect))
                    {
                        MyStringSelect thisdata = (MyStringSelect)data[i];
                        Label mynamelbl = new Label();
                        mynamelbl.Text = thisdata.name;
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str;
                        mytextbox.Location = new Point(250, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        Button newbutton2 = new Button();
                        newbutton2.BackColor = Color.LightGray;
                        newbutton2.Location = new Point(660, (30 * (i - 2)) + 3);
                        newbutton2.Size = new Size(100, 23);
                        newbutton2.Text = "Select";
                        newbutton2.Tag = new object[] { mytextbox, thisdata.selectlist };
                        newbutton2.Click += SelectModeOn;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mytextbox };
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringSelect))
                    {
                        MyCheckboxStringSelect thisdata = (MyCheckboxStringSelect)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        Label mynamelbl = new Label();
                        mynamelbl.Text = thisdata.name;
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str;
                        mytextbox.Location = new Point(250, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        Button newbutton2 = new Button();
                        newbutton2.BackColor = Color.LightGray;
                        newbutton2.Location = new Point(660, (30 * (i - 2)) + 3);
                        newbutton2.Size = new Size(100, 23);
                        newbutton2.Text = "Select";
                        newbutton2.Tag = new object[] { mytextbox, thisdata.selectlist };
                        newbutton2.Click += SelectModeOn;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox };
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringString))
                    {
                        MyCheckboxStringString thisdata = (MyCheckboxStringString)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str1;
                        mytextbox.Location = new Point(30, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        TextBox mytextbox2 = new TextBox();
                        mytextbox2.Text = thisdata.str2;
                        mytextbox2.Location = new Point(450, (30 * (i - 2)) + 3);
                        mytextbox2.Size = new Size(400, 23);
                        mytextbox2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox, mytextbox2 };
                    }
                    if (data[i].GetType() == typeof(MyCheckboxStringOpen))
                    {
                        MyCheckboxStringOpen thisdata = (MyCheckboxStringOpen)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        Label mynamelbl = new Label();
                        mynamelbl.Text = thisdata.name;
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str;
                        mytextbox.Location = new Point(250, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        Button newbutton2 = new Button();
                        newbutton2.BackColor = Color.LightGray;
                        newbutton2.Location = new Point(660, (30 * (i - 2)) + 3);
                        newbutton2.Size = new Size(100, 23);
                        newbutton2.Text = "Open";
                        newbutton2.Tag = new object[] { mytextbox };
                        newbutton2.Click += OpenLuaFile;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox };
                    }

                    if (data[i].GetType() == typeof(MyCheckboxStringStringSelect))
                    {
                        MyCheckboxStringStringSelect thisdata = (MyCheckboxStringStringSelect)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str1;
                        mytextbox.Location = new Point(30, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        TextBox mytextbox2 = new TextBox();
                        mytextbox2.Text = thisdata.str2;
                        mytextbox2.Location = new Point(450, (30 * (i - 2)) + 3);
                        mytextbox2.Size = new Size(400, 23);
                        mytextbox2.Parent = splitContainer1.Panel2;
                        Button newbutton2 = new Button();
                        newbutton2.BackColor = Color.LightGray;
                        newbutton2.Location = new Point(860, (30 * (i - 2)) + 3);
                        newbutton2.Size = new Size(100, 23);
                        newbutton2.Text = "Select";
                        newbutton2.Tag = new object[] { mytextbox, thisdata.selectlist };
                        newbutton2.Click += SelectModeOn;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox, mytextbox2 };
                    }

                    if (data[i].GetType() == typeof(MyCheckboxStringSelectString))
                    {
                        MyCheckboxStringSelectString thisdata = (MyCheckboxStringSelectString)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str1;
                        mytextbox.Location = new Point(30, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        TextBox mytextbox2 = new TextBox();
                        mytextbox2.Text = thisdata.str2;
                        mytextbox2.Location = new Point(560, (30 * (i - 2)) + 3);
                        mytextbox2.Size = new Size(400, 23);
                        mytextbox2.Parent = splitContainer1.Panel2;
                        Button newbutton2 = new Button();
                        newbutton2.BackColor = Color.LightGray;
                        newbutton2.Location = new Point(450, (30 * (i - 2)) + 3);
                        newbutton2.Size = new Size(100, 23);
                        newbutton2.Text = "Select";
                        newbutton2.Tag = new object[] { mytextbox, thisdata.selectlist };
                        newbutton2.Click += SelectModeOn;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox, mytextbox2 };
                    }

                    if (data[i].GetType() == typeof(MyCheckboxStringSelectStringSelect))
                    {
                        MyCheckboxStringSelectStringSelect thisdata = (MyCheckboxStringSelectStringSelect)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(10, (30 * (i - 2)) + 6);
                        mycheck.AutoSize = true;
                        mycheck.Checked = thisdata.check;
                        mycheck.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Text = thisdata.str1;
                        mytextbox.Location = new Point(30, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(400, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        TextBox mytextbox2 = new TextBox();
                        mytextbox2.Text = thisdata.str2;
                        mytextbox2.Location = new Point(560, (30 * (i - 2)) + 3);
                        mytextbox2.Size = new Size(400, 23);
                        mytextbox2.Parent = splitContainer1.Panel2;
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(450, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(100, 23);
                        newbutton1.Text = "Select";
                        newbutton1.Tag = new object[] { mytextbox, thisdata.selectlist1 };
                        newbutton1.Click += SelectModeOn;
                        newbutton1.Parent = splitContainer1.Panel2;
                        Button newbutton2 = new Button();
                        newbutton2.BackColor = Color.LightGray;
                        newbutton2.Location = new Point(980, (30 * (i - 2)) + 3);
                        newbutton2.Size = new Size(100, 23);
                        newbutton2.Text = "Select";
                        newbutton2.Tag = new object[] { mytextbox2, thisdata.selectlist2 };
                        newbutton2.Click += SelectModeOn;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox, mytextbox2 };
                    }
                    if (data[i].GetType() == typeof(MyAddNodes))
                    {
                        MyAddNodes locc = (MyAddNodes)data[i];
                        string[] items = locc.items;
                        ComboBox newcombbox = new ComboBox();
                        newcombbox.Location = new Point(30, (30 * (i - 2)) + 3);
                        newcombbox.Size = new Size(200, 23);
                        newcombbox.Parent = splitContainer1.Panel2;
                        newcombbox.Items.AddRange(items);
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(250, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(100, 23);
                        newbutton1.Text = "Add";
                        newbutton1.Tag = newcombbox;
                        newbutton1.Click += AddMyNode;
                        newbutton1.Parent = splitContainer1.Panel2;
                        //ToolStripItem newitem2 = menuStrip2.Items.Add("Add");
                        //newitem2.Alignment = ToolStripItemAlignment.Right;
                        //newitem2.Click += AddMyNode;
                        //ToolStripComboBox newitm = new ToolStripComboBox();
                        //newitm.Alignment = ToolStripItemAlignment.Right;
                        //newitm.Size = new Size(150,20);
                        //newitm.Items.AddRange(items);
                        //menuStrip2.Items.Add(newitm);
                        //newitem2.Tag = newitm;

                        //Array.Resize(ref menutag, menutag.Length + 2);
                        //menutag[menutag.Length - 2] = newitem2;
                        //menutag[menutag.Length - 1] = newitm;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] {  };
                    }

                    if (data[i].GetType() == typeof(MyAddCusttomNode))
                    {
                        Label mynamelbl = new Label();
                        mynamelbl.Text = "Add modifier:";
                        mynamelbl.Location = new Point(30, (30 * (i - 2)) + 3);
                        mynamelbl.AutoSize = true;
                        mynamelbl.Parent = splitContainer1.Panel2;
                        TextBox mytextbox = new TextBox();
                        mytextbox.Location = new Point(180, (30 * (i - 2)) + 3);
                        mytextbox.Size = new Size(200, 23);
                        mytextbox.Parent = splitContainer1.Panel2;
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(400, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(100, 23);
                        newbutton1.Text = "Add";
                        newbutton1.Tag = mytextbox;
                        newbutton1.Click += AddModifier;
                        newbutton1.Parent = splitContainer1.Panel2;
                        //ToolStripItem newitem2 = menuStrip2.Items.Add("Add Modifier");
                        //newitem2.Alignment = ToolStripItemAlignment.Right;
                        //newitem2.Click += AddModifier;
                        //ToolStripTextBox newitm = new ToolStripTextBox();
                        //newitm.Alignment = ToolStripItemAlignment.Right;
                        //menuStrip2.Items.Add(newitm);
                        //newitem2.Tag = newitm;

                        //Array.Resize(ref menutag, menutag.Length + 2);
                        //menutag[menutag.Length - 2] = newitem2;
                        //menutag[menutag.Length - 1] = newitm;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] {  };
                    }

                    if (data[i].GetType() == typeof(MyAddAbilitySpecialNode))
                    {
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(30, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(200, 23);
                        newbutton1.Text = "Add AbilitySpecial";
                        newbutton1.Click += AddAbilitySpecial;
                        newbutton1.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { };
                    }

                    if (data[i].GetType() == typeof(MyAddStatesOrPropertiesNode))
                    {
                        MyAddStatesOrPropertiesNode locc = (MyAddStatesOrPropertiesNode)data[i];
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(30, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(200, 23);
                        if (locc.name == "States")
                        {
                            newbutton1.Text = "Add State";
                        }
                        else
                        {
                            newbutton1.Text = "Add Propertie";
                        }
                        newbutton1.Tag = locc.name;
                        newbutton1.Click += AddStateOrPropertie;
                        newbutton1.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { };
                    }

                    if (data[i].GetType() == typeof(MyAddActionNode))
                    {
                        ComboBox newcombbox = new ComboBox();
                        newcombbox.Location = new Point(30, (30 * (i - 2)) + 3);
                        newcombbox.Size = new Size(200, 23);
                        newcombbox.Parent = splitContainer1.Panel2;
                        newcombbox.Items.AddRange(ActionList);
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(250, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(100, 23);
                        newbutton1.Text = "Add";
                        newbutton1.Tag = newcombbox;
                        newbutton1.Click += AddMyActionNode;
                        newbutton1.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { };
                    }

                    if (data[i].GetType() == typeof(MyAddItemRequirementsNode))
                    {
                        Button newbutton1 = new Button();
                        newbutton1.BackColor = Color.LightGray;
                        newbutton1.Location = new Point(30, (30 * (i - 2)) + 3);
                        newbutton1.Size = new Size(200, 23);
                        newbutton1.Text = "Add ItemRequirements";
                        newbutton1.Click += AddItemRequirements;
                        newbutton1.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { };
                    }
                }
                splitContainer1.Panel2.Tag = newdata;
                menuStrip2.Tag = menutag;
            }
        }

        [Serializable()]
        public class MyAddItemRequirementsNode
        {
        }

        [Serializable()]
        public class MyAddActionNode
        {
        }

        [Serializable()]
        public class MyAddStatesOrPropertiesNode
        {
            public string name { get; set; }
        }

        [Serializable()]
        public class MyAddAbilitySpecialNode
        {
        }

        [Serializable()]
        public class MyAddNodes
        {
            public string[] items { get; set; }
        }

        [Serializable()]
        public class MyAddCusttomNode
        {
        }

        [Serializable()]
        public class MyCheckbox
        {
            public string name { get; set; }
            public bool check { get; set; }
        }

        [Serializable()]
        public class MyString
        {
            public string name { get; set; }
            public string str { get; set; }
        }

        [Serializable()]
        public class MyStringSelect
        {
            public string name { get; set; }
            public string str { get; set; }
            public string[] selectlist { get; set; }
        }

        [Serializable()]
        public class MyCheckboxString
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str { get; set; }
        }

        [Serializable()]
        public class MyCheckboxStringString
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
        }

        [Serializable()]
        public class MyCheckboxStringSelect
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str { get; set; }
            public string[] selectlist { get; set; }
        }

        [Serializable()]
        public class MyCheckboxStringOpen
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str { get; set; }
        }

        [Serializable()]
        public class MyCheckboxStringStringSelect
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string[] selectlist { get; set; }
        }

        [Serializable()]
        public class MyCheckboxStringSelectString
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string[] selectlist { get; set; }
        }

        [Serializable()]
        public class MyCheckboxStringSelectStringSelect
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string[] selectlist1 { get; set; }
            public string[] selectlist2 { get; set; }
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            treeView1.CollapseAll();
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            treeView1.ExpandAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 2.0.5\r\nCreator: Niker323", "About");
        }

        private void donationAlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.donationalerts.com/r/niker323");
        }

        private void patreonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.patreon.com/nikergames");
        }

        private void saveTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPanels();
            treeView1.SelectedNode = null;
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "tree files (*.dact)|*.dact";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(myStream, treeView1.Nodes.Cast<TreeNode>().ToList());
                    myStream.Close();
                }
            }

            //using (var path_dialog = new FolderBrowserDialog())
            //{
            //    if (path_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        using (var stream = new FileStream(path_dialog.SelectedPath, FileMode.Create))
            //        {
            //            BinaryFormatter bf = new BinaryFormatter();
            //            bf.Serialize(stream, treeView1.Nodes.Cast<TreeNode>().ToList());
            //        }
            //    };
            //}
        }

        private void loadTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open Tree";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Tree files (*.dact)|*.dact";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(fdlg.FileName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(stream);

                    TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                    treeView1.Nodes.AddRange(nodeList);
                }
            }
        }
    }
}
