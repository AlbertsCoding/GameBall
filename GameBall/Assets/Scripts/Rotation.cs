using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    // Creem un contenidor per oder controlar la rotacio des de l'editor
    public Vector3 offsets;

	// Utilitzem aquest degut a que no volem aplicar cap fisica a l'objecte
	void Update () {

        // Apliquem la rotacio al transform
        // DeltaTime = Temps que tarda en fer el frame
        transform.Rotate(offsets * Time.deltaTime);
	}
}
