using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    //Object ���̾�� �浹��, �浹�� ��ü�� ����
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            Destroy(collision.gameObject);
        }
    }
}
