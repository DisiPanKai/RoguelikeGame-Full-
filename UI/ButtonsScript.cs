using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    public GameObject BeginBattleButton;
    public GameObject WaitButton;


    public void BeginBattle() //кнопка "Начать бой"
    {
        BattleMechanics.GameStarted = true;
        BeginBattleButton.SetActive(false);
        GameObject.Find("Attack Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Defence Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Clear Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Attack Scroll").transform.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Heal Scroll").transform.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Buff Scroll").transform.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Sleep Scroll").transform.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("HP Potion").transform.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Balsam Potion").transform.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Poison Potion").transform.Find("Button").GetComponent<Button>().enabled = true;
        ReadAllInputInfo.GetScrollInfo();
        //PlayerStats.CalculateStats();
        //PlayerStats.MaxToCurrent();
        Text logText = GameObject.Find("Log Field Text").GetComponent<Text>();
        logText.text += "Итак, бой начинается! Выберите себе противника. По умолчанию, выбран первый Монстр(" + BattleMechanics.NpcList[BattleMechanics.SelectedNpc].Name + ").\n\r";
        PlayerStats.PlayerNumbersToPercent();
        BattleMechanics.InitiativeCount();
        //foreach (var skills in NpcMonster.enemySkills)
        //{
        //    logText.text += "\n\rскил №" + skills + " добавлен в список активных скилов.\n\r";
        //}
    }

    public void ClearLog() //кнопка "Очистить"
    {
        GameObject.Find("Log Field Text").GetComponent<Text>().text = "";
        BeginBattleButton.SetActive(true);
        GameObject.Find("Attack Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Defence Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Clear Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Attack Scroll").transform.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Heal Scroll").transform.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Buff Scroll").transform.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Sleep Scroll").transform.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("HP Potion").transform.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Balsam Potion").transform.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Poison Potion").transform.Find("Button").GetComponent<Button>().enabled = false;
        PlayerStats.Poison = false;
        PlayerStats.DebuffCount = 0;
        PlayerStats.DebuffHeadAccPercent = 0; //дебафф игрока на точность
        PlayerStats.DebuffEvaPercent = 0; //дебафф игрока на уворот
        PlayerStats.DebuffRHandPhysDmg = 0; //дебафф игрока на урон с правой руки
        PlayerStats.DebuffLDmg = false;  //дебафф игрока на неспособность бить левой рукой
        //BattleMechanics.greaseIsActivated = false;
        PlayerStats.BuffIsActivated = false;
        PlayerStats.PoisonBonus = 0;
        PlayerStats.GreaseBonus = 0;
        PlayerStats.pBleed = false;
        PlayerStats.pVampire = false;
        PlayerStats.pBoneBreaker = false;
        PlayerStats.PDueler = false;
        PlayerStats.PSpikes = false;
        PlayerStats.PAntimagic = false;
        PlayerStats.pCrusher = false;
        PlayerStats.pSoulEater = false;
        PlayerStats.KickEffectOnHero = false;
        PlayerStats.PoisonEffectOnHero = false;
        PlayerStats.ToxicEffectOnHero = false;
        PlayerStats.WallEyeEffectOnHero = false;
        PlayerStats.pBeast = false;
        PlayerStats.PBerserk = false;
        PlayerStats.pMadMan = false;
        PlayerStats.pMadManMultiplier = 0;
        PlayerStats.PSpikes = false;
        PlayerStats.PAntimagic = false;
        BattleMechanics.GameOver = false;
        //BattleMechanics.NpcList.Clear();
        BattleMechanics.SelectedNpc = 0;
        //PlayerStats.CurrentNumberWhichIsHundredPercent = 10;
        BattleMechanics.GameStarted = false;
        PlayerStats.MadeTurn = false;
        GameObject.Find("Log Field Text").GetComponent<RectTransform>().localPosition = new Vector3(0, -14677);
        for (int i = 0; i < BattleMechanics.NpcList.Count; i++)
        {
            NpcMonster newNpcIncomming = BattleMechanics.NpcData[BattleMechanics.NpcList[i].Name].Clone();
            newNpcIncomming.Id = i;
            if (newNpcIncomming.Initiative == 10)
                newNpcIncomming.DistanceAttack = true;
            BattleMechanics.NpcList[i] = newNpcIncomming;
        }
        PlayerStats.HpReset();

    }

    public void PhysAttack() //
    {
        Text logText = GameObject.Find("Log Field Text").GetComponent<Text>();
        int npcId = BattleMechanics.SelectedNpc;
        NpcMonster npc = BattleMechanics.NpcList[npcId];
        if (npc.CurrentHp == 0)
        {
            logText.text += npc.Name + " уже недееспособен. Выберите другого противника.\n\r";
            return;
        }
        PlayerStats.PlayerBattlePhase(1, npc);
        if (npc.CurrentHp == 0 || PlayerStats.CurrentHp == 0)
        {
            BattleMechanics.WhoIsLoosing(npc);
            if (BattleMechanics.GameOver)
                return;
        }
        BattleMechanics.TurnPhase();
        //BattleMechanics.PlayerMadeHisTurn = false;
    }

    public void PhysDef() //
    {
        int npcId = BattleMechanics.SelectedNpc;
        NpcMonster npc = BattleMechanics.NpcList[npcId];
        PlayerStats.PlayerBattlePhase(2, npc);
        if (npc.CurrentHp == 0 || PlayerStats.CurrentHp == 0)
        {
            BattleMechanics.WhoIsLoosing(npc);
            if (PlayerStats.CurrentHp == 0 || BattleMechanics.GameOver)
                return;
        }
        BattleMechanics.TurnPhase();
        //BattleMechanics.PlayerMadeHisTurn = false;
    }

    public void WaitTurns() //Если игрок спит/оглушён/напуган, то запускается этот метод
    {
        //int npcId = BattleMechanics.SelectedNpc;
        //NpcMonster npc = BattleMechanics.NpcList[npcId];
        BattleMechanics.TurnPhase();
        if (PlayerStats.SleepinessEffectOnHero || !PlayerStats.StunEffectOnHero || !PlayerStats.TerrorEffectOnHero)
        {
            WaitButton.SetActive(false);
            GameObject.Find("Defence Button").GetComponent<Button>().enabled = true;
        }
    }

    public void WaitButtonAppears()
    {
        WaitButton.SetActive(true);
        GameObject.Find("Defence Button").GetComponent<Button>().enabled = false;
    }




}
