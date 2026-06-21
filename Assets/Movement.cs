using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;  

public class Movement : MonoBehaviour
{
    public int speed = 1;
    public int speed1 = 30;
    private Transform SpeedIncrease_posX;
    public GameObject _ObjectPlayer;
    private Rigidbody _Rigidbody_PLayer_force;
    // private float Call_location=-1000;
    
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        Debug.Log("Game is Start and initialized");
        _Rigidbody_PLayer_force = _ObjectPlayer.GetComponent<Rigidbody>();
        SpeedIncrease_posX=_ObjectPlayer.GetComponent<Transform>();

        if(SpeedIncrease_posX==null){Debug.LogError("No transform found on " + _ObjectPlayer.name);}
            
        
        if (_Rigidbody_PLayer_force == null)
        {
            Debug.LogError("No Rigidbody found on " + _ObjectPlayer.name);
        }
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _ObjectPlayer.transform.position=new Vector3(SpeedIncrease_posX.position.x,SpeedIncrease_posX.position.y,SpeedIncrease_posX.position.z+speed);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _ObjectPlayer.transform.position=new Vector3(SpeedIncrease_posX.position.x,SpeedIncrease_posX.position.y,SpeedIncrease_posX.position.z-speed);
        }

        //Debug.Log($"position of X posX {SpeedIncrease_posX.position.x}");

        // if (SpeedIncrease_posX.position.x <= Call_location)
        // {
        //     speed1 += 1;
        //     Call_location -= 1000f;
        //     Debug.Log($"Speed increased to {speed1} at X = {SpeedIncrease_posX.position.x}");
        // }

    }
    
    void FixedUpdate() 
    {
        _Rigidbody_PLayer_force.velocity = Vector3.left * speed1;
    }
}