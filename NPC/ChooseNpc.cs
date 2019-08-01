using UnityEngine;
using UnityEngine.UI;

public class ChooseNpc : MonoBehaviour
{
    public Dropdown npcDropdown;

    public void AddOptions()
    {
        foreach (string npcName in BattleMechanics.NpcData.Keys)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(npcName);
            npcDropdown.options.Add(option);
        }
    }

    //private void myDropdownValueChangedHandler(Dropdown target)
    //{
    //    Debug.Log("selected: " + target.captionText.text);
    //    //npcDropdown.value = index;
    //}
}
