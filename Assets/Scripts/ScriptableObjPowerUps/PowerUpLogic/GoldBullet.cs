using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GoldBullet : MonoBehaviour
{
    public LayerMask barrierLayer;
    private int ColisionCount;
    public float speedMultiplier;
    public float speed;
    public int colCount = 0;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GBBarrier"))
        {
            Debug.Log("Trigger Detected!");

            RaycastHit hit;
            if (Physics.Raycast(transform.position - 0.5f * transform.forward, transform.forward, out hit, Mathf.Infinity, barrierLayer))
            {
                Debug.Log("Raycast Emited");
                Vector3 normal = (hit.normal).normalized;
                Vector3 tangent = Vector3.Cross(normal, Vector3.up).normalized;
                Vector3 velocity = GetComponent<Rigidbody>().velocity;

                float Vn = Vector3.Dot(velocity, normal);
                float Vt = Vector3.Dot(velocity, tangent);

                Vector3 newVelocity = Vt * tangent - Vn * normal;
                transform.rotation = Quaternion.LookRotation(newVelocity, Vector3.up);
                if (colCount < 9)
                {
                    GetComponent<Rigidbody>().velocity = newVelocity * speedMultiplier;
                    colCount++;
                }
                else GetComponent<Rigidbody>().velocity = newVelocity;
            }
        }
    }
}
