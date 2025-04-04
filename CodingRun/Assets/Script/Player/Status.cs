using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("�������ͽ�")]
    public int maxHP = 100;
    public int currentHP;

    public float moveSpeed = 5f;

    private float hpDecayInterval = 2f;
    private float hpDecayTimer = 0f;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        HandleHPDecay();
    }

    void HandleHPDecay()    //2�ʸ��� ü�� 1�� ����
    {
        hpDecayTimer += Time.deltaTime;
        if (hpDecayTimer >= hpDecayInterval)
        {
            TakeDamage(1); // ü�� 1�� ����
            hpDecayTimer = 0f;
        }
    }

    public void TakeDamage(int amount)  //������ �Լ�
    {
        currentHP -= amount;
        currentHP = Mathf.Max(currentHP, 0); // ü���� ������ ���� �ʰ�
        Debug.Log($"���� ����! -{amount} �� ���� HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    /*public void Heal(int amount)  //ü�� ȸ�� �Լ�
    {
        currentHP += amount;
        currentHP = Mathf.Min(currentHP, maxHP); // ü���� �ִ밪 ���� �ʰ�
        Debug.Log($"HP ȸ��! +{amount} �� ���� HP: {currentHP}");
    }*/

    private void Die()  //HP=0�� ���ó�� & ���� ��Ȱ��ȭ
    {
        Debug.Log("�÷��̾� ���! ���� ���� ó�� ����");
        //GameManager.Instance.GameOver(); // ���� ���� ó��
        // �÷��̾� ���� ��Ȱ��ȭ
        GetComponent<Player>().enabled = false;
    }

    private void OnTriggerEnter(Collider other) //�浹 ���� �Լ�(���α���X)
    {
        // TODO: ������, ��ֹ�, ���� ó�� ����
    }
}
