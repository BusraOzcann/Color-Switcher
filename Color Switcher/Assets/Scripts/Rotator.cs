using UnityEngine;

public class Rotator : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = Object.FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, player.circleSpeed * Time.deltaTime);
    }
    
}
