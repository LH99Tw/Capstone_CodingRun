using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float laneDistance = 5.0f; // ���߿� ���� �� ���� & �̵��Ÿ� 5���̵�
    private int currentLane = 1;      // 0 = ����, 1 = �߾�, 2 = ������

    private Vector2 touchStart; //��ġ ���� ����
    private bool isSwiping = false; //������ ����

    void Update()
    {
        HandleSwipeOrKey();
        MoveToLane();
    }

    void MoveToLane()
    {
        Vector3 targetPos = transform.position;
        targetPos.x = (currentLane - 1) * laneDistance; //�÷��̾� x�� ����(-1)=-1*5   ���(1)=0*5  ������(1)=1*5
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10f); //�ε巯�� ������,10f������ ����->�����̵��ð� ���� ����(ũ�� Ŭ���� ����)
    }

    void HandleSwipeOrKey()
    {
        // ����� ��������
        if (Input.touchCount == 1)     //�հ��� 1���� ��ġ���ϋ�
        {
            Touch touch = Input.GetTouch(0);    //ù ��° ��ġ ���� ȣ��

            if (touch.phase == TouchPhase.Began)    //��ġ������
            {
                touchStart = touch.position;    //��ġ ���� x�� ����
                isSwiping = true;               //�������� ���·� ��ȯ
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)  //���������� & �������� �����
            {
                float deltaX = touch.position.x - touchStart.x; ��ġ ���� x���� ��ġ�� ���� x�� ���� ���

                if (Mathf.Abs(deltaX) > 50f)    //x���� ���̰� 50f�� �ѱ�� ������������ ����
                {
                    if (deltaX > 0 && currentLane < 2) currentLane++;   //������ �̵�
                    else if (deltaX < 0 && currentLane > 0) currentLane--;  //���� �̵� (���ι����� �ʰ����� �ʵ���)
                }

                isSwiping = false;  //�ѹ��� �������� �������� ���� �ʱ�ȭ
            }
        }

        // PC Ű���� �׽�Ʈ�� �Է�
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0) //���� ȭ��ǥ
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)   //������ ȭ��ǥ
        {
            currentLane++;
        }
    }
}
