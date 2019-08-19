using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NPC/Actions/moveAction")]
public class moveAction : NPCAction // It's just a test
{
    override public void Do(NPC npc)
    {
        npc.transform.Translate(Time.deltaTime,0,0);
    }
}
