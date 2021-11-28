using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats.GetDamage(1);
            Destroy(gameObject, 0.5f);
            // placeholder na dzwiek
        }
    }


}
