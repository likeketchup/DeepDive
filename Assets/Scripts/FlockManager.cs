using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish;
    public int fishNum = 25;
    public GameObject[] fishArray;
    public Vector3 flockLimit = new Vector3(1000,500,1000);
    public float minSpeed = 50f;
    public float maxSpeed = 200f;
    [Range(1f,100f)]
    public float neighbourDistance = 10f;
    [Range(1f,5f)]
    public float rotationSpeed = 2f;
    public float distanceBetweenFish = 10f;
    public Vector3 goalPosition;
    public Vector3 spawn = new Vector3(100,100,100);

    private float nextActionTime = 0.0f;
    private float period = 20f;
    private Vector3 limit = new Vector3(250,250,250);
    void Start()
    {
        spawn = this.transform.position;
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
            goalPosition = this.transform.position + new Vector3(Random.Range(-limit.x, limit.x),
                                                            Random.Range(-limit.y, limit.y),
                                                            Random.Range(-limit.z, limit.z));
            if (goalPosition.y > -45-limit.y/2) {
                goalPosition.y = -45-limit.y/2;
            }
            Debug.Log(goalPosition);
        } 
    }
}