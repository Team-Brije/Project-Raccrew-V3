using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkillshotSpawn : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    private float V0;
    public Transform target;
    private float g = 9.81f;
    public enum bulletType {StandartBullet, GoldBullet};
    public bulletType type ;
    // Start is called before the first frame update
    void Start()
    {
        if (type == bulletType.StandartBullet)
        {
            Angles();
            Vector3 p0 = shootPoint.position;
            Quaternion r0 = shootPoint.rotation;
            Vector3 v0 = V0 * shootPoint.forward;
            //GameObject bullet = Instantiate(bulletPrefab, p0, r0);
            bulletPrefab.GetComponent<Bullet>().P0 = p0;
            bulletPrefab.GetComponent<Bullet>().V0 = v0;
        }
    }


    Vector2 Angles()
    {
        Vector2 delta = Delta();
        float dx = delta.x;
        float dy = delta.y;
        float tanA = dy / dx;
        float secA = Mathf.Sqrt(1 + tanA * tanA);
        V0 = Mathf.Sqrt(g * dx * (tanA + secA)) + 1;

        float U = V0 * V0 / (dx * g);
        float w1 = U + Mathf.Sqrt(U * U - 2 * tanA * U - 1);
        float w2 = U - Mathf.Sqrt(U * U - 2 * tanA * U - 1);

        float angle1 = Mathf.Rad2Deg * Mathf.Atan(w1);
        float angle2 = Mathf.Rad2Deg * Mathf.Atan(w2);
        return new Vector2(angle1, angle2);
    }

    Vector2 Delta()
    {
        Vector3 relativePosition = target.position - shootPoint.position;
        Vector2 relativePosition2D = new Vector2(relativePosition.x, relativePosition.z);

        float dx = relativePosition.magnitude;
        float dy = relativePosition.y;
        return new Vector2(dx, dy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
