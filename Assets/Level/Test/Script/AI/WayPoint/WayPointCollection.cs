using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NPC/Create WayPoints Collection")]
public class WayPointCollection : ScriptableObject
{
    public Vector3[] collection;
}
