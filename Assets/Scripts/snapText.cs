using UnityEngine;
using System.Collections;

public class snapText : MonoBehaviour
{

    public GameObject text; // Assign in inspector
    void Start()
    {
        text.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            text.SetActive(true);
            Invoke("DisableText", 2f);
        }
    }
    void DisableText()
    {
        text.SetActive(false);
    }
}