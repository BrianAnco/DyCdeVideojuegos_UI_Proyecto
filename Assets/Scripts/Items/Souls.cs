using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls : MonoBehaviour
{
    public Text soulsText;
    public int soulsAmount;

    public static Souls instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		soulsText.text = "x " + soulsAmount.ToString();
	}
	public void SubItem(int subItemAmount)
	{
		soulsAmount += subItemAmount;
		soulsText.text = "x " + soulsAmount.ToString();
	}

}
