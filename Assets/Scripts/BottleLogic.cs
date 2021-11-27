using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats.playerHp--;
            UIUpdate.instance.SetHp(PlayerStats.playerHp);
            // placeholder na dzwiek
            Destroy(gameObject, 0.5f);
        }
    }


}
