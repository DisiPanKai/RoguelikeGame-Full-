
public static class PotionsEffects
{
    public static int Hp;
    public static int BonusDmg;
    public static int PoisonDmg;

    public static void HpPotionMechanic(int hpAmount)
    {
        PlayerStats.CurrentHp += hpAmount;
        if (PlayerStats.CurrentHp > PlayerStats.MaxHp)
            PlayerStats.CurrentHp = PlayerStats.MaxHp;
    }

    public static void BalsamMechanic(int bonusDmgAmount)
    {
        //BattleMechanics.greaseIsActivated = true;
        PlayerStats.GreaseBonus = bonusDmgAmount;
        //BattleMechanics.greaseTurns = 2;
    }

    public static void PoisonMechanic(int poisonDmgAmount)
    {
        PlayerStats.PoisonBonus = poisonDmgAmount;
    }
	
}
