using UnityEngine.UI;

public class AddIntelligencePoint : AddStatPointInner
{
    public new void AddStatPoint()
    {
        PlayerStats.AddNewIntStat();
        transform.GetChild(2).GetComponent<Text>().text = "" + PlayerStats.Intelligence;
        base.AddStatPoint();
    }
}
