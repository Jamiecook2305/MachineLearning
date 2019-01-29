using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class NeuralNetwork : MonoBehaviour
{
    //[HideInInspector]
    //public int NOInputs;
    //[HideInInspector]
    //public int numberOfHiddenLayers;
    //[HideInInspector]
    //public int nodesInHiddenLayers;
    //[HideInInspector]
    //public int NOOutputs;

    public TextAsset weightsText;
    //public TextAsset biasesText;
    
    public float [] [] layers;

    private float [] [] weights;

    private float epsilon = 0.1f;

    public void Initialise (int NOInputs, int[] HiddenNodes, int NOOutputs, string path)
    {
        int numberOfHiddenLayers = HiddenNodes.Length;
        //initialises a 2d float array with length = number of hidden layer plus i/o layers
        layers = new float [numberOfHiddenLayers + 2] [];

        //sets the i/o layers to the number of i/os
        layers [0] = new float [NOInputs];
        layers [numberOfHiddenLayers + 1] = new float[NOOutputs];

        //sets the length of each hidden layer to length "nodesInHiddenLayers"
        for (int i = 0; i < numberOfHiddenLayers; i++)
        {
            layers [i + 1] = new float [HiddenNodes[i]];
        }

        //creates 2d float array = the number of layers -1. this represents the connections
        weights = new float [layers.Length - 1] [];

        //populates each set of weights = to the number of connections in that set
        for (int i = 0; i < weights.Length; i++)
        {
            weights [i] = new float [layers [i].Length * layers [i + 1].Length];
        }

        //populate weights array
        if (File.Exists (path))
        {
            weights = ReadFromFile ((TextAsset)AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset)));
        }



        //Debug.Log (string.Format ("{0}, {1}, {2}", Sigmoid(-100), Sigmoid(0), Sigmoid(50)));

    }

    private float[][] ReadFromFile (TextAsset file)
    {

        string str = file.text;

        string [] temp = str.Split ('\n');

        string [] [] strings = new string [temp.Length] [];

        for (int i = 0; i < temp.Length; i++)
        {
            strings [i] = temp [i].Split (',');
        }

        float [] [] toReturn = new float [strings.Length] [];

        for (int i = 0; i < strings.Length; i++)
        {
            toReturn [i] = new float [strings [i].Length];
        }

        for (int i = 0; i < strings.Length; i++)
        {
            for (int a = 0; a < strings[i].Length; a++)
            {
                toReturn [i] [a] = float.Parse(strings [i] [a]);
            }
        }

        return toReturn;

    }

    private float SumInputs (int layerNumber, int nodeNumber)
    {
        float sum = 0;
        int offset = layers[layerNumber - 1].Length;
        for (int i = 0; i < layers[layerNumber - 1].Length; i++)
        {
            sum += (weights [layerNumber - 1] [i + nodeNumber*offset]) * layers[layerNumber - 1] [i];
        }
        return sum;
    }

    private float Sigmoid (float sum)
    {

        float result;

        result = 1 / (1 + (Mathf.Pow (2.71828f, -sum)));

        return result;

    }

    private void FeedForward ()
    {



    }

    public float[] Flow (float[] inputNodeValues)
    {

        float [] outputValues;

        layers [0] = inputNodeValues;

        for (int j = 1; j < layers.Length; j++)
        {

            for (int i = 0; i < layers [j].Length; i++)
            {
                layers [j] [i] = Sigmoid (SumInputs (j, i));
            }

        }

        outputValues = layers[layers.Length - 1];

        return outputValues;

    }



}
