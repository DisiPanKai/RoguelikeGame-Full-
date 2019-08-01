using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

using System.Xml;

public class Main : MonoBehaviour
{
    static Main Instance;

    public static Font my_font; // шрифт который используеться во всем проекте

    public static int stage_w = 1360; // разрешение экрана ( ширина )
    public static int stage_h = 768; // разрешение экрана ( высота )

    public static Dictionary<string, Sprite> Image_list = new Dictionary<string, Sprite>();

    public static int test_num = 0;

    public static float scale_cell = 1.0f;

    public static Data_DB db_data = new Data_DB(); // хранилище для данных полученых с БД путем запросов. 

    //public static Dictionary<string, Map_info_Data> Map_info = new Dictionary<string, Map_info_Data>(); // Хранит все данные о каждой редактируемой карте.
    /*
    public static int coverage_id;// для редактора
    public static int relief_id;// для редактора
    public static int point_id; // для редактора

    public static int dungeons_id; // подзимельн . для редактора
    */

    public static int coverage;
    //public static Cell_relief_Data relief = new Cell_relief_Data();
    //public static Point_item_Data stuff = new Point_item_Data();

    public static string action_edit;
    public static string action_name; // тип действия которое сейчас выполняеться . для редактора

    //public static Dictionary<string, Cell_relief_Data> custom_relief_list = new Dictionary<string, Cell_relief_Data>();
    //public static Dictionary<string, Point_item_Data> custom_stuff_list = new Dictionary<string, Point_item_Data>();

    // Use this for initialization
    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}