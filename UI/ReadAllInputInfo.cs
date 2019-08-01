using System;
using UnityEngine;
using UnityEngine.UI;

public static class ReadAllInputInfo
{
    private static String _transformingText;
    private static int _transformedNumber;


    public static void GetEquipInfo()
    {
        GameObject playerStats = GameObject.Find("Players Stats"); //графа основных характеристик героя

        Transform equip = playerStats.transform.Find("Equip");
        //_transformingText = equip.Find("Right Lvl InputField").Find("Text").GetComponent<Text>().text;
        //PlayerEquipmentStats.RightWeaponLvl = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Right Weapon Mult. InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.RightWeaponMinDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Right Weapon Damage InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.RightWeaponMaxDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Right Add Dmg InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.RightWeaponAddDmgPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        //_transformingText = equip.Find("Left Lvl InputField").Find("Text").GetComponent<Text>().text;
        //PlayerEquipmentStats.LeftWeaponLvl = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Left Weapon Mult. InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.LeftWeaponMinDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Left Weapon Damage InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.LeftWeaponMaxDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Left Add Dmg InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.LeftWeaponAddDmgPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Left Shield InputField").Find("Text").GetComponent<Text>().text;
        if (int.TryParse(_transformingText, out _transformedNumber))
        {
            PlayerEquipmentStats.LeftShieldPercent = _transformedNumber;
            if (_transformedNumber > 0)
                PlayerEquipmentStats.LeftShield = true;
        }
        else
        {
            PlayerEquipmentStats.LeftShieldPercent = 0;
        }

        _transformingText = equip.Find("Head InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.HelmetPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Body InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.BodyPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Gloves InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.GlovesPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = equip.Find("Boots InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.BootsPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;


        Transform addStats = playerStats.transform.Find("Additional Stats");

        _transformingText = addStats.Find("PenetrationPercent InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.Penetration = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("Health InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.Health = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("EvasionPercent InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.EvasionPercent = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("Mag Def InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.MagDef = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("AccuracyPercent InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.Accuracy = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("Initiative InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.Initiative = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("Phys Crit InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.PhysCritChance = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;

        _transformingText = addStats.Find("Mag Crit InputField").Find("Text").GetComponent<Text>().text;
        PlayerEquipmentStats.MagCritChance = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 0;
    }


    public static void GetScrollInfo()
    {
        _transformingText = GameObject.Find("Attack Scroll").transform.Find("Mult InputField").Find("Text").GetComponent<Text>().text;
        ScrollEffects.ScrollMult = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 1;

        _transformingText = GameObject.Find("Attack Scroll").transform.Find("Dmg InputField").Find("Text").GetComponent<Text>().text;
        ScrollEffects.ScrollDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 5;

        _transformingText = GameObject.Find("Heal Scroll").transform.Find("InputField").Find("Text").GetComponent<Text>().text;
        ScrollEffects.ScrollHp = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 5;

        _transformingText = GameObject.Find("Buff Scroll").transform.Find("InputField").Find("Text").GetComponent<Text>().text;
        ScrollEffects.ScrollBuff = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 2;

        _transformingText =
            GameObject.Find("HP Potion").transform.Find("InputField").Find("Text").GetComponent<Text>().text;
        PotionsEffects.Hp = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 10;

        _transformingText =
            GameObject.Find("Balsam Potion").transform.Find("InputField").Find("Text").GetComponent<Text>().text;
        PotionsEffects.BonusDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 3;


        _transformingText =
            GameObject.Find("Poison Potion").transform.Find("InputField").Find("Text").GetComponent<Text>().text;
        PotionsEffects.PoisonDmg = int.TryParse(_transformingText, out _transformedNumber) ? _transformedNumber : 2;
    }
}
