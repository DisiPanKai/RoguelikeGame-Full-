

public static class PlayerEquipmentStats
{
    public static int[] InventoryEquip = new int[8]; //весь инвентарь в одном массиве. Возможно, будет не нужно

    public static int RightWeaponLvl; //уровень оружия
    public static int RightWeaponMinDmg; //сколько раз нужно кидать кубик
    public static int RightWeaponMaxDmg; //максимальный урон для пушки
    public static int RightWeaponAddDmgPercent;
    public static int RightWeaponAddDmg;

    public static int LeftWeaponLvl; //уровень оружия
    public static int LeftWeaponMinDmg; //сколько раз нужно кидать кубик
    public static int LeftWeaponMaxDmg; //максимальный урон для пушки
    public static int LeftWeaponAddDmgPercent;
    public static int LeftWeaponAddDmg;

    public static int LeftShieldBonus; //сколько даёт защиты щит
    public static int LeftShieldPercent; //сколько даёт защиты щит
    public static bool LeftShield; //переменная для определения, есть ли вообще на игроке щит. Переменная здесь потому, что дебаффы убирают бонус защиты от щита(в игре игрок не может носить щит). 
    //Так легче понимать, есть ли вообще щит у игрока, даже если мы убрали бонусы. 
    //Ранее, всё в коде отталкивалось от бонусов, но как только бонус защиты убирался, то становилось непонятно, есть ли у игрока щит вообще, или нету.

    public static int HelmetPercent;
    public static int HelmetArmor;

    public static int BodyPercent;
    public static int BodyArmor;
    public static int GlovesPercent;
    public static int GlovesArmor;
    public static int BootsPercent;
    public static int BootsArmor;


    public static int MagDef; //маг защита от лёгкой брони
    public static int Penetration; //пробиваемость с тяжёлой брони
    public static int Health; //хп с тяжёлой брони
    public static int Accuracy; //точность с перчаток
    public static int EvasionPercent; //уворот с башмаков и лёгкой брони
    public static int Initiative;
    public static int PhysCritChance;
    public static int MagCritChance;

}
