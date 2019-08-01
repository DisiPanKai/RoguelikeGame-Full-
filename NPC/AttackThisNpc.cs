using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class AttackThisNpc : MonoBehaviour
{
    public int npcId;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GetComponent<AttackThisNpc>().ChooseNpcToAttack);
    }

    public void ChooseNpcToAttack()
    {
        BattleMechanics.SelectedNpc = npcId;

        Text logText = GameObject.Find("Log Field Text").GetComponent<Text>();
        NpcMonster npc = BattleMechanics.NpcList[npcId];
        if (npc.CurrentHp == 0)
        {
            logText.text += npc.Name + " уже недееспособен. Выберите другого противника.\n\r";
            return;
        }
        int closeCombat = BattleMechanics.NpcList.Count(monster => !monster.DistanceAttack && monster.CurrentHp != 0);
        bool noCombatNpc = closeCombat == 0;
        GameObject attackButton = GameObject.Find("Attack Button");
        if (npc.DistanceAttack && !PlayerStats.DistanceAttack && !noCombatNpc)
        {
            attackButton.GetComponent<Button>().enabled = false;
            attackButton.transform.Find("Text").GetComponent<Text>().color = Color.gray;
            logText.text += npc.Name + " за Монстрами ближнего боя. Сейчас не достать.\n\r";
            return;
        }
        else
        {
            attackButton.GetComponent<Button>().enabled = true;
            attackButton.transform.Find("Text").GetComponent<Text>().color = Color.black;
        }

        logText.text += "Выбран Монстр №" + (npcId + 1) + ".\n\r";
        if (npc.enemySkills.Count != 0)
        {
            logText.text += "Перечень активных скиллов: ";
            foreach (int skillId in npc.enemySkills)
            {
                logText.text += " " + skillId;
            }
            logText.text += ".\n\r";
        }
        if (npc.SkillsData.Count != 0)
        {
            logText.text += "Пассивки: ";
            foreach (var skillData in BattleMechanics.NpcList[npcId].SkillsData)
            {
                logText.text += " " + skillData.ability_id;
            }
            logText.text += ".\n\r";
        }
    }
}
