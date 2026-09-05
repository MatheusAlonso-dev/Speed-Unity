using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

    int positionEnemy;
    bool levelUp;


    [Header("Enemies")]
    public GameObject Enemy;
    float intervalSpawnEnemy;
    float yEnemy;

    [Header("Music")]
    public AudioSource _fxGame_music;
    public AudioSource _fxGame_efects;
    public AudioClip _fxLevelUp;
    public AudioClip _destroyEnemy;
    public AudioClip _time;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intervalSpawnEnemy = 5f;
        InvokeRepeating("updateScore", 0f,1f);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(life <= 0) {
            Debug.Log("FECHAR APLICAÇÃO");
            Invoke(nameof(fecharStage), 3f);
            
        }


        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            if (Time.timeScale == 1f) {
                Time.timeScale = 0f;
                _fxGame_music.Pause();
            }
            else {
                Time.timeScale = 1f;
                _fxGame_music.UnPause();
            }
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

    void fecharStage() {
        SceneManager.LoadScene("MainMenu");
    }


    public void updateScore() {
        score++;
        switch (score) {
            case 1:
                
                CancelInvoke("spawnEnemy");
                level = 1;
                intervalSpawnEnemy = 3;
                velocity = 2;
                InvokeRepeating("spawnEnemy", 3f, intervalSpawnEnemy);
                break;
            case 20:
                
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 2;
                intervalSpawnEnemy = 2;
                velocity = 2.5f;
                InvokeRepeating("spawnEnemy", 1f, intervalSpawnEnemy);
                break;
            case 40:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 3;
                intervalSpawnEnemy = 0.5f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, intervalSpawnEnemy);
                break;
            case 64:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 4;
                intervalSpawnEnemy = 0.5f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, intervalSpawnEnemy);
                break;
            case 80:
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                CancelInvoke("spawnEnemy");
                level = 5;
                intervalSpawnEnemy = 0.3f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, intervalSpawnEnemy);
                break;
            case 96:
                _fxGame_music.pitch = 0.5f;
                CancelInvoke("spawnEnemy");
                level = 6;
                intervalSpawnEnemy = 0.4f;
                velocity = 2f;
                InvokeRepeating("spawnEnemy", 1f, intervalSpawnEnemy);
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
                intervalSpawnEnemy = 0.5f;
                velocity = 3.3f;  //3
                InvokeRepeating("spawnEnemy", 1.3f, intervalSpawnEnemy);
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
                intervalSpawnEnemy = 0.3f;
                velocity = 2.6f;
                InvokeRepeating("spawnEnemy", 1f, intervalSpawnEnemy);
                break;
            case 152:
                _fxGame_music.pitch = 1.5f;
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                destroyAllEnemies();
                CancelInvoke("spawnEnemy");
                level = 9;
                intervalSpawnEnemy = 0.4f;
                velocity = 3.3f;
                InvokeRepeating("spawnEnemy", 2f, intervalSpawnEnemy);
                break;
            case 193:                
                _fxGame_efects.PlayOneShot(_fxLevelUp);
                level = 10;
                intervalSpawnEnemy = 0.5f;
                CancelInvoke("spawnEnemy");
                InvokeRepeating("spawnEnemy", 2f, intervalSpawnEnemy);
                velocity = 3.4f;
                break;

        }
        txtScore.text = score.ToString();
        txtLevel.text = level.ToString();
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
                if (positionEnemy == 1) {
                    positionEnemy = 2;
                }
                else {
                    positionEnemy = 1;
                }
                break;
            case 9:
                positionEnemy = Random.Range(1, 5);
                break;
            case 10:
                positionEnemy = Random.Range(1, 3);
                break;

        }

        if(positionEnemy == 1 || positionEnemy == 2) {
            if (positionEnemy == 1) {
                yEnemy = 1.51f;
            }
            else {
                yEnemy = -2.5f;
            }

            GameObject EnemyTemp = Instantiate(Enemy);
            EnemyTemp.transform.position = new Vector3(EnemyTemp.transform.position.x, yEnemy, EnemyTemp.transform.position.z);
        }
        
    }
}
