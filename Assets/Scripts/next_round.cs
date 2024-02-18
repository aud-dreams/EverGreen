using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class next_round : MonoBehaviour
{
    public TMP_Text textAB;
    public TMP_Text textBC;
    public TMP_Text textAD;
    public TMP_Text textDE;
    public TMP_Text textBE;
    public TMP_Text textEF;
    public TMP_Text textCF;
    public GameObject finish_on;
    public GameObject finish_off;
    public static int allow_next;
    private static Renderer next_render;

    public GameObject next_round_off;
    private static Renderer next_render_off;
    private static Dictionary<string, int> next_problem;

    public List<GameObject> aliens;
    private Renderer alien_render;
    public GameObject alienA;
    public List<GameObject> circles;
    private Renderer circle_render;
    public GameObject circleA;

    void Start()
    {
        allow_next = 0;
        next_render = GetComponent<Renderer>();
        next_render.enabled = false;

        next_render_off = next_round_off.GetComponent<Renderer>();
        next_render_off.enabled = true;
    }

    void Update()
    {
        if (allow_next == 1)
        {
            next_render.enabled = true;
            next_render_off.enabled = false;
        }

        if (question_bank.question_number == 3)
        {
            finish_on.SetActive(true);
            finish_off.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            finish_on.SetActive(false);
            finish_off.SetActive(false);
        }
    }

    private void reset()
    {
        foreach (GameObject alien in aliens)
        {
            alien_render = alien.GetComponent<Renderer>();
            alien_render.enabled = false;
        }

        alien_render = alienA.GetComponent<Renderer>();
        alien_render.enabled = true;

        foreach (GameObject circle in circles)
        {
            circle_render = circle.GetComponent<Renderer>();
            circle_render.enabled = false;
        }

        circle_render = circleA.GetComponent<Renderer>();
        circle_render.enabled = true;
    }

    private void OnMouseDown()
    {
        if (allow_next == 1)
        {
            // set next_problem
            if (question_bank.question_number == 1)
            {
                next_problem = question_bank.problem2;
            }
            else if (question_bank.question_number == 2)
            {
                next_problem = question_bank.problem3;
            }

            if (next_problem.TryGetValue("AB", out int valueAB))
            {
                textAB.text = valueAB.ToString();
            }

            if (next_problem.TryGetValue("BC", out int valueBC))
            {
                textBC.text = valueBC.ToString();
            }

            if (next_problem.TryGetValue("AD", out int valueAD))
            {
                textAD.text = valueAD.ToString();
            }

            if (next_problem.TryGetValue("DE", out int valueDE))
            {
                textDE.text = valueDE.ToString();
            }

            if (next_problem.TryGetValue("EF", out int valueEF))
            {
                textEF.text = valueEF.ToString();
            }

            if (next_problem.TryGetValue("CF", out int valueCF))
            {
                textCF.text = valueCF.ToString();
            }

            if (next_problem.TryGetValue("BE", out int valueBE))
            {
                textBE.text = valueBE.ToString();
            }

            question_bank.question_number++;
            allow_next = 0;
            next_render.enabled = false;
            if (question_bank.question_number != 3)
            {
                next_render_off.enabled = true;
            }
            else
            {
                next_render_off.enabled = false;
            }

            // error handling
            if (float.IsInfinity(round_scoring.score) || float.IsNaN(round_scoring.score))
            {
                round_scoring.score = 0;
            }

            // add to rounds
            game_scoring.rounds.Add(Tuple.Create(round_scoring.score, show_answer.show));

            reset();

            // reset list
            selected_toggle.selectedNodes.Clear();
            selected_toggle.selectedNodes.Add("A");

            show_answer.show = false;
        }
    }
}
