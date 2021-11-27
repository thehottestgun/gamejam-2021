using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats.playerHp++;

            UIUpdate.instance.SetHp(PlayerStats.playerHp);
            // placeholder na dzwiek
            Destroy(gameObject, 0.2f);
        }
    }
}
