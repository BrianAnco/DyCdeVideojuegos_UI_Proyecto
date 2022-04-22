using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public float vidaOtorgada;
	bool tomado;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")&&tomado==false)
		{
			collision.GetComponent<PlayerHealth>().vida += vidaOtorgada;
			tomado = true;
			Destroy(gameObject);
		}
	}

}
