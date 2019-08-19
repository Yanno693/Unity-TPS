﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Humanoid // Well ... It's a NPC
{
    public GameObject target; // The target of the NPC, it can be a Person to kill/stop or an object to get/protect;
    public Vector3 lastKnownLocation; // The lastKnownLocation is the place the NPC will be heading to, it can be a person but it can also be a position (For example a WayPoint for a patrolling guard)

    public List<int> alliedGroups; // The groups allied with the NPC group (Example: Policemen and Security Guards, or tho armies with the same enemy)
    public List<int> unknownGroups; // The groups the NPC will no really interact with (Security and Citizen for example)
    public List<int> enemyGroups; // The group the NPC will attack at sight (Two rival gang or two fighting armies), it can also depends on the location of the persons
    public List<GameObject> enemies; // A list of defined enemies (if the NPC spot a double-agent in his own group for example)

    public MyEnum.AlertLevel alertLevel; // The alert level of the NPC

    public NPCBrain brain;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        alertLevel = MyEnum.AlertLevel.Normal;

        //brain.StartState(this);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        brain.UpdateState(this);
    }
}
