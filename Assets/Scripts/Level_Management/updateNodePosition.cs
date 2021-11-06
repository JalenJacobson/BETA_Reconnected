using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class updateNodePosition : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();

    public GameObject Node;
    public MoveNode NodeMove_Script;

    public float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        NodeMove_Script = Node.GetComponent<MoveNode>();
    }

    // Update is called once per frame
    void Update()
    {
        updatePositions();
    }

    async void updatePositions()
    {
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions/node", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/positions/node", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var node = JsonUtility.FromJson<RobotPosition>(positionResponseString);
        if(node.position != null)
        {
            NodeMove_Script.rb.MovePosition(node.position.position);
            Node.transform.rotation = Quaternion.Slerp(Node.transform.rotation, node.position.rotation,  Time.deltaTime * rotationSpeed);
        }
    }
}

[Serializable]
public class NodePosition
{
    public RobotPosition Node;
}

