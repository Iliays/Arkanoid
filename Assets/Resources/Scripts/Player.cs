using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

	public int Health => _health;

    public static event UnityAction<int> OnHealthChange;

	private void Start()
	{
		OnHealthChange?.Invoke(_health);
	}

	public void ApplyDamage()
    {
        _health--;
        OnHealthChange?.Invoke(_health);
	}
}