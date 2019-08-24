using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (menuName = "NPC/Actions/Test/NavMeshTestNormalAction")]
public class NavMeshTestNormalAction : NPCAction
{
    override public void Do(NPC npc)
    {
        NavMeshTestNPC cast = (NavMeshTestNPC)npc;

        // Waiting Action
        if(cast.status == NavMeshTestNPC.STATUS_WAIT)
        {
            cast.waitTime += Time.deltaTime;

            if(cast.waitTime >= 3.0f)
            {
                Random rand = new Random();
                int randint = (int)Random.Range(0,cast.wayPoints.collection.Length);

                cast.lastKnownLocation = cast.wayPoints.collection[randint];
                cast.navMeshAgent.SetDestination(cast.lastKnownLocation);

                cast.status = NavMeshTestNPC.STATUS_PATROL;
            }
        }

        // Moving action
        if(cast.status == NavMeshTestNPC.STATUS_PATROL)
            if(!cast.navMeshAgent.pathPending)
                if(cast.navMeshAgent.remainingDistance <= cast.navMeshAgent.stoppingDistance)
                {
                    cast.waitTime = 0.0f;
                    cast.status = NavMeshTestNPC.STATUS_WAIT;
                }

        //Field Of View Operation()
        foreach (Humanoid h in cast.listHumanoid)
        {
            if(h.gameObject != cast.gameObject) // The NPC seeing has to be excluded
            {
                Vector3 direction = h.transform.position - cast.transform.position;
                float viewCheck = Vector3.Angle(h.transform.position - cast.transform.position, cast.transform.forward);
                if(viewCheck <= cast.fov * 0.5f) // if there is a person in the field of view
                {
                    RaycastHit hit;
                    if(Physics.Raycast(cast.transform.position, direction.normalized, out hit, 30f))
                    {
                        if(hit.collider.gameObject == h.gameObject)
                        {
                            if(cast.enemyGroups.Contains(h.group))
                            {
                                Debug.Log("ENEMY !!!");
                                cast.target = h.gameObject;
                                cast.lastKnownLocation = cast.target.transform.position;
                                cast.alertLevel = MyEnum.AlertLevel.Fight;
                            }
                        }
                    }
                }
            }
        }
    }
}
