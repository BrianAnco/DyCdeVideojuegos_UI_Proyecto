using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int SoulCost;
    public GameObject arrow;
    bool usoSubWeapon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
	{
		if (Input.GetButton("Fire2") && SoulCost <= Souls.instance.soulsAmount && !usoSubWeapon)
		{
            Souls.instance.SubItem(-SoulCost);
            StartCoroutine(Lanzar());
            GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,0));

			if (transform.localScale.x < 0)
			{
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f, 0f), ForceMode2D.Force);
                subItem.transform.localScale = new Vector2(-1, -1);
            }
			else
			{
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f, 0f), ForceMode2D.Force);
            }

            

		}
	}

    IEnumerator Lanzar()
	{
        usoSubWeapon = true;
        yield return new WaitForSeconds(0.5f);
        usoSubWeapon = false;
	}
}
