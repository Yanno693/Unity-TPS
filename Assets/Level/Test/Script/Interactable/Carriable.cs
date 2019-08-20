using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Carriable : MonoBehaviour // An objet that can be held/carried, like a weapon, a phone, or a snack
{
    public bool hideable; // Can the object being put in the inventory
    
    public abstract void Interact(Humanoid humanoid);

}
