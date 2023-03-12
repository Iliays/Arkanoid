using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
	[SerializeField] private int _health;
	[SerializeField] private Renderer _renderer;
	[SerializeField] private List<Material> _materials = new();
	[SerializeField] private ParticleSystem _effect;

	private	AudioSource _audioSource;
	private Renderer _effectRenderer;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_effectRenderer = _effect.GetComponent<Renderer>();
		ChangeMaterial(_health);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Ball>())
		{
			_audioSource.Play();
			_effectRenderer.material = _materials[_health];
			_effect.Play();
			Invoke(nameof(Die), 0.1f);
		}
	}

	private void Die()
	{
		if (_health > 0)
		{
			_health -= 1;
		}
		else
		{

			Invoke(nameof(Diactivate), 0.3f);
		}

		ChangeMaterial(_health);
	}

	private void Diactivate()
	{
		gameObject.SetActive(false);
	}

	private void ChangeMaterial(int index)
	{
		_renderer.material = _materials[index];
	}
}