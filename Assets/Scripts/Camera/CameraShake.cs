using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    [SerializeField] private float shakeAmount = 0.02f;
    private Vector3 initialPos;
    private bool canShake = false;
    void Awake()
    {
        initialPos = transform.position;
        Instance = this;
    }
    void Start()
    {
        canShake = false;
    }

    void Update()
    {
        if (canShake)
            transform.position = initialPos + Random.insideUnitSphere * shakeAmount;
    }

    public IEnumerator CanStartShaking(float shakeTime)
    {
        canShake = true;
        yield return new WaitForSeconds(shakeTime);
        canShake = false;
    }
    public void ShakeThisCamera(float shakeTime, float amountShake)
    {
        shakeAmount = amountShake;
        StartCoroutine(CanStartShaking(shakeTime));
    }
    
}
