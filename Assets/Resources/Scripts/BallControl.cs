using UnityEngine;

[RequireComponent(typeof(BallMover))]
public class BallControl : MonoBehaviour
{
	private BallMover _ballMover;
	[SerializeField] private Transform _target;

	public BallMover BallMover;

	private void Start()
	{
		_ballMover = GetComponent<BallMover>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			_ballMover.enabled = true;
			this.enabled = false;
		}
		else
		{
			transform.position = new Vector3(_target.position.x, transform.position.y);
		}
	}

	public void InitTarget(Transform target)
	{
		_target = target;
	}
}