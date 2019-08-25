using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -1.0f);
	}
}
