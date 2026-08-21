using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public Text txtScore;
    public Text txtLevel;

    [Header("Game")]
    public int level;
    public int score;
    public int life;
    public float velocity;

    private bool levelUp;

    [Header("Enemies")]
    public GameObject Enemy;
    private float interval;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelUp = false;
        interval = 5f;
        InvokeRepeating("updateScore", 0f,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void spawnEnemy() {
        
        int numero = Random.Range(1, 3);
        if(numero == 1) {
            GameObject EnemyTemp = Instantiate(Enemy);
            EnemyTemp.transform.position = new Vector3(EnemyTemp.transform.position.x,1.51f,EnemyTemp.transform.position.z);
            Debug.Log("Intanciado inimigo 1");
        }
        if (numero == 2) {
            GameObject EnemyTemp = Instantiate(Enemy);
            EnemyTemp.transform.position = new Vector3(EnemyTemp.transform.position.x, -2.5f, EnemyTemp.transform.position.z);
            Debug.Log("Instanciado inimigo 2");
        }
    }

    public void updateScore() {
        score++;
        switch (score) {
            case 1:
                CancelInvoke("spawnEnemy");
                level++;
                interval = 3;
                velocity = 2;
                InvokeRepeating("spawnEnemy", 2f, interval);
                break;
            case 10:
                CancelInvoke("spawnEnemy");
                level++;
                interval = 2;
                velocity = 3;
                InvokeRepeating("spawnEnemy", 2f, interval);
                break;
            case 20:
                CancelInvoke("spawnEnemy");
                level++;
                interval = 2;
                velocity = 3.5f;
                InvokeRepeating("spawnEnemy", 2f, interval);
                break;
            case 30:
                CancelInvoke("spawnEnemy");
                level++;
                interval = 1;
                velocity = 5;
                InvokeRepeating("spawnEnemy", 2f, interval);
                break;
            case 40:
                CancelInvoke("spawnEnemy");
                level++;
                interval = 1;
                velocity = 6;
                InvokeRepeating("spawnEnemy", 2f, interval);
                break;
            case 50:
                CancelInvoke("spawnEnemy");
                level++;
                interval = 0.5f;
                velocity = 7;
                InvokeRepeating("spawnEnemy", 2f, interval);
                break;
        }
        txtScore.text = score.ToString();
        txtLevel.text = level.ToString();
    }
}
