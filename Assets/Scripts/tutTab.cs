using UnityEngine;
using System.Collections;

public class tutTab : MonoBehaviour
{

    public GameObject text; // Assign in inspector

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            text.SetActive(false);
        } 
    }
}