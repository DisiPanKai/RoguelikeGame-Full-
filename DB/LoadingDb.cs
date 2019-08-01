using UnityEngine;
using System.Data;

public class LoadingDb : MonoBehaviour
{

    private Database_connection Data_Base = new Database_connection();

    private IDataReader sql_data;

    private int sql_num;

    void Start()
    {
        Data_Base.Connection();
        PlayerSkillsLoading();
        NpcLoading();

    }

    private void PlayerSkillsLoading()
    {
        Data_Base.Connection();
        string sqlQuery = "SELECT stuff_abilities_temp.id, stuff_abilities_temp.type, stuff_abilities_temp.ability_name, " +
            "stuff_abilities_temp.cooldown, stuff_abilities_temp.duration, stuff_abilities_temp.description FROM stuff_abilities_temp";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            PlayerSkills Skill_data = new PlayerSkills();

            sql_num = 0;
            Skill_data.id = sql_data.GetInt32(sql_num);
            sql_num++;
            Skill_data.type = sql_data.GetString(sql_num);
            sql_num++;
            Skill_data.ability_name = sql_data.GetString(sql_num);
            sql_num++;
            Skill_data.cooldown = sql_data.GetInt32(sql_num);
            sql_num++;
            Skill_data.duration = sql_data.GetInt32(sql_num);
            sql_num++;
            Skill_data.description = sql_data.GetString(sql_num);

            PlayerStats.skillData.Add(Skill_data);
        }
        sql_data.Close();
        sql_data = null;
        End_loading();
    }

    private void NpcLoading()
    {
        Data_Base.Connection();
        string sqlQuery = "SELECT bestiary.id, bestiary.map_id, bestiary.bestiary_name, bestiary.point_dungeon_id, bestiary.icon_image_id, bestiary.image_id, " +
                          "bestiary.fight_type_id, bestiary.phys_damage_min, bestiary.phys_damage_max, bestiary.damage_bonus, bestiary.magic_damage_min, bestiary.magic_damage_max, " +
                          "bestiary.magic_damage_bonus, bestiary.penetration, bestiary.phys_def, bestiary.mag_def, " +
                          "bestiary.health, bestiary.accuracy, bestiary.evasion, bestiary.crit_chance, bestiary.initiative, " +
                          "bestiary.ability_id, bestiary.first_ability_proc_chance_d, bestiary.first_ability_proc_chance, bestiary.first_ability_cooldown, " +
                          "bestiary.first_ability_id, bestiary.second_ability_proc_chance_d, bestiary.second_ability_proc_chance, " +
                          "bestiary.second_ability_cooldown, bestiary.second_ability_id, bestiary.third_ability_proc_chance_d, " +
                          "bestiary.third_ability_proc_chance, bestiary.third_ability_cooldown, bestiary.third_ability_id " +
                          "FROM bestiary";

        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            NpcMonster npcMonster = new NpcMonster();
            sql_num = 2;
            npcMonster.Name = sql_data.GetString(sql_num);
            sql_num = 7;
            npcMonster.PhysMinDmg = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.PhysMaxDmg = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.BonusPhysAttack = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.MagMinDmg = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.MagMaxDmg = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.BonusMagAttack = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.PenetrationPercent = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.PhysArmorPercent = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.MaxMagDef = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.CurrentHp = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.AccuracyPercent = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.EvasionPercent = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.CritChancePercent = sql_data.GetInt32(sql_num);
            sql_num++;
            npcMonster.Initiative = sql_data.GetInt32(sql_num);
            sql_num += 5;
            int skillId = sql_data.GetInt32(sql_num);
            if (skillId != 0)
                npcMonster.AddActiveOrPassiveSkill(skillId);
            sql_num += 4;
            skillId = sql_data.GetInt32(sql_num);
            if (skillId != 0)
                npcMonster.AddActiveOrPassiveSkill(skillId);
            sql_num += 4;
            skillId = sql_data.GetInt32(sql_num);
            if (skillId != 0)
                npcMonster.AddActiveOrPassiveSkill(skillId);
            BattleMechanics.NpcData.Add(npcMonster.Name, npcMonster);
        }
        sql_data.Close();
        sql_data = null;
        End_loading();
    }

    private void End_loading()
    {
        Data_Base.Connection_close();
    }
}
