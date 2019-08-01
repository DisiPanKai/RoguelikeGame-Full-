using System.Collections.Generic;

public class Data_DB
{
    public int map_list_count;
    public Dictionary<int, Map_list_Data> map_list = new Dictionary<int, Map_list_Data>(); // Таблица "map". Данные которые загружаютсья с базы данных.

    public int image_count;
    public Dictionary<int, Image_Data> image_data = new Dictionary<int, Image_Data>(); // Таблица "image". Данные которые загружаютсья с базы данных.
    public List<Image_type_Data> image_type = new List<Image_type_Data>(); // Таблица "image_type". Данные которые загружаютсья с базы данных.

    public Dictionary<int, Coverage_Data> coverage_data = new Dictionary<int, Coverage_Data>(); // Таблица "coverage". Данные которые загружаютсья с базы данных.
    public List<Coverage_type_Data> coverage_type = new List<Coverage_type_Data>(); // Таблица "coverage_type". Данные которые загружаютсья с базы данных.

    public Dictionary<int, Relief_Data> relief_data = new Dictionary<int, Relief_Data>(); // Таблица "relief". Данные которые загружаютсья с базы данных.
    public List<Relief_type_Data> relief_type = new List<Relief_type_Data>(); // Таблица "relief_type". Данные которые загружаютсья с базы данных.

    public Dictionary<int, Point_Data> point_data = new Dictionary<int, Point_Data>(); // Таблица "point". Данные которые загружаютсья с базы данных.
    public List<Point_type_Data> point_type = new List<Point_type_Data>(); // Таблица "point_type". Данные которые загружаютсья с базы данных.

    public Dictionary<int, Stuff_Data> stuff_data = new Dictionary<int, Stuff_Data>(); // Таблица "stuff". Данные которые загружаютсья с базы данных.
    public List<Stuff_type_Data> stuff_type = new List<Stuff_type_Data>(); // Таблица "stuff_type". Данные которые загружаютсья с базы данных.
    public List<Stuff_class_Data> stuff_class = new List<Stuff_class_Data>(); // Таблица "stuff_class". Данные которые загружаютсья с базы данных.
    public Dictionary<int, Stuff_abilities_Data> stuff_abilities = new Dictionary<int, Stuff_abilities_Data>(); // Таблица "stuff_abilities". Данные которые загружаютсья с базы данных.
    public List<Stuff_abilities_type_Data> stuff_abilities_type = new List<Stuff_abilities_type_Data>(); // Таблица "stuff_abilities_type". Данные которые загружаютсья с базы данных.
    public List<Stuff_abilities_class_Data> stuff_abilities_class = new List<Stuff_abilities_class_Data>(); // Таблица "stuff_abilities_class". Данные которые загружаютсья с базы данных.

    public Dictionary<int, Bestiary_Data> bestiary_data = new Dictionary<int, Bestiary_Data>(); // Таблица "bestiary". Данные которые загружаютсья с базы данных.
    public List<Bestiary_fight_type_Data> bestiary_fight_type = new List<Bestiary_fight_type_Data>(); // Таблица "bestiary_fight_type". Данные которые загружаютсья с базы данных.
    public Dictionary<int, Bestiary_abilities_Data> bestiary_abilities = new Dictionary<int, Bestiary_abilities_Data>(); // Таблица "bestiary_abilities". Данные которые загружаютсья с базы данных.
    public List<Bestiary_abilities_type_Data> bestiary_abilities_type = new List<Bestiary_abilities_type_Data>(); // Таблица "bestiary_abilities_type". Данные которые загружаютсья с базы данных.
    public List<Bestiary_abilities_class_Data> bestiary_abilities_class = new List<Bestiary_abilities_class_Data>(); // Таблица "bestiary_abilities_class". Данные которые загружаютсья с базы данных.
}
