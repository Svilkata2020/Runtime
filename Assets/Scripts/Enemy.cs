using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;

    [SerializeField] float groundCheckCooldown = 0.2f;
    [Header("Ground")]
    [SerializeField] float enemyHeight;
    [SerializeField] LayerMask whatIsGround;


    bool isGrounded;
    bool checkGround = true;

    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, enemyHeight * 0.5f + 0.2f, whatIsGround) && checkGround && agent.enabled == false)
        {
            EnableAgent();
        }
        ;
        if (agent.enabled)
        {
            agent.SetDestination(player.position);
        }
    }
    private void EnableAgent()
    {
        agent.enabled = true;
    }

    public void DisableGroundCheck() 
    {
        checkGround = false;
        Invoke(nameof(EnableGroundCheck), groundCheckCooldown);
    }

    void EnableGroundCheck()
    {
        checkGround = true;
    }
}
