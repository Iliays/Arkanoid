using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private BallControl _ball;
	[SerializeField] private Transform _target;
	[SerializeField] private float _minXClamp;
	[SerializeField] private float _maxXClamp;
	private Rigidbody _rigidbody;
	private Player _player;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_player = GetComponent<Player>();
		BallCreate();
	}

	//private void Update()
	//{
	//	transform.Translate(_speed * Input.GetAxis("Horizontal") * Time.deltaTime * Vector3.right);
	//	transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minXClamp, _maxXClamp), transform.position.y, transform.position.z);
	//}

	private void FixedUpdate()
	{
		float positionX = _rigidbody.position.x + Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
		positionX = Mathf.Clamp(positionX, _minXClamp + (transform.localScale.x / 2), _maxXClamp - (transform.localScale.x / 2));
		_rigidbody.MovePosition(new Vector3(positionX, _rigidbody.position.y));
	}

	public void BallCreate()
	{
		if (_player.Health > 0)
		{
			_ball.InitTarget(transform);
			Instantiate(_ball, _target.position, Quaternion.identity);
		}
	}

	public void BonusMultiBalls()
	{
		_ball.BallMover.MultiBalls();
	}
}