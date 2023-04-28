using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float BaseHealth { get; set; }
    public float BaseAttack { get; set; }
    public float BaseDefense { get; set; }
    public float BaseSpecialAttack { get; set; }
    public float BaseSpecialDefense{ get; set; }
    public float BaseSpeed { get; set; }

    public override string ToString()
    {
        string toString = string.Format("Id: {0}\nName: {1}\nDescription: {2}\nHealth: {3}\nAttack: {4}\nDefense: {5}\n" +
            "Special Attack: {6}\nSpecial Defense: {7}\nSpeed: {8}",
            Id, Name, Description, BaseHealth, BaseAttack, BaseDefense, BaseSpecialAttack, BaseSpecialDefense,
            BaseSpeed);
        return toString;
    }
}
