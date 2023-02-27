using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3_BasicAttack_Collider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        transform.parent.GetComponent<Player3_BasicAttack_Projectile>().Found(other);
    }
}
