using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPower : MonoBehaviour
{
    // Start is called before the first frame update
    public int superPowerNumber;
    void Start()
    {
        PlayerStats.superPower = superPowerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
