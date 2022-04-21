using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float vida;
    public float vidaMaxima;
    bool tieneInmunidad;
    public float tiempoInmunidad;
    SpriteRenderer sprite;
    Blink material;
    public float fuerzaGolpeX;
    public float fuerzaGolpeY;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        vida = vidaMaxima;
        material.original = sprite.material;
    }

    // Update is called once per frame
    void Update()
    {
		if (vida > vidaMaxima)
		{
            vida = vidaMaxima;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy") && !tieneInmunidad)
		{
            vida -= collision.GetComponent<Enemy>().dmgRealizado;
            StartCoroutine(Inmunidad());

            if(collision.transform.position.x > transform.position.x)
			{
                rb.AddForce(new Vector2(-fuerzaGolpeX, fuerzaGolpeY), ForceMode2D.Force);
			}
			else
			{
                rb.AddForce(new Vector2(fuerzaGolpeX, fuerzaGolpeY), ForceMode2D.Force);
            }

            
			if (vida <= 0)
			{
                //Pantalla de game over
                print("Perdiste.");
			}
		}
	}

    IEnumerator Inmunidad()
	{
        tieneInmunidad = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(tiempoInmunidad);
        sprite.material = material.original;
        tieneInmunidad = false;
    }
}
