using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static string name = " ";
    public static int playerHp = 3;
    public static int cans = 0;
    public static int superPower = 0;
    public static bool isInvisible = false;
    public static AudioClip tpClip;
    public static void StatReset()
    {
        name = "";
        playerHp = 3;
        cans = 0;
        superPower = 0;
        isInvisible = false;
    }

    public static void GetDamage(int damage)
    {
        playerHp -= damage;
        UIUpdate.instance.SetHp(playerHp);
    }
}
