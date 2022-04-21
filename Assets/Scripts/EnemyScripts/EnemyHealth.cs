using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	Enemy enemy;
	public bool isDamaged;
	public GameObject deathEffect;
	Blink material;
	SpriteRenderer sprite;
	Rigidbody2D rb;


	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		material = GetComponent<Blink>();
		enemy = GetComponent<Enemy>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Weapon") && !isDamaged)
		{
			enemy.vidaPuntos -= 2f;
			
			if (collision.transform.position.x < transform.position.x)
			{
				rb.AddForce(new Vector2(enemy.golpeFuerzaAtrasX, enemy.golpeFuerzaAtrasY), ForceMode2D.Force);
			}
			else
			{
				rb.AddForce(new Vector2(-enemy.golpeFuerzaAtrasX, enemy.golpeFuerzaAtrasY), ForceMode2D.Force);

			}
			StartCoroutine(Damager());
			if (enemy.vidaPuntos <= 0)
			{
				Instantiate(deathEffect, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			
		}
	}

	IEnumerator Damager()
	{
		isDamaged = true;
		sprite.material = material.blink;
		yield return new WaitForSeconds(0.25f);
		isDamaged = false;
		sprite.material = material.original;
	}
}
