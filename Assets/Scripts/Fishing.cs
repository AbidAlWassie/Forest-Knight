using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    Fishing fishingStage;
    Animator animator;
    public bool act = false;
    float strength = 0f;
    bool canMove;

    private void Update()
    {
        if (CanMove() == false ) { return; }
    }
    
    Fishing fishing;
    bool CanMove()
    {
        if(fishing.CanMove() == false) { return false; }
        return true;
    }
}
