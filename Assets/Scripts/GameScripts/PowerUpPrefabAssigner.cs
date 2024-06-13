using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPrefabAssigner : MonoBehaviour
{
    public ScriptableObjPower _powerUp;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _powerUp.img;
    }

    private void OnTriggerEnter(Collider other)
    {
        _powerUp.Apply(other.gameObject);
        Destroy(gameObject);
    }
}
