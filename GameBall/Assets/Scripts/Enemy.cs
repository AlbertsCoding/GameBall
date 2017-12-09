using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float Velocitat;
    // Use this for initialization
    private bool flagStart = false;
    private Vector3 Target = new Vector3(4, 0.5f, 4);

    void Start()
    {
        Target = new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7));
    }

    // Update is called once per frame
    void Update()
    {
        if(flagStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, Velocitat * Time.deltaTime + Time.timeSinceLevelLoad / 1000);
            if (transform.position == Target)
            {
                Target = new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7));
            }
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown("space"))
        {
            flagStart = true;
        }
    }

}
