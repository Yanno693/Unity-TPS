using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Carriable : MonoBehaviour // An objet that can be held/carried, like a weapon, a phone, or a snack
{
    public bool hideable; // Can the object be put in the inventory
    [HideInInspector] public bool carried; // Is the object carried by someone
    
    public abstract void Interact(Humanoid humanoid);

}
