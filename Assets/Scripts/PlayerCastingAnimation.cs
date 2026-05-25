using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCastingAnimation : MonoBehaviour
{
    // variables
    public UnityEvent castingMagic; // stores a unity event that takes place when the player casts magic

    // Start is called before the first frame update
    public void castingSpell()
    {
        castingMagic.Invoke();
    } // end of castingSpell

} // end of class
