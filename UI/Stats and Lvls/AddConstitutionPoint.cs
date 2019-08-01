using UnityEngine.UI;

public class AddConstitutionPoint : AddStatPointInner
{
    public new void AddStatPoint()
    {
        PlayerStats.AddNewConStat();
        transform.GetChild(2).GetComponent<Text>().text = "" + PlayerStats.Constitution;
        base.AddStatPoint();
    }
}
