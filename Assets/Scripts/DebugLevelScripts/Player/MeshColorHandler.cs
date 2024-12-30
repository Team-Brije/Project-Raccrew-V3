using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshColorHandler : MonoBehaviour
{
    MovementHandler movement;
    int id;
    public MeshRenderer hatMesh;

    void Start()
    {
        movement = GetComponent<MovementHandler>();
        id = movement.playerId;
        switch (id)
        {
            case 0:
                if (ColorManagerSingleton.Instance.materialP1 != null)
                {
                    hatMesh.material = ColorManagerSingleton.Instance.materialP1;
                }
                break;
            case 1:
                if (ColorManagerSingleton.Instance.materialP2 != null)
                {
                    hatMesh.material = ColorManagerSingleton.Instance.materialP2;
                }
                break;
            case 2:
                if (ColorManagerSingleton.Instance.materialP3 != null)
                {
                    hatMesh.material = ColorManagerSingleton.Instance.materialP3;
                }
                break;
            case 3:
                if (ColorManagerSingleton.Instance.materialP4 != null)
                {
                    hatMesh.material = ColorManagerSingleton.Instance.materialP4;
                }
                break;
        }
    }
}
