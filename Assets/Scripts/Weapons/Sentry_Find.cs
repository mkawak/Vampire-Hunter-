using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Find : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        transform.parent.GetComponent<Sentry>().ChildTrigger(other);
    }
}
