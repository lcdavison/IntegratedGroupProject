using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Help/HelpInfo", fileName = "help")]
public class HelpObject : ScriptableObject
{
    [Multiline]
    public string help_information;
}
