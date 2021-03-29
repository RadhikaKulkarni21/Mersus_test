using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    //ray tracing variables
    public float damage = 10f;
    public float range = 100f;
   //firing variables
    public GameObject bulletPrefab;
    //scoreboard UI
    public float limit = 0f;
    public float accurateShots = 0f;
    public float inaccurateShots = 0f;
    Text AccurateShots;
    Text InAccurateShots;
    public string sceneNext;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//fire1 unity bydeafault key
        {
            
            Fire();
            GameObject bulletObject = Instantiate(bulletPrefab);
            limit++;
            if (limit > 20)
            {
                GameObject.Find("Pipette_Gun_Controller").SetActive(false);
                LoadScene(sceneNext);
                
            }
            else
            {
                bulletObject.transform.position = fpsCam.transform.position + fpsCam.transform.forward;//bullet direction
                bulletObject.transform.forward = fpsCam.transform.forward;
            }
            
        }
        //RayCasting
        void Fire()
        {
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                //Counting accurate shots
                if(hit.transform.name == "FixedJointGrab_Cube")
                {
                    accurateShots++;
                    AccurateShots = GameObject.Find("Text").GetComponent<Text>();
                    AccurateShots.text = "Accurate Shots: " + accurateShots;
                }
                //counting inaccurate shots
                else
                {
                    inaccurateShots++;
                    InAccurateShots = GameObject.Find("TextInA").GetComponent<Text>();
                    InAccurateShots.text = "Inaccurate Shots: " + inaccurateShots;
                }
            }
            
        }
    }
    //Third scene of Socerboard.
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

}
