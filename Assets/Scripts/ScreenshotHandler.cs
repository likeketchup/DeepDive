using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenshotHandler : MonoBehaviour
{

    private Camera cam;
    int resWidth = 256;
    int resHeight = 256;


    private void Awake()
    {
        cam = GetComponent<Camera>();
        if (cam.targetTexture == null)
        {
            cam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = cam.targetTexture.width;
            resHeight = cam.targetTexture.height;
        }
        cam.gameObject.SetActive(false);
    }

    public void CallTakeSnapshot()
    {
        cam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (cam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            cam.Render();
            RenderTexture.active = cam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapshotName();
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log("Snapshot taken!");
            cam.gameObject.SetActive(false);
        }
    }

    string SnapshotName()
    {
        return string.Format("{0}/snapshots/snap_{1}x{2}_{3}.png", Application.dataPath, resWidth, resHeight,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
