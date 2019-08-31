using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NPC/Create WayPoints Collection")]
public class WayPointCollection : ScriptableObject // A collection a WayPoints for NPC's
{
    public Vector3[] collection;
}
