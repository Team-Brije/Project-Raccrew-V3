using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPrefabAssigner : MonoBehaviour
{
    public ScriptableObjPower _powerUp;
    private SpriteRenderer _spriteRenderer;
    bool _hasCollided;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _powerUp.img;
    }

    private void LateUpdate()
    {
        _hasCollided = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4")
        {
            if (_hasCollided) { return; }
            _hasCollided = true;
            _powerUp.Apply(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
