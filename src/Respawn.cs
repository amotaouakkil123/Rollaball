using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Transform Player;
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other) {
       if (other.gameObject.tag =="Player") {
        Player.transform.position = respawnPoint.transform.position; 
    } }
        
    }