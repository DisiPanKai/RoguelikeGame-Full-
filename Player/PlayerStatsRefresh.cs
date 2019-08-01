using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsRefresh : MonoBehaviour
{
    void Update()
    {
        RefreshPlayerStats();
    }


    public void RefreshPlayerStats()
    {
        string fightType = PlayerStats.Initiative == 6 ? "(ББ)" : "(ДБ)";
        transform.Find("Initiative Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.Initiative + fightType;
        transform.Find("Close Combat Dmg Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.CloseCombatDmgPercent + "%";
        //int PercentToNumber = Mathf.RoundToInt(PlayerStats.CurrentNumberWhichIsHundredPercent / 100f * PlayerStats.PenetrationPercent);
        int numberToPercent = BattleMechanics.RoundItUp((float)PlayerStats.Penetration / PlayerStats.CurrentNumberWhichIsHundredPercent * 100f);
        transform.Find("Penetration Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.Penetration + "(" + numberToPercent + "%)";
        transform.Find("Crit. Strength Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.PhysCritPowerPercent + "%";
        transform.Find("Distance Combat Dmg Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.DistantCombatDmg + "%";
        numberToPercent = BattleMechanics.RoundItUp((float)PlayerStats.Evasion / PlayerStats.CurrentNumberWhichIsHundredPercent * 100f);
        //PercentToNumber = Mathf.RoundToInt(PlayerStats.CurrentNumberWhichIsHundredPercent / 100f * PlayerStats.EvasionPercent);
        transform.Find("EvasionPercent Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.Evasion + "(" + numberToPercent + "%)";
        numberToPercent = BattleMechanics.RoundItUp((float)PlayerStats.PhysCritChance / PlayerStats.CurrentNumberWhichIsHundredPercent * 100f);
        transform.Find("Crit. Chance Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.PhysCritChance + "(" + numberToPercent + "%)";
        transform.Find("Health Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.MaxHp + "";
        //PercentToNumber = Mathf.RoundToInt(PlayerStats.CurrentNumberWhichIsHundredPercent / 100f * PlayerStats.PhysArmorPercent);
        numberToPercent = BattleMechanics.RoundItUp((float)PlayerStats.PhysArmor / PlayerStats.CurrentNumberWhichIsHundredPercent * 100f);
        transform.Find("Armor Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.PhysArmor + "(" + numberToPercent + "%)";
        transform.Find("Magic Dmg Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.MagicCombatDmg + "";
        transform.Find("Elemental Resistance Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.ElementalResistancePercent + "%";
        transform.Find("Accuracy Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.AccuracyPercent + "%";
        transform.Find("RDmg Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.RightWeaponMinDmg + "-" + PlayerStats.RightWeaponMaxDmg;
        transform.Find("LDmg Stat Info").Find("Number Text").GetComponent<Text>().text = PlayerStats.LeftWeaponMinDmg + "-" + PlayerStats.LeftWeaponMaxDmg;
    }
}
