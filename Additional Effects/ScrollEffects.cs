
public static class ScrollEffects
{
    public static int ScrollMult;
    public static int ScrollDmg;
    public static int ScrollHp;
    public static int ScrollBuff;
    public static int ScrollSleep = 2;
    
    public static void HpScrollMechanic(int hp)
    {
        PlayerStats.CurrentHp += hp;
        if (PlayerStats.CurrentHp > PlayerStats.MaxHp)
            PlayerStats.CurrentHp = PlayerStats.MaxHp;
    }

    public static void BoostScrollMechanic(int buff)
    {
        PlayerStats.BuffIsActivated = true;
        PlayerStats.BuffTurns = 3;
        PlayerStats.Buffboost = buff;
        PlayerStats.Strength += buff;
        PlayerStats.Agility += buff;
        PlayerStats.Constitution += buff;
        //PlayerStats.CalculateStats();
        PlayerStats.CurrentHp += buff*5;
        //PlayerStats.CurrentMagDef += buff;
    }

    public static void SleepScrollMechanic(NpcMonster npc)
    {
        npc.SleepTurns = ScrollSleep;
        npc.EnemyIsSleeping = true;
    }
}
