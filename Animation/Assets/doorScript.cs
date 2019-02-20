using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public int firstRoomPickup;
    public int secondRoomPickup;
    public int thirdRoomPickup;

    private bool sent = false;
    public GameObject canvases;
    // Update is called once per frame
    void Update()
    {
        if (firstRoomPickup == 0)
        {
            transform.Find("Door1").GetComponentInChildren<Animator>().enabled = true;
        }
        if (secondRoomPickup == 0)
        {
            transform.Find("Door2").GetComponentInChildren<Animator>().enabled = true;
        }
        if (thirdRoomPickup == 0)
        {
            if(sent == false)
            {
                canvases.GetComponent<Canvas_Controll>().gameEnd();
                sent = true;
            }

        }
    }
}
