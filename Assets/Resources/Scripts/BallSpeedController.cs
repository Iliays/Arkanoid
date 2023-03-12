using UnityEngine;

public class BallSpeedController : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	private const float MinSpeed = 15f;
	private const float MaxSpeed = 20f;
	private const int WaitFrame = 30;

	private void Update()
	{
		if (_rigidbody.velocity.magnitude != 0)
		{
			if (Time.frameCount % WaitFrame == 0)
			{
				if (_rigidbody.velocity.magnitude < MinSpeed || _rigidbody.velocity.magnitude > MaxSpeed)
				{
					float speedCorrect = MaxSpeed / _rigidbody.velocity.magnitude;
					_rigidbody.velocity *= speedCorrect;
				}
			}
		}
	}
}