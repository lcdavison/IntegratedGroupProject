using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Buildings/Building", fileName = "new_building")]
public class Building : ScriptableObject
{
    public int id = 0;
    public string name = "";
    public string scene = "";
    public Sprite sprite = null;
}
