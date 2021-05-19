using UnityEngine;
using System.Collections;

public class tutSpace : MonoBehaviour
{

    public GameObject text; // Assign in inspector

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            text.SetActive(false);
        }
    }
}