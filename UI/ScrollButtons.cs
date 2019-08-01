using UnityEngine;
using UnityEngine.UI;

public class ScrollButtons : MonoBehaviour
{

    public void UseAttackScroll()
    {
        ScrollMechanics(1, BattleMechanics.SelectedNpc);
    }

    public void UseHpScroll()
    {
        ScrollMechanics(2, BattleMechanics.SelectedNpc);
    }

    public void UseBuffScroll()
    {
        ScrollMechanics(3, BattleMechanics.SelectedNpc);
    }

    public void UseSleepScroll()
    {
        ScrollMechanics(4, BattleMechanics.SelectedNpc);
    }


    /* 1 - свиток маг атаки
     * 2 - свиток восстановления
     * 3 - свиток усиления хар.
     * 4 - свиток сна
     */

    void ScrollMechanics(int option, int npcId)
    {
        Text logText = GameObject.Find("Log Field Text").GetComponent<Text>();
        NpcMonster npc = BattleMechanics.NpcList[npcId];
        if (npc.CurrentHp == 0 && (option == 1 || option == 4))
        {
            logText.text += npc.Name + " уже недееспособен. Выберите другого противника.\n\r";
            return;
        }
        PlayerStats.PlayerBattlePhase(3, npc);
        if (PlayerStats.CurrentHp == 0)
        {
            BattleMechanics.WhoIsLoosing(npc);
            return;
        }
        //BattleMechanics.PlayerSkillAndBuffCountersCheck();
        switch (option)
        {
            case 1:
                PlayerStats.PlayerMagicAttack(npc, ScrollEffects.ScrollMult, ScrollEffects.ScrollDmg);
                break;
            case 2:
                ScrollEffects.HpScrollMechanic(ScrollEffects.ScrollHp);
                logText.text += "\n\rИспользован свиток лечения. ХП Героя возросло на " + ScrollEffects.ScrollHp +
                                ", теперь у Героя " + PlayerStats.CurrentHp + " ХП.\n\r";
                break;
            case 3:
                if (!PlayerStats.BuffIsActivated)
                {
                    ScrollEffects.BoostScrollMechanic(ScrollEffects.ScrollBuff);
                    logText.text +=
                        "\n\rИспользован свиток усиления характеристик на 3 хода. Характеристики возросли на " +
                        ScrollEffects.ScrollBuff + ".\n\r";
                }
                else
                {
                    logText.text += "\n\rСвиток усиления характеристик уже действует. Эффект продлён до 3 ходов\n\r";
                    PlayerStats.BuffTurns = 3;
                }
                break;
            case 4:
                ScrollEffects.SleepScrollMechanic(npc);
                logText.text += "\n\rИспользован свиток сна. " + npc.Name + " засыпает на 2 хода\n\r";
                break;
        }
        if (npc.CurrentHp == 0) //если боевой свиток убил моба
        {
            //if (BattleMechanics.eZombie)
            //{
            //    BattleMechanics.EnemySkillZombieDied();
            //    logText.text += "Магия убила зомби. Теперь на место зомби встал хозяин.\n\r";
            //    return;
            //}
            if (npc.Reincarnation)
            {
                npc.EnemyReincarnation();
            }
            else
            {
                BattleMechanics.WhoIsLoosing(npc);
            }

        }
        //if (option != 1)//в методе PlayerBattlePhase уже есть атака монстра
        BattleMechanics.AfterPlayerAction();
    }

}
