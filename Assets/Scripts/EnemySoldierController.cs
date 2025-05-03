using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierController : MonoBehaviour
{
    [SerializeField]
    GameObject soldier;

    private SpriteRenderer soldierSR;

    private void Awake()
    {
        soldierSR = soldier.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }
   
    private void Flip()
    {
        
    }
}
