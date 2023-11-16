using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        print(data);
        string[] points = data.Split(',');
        //print(points[8*3]);

        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3

        for ( int i = 0; i<1; i++)
        {
            float x = 4-float.Parse(points[8 * 3])/100;
            print(x);
            float y = float.Parse("-0.183");// + 5-float.Parse(points[8 * 3 + 1])/100;
            float z = 0;//float.Parse(0);

            if (x < -1.5)
                x = float.Parse("-1.5");
            else if (x > 1.5)
                x = float.Parse("1.5");

            /*if (y > .4)
                y = float.Parse("-.55");
            if (y < -.183)
                y = float.Parse("-0.183");*/
            
            handPoints[i].transform.localPosition = new Vector3(x, y, z);

        }


    }
}