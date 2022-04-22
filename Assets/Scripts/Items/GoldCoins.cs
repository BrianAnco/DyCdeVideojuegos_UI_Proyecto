using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : MonoBehaviour
{
    public float cashToGive;
	bool Tomado;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")&&Tomado==false)
		{
			BankAccount.instance.Money(cashToGive);
			Tomado = true;
			Destroy(gameObject);
		}
	}

}
