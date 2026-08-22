using UnityEngine;
using UnityEngine.Audio;
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

    private int positionEnemy;
    private bool levelUp;


    [Header("Enemies")]
    public GameObject Enemy;
    private float interval;

    [Header("Music")]
    public AudioSource _fxGame_music;
    public AudioSource _fxGame_efects;
    public AudioClip _fxLevelUp;
    public AudioClip _destroyEnemy;
    public AudioClip _time;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interval = 5f;
        InvokeRepeating("updateScore", 0f,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void spawnEnemy() {
        switch (level) {
            case 1:
                positionEnemy = Random.Range(1, 3);
                break;
            case 2:
                positionEnemy = Random.Range(1, 3);
                break;
            case 3:
                positionEnemy = Random.Range(1, 4);
                break;
            case 4:
                positionEnemy = Random.Range(1, 3);
                break;
            case 5:
                positionEnemy = Random.Range(1, 3);
                break;
            case 6:
                positionEnemy = Random.Range(1, 3);
                break;
            case 7:
                positionEnemy = Random.Range(1, 3);
                break;
            case 8:
                if(positionEnemy == 1) {
                    positionEnemy = 2;
                }
                else {
                    positionEnemy = 1;
                }
                break;
            case 9:
                positionEnemy = Random.Range(1, 3);
                break;
            case 10:
                if (positionEnemy == 1) {
                    positionEnemy = 2;
                }
                else {
                    positionEnemy = 1;
                }
                break;

        }

        
        if(positionEnemy == 1) {
            GameObject EnemyTemp = Instantiate(Enemy);
            EnemyTemp.transform.position = new Vector3(EnemyTemp.transform.position.x,1.51f,EnemyTemp.transform.position.z);
            Debug.Log("Intanciado inimigo 1");
        }
        if (positionEnemy == 2) {
            GameObject EnemyTemp = Instantiate(Enemy);
            EnemyTemp.transform.position = new Vector3(EnemyTemp.transform.position.x, -2.5f, EnemyTemp.transform.position.z);
            Debug.Log("Instanciado inimigo 2");
        }
    }

    void destroyAllEnemies() {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("enemy");
        _fxGame_efects.PlayOneShot(_destroyEnemy);

        foreach (GameObject inimigo in inimigos) {
            Destroy(inimigo);
        }
    }
    void destroyAllEnemiesNoSongs() {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject inimigo in inimigos) {
            Destroy(inimigo);
        }
    }

    public void updateScore() {
        score++;
        switch (score) {
            case 1:
                
                CancelInvoke("spawnEnemy");
                level = 1;
                interval = 3;
                velocity = 2;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 20:
                
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 2;
                interval = 2;
                velocity = 2.5f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 40:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 3;
                interval = 0.5f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 64:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 4;
                interval = 0.5f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 80:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 5;
                interval = 0.3f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 96:
                _fxGame_music.pitch = 0.5f;
                CancelInvoke("spawnEnemy");
                level = 6;
                interval = 0.4f;
                velocity = 2f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 108:
                _fxGame_music.pitch = 1f;
                break;
            case 117:
                _fxGame_efects.PlayOneShot(_time);
                _fxGame_music.Stop();
                destroyAllEnemiesNoSongs();
                CancelInvoke("spawnEnemy");
                break;
            case 121:
                level = 7;
                interval = 0.5f;
                velocity = 3f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 122:
                _fxGame_music.time = 126.4f;                
                _fxGame_music.pitch = 1f;
                _fxGame_music.Play();
                break;
            case 136:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                positionEnemy = 1;
                level = 8;
                interval = 0.3f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 152:
                _fxGame_music.pitch = 1.5f;
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                destroyAllEnemies();
                CancelInvoke("spawnEnemy");
                level = 9;
                interval = 0.4f;
                velocity = 3f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;
            case 173:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 10;
                interval = 0.4f;
                velocity = 2f;
                InvokeRepeating("spawnEnemy", 1f, interval);
                break;


        }
        txtScore.text = score.ToString();
        txtLevel.text = level.ToString();
    }
}
