using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class detectSubject : MonoBehaviour
{
    // Public Vars
    public Camera cam;
    public Text obj1Text;
    public Text obj2Text;
    public Text obj3Text;
    public Text obj4Text;
    public Text obj5Text;
    public Text obj6Text;
    public Text obj7Text;
    public Text obj8Text;
    public Text obj9Text;
    public Text obj10Text;
    // Tracking Arrays
    private GameObject[] sub1Ob;
    private Renderer[] sub1R;
    private GameObject[] sub2Ob;
    private Renderer[] sub2R;
    private GameObject[] sub3Ob;
    private Renderer[] sub3R;
    private GameObject[] sub4Ob;
    private Renderer[] sub4R;
    private GameObject[] sub5Ob;
    private Renderer[] sub5R;
    private GameObject[] sub6Ob;
    private Renderer[] sub6R;
    private GameObject[] sub7Ob;
    private Renderer[] sub7R;
    private GameObject[] sub8Ob;
    private Renderer[] sub8R;
    private GameObject[] sub9Ob;
    private Renderer[] sub9R;
    private GameObject[] sub10Ob;
    private Renderer[] sub10R;



    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        updateUIText(sub1R, obj1Text);
        updateUIText(sub2R, obj2Text);
        updateUIText(sub3R, obj3Text);
        updateUIText(sub4R, obj4Text);
        updateUIText(sub5R, obj5Text);
        updateUIText(sub6R, obj6Text);
        updateUIText(sub7R, obj7Text);
        updateUIText(sub8R, obj8Text);
        updateUIText(sub9R, obj9Text);
        updateUIText(sub10R, obj10Text);
    }

    void updateUIText(Renderer[] subjectArray, Text subTxt)
    {
        if(subjectArray == null){
            return;
        }
        for (int i = 0; i < subjectArray.Length; i++)
        {
            if (subjectArray[i] != null && subjectArray[i].isVisible && Input.GetKey(KeyCode.Space))
            {
                float dist = Vector3.Distance(subjectArray[i].bounds.center, cam.transform.position);
                if (dist <= 350)
                {
                    Debug.Log("Subject in view and has a range of " + dist);
                    subTxt.text = "Captured";
                }
                
            }
        }
    }

    IEnumerator waiter()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Searching Through 10 Objectives
        sub1Ob = GameObject.FindGameObjectsWithTag("obj1");
        sub1R = new Renderer[sub1Ob.Length];
        for (int i = 0; i < sub1Ob.Length; i++)
        {
            Renderer r = sub1Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub1R[i] = r;
            }
        }

        sub2Ob = GameObject.FindGameObjectsWithTag("obj2");
        sub2R = new Renderer[sub2Ob.Length];
        for (int i = 0; i < sub2Ob.Length; i++)
        {
            Renderer r = sub2Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub2R[i] = r;
            }
        }

        sub3Ob = GameObject.FindGameObjectsWithTag("obj3");
        sub3R = new Renderer[sub3Ob.Length];
        for (int i = 0; i < sub3Ob.Length; i++)
        {
            Renderer r = sub3Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub3R[i] = r;
            }
        }

        sub4Ob = GameObject.FindGameObjectsWithTag("obj4");
        sub4R = new Renderer[sub4Ob.Length];
        for (int i = 0; i < sub4Ob.Length; i++)
        {
            Renderer r = sub4Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub4R[i] = r;
            }
        }

        sub5Ob = GameObject.FindGameObjectsWithTag("obj5");
        sub5R = new Renderer[sub5Ob.Length];
        for (int i = 0; i < sub5Ob.Length; i++)
        {
            Renderer r = sub5Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub5R[i] = r;
            }
        }

        sub6Ob = GameObject.FindGameObjectsWithTag("obj6");
        sub6R = new Renderer[sub6Ob.Length];
        for (int i = 0; i < sub6Ob.Length; i++)
        {
            Renderer r = sub6Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub6R[i] = r;
            }
        }

        sub7Ob = GameObject.FindGameObjectsWithTag("obj7");
        sub7R = new Renderer[sub7Ob.Length];
        for (int i = 0; i < sub7Ob.Length; i++)
        {
            Renderer r = sub7Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub7R[i] = r;
            }
        }

        sub8Ob = GameObject.FindGameObjectsWithTag("obj8");
        sub8R = new Renderer[sub8Ob.Length];
        for (int i = 0; i < sub8Ob.Length; i++)
        {
            Renderer r = sub8Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub8R[i] = r;
            }
        }

        sub9Ob = GameObject.FindGameObjectsWithTag("obj9");
        sub9R = new Renderer[sub9Ob.Length];
        for (int i = 0; i < sub9Ob.Length; i++)
        {
            Renderer r = sub9Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub9R[i] = r;
            }
        }

        sub10Ob = GameObject.FindGameObjectsWithTag("obj10");
        sub10R = new Renderer[sub10Ob.Length];
        for (int i = 0; i < sub10Ob.Length; i++)
        {
            Renderer r = sub10Ob[i].GetComponent<Renderer>();
            if (r != null)
            {
                sub10R[i] = r;
            }
        }
    }
}
