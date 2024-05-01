using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyScript : MonoBehaviour
{

    public Rigidbody monsRigid;
    public Transform monsTrans;
    public Transform playTrans;

    public int monsSpeed;

    public float detectionRange = 10f;


    private bool isPlayerLooking = false;
    private float lookTimer = 0f;
    private float teleportCooldown = 2f;
    private Vector3 teleportDestination;


    private void FixedUpdate()
    {
        monsRigid.velocity = transform.forward * monsSpeed * Time.deltaTime;
    }

    private void Update()
    {
        monsTrans.LookAt(playTrans);

        
        float distanceToPlayer = Vector3.Distance(monsTrans.position, playTrans.position);
        if (distanceToPlayer <= detectionRange)
        {
            
            if (IsPlayerLookingAtMonster())
            {
                lookTimer += Time.deltaTime;
                if (lookTimer >= teleportCooldown)
                {
                    TeleportMonster();
                    lookTimer = 0f;
                }
            }
            else
            {
                lookTimer = 0f;
            }
        }
        else
        {
            lookTimer = 0f;
        }
    }

    private bool IsPlayerLookingAtMonster()
    {
        Vector3 directionToMonster = monsTrans.position - playTrans.position;
        float angle = Vector3.Angle(playTrans.forward, directionToMonster);
        return angle < 45f;
    }

    private void TeleportMonster()
    {
        float randomX = Random.Range(-10f, 10f); 
        float randomZ = Random.Range(-10f, 10f);
        teleportDestination = new Vector3(randomX, 0f, randomZ);

        monsTrans.position = teleportDestination;
    }
}
