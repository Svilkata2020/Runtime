using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Transform player;

    private void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if(playerGO != null)
        {
            player = playerGO.transform;
        }
    }

    private void Update()
    {
        transform.Translate((player.position - transform.position) * speed * Time.deltaTime);
    }
}
