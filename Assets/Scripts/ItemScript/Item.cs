using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string _name;
    public int value;
    public Sprite icon;
    public ItemType type;
    
    public enum ItemType
    {
        MagicRock,
        Potion,
        Gemme
    }
}
