using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Item_Spawner : MonoBehaviour {

    public GameObject coin;
    public GameObject key;
    public GameObject magicianCube;
    public GameObject spike;
    public GameObject trampoline;
    public GameObject healthPickUp;
    public GameObject falsePlatform;

    // Use this for initialization
    void Start ()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 1")
        {
            for (int i = 0; i < 6; i++)
            {
                Instantiate(falsePlatform, new Vector3(286 + (i * 2f), -7, 0), Quaternion.identity);
            }

            for (int i = 0; i < 2; i++)
            {
                Instantiate(falsePlatform, new Vector3(97.5f + (i * 1), 0, 0), Quaternion.identity);
            }

            for (int i = 0; i < 5; i++)
            {
                Instantiate(spike, new Vector3(-35.85f + (i * 1.5f), -3.5f, -0.3f), Quaternion.identity);
            }

            for (int i = 0; i < 2; i++)
            {
                Instantiate(spike, new Vector3(22 + (i * 1.5f), 0.5f, -0.3f), Quaternion.identity);
            }

            for (int i = 0; i < 2; i++)
            {
                Instantiate(spike, new Vector3(262.9f + (i * 1.5f), -10.5f, -0.3f), Quaternion.identity);
            }

            for (int i = 0; i < 2; i++)
            {
                Instantiate(spike, new Vector3(266.9f + (i * 1.5f), -10.5f, -0.3f), Quaternion.identity);
            }

            for (int i = 0; i < 2; i++)
            {
                Instantiate(spike, new Vector3(258.9f + (i * 1.5f), -10.5f, -0.3f), Quaternion.identity);
            }

            for (int i = 0; i < 10; i++)
            {
                Instantiate(coin, new Vector3(-55 + (i * 2), 1, 0), Quaternion.identity);
            }

            for (int i = 0; i < 6; i++)
            {
                Instantiate(coin, new Vector3(-26 + (i * 2), -3, 0), Quaternion.identity);
            }

            for (int i = 0; i < 6; i++)
            {
                Instantiate(coin, new Vector3(-9 + (i * 2), 1, 0), Quaternion.identity);
            }

            for (int i = 0; i < 7; i++)
            {
                Instantiate(coin, new Vector3(-1 + (i * 2), 9.5f, 0), Quaternion.identity);
            }

            for (int i = 0; i < 3; i++)
            {
                Instantiate(coin, new Vector3(15 + (i * 2), 1, 0), Quaternion.identity);
            }

            for (int i = 0; i < 5; i++)
            {
                Instantiate(coin, new Vector3(15 + (i * 2), 6, 0), Quaternion.identity);
            }

            for (int i = 0; i < 7; i++)
            {
                Instantiate(coin, new Vector3(55 + (i * 2), 9, 0), Quaternion.identity);
            }

            for (int i = 0; i < 4; i++)
            {
                Instantiate(coin, new Vector3(90 + (i * 2), 1, 0), Quaternion.identity);
            }

            for (int i = 0; i < 6; i++)
            {
                Instantiate(coin, new Vector3(137 + (i * 2), 2, 0), Quaternion.identity);
            }

            for (int i = 0; i < 5; i++)
            {
                Instantiate(coin, new Vector3(155 + (i * 2), 11, 0), Quaternion.identity);
            }

            for (int i = 0; i < 11; i++)
            {
                Instantiate(coin, new Vector3(234 + (i * 2), -6, 0), Quaternion.identity);
            }

            for (int i = 0; i < 5; i++)
            {
                Instantiate(coin, new Vector3(287 + (i * 2f), -6, 0), Quaternion.identity);
            }

            Instantiate(coin, new Vector3(35, 3, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(42, 5, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(49, 7, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(125, 17, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(130, 15, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(135, 13, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(165.25f, 2, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(211, 0, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(217, -2, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(223, -4, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(229, -6, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(258, -6, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(262, -6, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(266, -6, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(270, -6, 0), Quaternion.identity);

            Instantiate(falsePlatform, new Vector3(119.5f, 18, 0), Quaternion.identity);

            Instantiate(key, new Vector3(21, 1, 0), Quaternion.identity);
            Instantiate(key, new Vector3(165, 11, 0), Quaternion.identity);
            Instantiate(key, new Vector3(276.5f, -6, 0), Quaternion.identity);

            Instantiate(spike, new Vector3(123.5f, 0.5f, -0.3f), Quaternion.identity);


            Instantiate(trampoline, new Vector3(-32, 0, 0), Quaternion.identity);
            Instantiate(trampoline, new Vector3(150, 7.5f, 0), Quaternion.identity);
            Instantiate(trampoline, new Vector3(165.25f, 5, 0), Quaternion.identity);

            Instantiate(magicianCube, new Vector3(-5.5f, 9.5f, 0), Quaternion.identity);
            Instantiate(magicianCube, new Vector3(118.5f, 19, 0), Quaternion.identity);
            Instantiate(magicianCube, new Vector3(244.5f, -4, 0), Quaternion.identity);

            Instantiate(healthPickUp, new Vector3(8, 6, 0), Quaternion.identity);
            Instantiate(healthPickUp, new Vector3(98, 1, 0), Quaternion.identity);
            Instantiate(healthPickUp, new Vector3(165.25f, 8, 0), Quaternion.identity);
            Instantiate(healthPickUp, new Vector3(281f, -3, 0), Quaternion.identity);
        }

        if (scene.name == "Level 2")
        {

        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
