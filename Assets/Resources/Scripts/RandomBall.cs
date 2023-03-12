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
		_rigidbody.velocity = new Vector3(15f, 15f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Destroyer>())
		{
			Destroy(gameObject);
		}
	}
}