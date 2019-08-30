using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour // Represents an interactable object on the game (like a door, a light switch, or something like that)
{
    public abstract void Interact(Humanoid humanoid);
}
