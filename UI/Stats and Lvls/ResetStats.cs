using UnityEngine;
using UnityEngine.UI;

public class ResetStats : MonoBehaviour
{

    public void ResetAllStats()
    {
        foreach (var buttonObj in BattleMechanics.MainStatsGameObjects)
        {
            buttonObj.GetComponent<Button>().enabled = true;
            buttonObj.transform.Find("Text").GetComponent<Text>().color = Color.black;
        }

        BattleMechanics.RemainingPoints = BattleMechanics.CurrentLvl * 2;
        GameObject.Find("Remaining Points").transform.Find("Points Text").
            GetComponent<Text>().text = "" + BattleMechanics.RemainingPoints;

        BattleMechanics.CurrentLvl = 1;
        GameObject.Find("Current Lvl").transform.Find("Number Text").
            GetComponent<Text>().text = "" + BattleMechanics.CurrentLvl;

        PlayerStats.FirstLvlCalculatingStats();
        ResetStatsText(GameObject.Find("Strength"));
        ResetStatsText(GameObject.Find("Agility"));
        ResetStatsText(GameObject.Find("Constitution"));
        ResetStatsText(GameObject.Find("Intelligence"));

        PlayerStats.CurrentNumberWhichIsHundredPercent = 10;
        GameObject.Find("100%").transform.Find("Number Text").
            GetComponent<Text>().text = "" + PlayerStats.CurrentNumberWhichIsHundredPercent;
        GameObject.Find("Stats Screen").GetComponent<PlayerStatsRefresh>().RefreshPlayerStats();
    }

    private void ResetStatsText(GameObject statObj)
    {
        statObj.transform.Find("Number Text").GetComponent<Text>().text = "1";
    }
}
