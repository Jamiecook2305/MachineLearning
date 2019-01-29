using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Macro : MonoBehaviour {

    private GameObject enemy;
    private GameObject player;
    private NavMeshAgent enemyAgent;
    private bool goToPlayer;
    private bool playing;

    public float pace = 10;

	void Start () {

        player = GameObject.FindGameObjectWithTag ("Player");
        enemy = GameObject.FindGameObjectWithTag ("Enemy");
        enemyAgent = enemy.GetComponent<Micro> ().agent;

	}

    private void DirectMicro ()
    {

        enemyAgent.SetDestination (SelectPosition ());

    }

    private Vector3 SelectPosition ()
    {

        Vector3 selectedPosition = Vector3.zero;

        if (goToPlayer)
        {
            return player.transform.position;
        }
        else
        {
            return selectedPosition;
        }

    }

    IEnumerator PaceControl ()
    {

        while (playing)
        {
            DirectMicro ();
            yield return new WaitForSeconds (pace);
        }

    }

}
