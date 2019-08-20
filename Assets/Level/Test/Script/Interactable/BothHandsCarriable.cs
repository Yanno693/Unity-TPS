using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BothHandsCarriable : Carriable // A Carriable objet that needs both hands, like a rifle, or a box
{
    public abstract void SecondaryInteract(Humanoid humanoid);
}
