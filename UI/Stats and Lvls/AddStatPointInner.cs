using UnityEngine;
using UnityEngine.UI;

public class AddStatPointInner : MonoBehaviour
{
    public void AddStatPoint()
    {
        GameObject.Find("Stats Screen").GetComponent<PlayerStatsRefresh>().RefreshPlayerStats();
        BattleMechanics.PointsPerLvl--;
        GameObject.Find("Remaining Points").GetComponent<RemainigPoints>().MinusRemainingPoints();
        if (BattleMechanics.PointsPerLvl == 0)
        {
            foreach (var buttonObj in BattleMechanics.MainStatsGameObjects)
            {
                buttonObj.GetComponent<Button>().enabled = true;
                buttonObj.transform.Find("Text").GetComponent<Text>().color = Color.black;
            }
            //PlayerStats.TransformToNewLvlStat();
            if (BattleMechanics.RemainingPoints != 0)
            {
                BattleMechanics.CurrentLvl++;
                GameObject.Find("Current Lvl").transform.Find("Number Text").GetComponent<Text>().text = "" + BattleMechanics.CurrentLvl;
                PlayerStats.CurrentNumberWhichIsHundredPercent = 10; //выставление стандартного значения переменной

                for (int i = 1; i < BattleMechanics.CurrentLvl; i++)
                {
                    PlayerStats.CurrentNumberWhichIsHundredPercent =
                        (int)(1.5f * PlayerStats.CurrentNumberWhichIsHundredPercent);
                }
                GameObject.Find("100%").transform.Find("Number Text").
                    GetComponent<Text>().text = "" + PlayerStats.CurrentNumberWhichIsHundredPercent;
            }
            else
            {
                AllButtonsInactive();
            }
            BattleMechanics.PointsPerLvl = 2;
        }
        else
        {
            DeactivateButton(transform.Find("Button"));
        }
    }


    public void AllButtonsInactive()
    {
        foreach (var buttonObj in BattleMechanics.MainStatsGameObjects)
        {
            DeactivateButton(buttonObj);
        }
    }


    private void DeactivateButton(Transform buttonTransform)
    {
        buttonTransform.GetComponent<Button>().enabled = false;
        buttonTransform.transform.Find("Text").GetComponent<Text>().color = Color.gray;
    }
}
