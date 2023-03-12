using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomBall : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] private BallSpeedController _ballSpeedController;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_ballSpeedController.enabled = true;
		_rigidbody.velocity = new Vector3(Random.Range(15f, 20f), Random.Range(15f, 20f));
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Destroyer>())
		{
			Destroy(gameObject);
		}
	}
}