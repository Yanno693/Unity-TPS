using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTestNPC : NPC
{
    public static readonly int STATUS_PATROL = 1;
    public static readonly int STATUS_WAIT = 2;
    
    public WayPointCollection wayPoints;
    [HideInInspector] public float waitTime;
    [HideInInspector] public int status;

    public float fov;
    
    new protected void Start()
    {
        base.Start();
        this.group = 1;
        this.alliedGroups.Add(1);
        this.enemyGroups.Add(2);
        waitTime = 0.0f;
        status = STATUS_WAIT;
        fov = 60f;

        Gizmos.color = Color.red;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,10,110,110),navMeshAgent.velocity.ToString());
        GUI.Label(new Rect(110,10,210,110),waitTime.ToString());
        GUI.Label(new Rect(210,10,310,110),navMeshAgent.remainingDistance.ToString());
    }

    /*void OnDrawGizmos()
    {
        foreach(Vector3 v in wayPoints.collection)
            Gizmos.DrawWireSphere(v,0.5f);
    }*/
    
    override protected void UseBothHandsObjectSecondary()
    {
    }
}
