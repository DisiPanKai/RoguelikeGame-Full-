using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDmgCalculation : MonoBehaviour
{
    public Dropdown WeaponDropdown;
    private int _minDmg = 1;
    private int _maxDmg = 2;
    private Text _dmgText;

    void Start()
    {
        _dmgText = transform.Find("Dmg Text").GetComponent<Text>();
        WeaponDropdown.onValueChanged.AddListener(delegate
        {
            myDropdownValueChangedHandler(WeaponDropdown);
        });
    }


    private void myDropdownValueChangedHandler(Dropdown target)
    {
        //Text _dmgText = transform.FindChild("Dmg Text").GetComponent<Text>();
        switch (target.value)
        {
            case 0:
                _minDmg = 1;
                _maxDmg = 2;
                DisplayDmgText();
                break;
            case 1:
                _minDmg = 2;
                _maxDmg = 3;
                DisplayDmgText();
                break;
            case 2:
                _minDmg = 1;
                _maxDmg = 4;
                DisplayDmgText();
                break;
            case 3:
                _minDmg = 3;
                _maxDmg = 5;
                DisplayDmgText();
                break;
        }
    }


    public void CalculateDmg()
    {
        string weaponLvlText = transform.Find("Weapon Lvl InputField").Find("Text").GetComponent<Text>().text;
        int weaponLvl;
        if (int.TryParse(weaponLvlText, out weaponLvl))
        {
        }
        else
        {
            return;
        }
        for (int i = 1; i < weaponLvl; i++)
        {
            int tempMaxDmg = _maxDmg;
            _minDmg = _maxDmg + 1;
            float roundedNumber = tempMaxDmg * 2.5f;
            _maxDmg = (int)BattleMechanics.RoundItUp(roundedNumber);
        }
        DisplayDmgText();
    }


    private void DisplayDmgText()
    {
        _dmgText.text = _minDmg + "-" + _maxDmg;
    }


    //private float RoundItUp(float f)
    //{
    //    return Mathf.Floor(f + 0.5f);
    //}
}
