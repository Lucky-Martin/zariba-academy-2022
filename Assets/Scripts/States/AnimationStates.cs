using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationStates
{
    Walk,
    Run,
    Attack,
    CarryWood,
    CarryWoodAttack,
    CarryBag,
    CarryBagAttack,
    Attacking, // for the zombie attacks not to mess with the player attacks idk
    Search, // there was a search in the enemy so not to touch it
    Death
}