using UnityEngine;
using UnityEngine.UI;

public class RemainigPoints : MonoBehaviour
{
    public void MinusRemainingPoints()
    {
        BattleMechanics.RemainingPoints--;
        transform.Find("Points Text").GetComponent<Text>().text = "" + BattleMechanics.RemainingPoints;
    }
}
