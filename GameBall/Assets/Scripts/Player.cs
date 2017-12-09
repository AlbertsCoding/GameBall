using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // PAS 1

    // Creem el objecte contenidor rb en privat perque no fa falta que surti a l'editor
    private Rigidbody rb;

    // PAS 4
    public float speed;


    // PAS 6

    // Creem les variables per controlar els textos
    // La fem privada perque no te perque estar a l'editor
    private int count;
    // Aquestes les fem publiques per poder adjuntar els labels del canvas
    public Text countText;
    public Text victoryText;
    public Text keyText;
    public Text punctuationText;

    private bool move = false;
    private bool final = false;

    private Vector3 explosion;


    // Use this for initialization
    void Start()
    {

        // PAS 2

        // Enllacem el RigidBody que em posat al editor amb el contenidor rb
        rb = GetComponent<Rigidbody>();

        // Reiniciem els labels
        count = 0;
        countText.text = "Points: " + count.ToString();

        explosion = new Vector3(Random.Range(-500, 500), 10000, Random.Range(-500, 500));

    }

    // Update is called once per frame
    void Update()
    {

    }

    // PAS 3

    // Aquesta funcio s'ecjectuta abans del update
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && ! final)
        {
            move = true;
            keyText.text = "";
        }
        if (final)
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("Game");
            }
        }
        if (move)
        {
            // Guardem en variables la input de les fletxes / accelerometre (H i V son fixes de Unity)
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Creem un vector on guardem els valors rebuts de les inputs, en forma de variables        
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Apliquem una forca a la bola per moure-la a traves del rb
            rb.AddForce(movement * speed);
        }


    }


    // PAS 5

    private void OnTriggerEnter(Collider other)
    {
        // Ens assegurem de que estem xocant contra un PickUp
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Desactivem el PickUp en comtes de eliminar-ho perque aixi es molt mes facil si el volem tornar a activar
            Destroy(other.gameObject);

            // PAS 6
            // Afegim 1 a count i cridem a la nostra funcio
            count += 1;
            countText.text = "Points: " + count.ToString();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(explosion);
            Invoke("GameOver", 1);


        }
    }

    void GameOver()
    {
        victoryText.text = "Game Over";
        punctuationText.text = "You got " + count.ToString() + " Points!";
        Invoke("Restart", 1);
    }

    void Restart()
    {
        keyText.text = "Press R to restart";
        final = true;
    }
}
    