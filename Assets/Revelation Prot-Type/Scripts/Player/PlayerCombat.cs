using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Player controls;

    void Awake()
    {
        //controls = new Player();
        //controls.Gameplay.Up.performed += ctx => Attack();
    }

    void Attack()
    {
        Debug.Log("Works!");
    }
}
