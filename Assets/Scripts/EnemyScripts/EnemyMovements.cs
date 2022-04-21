using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{

    float velocidad;
    Rigidbody2D rb;
    Animator anim;
    public bool enemigoEstatico;
    public bool enemigoMovimiento;
    public bool enemigoPatrulla;
    public bool debeEsperar;
    public float tiempoEsperar;
    bool estaEsperando;

    public bool caminarDerecha;

    public Transform comprobarMuro, comprobarVacio, comprobarSuelo;
    public bool muroDetectado, vacioDetectado, sueloDetectado;
    public float radioDeDeteccion;
    public LayerMask identificarTerreno;

    public Transform puntoA, puntoB;
    bool irA, irB;


    // Start is called before the first frame update
    void Start()
    {
        irA = true;
        velocidad = GetComponent<Enemy>().velocidad;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vacioDetectado = !Physics2D.OverlapCircle(comprobarVacio.position, radioDeDeteccion, identificarTerreno);
        muroDetectado = Physics2D.OverlapCircle(comprobarMuro.position, radioDeDeteccion, identificarTerreno);
        sueloDetectado = Physics2D.OverlapCircle(comprobarSuelo.position, radioDeDeteccion, identificarTerreno);

        if ((vacioDetectado || muroDetectado) && sueloDetectado)
		{
            Voltear();
		}

    }

	private void FixedUpdate()
	{
		if (enemigoEstatico)
		{
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		if (enemigoMovimiento)
		{
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!caminarDerecha)
			{
                rb.velocity = new Vector2(-velocidad * Time.deltaTime, rb.velocity.y);
			}
			else
			{
                rb.velocity = new Vector2(velocidad * Time.deltaTime, rb.velocity.y);
            }

        }
		if (enemigoPatrulla)
		{
            if (irA)
			{
                if (!estaEsperando)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-velocidad * Time.deltaTime, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, puntoA.position)< 0.2f)
				{
					if (debeEsperar)
					{
                        StartCoroutine(Esperando());
					}
                    Voltear();
                    irA = false;
                    irB = true;
				}
            }

			if (irB)
			{

                if (!estaEsperando)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(velocidad * Time.deltaTime, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, puntoB.position) < 0.2f)
                {
                    if (debeEsperar)
                    {
                        StartCoroutine(Esperando());
                    }

                    Voltear();
                    irA = true;
                    irB = false;
                }
            }
		}
	}

    public void Voltear()
	{
        caminarDerecha = !caminarDerecha;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
	}

    IEnumerator Esperando()
	{
        anim.SetBool("Idle", true);
        estaEsperando = true;
        Voltear();
        yield return new WaitForSeconds(tiempoEsperar);
        estaEsperando = false;
        anim.SetBool("Idle", false);
        Voltear();
	}
}
