using UnityEngine;

public class ChangeWeaponType : MonoBehaviour
{

    public void ChangeWeaponTypeToCloseCombat()
    {
        if (PlayerStats.Initiative == 6 && BattleMechanics.GameStarted)
        {
            BattleMechanics.LogText.text += "\n\rУ Героя и так Ближний Бой.\n\r";      
            return;
        }
        PlayerStats.Initiative = 6;
        PlayerStats.DistanceAttack = false;
        if (BattleMechanics.GameStarted)
        {
            BattleMechanics.LogText.text += "\n\rГерой меняет своё оружие на Ближний Бой.\n\r";
            PlayerStats.MadeTurn = true;
            PlayerStats.WeaponSwitch = true;
            BattleMechanics.TurnPhase();
            BattleMechanics.InitiativeCount();
        }
    }


    public void ChangeWeaponTypeToDistanceCombat()
    {
        if (PlayerStats.Initiative == 11 && BattleMechanics.GameStarted)
        {
            BattleMechanics.LogText.text += "\n\rУ Героя и так Дальний Бой.\n\r";
            return;
        }
        PlayerStats.Initiative = 11;
        PlayerStats.DistanceAttack = true;
        if (BattleMechanics.GameStarted)
        {
            BattleMechanics.LogText.text += "\n\rГерой меняет своё оружие на Дальний Бой.\n\r";
            PlayerStats.MadeTurn = true;
            PlayerStats.WeaponSwitch = true;
            BattleMechanics.TurnPhase();
            BattleMechanics.InitiativeCount();
        }
    }
}
