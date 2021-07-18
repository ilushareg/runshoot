using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Transform player_tr = null;
    Transform barrel_tr = null;
    bool fire_on = false;
    float fire_timer = 0.0f;
    float fire_rate = 0.5f;

    GameObject bulletInstance = null;

    // Start is called before the first frame update
    void Start()
    {
        player_tr = ((GameObject)GameObject.Find("Player")).transform;
        barrel_tr = ((GameObject)GameObject.Find("gun/Cylinder")).transform;
        bulletInstance = (GameObject)Resources.Load("bullet");
    }

    GameObject SpawnBullet()
    {
        return Object.Instantiate<GameObject>(bulletInstance);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            fire = true;
        }
        else
        {
            fire = false;
        }

        if (fire_on)
        {
            fire_timer -= Time.deltaTime;
            while (fire_timer <= 0.0f)
            {
                bullet_animator bullet = SpawnBullet().GetComponent<bullet_animator>();
                bullet.Place(barrel_tr, fire_timer);

                fire_timer += fire_rate;
            }
        }

    }

    public bool fire
    {
        get { return fire_on; }
        set {
            if(value == true && fire_on == false)
            {
                fire_timer = 0.0f;
            }
            else if(value == false && fire_on == true)
            {

            }
            fire_on = value;
        }
    }

}
