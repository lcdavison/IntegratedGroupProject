using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "Conversation/Script", fileName = "new_script" )]
public class ConversationScript : ScriptableObject
{
    [Multiline]
    public string [ ] segments = new string [ 5 ];
}
