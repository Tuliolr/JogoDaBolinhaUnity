using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentaBolinha : MonoBehaviour {

    private Rigidbody rb;
    public float velocidade;
    public GameObject particulaItem;
    public Text textoScore;
    public Text textofinal;
    public Text textoVida;
    public Text textoGameOver;
    private int pontos;
    private Vector3 gameOver;
    public int vida = 3;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        textofinal.text = " ";
        textoGameOver.text = "";
        textoScore.text = textoScore.text + pontos.ToString();
        textoVida.text = textoVida.text + vida.ToString();
        gameOver = new Vector3(0, 0.5f, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(move * velocidade);
        GameOver();

    }

    private void OnTriggerEnter(Collider outro)
    {

        if (outro.gameObject.CompareTag("Item"))
        {
            Instantiate(particulaItem, outro.gameObject.transform.position, Quaternion.identity);
            Destroy(outro.gameObject);//destruir item

            MarcaPonto();

        }
    }
    void MarcaPonto()
    {

        pontos++;
        textoScore.text = "Score: " + pontos.ToString();
        if (pontos == 2)
        {
            textofinal.text = "You win!!!";
        }
    }


    void GameOver()
    {

        if (transform.position.y < -5)
        {
            transform.position = gameOver;
            vida--;
            textoVida.text = "Life: " + vida.ToString();
        }
        else if (vida == 0)
        {
            textoGameOver.text = "Game Over!";
        }

    }

       
    
}
