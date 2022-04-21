using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Rigidbody2D rbP;
    public Image vidaImagen;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        rbP = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        vida = vidaMaxima;
        material.original = sprite.material;
    }

    // Update is called once per frame
    void Update()
    {
        vidaImagen.fillAmount = vida / 100;
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
                rbP.AddForce(new Vector2(-fuerzaGolpeX, fuerzaGolpeY), ForceMode2D.Force);
			}
			else
			{
                rbP.AddForce(new Vector2(fuerzaGolpeX, fuerzaGolpeY), ForceMode2D.Force);
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
