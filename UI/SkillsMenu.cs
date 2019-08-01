using UnityEngine;
using UnityEngine.UI;

public class SkillsMenu : MonoBehaviour
{
    Animator animator;
    public GameObject npcList1;
    public GameObject npcList2;
    public GameObject npcList3;
    private bool npcAdded;


    void Start()
    {
        animator = GetComponent<Animator>();

    }


    public void SkillsRide()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DeadState"))
            animator.SetBool("skillsRide", true);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SkillsOn"))
            animator.SetBool("skillsRide", false);
    }


    public void AddOptionsToNpcList()
    {
        if (!npcAdded)
        {
            npcList1.transform.Find("Dropdown").GetComponent<ChooseNpc>().AddOptions();
            npcList2.transform.Find("Dropdown").GetComponent<ChooseNpc>().AddOptions();
            npcList3.transform.Find("Dropdown").GetComponent<ChooseNpc>().AddOptions();
            npcAdded = true;
        }
    }


    public void ConfirmAndAddNpcToBattle()
    {
        string npcName1 = npcList1.transform.Find("Dropdown").GetComponent<Dropdown>().captionText.text;
        string npcName2 = npcList2.transform.Find("Dropdown").GetComponent<Dropdown>().captionText.text;
        string npcName3 = npcList3.transform.Find("Dropdown").GetComponent<Dropdown>().captionText.text;

        if (npcName1 != "Choose wisely")
        {
            NpcMonster npc = BattleMechanics.NpcData[npcName1].Clone();
            if (npc.Initiative == 10)
            {
                npc.DistanceAttack = true;
            }
            BattleMechanics.NpcList.Add(npc);
        }
        if (npcName2 != "Choose wisely")
        {
            NpcMonster npc = BattleMechanics.NpcData[npcName2].Clone();
            if (npc.Initiative == 10)
            {
                npc.DistanceAttack = true;
            }
            BattleMechanics.NpcList.Add(npc);
        }
        if (npcName3 != "Choose wisely")
        {
            NpcMonster npc = BattleMechanics.NpcData[npcName3].Clone();
            if (npc.Initiative == 10)
            {
                npc.DistanceAttack = true;
            }
            BattleMechanics.NpcList.Add(npc);
        }
        foreach (NpcMonster npc in BattleMechanics.NpcList)
        {
            Debug.Log(npc.Name + ", " + npc.CurrentHp + " HP.");
        }
    }


    public void ClearNpcList()
    {
        GameObject[] npcButtons = GameObject.FindGameObjectsWithTag("NpcButtons");
        foreach (GameObject button in npcButtons)
        {
            Destroy(button);
        }
        BattleMechanics.NpcList.Clear();
        BattleMechanics.InitiativeOrder.Clear();
    }
}
