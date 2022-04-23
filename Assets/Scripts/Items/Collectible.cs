using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public int arrowsToGive;
	bool Tomado;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")&&Tomado==false)
		{
			Souls.instance.SubItem(arrowsToGive);
			Tomado = true;
			Destroy(gameObject);
		}
	}
}
