using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{
	[SerializeField] private RandomBall _randomBall;
	[SerializeField] private BallSpeedController _ballSpeedController;
	[SerializeField] private Rigidbody _rigidbody;

	private int _count;
	private float _lastPositionX;

	private void OnEnable()
	{
		//_rigidbody.velocity = new Vector3(Random.Range(10f, 15f), Random.Range(10f, 15f));
		_rigidbody.velocity = Vector3.up * 15f;
		_ballSpeedController.enabled = true;
	}

	public void MultiBalls()
	{
		Instantiate(_randomBall, transform.position, Quaternion.identity);
		Instantiate(_randomBall, transform.position, Quaternion.identity);
	}

	private void OnCollisionEnter(Collision collision)
	{
		//float ballPositionX = transform.position.x;

		//if (collision.gameObject.TryGetComponent(out PlayerMover playerMove))
		//{
		//	if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1) // движение почти вертикальное
		//	{
		//		float collisionPointX = collision.contacts[0].point.x; // точка касания
		//		float playerCenterPosition = playerMove.gameObject.transform.position.x;
		//		float difference = playerCenterPosition - collisionPointX; // разница между центром ваганетки и местом касания
		//		float direction = collisionPointX < playerCenterPosition ? -1 : 1; // расчет направления 
		//		_rigidbody.velocity = Vector3.zero;
		//		_rigidbody.AddForce(new Vector3(direction * Mathf.Abs(difference) * (20 / 2), 20));
		//	}
		//}
		//_lastPositionX = ballPositionX;

		//if (collision.gameObject.GetComponent<Block>())
		//{
		//	_count++;
		//	if (_count >= 3)
		//	{
		//		Instantiate(_randomBall, transform.position, Quaternion.identity);
		//		Instantiate(_randomBall, transform.position, Quaternion.identity);
		//		_count = 0;
		//	}
		//}
		//else if (collision.gameObject.GetComponent<PlayerMover>())
		//{
		//	_count = 0;
		//}
	}
}