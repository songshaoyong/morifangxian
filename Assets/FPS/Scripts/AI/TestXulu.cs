using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestXulu : MonoBehaviour
{
    //    public NavMeshAgent nav;
    public Transform[] target;
    private int currentTargetIndex = 0;
    public float maxOffset = 1.0f; // 最大的左右偏移量
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
            OnPathComplete(); // 手动触发事件
        }
    }

    // 用于设置目标对象的方法
    public void SetTarget(Transform[] newTarget)
    {
        target = newTarget;
    }

    // 到达目标点时调用的方法
    void OnPathComplete()
    {
        Debug.Log("Enemy reached the destination!");

        // 到达目标后切换到下一个目标点
        currentTargetIndex = (currentTargetIndex + 1) % target.Length;
        if (currentTargetIndex == target.Length - 1)
        {
            SetRandomDestination(0); // 到达目标后重新设置随机目标位置
        }
        else
        {
            SetRandomDestination(maxOffset); // 到达目标后重新设置随机目标位置
        }
       
    }
    // 设置随机目标位置
    void SetRandomDestination(float maxOffset)
    {
        Vector3 randomOffset = new Vector3(Random.Range(-maxOffset, maxOffset), 0f, Random.Range(-maxOffset, maxOffset));
        Vector3 newDestination = target[currentTargetIndex].position + randomOffset;
        navMeshAgent.SetDestination(newDestination);
    }
}
