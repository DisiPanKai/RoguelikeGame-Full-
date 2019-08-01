using UnityEngine;
using UnityEngine.UI;

public class CreateNpcButtonList : MonoBehaviour
{
    public GameObject npcButtonPrefab;

    public void CreateButtonList()
    {
        float titlePosY = transform.Find("Title Text").GetComponent<RectTransform>().anchoredPosition.y;
        int npcId = 0;
        foreach (NpcMonster npc in BattleMechanics.NpcList)
        {
            titlePosY -= 60f;
            GameObject buttonPrefab = Instantiate(npcButtonPrefab);
            buttonPrefab.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            buttonPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, titlePosY);
            buttonPrefab.GetComponent<AttackThisNpc>().npcId = npcId;
            npc.Id = npcId;
            buttonPrefab.name = "Npc Button №" + (npcId + 1);
            npcId++;
            buttonPrefab.transform.Find("Text").GetComponent<Text>().text = npc.Name;
        }
    }
}
