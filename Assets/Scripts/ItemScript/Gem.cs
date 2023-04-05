using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/GemItem")]
public class Gem : ScriptableObject
{
    #region Expose
    public string _name;
    public int value;
    public Sprite icon;
    #endregion
}
