using UnityEngine.UI;

public class AddAgilityPoint : AddStatPointInner
{
    public new void AddStatPoint()
    {
        PlayerStats.AddNewAgiStat();
        transform.GetChild(2).GetComponent<Text>().text = "" + PlayerStats.Agility;
        base.AddStatPoint();
    }
}