using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Text ScoreTextArea;
    public GameObject[] CirclePrefabs;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public int score;
    public float jumpForce = 10f;
    public string currentColor;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    public float circleSpeed = 100f;
    public float circleMaxSpeed = 250f;
    float circlePos;
    int count = 1;

    private void Start()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        score = 0;
        circlePos = 26f;
        SetRandomColor();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            score += 5;
            ScoreTextArea.text = "Skore : " + score;
            if (score >= 20 * count) //every 20 scores
            {
                Debug.Log("donguye girdi");
                if (circleSpeed < circleMaxSpeed)
                {
                    if (circleSpeed > 0)
                    {
                        circleSpeed += 5;
                    }
                    else if (circleSpeed < 0)
                    {
                        //if circle direction is negatif we have to subtract number.
                        circleSpeed -= 5;
                    }

                    //for rotate opposite direction
                    
                    count++;
                }
                else if (circleSpeed >= circleMaxSpeed)
                {
                    circleSpeed = circleMaxSpeed;
                }
            }
            SetRandomColor();
            Destroy(collision.gameObject);
            CreateCircle();
            return;
        }

        if (collision.tag != currentColor && collision.tag != "ColorChanger")
        {
            gameManager.SetScore(score);
            Time.timeScale = 0f;
        }
    }

    public void CreateCircle()
    {
        int rnd = Random.Range(0, 100);
        if (rnd <= 50)
        {
            circleSpeed *= -1;
        }
        else
        {
            circleSpeed *= +1;
        }
        Instantiate(CirclePrefabs[0], new Vector3(0, circlePos, 0), Quaternion.identity);
        circlePos += 8f;
    }

}
