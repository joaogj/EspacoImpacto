using UnityEngine;
using System.Collections;

public class Done_EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	void Start ()
	{
		//currentSpeed = GetComponent<Rigidbody2D>().velocity.y;
		//GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -1.0f);
		
		StartCoroutine(Evade());
	}
	
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody2D>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
		GetComponent<Rigidbody2D>().velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		transform.Translate(0, -0.1f, 0);
		// GetComponent<Rigidbody2D>().position = new Vector3
		// (
		// 	Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax), 
		// 	0.0f,
		// 	Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, 4, 5)
		// );
		
		// GetComponent<Rigidbody2D>().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody2D>().velocity.x * -tilt);
	}
}
