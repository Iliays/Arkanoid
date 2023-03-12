using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Win : MonoBehaviour
{
    [SerializeField] private List<Block> _blocks = new List<Block>();

	public static event UnityAction<bool> OnWin;

	private void OnEnable()
	{
		Block.OnDie += OnDeleteBlock;
	}

	private void OnDisable()
	{
		Block.OnDie -= OnDeleteBlock;
	}

	private void OnDeleteBlock(Block block)
	{
		_blocks.Remove(block);
		OnWin?.Invoke(_blocks.Count == 0);
	}
}