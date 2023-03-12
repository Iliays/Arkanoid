using UnityEngine;

public class BonusMultiBalls : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.attachedRigidbody.TryGetComponent(out PlayerMover playerMover))
		{
			playerMover.BonusMultiBalls();
			Destroy(gameObject);
		}
	}
}