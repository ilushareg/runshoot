using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_animator : MonoBehaviour
{
    public Quaternion rot = new Quaternion();
    float updated = 0.0f;
    [Range(0.01f, 0.8f)]
    public float update_interval = 0.1f;

    float speed = 3.0f;
    float acceleration = 3.0f;

    float liveTime = 0.0f;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Place(Transform barrel, float fDt)
    {
        transform.position = barrel.position;
        transform.rotation = barrel.rotation;
        initPos = barrel.position;
        updatePosition(fDt);
    }

    void updatePosition(float fDt)
    {

        liveTime += fDt;

        Vector3 dir = transform.rotation * Vector3.down;


        Vector3 newPos = initPos + dir*liveTime* liveTime * speed + dir*liveTime* liveTime * acceleration;
        transform.position = newPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        //animate
        updated += Time.deltaTime;
        if(updated > update_interval)
        {
            Vector3 scale = new Vector3(Random.Range(1000, 2000) / 1000.0f, Random.Range(2000, 5000) / 1000.0f, 1);
            transform.localScale = scale;
        }

        while (updated > update_interval)
        {
            updated -= update_interval;
        }

        //move
        updatePosition(Time.deltaTime);


        if(liveTime>10)
        {
            Destroy(this.gameObject);
        }

    }
}
