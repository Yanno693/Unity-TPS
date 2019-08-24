using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (menuName = "NPC/Actions/Test/NavMeshTestFightAction")]
public class NavMeshTestFightAction : NPCAction
{
    private float visibleClock = 0.0f;
    
    override public void Do(NPC npc)
    {
        NavMeshTestNPC cast = (NavMeshTestNPC)npc;

        Vector3 direction = cast.target.transform.position - cast.transform.position;
        RaycastHit hit;
        if(Physics.Raycast(cast.transform.position, direction, out hit, 30f))
        {
            if(hit.collider.gameObject == cast.target)
            {
                cast.lastKnownLocation = cast.target.transform.position;
                visibleClock = 0f;

                if(!cast.navMeshAgent.pathPending)
                    cast.navMeshAgent.SetDestination(cast.lastKnownLocation);
            }
        }

        if(visibleClock > 5.0f)
        {
            cast.target = null;
            cast.alertLevel = MyEnum.AlertLevel.Normal;
        }
        
        visibleClock += Time.deltaTime;
    }
}
