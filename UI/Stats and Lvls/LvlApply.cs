using UnityEngine;
using UnityEngine.UI;

public class LvlApply : MonoBehaviour
{

    public void ApplyInputLvl()
    {
        Transform textFromLvlInputField = GameObject.Find("Player Lvl").transform.Find("Lvl InputField").Find("Text");
        string transformingText = textFromLvlInputField.GetComponent<Text>().text; //графа основных характеристик героя
        int transformedNumber;
        if (int.TryParse(transformingText, out transformedNumber))
        {
            if (transformedNumber > BattleMechanics.CurrentLvl)
            {
                BattleMechanics.RemainingPoints = transformedNumber * 2;
                GameObject.Find("Remaining Points").transform.Find("Points Text").
                    GetComponent<Text>().text = "" + BattleMechanics.RemainingPoints;
                
                //if (transformedNumber > 0) //вычисление текущего числа для уровня
                //{
                //    PlayerStats.CurrentNumberWhichIsHundredPercent = 10;
                //    PlayerStats.CurrentLevelCounter = transformedNumber - 1;
                //    for (int i = 0; i < PlayerStats.CurrentLevelCounter; i++)
                //    {
                        
                //    }
                //}
            }
        }
    }
}
