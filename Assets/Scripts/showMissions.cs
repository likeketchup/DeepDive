using UnityEngine;
using System.Collections;

public class showMissions : MonoBehaviour
{

    public GameObject menu; // Assign in inspector
    public GameObject quitButton;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            menu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else if (Input.GetKey(KeyCode.Escape))
        {
            quitButton.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            menu.SetActive(false);
            quitButton.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}