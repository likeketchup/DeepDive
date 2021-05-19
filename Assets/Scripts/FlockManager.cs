using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish;
    public int fishNum = 50;
    public GameObject[] fishArray;
    public Vector3 flockLimit = new Vector3(100,100,100);
    public float minSpeed = 10f;
    public float maxSpeed = 20f;
    [Range(1f,100f)]
    public float neighbourDistance = 50f;
    [Range(1f,10f)]
    public float rotationSpeed = 1f;
    public float distanceBetweenFish = 10f;
    public Vector3 goalPosition;
    public Vector3 spawn = new Vector3(100,100,100);

    private float nextActionTime = 0.0f;
    private float period = 10f;
    private Vector3 startCenter = new Vector3(500,-500,500);
    void Start()
    {
        startCenter = this.transform.position;
        fishArray = new GameObject[fishNum];
        for(int i = 0; i<fishNum; i++){
            Vector3 position = this.transform.position + new Vector3(
                Random.Range(-flockLimit.x,flockLimit.x),
                Random.Range(-flockLimit.y,flockLimit.y),
                Random.Range(-flockLimit.z,flockLimit.z));
            fishArray[i] = (GameObject) Instantiate(fish,position,Quaternion.identity);
            fishArray[i].GetComponent<Flock>().manager = this;
        }
        goalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // test object avoid
        //goalPosition = new Vector3(-1000,-700,2500);
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            goalPosition = new Vector3(
                Random.Range(startCenter.x-spawn.x,startCenter.x+spawn.x),
                Random.Range(startCenter.y-spawn.y,startCenter.y+spawn.y),
                Random.Range(startCenter.z-spawn.z,startCenter.z+spawn.z));
            Debug.Log(goalPosition);
        } 
    }
}
