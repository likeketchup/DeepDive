using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// source : https://learn.unity.com/tutorial/flocking?uv=2019.4&courseId=5dd851beedbc2a1bf7b72bed&projectId=5e0bb649edbc2a00260e5de3#5e0bbe05edbc2a23141712ee
public class Flock : MonoBehaviour
{
    // Start is called before the first frame update
    public FlockManager manager;
    private float speed;
    bool turning = false;
    void Start()
    {
        speed = Random.Range(manager.minSpeed, manager.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Bounds b = new Bounds(manager.transform.position, manager.flockLimit * 2.0f);

        // If the fish is outside the bounds of the cube or about to hit something
        // then start turning around
        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;

        if (!b.Contains(transform.position)) {

            turning = true;
            direction = manager.transform.position - transform.position;
        } else if (Physics.Raycast(transform.position, this.transform.TransformDirection(Vector3.forward), out hit,10f)) {
            turning = true;
            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green,10f);
            Debug.Log("drawray");
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
        } else if(transform.position.y >= -45){
            turning = true;
            direction = manager.transform.position - transform.position;
            Debug.Log("Trun around from surface");
        }

        if(turning){
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  manager.rotationSpeed * Time.deltaTime);
        }else{
            if(Random.Range(0,100)<=10)
                speed = Random.Range(manager.minSpeed, manager.maxSpeed);
            //if(Random.Range(0,100)<=30)
            //    boids();   
        }
        boids();  
        transform.Translate(0f,0f,Time.deltaTime*speed);
        turning = false;
    }
    
    void boids(){
        GameObject[] fishes;
        fishes = manager.fishArray;

        Vector3 center = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float globalSpeed = 0.01f;
        float distance;
        int groupSize = 0;
        foreach (GameObject fish in fishes){
            if(fish != this.gameObject){
                distance = Vector3.Distance(fish.transform.position, this.transform.position);
                if(distance<=manager.neighbourDistance){
                    center += fish.transform.position;
                    groupSize++;
                    globalSpeed += fish.GetComponent<Flock>().speed;
                    if (distance < manager.distanceBetweenFish) {
                        avoid = avoid + (this.transform.position - fish.transform.position);
                    }
                }
            }
        }
        if (groupSize > 0) {
            // Find the average center of the group then add a vector to the target (goalPos)
            center = center / groupSize + (manager.goalPosition - this.transform.position);
            speed = globalSpeed / groupSize;

            Vector3 direction = (center + avoid) - transform.position;
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    manager.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
