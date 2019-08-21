using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NPC/Create New NPC Brain")]
public class NPCBrain : ScriptableObject // An NPC Brain manages all action an NPC will do
{
    public NPCAction normalAction;
    public NPCAction investigationAction;
    public NPCAction searchAction;
    public NPCAction fightAction;

    public void UpdateState(NPC npc)
    {
        switch(npc.alertLevel)
        {
            case MyEnum.AlertLevel.Normal :
                normalAction.Do(npc);
            break;
            case MyEnum.AlertLevel.Investigation :
                investigationAction.Do(npc);
            break;
            case MyEnum.AlertLevel.Search :
                searchAction.Do(npc);
            break;
            case MyEnum.AlertLevel.Fight :
                fightAction.Do(npc);
            break;
        }
    }
}
