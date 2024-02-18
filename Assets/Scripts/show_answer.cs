using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class show_answer : MonoBehaviour
{
    public List<GameObject> nodes;
    private Renderer circle_render;
    public static bool show = false;

    void Start()
    {

    }

    private void OnMouseDown()
    {
        show = true;

        next_round.allow_next = 1;

        // loop through answer_path & reveal answer
        // turn off all first
        foreach (GameObject node in nodes)
        {
            circle_render = node.GetComponent<Renderer>();
            circle_render.enabled = false;
        }

        // turn on answer nodes
        foreach (GameObject node in nodes)
        {
            if (round_scoring.answer_path.Contains(node.name.Replace("selected", "")))
            {
                circle_render = node.GetComponent<Renderer>();
                circle_render.enabled = true;
            }
        }
    }
}
