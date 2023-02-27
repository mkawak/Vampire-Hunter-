using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCharacter controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.ChangeExperience(1);
            Debug.Log("Object that entered the trigger : " + other);
            Destroy(gameObject);
        }
    }
}
