using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour
{
    public int HpAmount;


    public void HpPotionMechanic()
    {
        PlayerStats.CurrentHp += HpAmount;
        if (PlayerStats.CurrentHp > PlayerStats.MaxHp)
            PlayerStats.CurrentHp = PlayerStats.MaxHp;
    }
}
