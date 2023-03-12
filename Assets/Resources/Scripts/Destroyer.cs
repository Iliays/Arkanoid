using UnityEngine;

public class Destroyer : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private PlayerMover _playerMover;

	private void OnTriggerEnter(Collider other)
	{
		if (other.attachedRigidbody.GetComponent<BallMover>())
		{
			_player.ApplyDamage();
			_playerMover.BallCreate();
			Destroy(other.attachedRigidbody.gameObject);
		}
	}
}