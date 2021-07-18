using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_tracker : MonoBehaviour
{
    Transform player_tr = null;

    // Start is called before the first frame update
    void Start()
    {
        player_tr = ((GameObject)GameObject.Find("Player")).transform;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(player_tr.position.x, 4, player_tr.position.z);

    }
}
