using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad, saltoFuerza;
    //public int contadorSaltos = 0;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
        
		if (isGrounded)
		{
            anim.SetBool("Jump", false);
		}
		else
		{
            anim.SetBool("Jump", true);
		}

        VoltearPersonaje();
        Atacar();
    }

    private void FixedUpdate()
    {
        Movimiento();
        Saltar();
    }

    public void Movimiento()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * velocidad, velY);

        if(rb.velocity.x != 0)
		{
            anim.SetBool("Run", true);
		}
		else
		{
            anim.SetBool("Run", false);
		}
    }

    public void VoltearPersonaje()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Saltar()
	{

		if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, saltoFuerza);
            //contadorSaltos = 1;
		}
		/*else if (Input.GetButton("Jump") && isGrounded==false)
		{
			if (contadorSaltos == 1)
			{
                rb.velocity = new Vector2(rb.velocity.x, (saltoFuerza));
                contadorSaltos = 2;
            }
		}*/
	}

    public void Atacar()
	{
		if (Input.GetButton("Fire1"))
		{
            anim.SetBool("Attack", true);
		}
		else
		{
            anim.SetBool("Attack", false);
        }
	}
}
