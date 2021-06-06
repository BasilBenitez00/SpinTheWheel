using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{

    private float rotSpeed;
    private float spinInterval;

    private float totalAngle;
    private int designatedAngle;

    private bool canSpin;
    
    private int baseAngle;
    private int finalAngle;

    private int spins;

    public int[] numberList;


    public Text resultText;
    

    // Start is called before the first frame update
    void Start()
    {
        canSpin = true;
        totalAngle = 360/numberList.Length;

        baseAngle = Mathf.RoundToInt(totalAngle);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerInput();
    }

    
    void PlayerInput()
    {
       
        if(Input.GetKey(KeyCode.Alpha1)&& canSpin)
        {
            designatedAngle = baseAngle * 3;
            
            StartCoroutine(Spin(designatedAngle));
            Debug.Log("Selected 1");
        }
        else if(Input.GetKey(KeyCode.Alpha2) && canSpin)
        {
            designatedAngle = baseAngle * 4;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 2");
        }
        else if(Input.GetKey(KeyCode.Alpha3)&& canSpin)
        {
            designatedAngle = baseAngle*5;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 3");
        }
        else if(Input.GetKey(KeyCode.Alpha4)&& canSpin)
        {
            designatedAngle = baseAngle * 6;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 4");
        }
        else if(Input.GetKey(KeyCode.Alpha5)&& canSpin)
        {
            designatedAngle = baseAngle * 7;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 5");
        }
        else if(Input.GetKey(KeyCode.Alpha6)&& canSpin)
        {
            designatedAngle = baseAngle * 8;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 6");
        }
        else if(Input.GetKey(KeyCode.Alpha7)&& canSpin)
        {
            designatedAngle = baseAngle *9;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 7");
        }
        else if(Input.GetKey(KeyCode.Alpha8)&& canSpin)
        {
            designatedAngle = baseAngle *0;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 8");
        }
        else if(Input.GetKey(KeyCode.Alpha9)&& canSpin)
        {
            designatedAngle = baseAngle * 1;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 9");
        }
        else if(Input.GetKey(KeyCode.Alpha0)&& canSpin)
        {
            designatedAngle = baseAngle*2;
            
            StartCoroutine(Spin(designatedAngle));
             Debug.Log("Selected 10");
        }
    }



    IEnumerator Spin(float targetAngle)
    {
        canSpin = false;
        
        spins = Random.Range(200,300);
        //float inAngle;
        spinInterval = 0.0001f*Time.deltaTime * 2;

        
        for (int i = 0; i < spins; i++)
        {
            transform.Rotate(0,0,(totalAngle));
           
            yield return new WaitForSeconds(spinInterval);
            
            //Debug.Log(Mathf.RoundToInt(transform.eulerAngles.z));
            float remainder = Mathf.RoundToInt(transform.eulerAngles.z) % totalAngle;
            if(remainder !=0)
            {
                 transform.Rotate(0,0,(totalAngle));
            }
            if(Mathf.RoundToInt(transform.eulerAngles.z)== targetAngle)
            {
                i= spins;
            }
               

        }

        
        
        
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        Debug.Log(finalAngle);
    
        for (int i = 0; i < numberList.Length; i++)
        {

            if(finalAngle == i * totalAngle)
            {
                resultText.text = numberList[i].ToString();
            }
        }

        canSpin = true;



    }

}
