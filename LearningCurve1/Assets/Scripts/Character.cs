using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    public Character()
    {
        name = "Not assigned";
    }

    public Character(string name)
    {
        this.name = name;
    }

    public virtual void PrintStatInfo()
    {
        Debug.LogFormat("Hero: {0} - {1} Exp", name, exp);
    }

}

public struct Weapon
{
    public string name;
    public int damage;
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
    public void PrintWeaponStat()
    {
        Debug.LogFormat("Weapon: {0} - {1} DMB", name, damage);
    }
}
