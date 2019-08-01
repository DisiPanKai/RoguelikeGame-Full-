using UnityEngine.UI;

public class AddStrengthPoint : AddStatPointInner
{
    void Start()
    {
        PlayerStats.FirstLvlCalculatingStats();
    }


    public new void AddStatPoint()
    {
        PlayerStats.AddNewStrStat();
        transform.GetChild(2).GetComponent<Text>().text = "" + PlayerStats.Strength;
        base.AddStatPoint();
    }
}
