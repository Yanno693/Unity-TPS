using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCAction : ScriptableObject // An abstract void for an NPC routine, create a class implementing NPCAction, override the Do() method and write some stuff !
{
    public abstract void Do(NPC npc);
}
