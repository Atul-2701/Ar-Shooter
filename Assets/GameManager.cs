using BigRookGames.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] GameObject target;
    public Scrollbar xAxis;
    public Scrollbar yAxis;
    public Scrollbar Distance;

    [SerializeField] Text xValue;
    [SerializeField] Text yValue;
    [SerializeField] Text distanceValue;

    [SerializeField] GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3();
        xAxis.value = 0.5f;
        yAxis.value = 0.5f;
        Distance.value = 0.4f;
        xAxis.onValueChanged.AddListener(delegate { UpdateValue(pos); });
        yAxis.onValueChanged.AddListener(delegate { UpdateValue(pos); });
        Distance.onValueChanged.AddListener(delegate { UpdateValue(pos); });
        Instantiate(target, Boundary(xAxis.value, xAxis.value, Distance.value), Quaternion.identity);
    }

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
            if (instance == null)
            {
                Debug.LogError("No GameManager found in scene. Please add one to the scene.");
            }
        }
        return instance;
    }
    public void CloseAndOpenMenu()
    {
        if (menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(true);
        }
    }

    public void UpdateValue(Vector3 position)
    {
        position = Boundary(xAxis.value, xAxis.value, Distance.value);
        xValue.text = (xAxis.value * 10f).ToString();
        yValue.text = (yAxis.value * 10f).ToString();
        distanceValue.text = (Distance.value * 30f).ToString();

    }

    public Vector3 Boundary(float xAxis, float yAxis, float Distance)
    {
        Vector3 SpawnPoint = new Vector3(Random.Range(xAxis, -xAxis) * 10f, Random.Range(yAxis, -yAxis) * 10f, Distance * 30f);
        return SpawnPoint;
    }
}