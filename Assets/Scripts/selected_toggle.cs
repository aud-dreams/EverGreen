using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_toggle : MonoBehaviour
{
    public GameObject alien;
    private Renderer alien_render;
    private Renderer circle_render;
    public List<Renderer> alienRenderers;

    public static List<string> selectedNodes = new List<string>();

    void Start()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("alien");
        foreach (GameObject alien in aliens)
        {
            alien_render = alien.GetComponent<Renderer>();
            alienRenderers.Add(alien_render);
        }

        alien_render = alien.GetComponent<Renderer>();
        circle_render = GetComponent<Renderer>();

        if (gameObject.name != "selectedA")
        {
            alien_render.enabled = false;
            circle_render.enabled = false;
        }

        // add node A
        if (gameObject.name == "selectedA")
        {
            selectedNodes.Add("A");
        }
    }

    private void OnMouseDown()
    {
        if (show_answer.show != true)
        {
            // toggle the other alien off
            if (alien_render.enabled == false)
            {
                foreach (Renderer renderer in alienRenderers)
                {
                    renderer.enabled = false;
                }
            }

            // turn node's alien & circle on
            if (alien_render.enabled == false && circle_render.enabled == false)
            {
                alien_render.enabled = true;
                circle_render.enabled = true;
                selectedNodes.Add(gameObject.name.Replace("selected", ""));
            }

            if (gameObject.name == "selectedF")
            {
                round_scoring.CheckScore(selectedNodes);
            }
        }
    }
}