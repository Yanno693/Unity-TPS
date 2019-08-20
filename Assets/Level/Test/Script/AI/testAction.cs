using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NPC/Actions/testAction")]
public class testAction : NPCAction // It's just a test
{
    public override void Do(NPC npc)
    {
        npc.transform.Translate(Time.deltaTime,0,0);

        //if(npc is SomethingNPC)
    }
}
