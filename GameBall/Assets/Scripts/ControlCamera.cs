using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour {

    // Necessitem agafar els valors del personatge, aixi que fem un contenidor per controlar-ho
    public GameObject player;

    // Creem un vector on posem la diferecia entre la posicio del personatge i la de la camera
    private Vector3 offset;


	// Use this for initialization
	void Start () {

        // Donem un valor al offset al principi del programa
        offset = transform.position - player.transform.position;

		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        // Canviem la posicio de la camera perque es mantigui relativament immovil respecte al player
        transform.position = player.transform.position + offset;
	}
}
