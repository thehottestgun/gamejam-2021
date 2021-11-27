using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerData.cans++;
            UIUpdate.instance.SetCans(PlayerData.cans);
            Destroy(gameObject);
        }
    }
}
