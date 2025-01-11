using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public enum ColliderOrientation {  Left, Right };
    public ColliderOrientation orientation;
    private void OnTriggerEnter(Collider other)
    {
        switch (orientation)
        {
            case ColliderOrientation.Left:
                if(other.gameObject.TryGetComponent(out CharacterSelectItemStorage storage))
                {
                    storage.ChangeAttributeDown();
                }
                break;
            case ColliderOrientation.Right:
                if (other.gameObject.TryGetComponent(out CharacterSelectItemStorage storage1))
                {
                    storage1.ChangeAttributeUp();
                }
                break;
        }
    }
}
