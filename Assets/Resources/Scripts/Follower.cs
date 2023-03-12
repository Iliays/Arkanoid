using UnityEngine;

public class Follower : MonoBehaviour
{
	[SerializeField] private Transform _target;

	private void Update()
	{
		transform.position = new Vector3(_target.position.x, transform.position.y);
	}
}