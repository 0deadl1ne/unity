using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ServiceManager : MonoBehaviour
{
    private LvEnder _lvEnder;

    [SerializeField] private GameObject _spawnPoint;

    [Header("LevelEnder")]
    [SerializeField] private TMP_Text _coinScore;
    [SerializeField] private TMP_Text _enemyscore;
    [SerializeField] private int _maxCoins;
    [SerializeField] private int _maxEnemies;
    [SerializeField] private GameObject[] _items;
    private int _score;
    private int _enemyScore;
    private bool _checkpoint = false;
    #region Singelton
    private Animator _caveAnimator;
    public static ServiceManager Instanse;
    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;
        else
            Destroy(gameObject);
    }
    #endregion 
    private void Start()
    {
        _lvEnder = LvEnder.Instanse;
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            PlayerPrefs.SetInt(GamePrefs.LastPlayedLvl.ToString(), SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt(GamePrefs.LvlPlayed.ToString() + SceneManager.GetActiveScene().buildIndex, 1);
        }

        _coinScore.text = "0/" + _maxCoins.ToString();
        _enemyscore.text = "0/" + _maxEnemies.ToString();
    }
    public void Restart()
    {
        ChangeLvl(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {
        ChangeLvl(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ChangeLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ResetProgres()
    {
        PlayerPrefs.DeleteAll();
    }


    public void Checkpoint (GameObject checkpoint)
    {
        _spawnPoint.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y, checkpoint.transform.position.z);
        _checkpoint = true;

    }

    public void Respown (GameObject player)
    {
        if (_checkpoint)
        {
            Player_Controller.Instanse.CheckpointHP();
            player.transform.position = _spawnPoint.transform.position;
            
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].SetActive(true);
            }
        }
           
        else
            Restart();
    }

    public void Score ()
    {
        _score++;
        _coinScore.text = _score + "/" + _maxCoins.ToString();
        EndLvlChecker();
    }

    public void EnemyScore()
    {
        _enemyScore++;
        _enemyscore.text = _enemyScore.ToString() + "/" + _maxEnemies.ToString();
        EndLvlChecker();
    }

    private void EndLvlChecker ()
    {
        if (_score == _maxCoins && _enemyScore == _maxEnemies)
            _lvEnder.EnderLevelStart();
    }
}


public enum Scenes
{
    MainMenu,
    first,
    second,
    third,
}

public enum GamePrefs
{
    LastPlayedLvl,
    LvlPlayed,
}
 