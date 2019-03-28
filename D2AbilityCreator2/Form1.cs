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
        string[] AbilityUnitTargetTeamSelectedList =
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
                    //TreeNode[] neednodes = treeView1.Nodes.Find(nodes[level], true);
                    Array.Resize(ref nodes, nodes.Length + 1);
                    nodes[level + 1] = CreateAbility(nowselected.name, nowselected.data, nodes[level]);
                }
                //else if (value == "item_datadriven")
                //{

                //}
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
            Button thisb = (Button)sender;
            treeView1.Nodes.Remove((TreeNode)thisb.Tag);
            ClearPanels();
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
                    newnode.Name = RemovePath(files[i]);
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
            TreeNode[] neednodes = treeView1.Nodes.Find(textbox.Text,true);
            object[] nodetag = (object[])neednodes[0].Tag;
            Process.Start((string)nodetag[0]);
        }

        public void SelectModeOn(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            treeView1.Visible = false;
            splitContainer1.Visible = false;
            Button thisb = (Button)sender;
            object[] objlist = (object[])thisb.Tag;
            TextBox oldtextbox = (TextBox)objlist[0];
            TextBox newtextbox = new TextBox();
            newtextbox.Text = oldtextbox.Text;
            newtextbox.Location = new Point(20, 20);
            newtextbox.Size = new Size(600, 24);
            Controls.Add(newtextbox);
            newtextbox.BringToFront();
            ListBox newlistbox = new ListBox();
            string[] strlist = (string[])objlist[1];
            newlistbox.Items.AddRange(strlist);
            newlistbox.Location = new Point(20, 60);
            newlistbox.Size = new Size(500, 400);
            Controls.Add(newlistbox);
            newlistbox.BringToFront();
            Button newbutton = new Button();
            newbutton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            newbutton.Location = new Point(Form1.ActiveForm.Size.Width - 110, 53);
            newbutton.Size = new Size(80, 23);
            newbutton.Text = "Add";
            newbutton.Tag = new object[] { newlistbox, newtextbox };
            newbutton.Click += AddString;
            Controls.Add(newbutton);
            newbutton.BringToFront();
            Button newbutton2 = new Button();
            newbutton2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            newbutton2.Location = new Point(Form1.ActiveForm.Size.Width - 110, 83);
            newbutton2.Size = new Size(80, 23);
            newbutton2.Text = "Back";
            newbutton2.Tag = new object[] { oldtextbox, newtextbox, newlistbox, newbutton };
            newbutton2.Click += SelectModeOff;
            Controls.Add(newbutton2);
            newbutton2.BringToFront();
        }

        public void SelectModeOff(object sender, EventArgs e)
        {
            Button thisb = (Button)sender;
            object[] objlist = (object[])thisb.Tag;
            TextBox oldtextbox = (TextBox)objlist[0];
            TextBox newtextbox = (TextBox)objlist[1];
            ListBox newlistbox = (ListBox)objlist[2];
            Button newbutton = (Button)objlist[3];
            oldtextbox.Text = newtextbox.Text;
            thisb.Dispose();
            newtextbox.Dispose();
            newlistbox.Dispose();
            newbutton.Dispose();
            menuStrip1.Visible = true;
            treeView1.Visible = true;
            splitContainer1.Visible = true;
        }

        public void CreateAbilityButtonClick(object sender, EventArgs e)
        {
            TextBox namebox = (TextBox)splitContainer1.Panel2.Tag;
            CreateAbility(namebox.Text, null, null);
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
            if (data == null)
            {
                ClearPanels();
                newnode.Tag = new object[] {
                    name,
                    "ability",
                    new MyCheckboxString(){ name = "ID", check = false, str = "" },
                    new MyStringSelect(){ name = "AbilityBehavior", str = "", selectlist = AbilityBehaviorSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityType", check = false, str = "", selectlist = AbilityTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetType", check = false, str = "", selectlist = UnitTargetTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetTeam", check = false, str = "", selectlist = AbilityUnitTargetTeamSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitDamageType", check = false, str = "", selectlist = DamageTypeSelectedList }
                };
                treeView1.SelectedNode = newnode;
            }
            else
            {
                //ClearPanels();
                //Debug.WriteLine(data.TryGetValue(4, out result));
                newnode.Tag = new object[] {
                    name,
                    "ability",
                    new MyCheckboxString(){ name = "ID", check = data.TryGetValue("ID", out _), str = MyMiniF(data,"ID") ?? "" },
                    new MyStringSelect(){ name = "AbilityBehavior", str = MyMiniF(data,"AbilityBehavior") ?? "", selectlist = AbilityBehaviorSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityType", check = data.TryGetValue("AbilityType", out _), str = MyMiniF(data,"AbilityType") ?? "", selectlist = AbilityTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetType", check = data.TryGetValue("AbilityUnitTargetType", out _), str = MyMiniF(data,"AbilityUnitTargetType") ?? "", selectlist = UnitTargetTypeSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitTargetTeam", check = data.TryGetValue("AbilityUnitTargetTeam", out _), str = MyMiniF(data,"AbilityUnitTargetTeam") ?? "", selectlist = AbilityUnitTargetTeamSelectedList },
                    new MyCheckboxStringSelect(){ name = "AbilityUnitDamageType", check = data.TryGetValue("AbilityUnitDamageType", out _), str = MyMiniF(data,"AbilityUnitDamageType") ?? "", selectlist = DamageTypeSelectedList }
                };
                //treeView1.SelectedNode = newnode;
            }
            return newnode.Name;
        }

        public string AddAbilityDataByObject(MyNodeData data, string nodename)
        {
            TreeNode[] neednode = treeView1.Nodes.Find(nodename, true);
            TreeNode newnode = neednode[0].Nodes.Add(data.name);
            newnode.Name = "node" + nodenum;
            object[] tagdata = new object[] { data.name,
                "abilitydata"
            };
            nodenum++;
            if (!neednode[0].IsExpanded)
                neednode[0].Toggle();
            
            for (int i = 0; data.data.Count > i;i++)
            {
                Array.Resize(ref tagdata, tagdata.Length + 1);
                if (data.name == "01")
                {
                    tagdata[tagdata.Length - 1] = new MyCheckboxStringString() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value };
                }
                else if(data.name == "Properties")
                {
                    tagdata[tagdata.Length - 1] = new MyCheckboxStringSelectString() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value, selectlist = Properties };
                }
                else if(data.name == "States")
                {
                    tagdata[tagdata.Length - 1] = new MyCheckboxStringSelectStringSelect() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value, selectlist1 = States, selectlist2 = StatesValues };
                }
                else
                {
                    if (data.data.ElementAt(i).Key == "ScriptFile")
                    {
                        tagdata[tagdata.Length - 1] = new MyCheckboxStringOpen() { check = true, name = data.data.ElementAt(i).Key, str = data.data.ElementAt(i).Value };
                    }
                    else
                    {
                        tagdata[tagdata.Length - 1] = new MyCheckboxStringString() { check = true, name = "", str1 = data.data.ElementAt(i).Key, str2 = data.data.ElementAt(i).Value };
                    }
                }
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

        public void CreateItem(object sender, EventArgs e)
        {
            TextBox namebox = (TextBox)splitContainer1.Panel2.Tag;
            string name = namebox.Text;
            ClearPanels();
            //Debug.WriteLine(name);
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearPanels();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File";
            fdlg.InitialDirectory = @"c:\";
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
            newbutton2.Click += CreateItem;
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
            else if ((string)data[1] == "ability" || (string)data[1] == "abilitydata")
            {
                selectednode = e.Node.Name;
                object[] newdata = new object[0];
                //Debug.WriteLine("Length = " + data.Length);
                for (int i = 2; i < data.Length; i++)
                {
                    //Debug.WriteLine("Load " + i);
                    if (data[i].GetType() == typeof(MyCheckbox))
                    {
                        MyCheckbox thisdata = (MyCheckbox)data[i];
                        CheckBox mycheck = new CheckBox();
                        mycheck.Location = new Point(230, (30 * (i - 2)) + 6);
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
                        mytextbox.Location = new Point(230, (30 * (i - 2)) + 3);
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
                        mytextbox.Location = new Point(230, (30 * (i - 2)) + 3);
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
                        mytextbox.Location = new Point(230, (30 * (i - 2)) + 3);
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
                        mytextbox.Location = new Point(230, (30 * (i - 2)) + 3);
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
                        mytextbox.Location = new Point(230, (30 * (i - 2)) + 3);
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
                        newbutton2.Tag = new object[] { mytextbox, thisdata.selectlist2 };
                        newbutton2.Click += SelectModeOn;
                        newbutton2.Parent = splitContainer1.Panel2;

                        Array.Resize(ref newdata, newdata.Length + 1);
                        newdata[i - 2] = new object[] { mycheck, mytextbox, mytextbox2 };
                    }
                }
                splitContainer1.Panel2.Tag = newdata;
            }
        }

        public class MyCheckbox
        {
            public string name { get; set; }
            public bool check { get; set; }
        }

        public class MyString
        {
            public string name { get; set; }
            public string str { get; set; }
        }

        public class MyStringSelect
        {
            public string name { get; set; }
            public string str { get; set; }
            public string[] selectlist { get; set; }
        }

        public class MyCheckboxString
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str { get; set; }
        }

        public class MyCheckboxStringString
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
        }

        public class MyCheckboxStringSelect
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str { get; set; }
            public string[] selectlist { get; set; }
        }

        public class MyCheckboxStringOpen
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str { get; set; }
        }

        public class MyCheckboxStringStringSelect
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string[] selectlist { get; set; }
        }

        public class MyCheckboxStringSelectString
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string[] selectlist { get; set; }
        }

        public class MyCheckboxStringSelectStringSelect
        {
            public string name { get; set; }
            public bool check { get; set; }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string[] selectlist1 { get; set; }
            public string[] selectlist2 { get; set; }
        }
    }
}
