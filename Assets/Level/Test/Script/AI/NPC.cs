using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class NPC : Humanoid // Well ... It's a NPC, you can create NPC classes inheriting from this class to add more attributes and methods :)
{
    public GameObject target; // The target of the NPC, it can be a Person to kill/stop or an object to get/protect;
    [HideInInspector] public Vector3 lastKnownLocation; // The lastKnownLocation is the place the NPC will be heading to, it can be a person but it can also be a position (For example a WayPoint for a patrolling guard)

    public List<int> alliedGroups; // The groups allied with the NPC group (Example: Policemen and Security Guards, or two armies with the same enemy)
    public List<int> unknownGroups; // The groups the NPC will no really interact with (Security and Citizen for example)
    public List<int> enemyGroups; // The groups the NPC will attack at sight (Two rival gang or two fighting armies), it can also depends on the location of the persons
    public List<GameObject> enemies; // A list of defined enemies (if the NPC spot a double-agent in his own group for example)

    [HideInInspector] public MyEnum.AlertLevel alertLevel; // The alert level of the NPC

    public NPCBrain brain; // The brain of the NPC
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Humanoid[] listHumanoid;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        navMeshAgent = GetComponent<NavMeshAgent>();
        alertLevel = MyEnum.AlertLevel.Normal;
        listHumanoid = FindObjectsOfType<Humanoid>();
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();

        brain.UpdateState(this);
    }
}
