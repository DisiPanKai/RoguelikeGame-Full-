using UnityEngine;
using UnityEngine.UI;

public class AssignOnClick : MonoBehaviour {

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GetComponent<AddEnemySkill>().AddSkillbyID);
    }

}
