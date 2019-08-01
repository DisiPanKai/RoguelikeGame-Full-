using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PotionMenu : MonoBehaviour
{
    //public GameObject HpPotion;
    //public GameObject Balsam;
    //public GameObject Poison;
    private bool _active = true;
    public static int HpPotAmount;


    //public void PotionButton() //метод для появления и исчезания полей потов
    //{
    //    if (_active == false)
    //    {
    //        _active = true;
    //        HpPotion.SetActive(true);
    //        Balsam.SetActive(true);
    //        Poison.SetActive(true);
    //    }
    //    else
    //    {
    //        _active = false;
    //        HpPotion.SetActive(false);
    //        Balsam.SetActive(false);
    //        Poison.SetActive(false);
    //    }
    //}


    public void UseHpPotion() //методы для кнопок
    {
        PotionMechanics(1);
    }


    public void UseBalsam()
    {
        PotionMechanics(2);
    }


    public void UsePoison()
    {
        PotionMechanics(3);
    }


    void PotionMechanics(int option) //инструкция для того, что делать с потами
    {
        Text logText = GameObject.Find("Log Field Text").GetComponent<Text>();
        bool toxicPassive = false;
        foreach (NpcMonster npc in BattleMechanics.NpcList)
        {
            if (npc.CurrentHp > 0)
            {
                if (npc.Toxic)
                {
                    toxicPassive = true;
                }
            }
        }
        switch (option)
        {
            case 1:
                if (toxicPassive)
                {
                    int rndmChance = Random.Range(1, 6);
                    logText.text += "У Монстра есть навык \"Отрава\", шанс 1d5. Выпало " + rndmChance + ". ";
                    if (rndmChance == 5)
                    {
                        logText.text +=
                            "А \"Отрава\" то сработала! Каждый ход будем терять 3 ХП в ход, пока не выпьем противоядие.\n\r";
                        PlayerStats.ToxicEffectOnHero = true;
                        break;
                    }
                    else
                    {
                        logText.text += "\"Отрава\" не прошла. А Герою то повезло!\n\r";
                    }
                }
                PotionsEffects.HpPotionMechanic(PotionsEffects.Hp);
                logText.text += "Герой выпил зелье здоровья. Восполнено ХП " +
                                PotionsEffects.Hp + ", у Героя теперь " + PlayerStats.CurrentHp + " ХП.\n\r";
                break;
            case 2:
                PotionsEffects.BalsamMechanic(PotionsEffects.BonusDmg);
                logText.text += "Герой смазал оружие. Теперь у него есть " + PotionsEffects.BonusDmg +
                                " дополнительных урона до конца боя.\n\r";
                break;
            case 3:
                PotionsEffects.PoisonMechanic(PotionsEffects.PoisonDmg);
                logText.text +=
                    "Герой смазал своё оружие ядом. При пробитии брони у монстра будет отниматься " +
                    PotionsEffects.PoisonDmg + " ХП каждый ход.\n\r";
                break;
        }
        //if (option == 1) //убрали, чтобы хилки хиляли меньше
        //{
        //    BattleMechanics.CheckingGains();
        //    BattleMechanics.MonsterDmgPhase();
        //    BattleMechanics.WhoIsLoosing(); //победил ли монстр?
        //}
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
