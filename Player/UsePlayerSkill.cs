using UnityEngine;
using UnityEngine.UI;

public class UsePlayerSkill : MonoBehaviour
{
    public int skillId;


    public void UseSkillbyID()
    {
        Text logText = GameObject.Find("Log Field Text").GetComponent<Text>();
        NpcMonster npc = BattleMechanics.NpcList[BattleMechanics.SelectedNpc];
        if (npc.CurrentHp == 0)
        {
            logText.text += npc.Name + " уже недееспособен. Выберите другого противника.\n\r";
            return;
        }

        switch (skillId)
        {
            //скилы, которые атакуют сразу
            //оружейные:
            case 2: //Удар в печень
            case 4: //Оружие вон
            case 6: //Саблезуб
            case 7: //Камикадзе
            case 15: //Стрела к олено
            case 16: //Рыцарский хук
            case 17: //Безумец
            case 18: //Разряд
            case 19: //Выпад
            case 20: //Тишина
            case 21: //Невозмутимость
            //щитовые:
            case 27: //Электро
            case 28: //Всем лежать!
                if (npc.CurrentHp == 0)
                {
                    logText.text += npc.Name + " уже недееспособен. Выберите другого противника.\n\r";
                    return;
                }
                PlayerStats.PlayerSkillEffects(skillId, npc); //используем скил
                PlayerStats.PlayerBattlePhase(1, npc);
                break;

            //просто включают пассивки
            //оружейные:
            case 8: //Кровотечение
            case 9: //Вампир
            case 10: //Костолом
            case 11: //Дуэлянт
            case 22: //пассивка "Безумца"
            case 23: //Ярость
            case 24: //Пожиратель душ
            case 25: //Крушитель
            //щитовые:
            case 29: //Месть
            case 30: //Везунчик
            case 31: //Зеркало
            case 32: //Хранитель
            case 33: //Стратег
            case 34: //Дубовая голова

            //моментальное использование скила без проматывания хода 
            //оружейные скилы:
            case 3: //Зверь
            case 5: //Берсерк
            //щитовые:
            case 12: //Шипы
            case 13: //Антимагия
            case 26: //Накопитель
                PlayerStats.PlayerSkillEffects(skillId, npc); //используем скил
                return;
                //BattleMechanics.PlayerBattlePhase(3, npc);
                //break;
        }
        if (npc.CurrentHp == 0 || PlayerStats.CurrentHp == 0)
        {
            BattleMechanics.WhoIsLoosing(npc);
            if (PlayerStats.CurrentHp == 0 || BattleMechanics.GameOver)
                return;
        }
        BattleMechanics.AfterPlayerAction(); //после использования скила монстр атакует в ответ
    }
}
