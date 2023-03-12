using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{
	[SerializeField] private RandomBall _randomBall;
	[SerializeField] private BallSpeedController _ballSpeedController;

	private Rigidbody _rigidbody;
	private int _count;

	private void OnEnable()
	{
		_rigidbody = GetComponent<Rigidbody>();
		//_rigidbody.velocity = new Vector3(Random.Range(10f, 15f), Random.Range(10f, 15f));
		_rigidbody.velocity = Vector3.up * 20f; // + new Vector3(10f, 10f);
		_ballSpeedController.enabled = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Block>())
		{
			_count++;
			if (_count >= 3)
			{
				Instantiate(_randomBall, transform.position, Quaternion.identity);
				Instantiate(_randomBall, transform.position, Quaternion.identity);
				_count = 0;
			}
		}
		else if(collision.gameObject.GetComponent<PlayerMover>())
		{
			_count = 0;
		}
	}
}