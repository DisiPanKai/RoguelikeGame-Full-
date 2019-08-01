using UnityEngine;
using UnityEngine.UI;

public class ReadingEquipValues : MonoBehaviour
{
    void Update()
    {
        ReadAllInputInfo.GetEquipInfo();
        PlayerStats.CalculateDmgStats();
        //PlayerStats.CalculateStats();
        NumbersInBracketsOutput();
    }

    private void NumbersInBracketsOutput() //вывод статов на экран
    {
        //Transform tempTransform = transform.FindChild("Right Lvl InputField");

        Transform tempTransform = transform.Find("Right Add Dmg InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.RightWeaponAddDmgPercent, out PlayerEquipmentStats.RightWeaponAddDmg);

        tempTransform = transform.Find("Left Add Dmg InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.LeftWeaponAddDmgPercent, out PlayerEquipmentStats.LeftWeaponAddDmg);

        tempTransform = transform.Find("Left Shield InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.LeftShieldPercent, out PlayerEquipmentStats.LeftShieldBonus);

        tempTransform = transform.Find("Head InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.HelmetPercent, out PlayerEquipmentStats.HelmetArmor);

        tempTransform = transform.Find("Body InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.BodyPercent, out PlayerEquipmentStats.BodyArmor);

        tempTransform = transform.Find("Gloves InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.GlovesPercent, out PlayerEquipmentStats.GlovesArmor);

        tempTransform = transform.Find("Boots InputField");
        PercentToNumber(tempTransform, PlayerEquipmentStats.BootsPercent, out PlayerEquipmentStats.BootsArmor);
    }

    private void PercentToNumber(Transform inputFieldTransform, int percent, out int result) //метод для сокращения текста
    {
        result = (int)(PlayerStats.CurrentNumberWhichIsHundredPercent / 100f * percent);
        inputFieldTransform.Find("Transfered Number Text ").GetComponent<Text>().text = "(" + result + ')';
    }
}
