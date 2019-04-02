
using UnityEngine;


public class CameraBackground : MonoBehaviour
{
    public Camera[] cameras;

    Vector3 startposTop;
    Vector3 startposSide;
    Vector3 startposUP;

    float speed = 30f;
    int cameraNum;
    public bool switchCamNow;
    public Animator animator;
    // Update is called once per frame

   

    private void Start()
    {        
        startposTop = cameras[0].transform.position;        
        cameras[0].GetComponent<Camera>().enabled = true;
        startposSide = cameras[1].transform.position;
        cameras[1].GetComponent<Camera>().enabled = false;
        startposUP = cameras[2].transform.position;
        cameras[2].GetComponent<Camera>().enabled = false;
    }

    void Update()
    {        
        cameraMove(cameraNum);        
    }

    public void selectCamera(bool switchNow)
    {
        
        int randomnum = 0;
        int prev = randomnum;
        if (switchNow)
        {
            while (prev == randomnum)
            {
                randomnum = Random.Range(0, cameras.Length);
            }
        }
        switchNow = false;
        cameraNum = randomnum;        
        switch (randomnum)
        {
            case 0:
                cameras[0].transform.Rotate(Random.Range(40, 85), 0, 0);
                cameras[0].GetComponent<Camera>().enabled = true;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = false;
                break;
            case 1:
                cameras[cameraNum].transform.Rotate(0, Random.Range(0, -90), 0);
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = true;
                cameras[2].GetComponent<Camera>().enabled = false;
                break;
            case 2:
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = true;
                break;
            default:
                break;
        }        
            
    }
    void cameraMove(int cameraNum)
    {
        cameras[cameraNum].transform.position += Vector3.forward * Time.deltaTime * speed;
        if (cameras[cameraNum].transform.position.z > -192f)
        {
            selectCamera(true);
            switch (cameraNum)
            {                
                case 0:
                    cameras[cameraNum].transform.position = startposTop;
                    
                    break;
                case 1:
                    cameras[cameraNum].transform.position = startposSide;
                    
                    break;
                case 2:
                    cameras[cameraNum].transform.position = startposUP;
                    break;
            }
            
        }
        
    }

    void FadeToCam()
    {
        animator.SetTrigger("CamFade");
    }
    

}
