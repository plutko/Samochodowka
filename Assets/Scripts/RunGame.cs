using UnityEngine;

public class RunGame : MonoBehaviour
{
    public float player1Score;
    public float player2Score;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    private GameObject Car1;
    private GameObject Car2;

    void Start()
    {
        
    }

    public void Start1P()
    {
        //Car1 = Instantiate(Player1, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
        //Car1.name = "Car1";
        Player1.transform.position = SpawnPoint1.transform.position;
        Player2.transform.position = SpawnPoint3.transform.position;
    }

    public void Start2P()
    {
        Player1.transform.position = SpawnPoint1.transform.position;
        Player2.transform.position = SpawnPoint2.transform.position;
        //Car1 = Instantiate(Player1, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
        //Car2 = Instantiate(Player2, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
        //Car1.name = "Car1";
        //Car2.name = "Car2";
    }

    public GameObject GetCar1()
    {
        return Car1;
    }
}
