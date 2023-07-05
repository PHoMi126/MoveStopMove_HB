using UnityEngine;
using UnityEngine.AI;
using static CharacterController;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    public CharacterController _characterController;

    public float waitTimer = 0f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (_characterController != null)
        {
            _characterController.SetClothes(Random.Range(0, 8));
        }
    }

    void Update()
    {
        waitTimer += Time.deltaTime;
        if (_characterController != null)
        {
            if (_characterController.animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                _characterController.weaponPrefab.SetActive(false);
                Invoke(nameof(Dead), 2.2f);
                agent.isStopped = true;
            }
            else
            {
                if (agent.remainingDistance <= agent.stoppingDistance) //done with path
                {
                    _characterController.ChangeAnimation(AnimState.Idle);

                    if (RandomPoint(centrePoint.position, range, out Vector3 point) && waitTimer >= 4f) //pass in our centre point and radius of area
                    {
                        _characterController.ChangeAnimation(AnimState.Run);
                        waitTimer = 0f;
                        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                        agent.SetDestination(point);
                    }
                }

                _characterController.attackTime -= Time.deltaTime;
                if (_characterController != null && _characterController.attackTime <= 0f)
                {
                    if (_characterController.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    {
                        _characterController.Attack();
                    }
                }
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    void Dead()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}