using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Rotater : MonoBehaviour
{
    public int roomNum;

    void Update()
    {
        transform.Find("Body").transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime/2);
    }
}