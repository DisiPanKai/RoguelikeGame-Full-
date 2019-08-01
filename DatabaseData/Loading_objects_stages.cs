using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class Loading_objects_stages : MonoBehaviour
{
    private Database_connection Data_Base = new Database_connection();

    private IDataReader sql_data;

    private int sql_num;
    //private int sql_line_num;

    private int mask_bar_size_step_num;
    private int mask_bar_size_step = 20;

    //public GameObject mask_progress_bar;
    //public Text loading_text;

    // Use this for initialization
    void Start()
    {
        Create_scene();
    }

    void Create_scene()
    {
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //mask_bar_size_step_num = 0;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);
        //loading_text.text = "Подключение к БД";

        Data_Base.Connection();
        Image_count();
        //Map_list_count();
    }

    //#region Подсчет колисечтва карт в БД, и загрузка списка карт, если их больше 0
    //private void Map_list_count()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    string sqlQuery = "SELECT count(*) FROM map";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        sql_num = sql_data.GetInt32(0);
    //    }
    //    sql_data.Close();
    //    sql_data = null;

    //    Main.db_data.map_list_count = sql_num;

    //    if (Main.db_data.map_list_count > 0)
    //    {
    //        Map_list_loading();
    //    }
    //    else
    //    {
    //        Image_count();
    //    }
    //}

    //private void Map_list_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Map_list";

    //    string sqlQuery = "SELECT map.id, map.map_name, map.file_name, map.minimum_level, map.maximum_level FROM map";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Map_list_Data Map_list = new Map_list_Data();

    //        Map_list.id = sql_data.GetInt32(0);
    //        Map_list.map_name = sql_data.GetString(1);
    //        Map_list.file_name = sql_data.GetString(2);
    //        Map_list.minimum_level = sql_data.GetInt32(3);
    //        Map_list.maximum_level = sql_data.GetInt32(4);

    //        Main.db_data.map_list.Add(Map_list.id, Map_list);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Map_list[0].map_name);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Image_data_loading();
    //}
    //#endregion

    #region Подсчет, и загрузка данных с таблици Image, Image_type
    private void Image_count()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        string sqlQuery = "SELECT count(*) FROM image";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            sql_num = sql_data.GetInt32(0);
        }
        sql_data.Close();
        sql_data = null;

        //loading_text.text = "Загрузка изображений";

        Sprite[] sprites = Resources.LoadAll<Sprite>("Content/texture_image");

        foreach (Sprite sprite in sprites)
        {
            //loading_text.text = "Загрузка изображения '\"' " + sprite.name + " '\"'";
            Main.Image_list.Add(sprite.name, sprite);
        }

        Image_data_loading();
    }

    private void Image_data_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Image_data";

        string sqlQuery = "SELECT image.id, image.type_id, image_type.type_name, image_type.type_name_ru, image.image_name FROM image, image_type WHERE image.type_id = image_type.id";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Image_Data Image_data = new Image_Data();

            sql_num = 0;
            Image_data.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Image_data.type_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Image_data.type_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Image_data.type_name_ru = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Image_data.image_name = sql_data.GetString(sql_num);

            Main.db_data.image_data.Add(Image_data.id, Image_data);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Image_data[0].image_name);
        Debug.Log(Main.Image_data[105].image_name);
        Debug.Log(Main.Image_data.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        Image_type_loading();
    }

    private void Image_type_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Image_type";

        string sqlQuery = "SELECT image_type.id, image_type.type_name, image_type.type_name_ru FROM image_type";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Image_type_Data Image_type = new Image_type_Data();

            sql_num = 0;
            Image_type.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Image_type.type_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Image_type.type_name_ru = sql_data.GetString(sql_num);

            Main.db_data.image_type.Add(Image_type);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Image_type.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        //Coverage_loading();
        Stuff_loading();
    }
    #endregion

    //#region Загрузка данных с таблици Coverage, Coverage_type
    //private void Coverage_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Coverage";

    //    string sqlQuery = "SELECT coverage.id, coverage.type_id, coverage_type.type_name, coverage_type.type_name_ru, coverage.coverage_name, coverage.image_id, image.image_name " +
    //            "FROM coverage, coverage_type, image WHERE coverage.type_id = coverage_type.id AND coverage.image_id = image.id";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Coverage_Data Coverage_data = new Coverage_Data();

    //        sql_num = 0;
    //        Coverage_data.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_data.type_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_data.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_data.type_name_ru = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_data.coverage_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_data.image_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_data.image_name = sql_data.GetString(sql_num);

    //        Main.db_data.coverage_data.Add(Coverage_data.id, Coverage_data);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Coverage_data.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Coverage_type_loading();
    //}

    //private void Coverage_type_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Coverage_type";

    //    string sqlQuery = "SELECT coverage_type.id, coverage_type.type_name, coverage_type.type_name_ru FROM coverage_type";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Coverage_type_Data Coverage_type = new Coverage_type_Data();

    //        sql_num = 0;
    //        Coverage_type.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_type.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Coverage_type.type_name_ru = sql_data.GetString(sql_num);

    //        Main.db_data.coverage_type.Add(Coverage_type);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Coverage_type.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Relief_loading();
    //}
    //#endregion

    //#region Загрузка данных с таблици Relief, Relief_type
    //private void Relief_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Relief";

    //    string sqlQuery = "SELECT relief.id, relief.type_id, relief_type.type_name, relief_type.type_name_ru, relief.relief_name, relief.image_id, image.image_name FROM relief, relief_type, image " +
    //            "WHERE relief.type_id = relief_type.id AND relief.image_id = image.id";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Relief_Data Relief_data = new Relief_Data();

    //        sql_num = 0;
    //        Relief_data.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_data.type_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_data.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_data.type_name_ru = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_data.relief_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_data.image_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_data.image_name = sql_data.GetString(sql_num);

    //        Main.db_data.relief_data.Add(Relief_data.id, Relief_data);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Relief_data.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Relief_type_loading();
    //}

    //private void Relief_type_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Relief_type";

    //    string sqlQuery = "SELECT relief_type.id, relief_type.type_name, relief_type.type_name_ru FROM relief_type";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Relief_type_Data Relief_type = new Relief_type_Data();

    //        sql_num = 0;
    //        Relief_type.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_type.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Relief_type.type_name_ru = sql_data.GetString(sql_num);

    //        Main.db_data.relief_type.Add(Relief_type);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Relief_type.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Point_loading();
    //}
    //#endregion

    //#region Загрузка данных с таблици Point, Point_type
    //private void Point_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Point";

    //    string sqlQuery = "SELECT point.id, point.type_id, point_type.type_name, point_type.type_name_ru, point.point_name, point.image_id, image.image_name FROM point, point_type, image " +
    //            "WHERE point.type_id = point_type.id AND point.image_id = image.id";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Point_Data Point_data = new Point_Data();

    //        sql_num = 0;
    //        Point_data.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_data.type_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_data.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_data.type_name_ru = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_data.point_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_data.image_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_data.image_name = sql_data.GetString(sql_num);

    //        Main.db_data.point_data.Add(Point_data.id, Point_data);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Point_data.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Point_type_loading();
    //}

    //private void Point_type_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Point_type";

    //    string sqlQuery = "SELECT point_type.id, point_type.type_name, point_type.type_name_ru FROM point_type";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Point_type_Data Point_type = new Point_type_Data();

    //        sql_num = 0;
    //        Point_type.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_type.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Point_type.type_name_ru = sql_data.GetString(sql_num);

    //        Main.db_data.point_type.Add(Point_type);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Point_type.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Stuff_loading();
    //}
    //#endregion

    #region Загрузка данных с таблици Stuff, Stuff_type, Stuff_class, Stuff_abilities, Stuff_abilities_type, Stuff_abilities_class
    private void Stuff_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Stuff";

        string sqlQuery =
            "SELECT stuff.id, stuff.type_id, stuff.class_id, stuff.stuff_name, stuff.image_id, stuff.phys_damage_min, " +
            "stuff.phys_damage_max, stuff.magic_damage_min, stuff.magic_damage_max, stuff.strength_min, stuff.strength_max, " +
            "stuff.agility_min, stuff.agility_max, stuff.vitality_min, stuff.vitality_max, stuff.crit_chance_min_p," +
            "stuff.crit_chance_max_p, stuff.initiative_min, stuff.initiative_max, stuff.health_regeneration_min_p, " +
            "stuff.penetration_min_p, stuff.penetration_max_p, stuff.phys_armor_min_p, stuff.phys_armor_max_p, " +
            "stuff.magic_armor_min, stuff.magic_armor_max, stuff.health_min_p, stuff.health_max_p, stuff.evasion_min, " +
            "stuff.evasion_max, stuff.satiety_min, stuff.satiety_max, stuff.endurance_min, stuff.endurance_max, stuff.durability, " +
            "stuff.price, stuff.cooldown, stuff.duration, stuff.ability_id, stuff.description FROM stuff";


        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Stuff_Data Stuff_data = new Stuff_Data();

            sql_num = 0;
            Stuff_data.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.type_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.type_name = sql_data.GetString(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.class_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.class_name = sql_data.GetString(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.stuff_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.image_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.image_name = sql_data.GetString(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.level = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.bestiary_level_min = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.bestiary_level_max = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.experience_min = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.experience_max = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.money_min = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.money_max = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.damage_d = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.phys_damage_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.phys_damage_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.damage_bonus_min = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.damage_bonus_max = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.magic_damage_d = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.magic_damage_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.magic_damage_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.magic_damage_bonus_min = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.magic_damage_bonus_max = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.strength_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.strength_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.agility_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.agility_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.vitality_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.vitality_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.crit_chance_d = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.crit_chance_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.crit_chance_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_data.crit_chance_bonus_min = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            //Stuff_data.crit_chance_bonus_max = sql_data.GetInt32(sql_num);
            //sql_num = sql_num + 1;
            Stuff_data.crit_damage_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.crit_damage_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.initiative_d = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.initiative_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.initiative_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.initiative_bonus_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.initiative_bonus_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.health_regeneration_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.health_regeneration_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.penetration_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.penetration_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.penetration_bonus_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.penetration_bonus_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.protection_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.protection_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.protection_bonus_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.protection_bonus_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.magic_protection_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.magic_protection_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.health_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.health_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.accuracy_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.accuracy_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.lubricity_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.lubricity_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.satiety_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.satiety_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.endurance_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.endurance_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.robustness_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.robustness_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.price_min = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.price_max = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.cooldown = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.duration = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.level_improvement = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.ability_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.ability_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.ability_game_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.ability_image_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.ability_description = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_data.description = sql_data.GetString(sql_num);

            Main.db_data.stuff_data.Add(Stuff_data.id, Stuff_data);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Stuff_data.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        Stuff_type_loading();
    }

    private void Stuff_type_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Stuff_type";

        string sqlQuery = "SELECT stuff_type.id, stuff_type.type_name, stuff_type.type_name_ru FROM stuff_type";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Stuff_type_Data Stuff_type = new Stuff_type_Data();

            sql_num = 0;
            Stuff_type.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_type.type_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_type.type_name_ru = sql_data.GetString(sql_num);

            Main.db_data.stuff_type.Add(Stuff_type);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Stuff_type.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        Stuff_class_loading();
    }

    private void Stuff_class_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Stuff_class";

        string sqlQuery = "SELECT stuff_class.id, stuff_class.class_name, stuff_class.class_name_ru FROM stuff_class";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Stuff_class_Data Stuff_class = new Stuff_class_Data();

            sql_num = 0;
            Stuff_class.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_class.class_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_class.class_name_ru = sql_data.GetString(sql_num);

            Main.db_data.stuff_class.Add(Stuff_class);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Stuff_class.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        Stuff_abilities_loading();
    }

    private void Stuff_abilities_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Stuff_abilities";

        string sqlQuery = "SELECT stuff_abilities.id, stuff_abilities.type_id, stuff_abilities_type.type_name_ru, stuff_abilities.class_id, stuff_abilities_class.class_name_ru, " +
            "stuff_abilities.ability_name, stuff_abilities.game_id, stuff_abilities.image_id, stuff_abilities.cooldown, stuff_abilities.duration, stuff_abilities.description " +
            "FROM stuff_abilities , stuff_abilities_class , stuff_abilities_type " +
            "WHERE stuff_abilities.type_id = stuff_abilities_type.id AND stuff_abilities.class_id = stuff_abilities_class.id";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Stuff_abilities_Data Stuff_abilities = new Stuff_abilities_Data();

            sql_num = 0;
            Stuff_abilities.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.type_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.type_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.class_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.class_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.ability_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.game_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.image_id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_abilities.cooldown = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            //Stuff_abilities.duration = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities.description = sql_data.GetString(sql_num);

            Main.db_data.stuff_abilities.Add(Stuff_abilities.id, Stuff_abilities);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Stuff_class.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        Stuff_abilities_type_loading();
    }

    private void Stuff_abilities_type_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Stuff_abilities_type";

        string sqlQuery = "SELECT stuff_abilities_type.id, stuff_abilities_type.type_name, stuff_abilities_type.type_name_ru FROM stuff_abilities_type";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Stuff_abilities_type_Data Stuff_abilities_type = new Stuff_abilities_type_Data();

            sql_num = 0;
            Stuff_abilities_type.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities_type.type_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities_type.type_name_ru = sql_data.GetString(sql_num);

            Main.db_data.stuff_abilities_type.Add(Stuff_abilities_type);
        }
        sql_data.Close();
        sql_data = null;
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Stuff_class.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        Stuff_abilities_class_loading();
    }

    private void Stuff_abilities_class_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "Загрузка Stuff_abilities_class";

        string sqlQuery = "SELECT stuff_abilities_class.id, stuff_abilities_class.class_name, stuff_abilities_class.class_name_ru FROM stuff_abilities_class";
        sql_data = Data_Base.SQL_Query(sqlQuery);
        while (sql_data.Read())
        {
            Stuff_abilities_class_Data Stuff_abilities_class = new Stuff_abilities_class_Data();

            sql_num = 0;
            Stuff_abilities_class.id = sql_data.GetInt32(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities_class.class_name = sql_data.GetString(sql_num);
            sql_num = sql_num + 1;
            Stuff_abilities_class.class_name_ru = sql_data.GetString(sql_num);

            Main.db_data.stuff_abilities_class.Add(Stuff_abilities_class);
        }
        sql_data.Close();
        sql_data = null;
        End_loading();
        /*
        Debug.Log("----------------------------------------------------------------------------------------");
        Debug.Log(Main.Stuff_class.Count);
        Debug.Log("----------------------------------------------------------------------------------------");
        */
        //Bestiary_loading();
    }
    #endregion

    //#region Загрузка данных с таблици Bestiary, Bestiary_fight_type, Bestiary_abilities, Bestiary_abilities_type, Bestiary_abilities_type, Bestiary_abilities_class
    //private void Bestiary_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Bestiary";

    //    string sqlQuery = "SELECT bestiary.id, bestiary.map_id, bestiary.bestiary_name, bestiary.point_dungeon_id, point.point_name, bestiary.icon_image_id, bestiary.image_id, bestiary.fight_type_id, " +
    //    "bestiary_fight_type.type_name_ru, bestiary.damage_d, bestiary.phys_damage_min, bestiary.phys_damage_max, bestiary.damage_bonus_min, bestiary.damage_bonus_max, bestiary.magic_damage_d, bestiary.magic_damage_min, " +
    //    "bestiary.magic_damage_max, bestiary.magic_damage_bonus_min, bestiary.magic_damage_bonus_max, bestiary.strength_min, bestiary.strengthpower_max, bestiary.penetration_min, bestiary.penetration_max, " +
    //    "bestiary.penetration_bonus_min, bestiary.penetration_bonus_max, bestiary.protection_min, bestiary.protection_max, bestiary.magic_protection_min, bestiary.magic_protection_max, bestiary.health_min, " +
    //    "bestiary.health_max, bestiary.accuracy_min, bestiary.accuracy_max, bestiary.lubricity_min, bestiary.lubricity_max, bestiary.crit_chance_d, bestiary.crit_chance_min, bestiary.crit_chance_max, " +
    //    "bestiary.crit_chance_bonus_min, bestiary.crit_chance_bonus_max, bestiary.crit_damage_min, bestiary.crit_damage_max, bestiary.initiative_d, bestiary.initiative_min, bestiary.initiative_max, " +
    //    "bestiary.initiative_bonus_min, bestiary.initiative_bonus_max, bestiary.first_ability_proc_chance_d, bestiary.first_ability_proc_chance_min, bestiary.first_ability_proc_chance_max, " +
    //    "bestiary.first_ability_cooldown_min, bestiary.first_ability_cooldown_max, bestiary.first_ability_id, bestiary.second_ability_proc_chance_d, bestiary.second_ability_proc_chance_min, " +
    //    "bestiary.second_ability_proc_chance_max, bestiary.second_ability_cooldown_min, bestiary.second_ability_cooldown_max, bestiary.second_ability_id, bestiary.third_ability_proc_chance_d, " +
    //    "bestiary.third_ability_proc_chance_min, bestiary.third_ability_proc_chance_max, bestiary.third_ability_cooldown_min, bestiary.third_ability_cooldown_max, bestiary.third_ability_id " +
    //    "FROM bestiary , point , bestiary_fight_type " +
    //    "WHERE bestiary.point_dungeon_id = point.id AND bestiary.fight_type_id = bestiary_fight_type.id";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Bestiary_Data Bestiary_data = new Bestiary_Data();

    //        sql_num = 0;		
    //        Bestiary_data.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.map_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.bestiary_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.point_dungeon_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.point_dungeon_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.icon_image_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.image_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.fight_type_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.fight_type = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.damage_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.phys_damage_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.phys_damage_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.damage_bonus_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.damage_bonus_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_damage_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_damage_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_damage_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_damage_bonus_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_damage_bonus_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.strength_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.strengthpower_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.penetration_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.penetration_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.penetration_bonus_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.penetration_bonus_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.protection_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.protection_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_protection_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.magic_protection_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.health_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.health_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.accuracy_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.accuracy_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.lubricity_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.lubricity_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_chance_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_chance_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_chance_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_chance_bonus_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_chance_bonus_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_damage_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.crit_damage_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.initiative_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.initiative_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.initiative_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.initiative_bonus_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.initiative_bonus_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.first_ability_proc_chance_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.first_ability_proc_chance_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.first_ability_proc_chance_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.first_ability_cooldown_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.first_ability_cooldown_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.first_ability_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.second_ability_proc_chance_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.second_ability_proc_chance_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.second_ability_proc_chance_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.second_ability_cooldown_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.second_ability_cooldown_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.second_ability_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.third_ability_proc_chance_d = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.third_ability_proc_chance_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.third_ability_proc_chance_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.third_ability_cooldown_min = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.third_ability_cooldown_max = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_data.third_ability_id = sql_data.GetInt32(sql_num);

    //        Main.db_data.bestiary_data.Add(Bestiary_data.id, Bestiary_data);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Stuff_class.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Bestiary_fight_type_loading();
    //}

    //private void Bestiary_fight_type_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка bestiary_fight_type";

    //    string sqlQuery = "SELECT bestiary_fight_type.id, bestiary_fight_type.type_name, bestiary_fight_type.type_name_ru FROM bestiary_fight_type";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Bestiary_fight_type_Data Bestiary_fight_type = new Bestiary_fight_type_Data();

    //        sql_num = 0;
    //        Bestiary_fight_type.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_fight_type.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_fight_type.type_name_ru = sql_data.GetString(sql_num);

    //        Main.db_data.bestiary_fight_type.Add(Bestiary_fight_type);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Stuff_class.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Bestiary_abilities_loading();
    //}

    //private void Bestiary_abilities_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Bestiary_abilities";

    //    string sqlQuery = "SELECT bestiary_abilities.id, bestiary_abilities.type_id, bestiary_abilities_type.type_name_ru, bestiary_abilities.class_id, bestiary_abilities_class.class_name_ru, " +
    //        "bestiary_abilities.ability_name, bestiary_abilities.game_id, bestiary_abilities.image_id, bestiary_abilities.cooldown, bestiary_abilities.duration,  bestiary_abilities.description " + 
    //        "FROM bestiary_abilities , bestiary_abilities_class , bestiary_abilities_type " +
    //        "WHERE bestiary_abilities.type_id = bestiary_abilities_type.id AND bestiary_abilities.class_id = bestiary_abilities_class.id";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Bestiary_abilities_Data Bestiary_abilities = new Bestiary_abilities_Data();

    //        sql_num = 0;
    //        Bestiary_abilities.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.type_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.class_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.class_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.ability_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.game_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.image_id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.cooldown = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.duration = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities.description = sql_data.GetString(sql_num);

    //        Main.db_data.bestiary_abilities.Add(Bestiary_abilities.id, Bestiary_abilities);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Stuff_class.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Bestiary_abilities_type_loading();
    //}

    //private void Bestiary_abilities_type_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Bestiary_abilities_type";

    //    string sqlQuery = "SELECT bestiary_abilities_type.id, bestiary_abilities_type.type_name, bestiary_abilities_type.type_name_ru FROM bestiary_abilities_type";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Bestiary_abilities_type_Data Bestiary_abilities_type = new Bestiary_abilities_type_Data();

    //        sql_num = 0;
    //        Bestiary_abilities_type.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities_type.type_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities_type.type_name_ru = sql_data.GetString(sql_num);

    //        Main.db_data.bestiary_abilities_type.Add(Bestiary_abilities_type);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Stuff_class.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    Bestiary_abilities_class_loading();
    //}

    //private void Bestiary_abilities_class_loading()
    //{
    //    mask_bar_size_step_num = mask_bar_size_step_num + 1;
    //    mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

    //    loading_text.text = "Загрузка Bestiary_abilities_class";

    //    string sqlQuery = "SELECT bestiary_abilities_class.id, bestiary_abilities_class.class_name, bestiary_abilities_class.class_name_ru FROM bestiary_abilities_class";
    //    sql_data = Data_Base.SQL_Query(sqlQuery);
    //    while (sql_data.Read())
    //    {
    //        Bestiary_abilities_class_Data Bestiary_abilities_class = new Bestiary_abilities_class_Data();

    //        sql_num = 0;
    //        Bestiary_abilities_class.id = sql_data.GetInt32(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities_class.class_name = sql_data.GetString(sql_num);
    //        sql_num = sql_num + 1;
    //        Bestiary_abilities_class.class_name_ru = sql_data.GetString(sql_num);

    //        Main.db_data.bestiary_abilities_class.Add(Bestiary_abilities_class);
    //    }
    //    sql_data.Close();
    //    sql_data = null;
    //    /*
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    Debug.Log(Main.Stuff_class.Count);
    //    Debug.Log("----------------------------------------------------------------------------------------");
    //    */
    //    End_loading();
    //}
    //#endregion

    private void End_loading()
    {
        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //loading_text.text = "End Загрузки";

        Data_Base.Connection_close();

        mask_bar_size_step_num = mask_bar_size_step_num + 1;
        //mask_progress_bar.GetComponent<RectTransform>().sizeDelta = new Vector2((mask_bar_size_step_num * mask_bar_size_step), mask_progress_bar.GetComponent<RectTransform>().sizeDelta.y);

        //switch (Main.action_name)
        //{
        //    case "new_map":
        //        Debug.Log("Открыть окно '\"'New_map'\"'");
        //        SceneManager.LoadScene("4_New_map");
        //        break;
        //    case "loading_map":
        //        Debug.Log("Открыть окно '\"'Loading_map'\"'");
        //        break;
        //}
    }
}