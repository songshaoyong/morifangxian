using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestXulu : MonoBehaviour
{
    //    public NavMeshAgent nav;
    public Transform[] target;
    private int currentTargetIndex = 0;
    public float maxOffset = 1.0f; // ��������ƫ����
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       // navMeshAgent.SetDestination(this.target[currentTargetIndex].position);
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            OnPathComplete(); // �ֶ������¼�
        }
    }

    // ��������Ŀ�����ķ���
    public void SetTarget(Transform[] newTarget)
    {
        target = newTarget;
    }

    // ����Ŀ���ʱ���õķ���
    void OnPathComplete()
    {
        Debug.Log("Enemy reached the destination!");

        // ����Ŀ����л�����һ��Ŀ���
        currentTargetIndex = (currentTargetIndex + 1) % target.Length;
        if (currentTargetIndex == target.Length - 1)
        {
            SetRandomDestination(0); // ����Ŀ��������������Ŀ��λ��
        }
        else
        {
            SetRandomDestination(maxOffset); // ����Ŀ��������������Ŀ��λ��
        }
       
    }
    // �������Ŀ��λ��
    void SetRandomDestination(float maxOffset)
    {
        Vector3 randomOffset = new Vector3(Random.Range(-maxOffset, maxOffset), 0f, Random.Range(-maxOffset, maxOffset));
        Vector3 newDestination = target[currentTargetIndex].position + randomOffset;
        navMeshAgent.SetDestination(newDestination);
    }
}
