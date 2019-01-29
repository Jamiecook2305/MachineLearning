using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public NeuralNetwork net;
    public int numberOfInputs;
    public int [] hiddenLayers;
    public int numberOfOutputs;
    private int rotate = 0;
    private float rotateSpeed = 30;
    private int walk = 0;
    private int moveSpeed = 1;

    private float [] state;

    private float [] newState;
    private float action;
    private float reward;
    public string path;
    
    //private List<>

    private void Start ()
    { 

        net.Initialise (numberOfInputs, hiddenLayers, numberOfOutputs, path);

        state = new float [] {10.5f, 65.3f};

        Debug.Log((net.Flow (new float [] { 5, -4, 30 , 5, -14, 3.6f}))[0]);

        //foreach(var val in state)
        //    Debug.Log (val);

        //var memoryChunk = (state, action, reward, newState);
        string nums = "";
        for (int i = 0; i < 10; i++)
        {
            nums += ("," + Random.Range (-4.9f, 4.9f)).ToString ();
        }
            System.IO.File.WriteAllText ("Assets/Texts/file.txt", nums);

    }

    private void Update ()
    {
        //state = changeInDistance, degreesFromTarget

        //choose action
        action = ChooseAction (state);

        //take action!!!
        transform.Rotate (0, action, 0);
        transform.Translate (0, 0, 1 * Time.deltaTime);

        //get new state
        newState = GetState();

        //get reward
        reward = GetReward (state, action, newState);

        //store in m?


        //s = s'
        state = newState;

    }

    private float[] GetState ()
    {
        float [] state = new float [] {5, 5};

        return state;
    }

    public float GetReward (float [] state, float action, float [] newState)
    {

        float reward = 0.5f;

        return reward;

    }

    public float ChooseAction (float [] state)
    {

        float action = 1;

        return action;

    }

}
