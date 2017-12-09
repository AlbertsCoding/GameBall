using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject PickUp;
    public float Velocitat;
    private bool start = false;


    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
		if(start)
        {
            Repeat();
            start = false;
        }
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            start = true;
        }
    }

    void Repeat()
    {
            InvokeRepeating("Generate", 0, Velocitat);
    }

    void Generate()
    {
        int x = Random.Range(-7, 7);
        int z = Random.Range(-7, 7);
        Vector3 Target = (new Vector3(x, 0.5f, z));
        Instantiate(PickUp, Target, Quaternion.identity);
    }
}

