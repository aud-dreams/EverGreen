using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class finish_game : MonoBehaviour
{
    public static float timespent;
    public GameObject finish_game_off;
    private Renderer finish_off_render;
    private Renderer finish_on_render;

    void Start()
    {
        finish_on_render = GetComponent<Renderer>();
        finish_off_render = finish_game_off.GetComponent<Renderer>();

        finish_off_render.enabled = true;
        finish_on_render.enabled = false;
    }

    void Update()
    {
        if (next_round.allow_next == 1)
        {
            finish_off_render.enabled = false;
            finish_on_render.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if (next_round.allow_next == 1)
        {
            timespent = game_scoring.elapsedTime;
            game_scoring.finish_bool = 1;
        }

        // add to rounds
        game_scoring.rounds.Add(Tuple.Create(round_scoring.score, show_answer.show));
    }
}
