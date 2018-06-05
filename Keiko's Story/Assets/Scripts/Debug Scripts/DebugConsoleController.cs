using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugConsoleController : MonoBehaviour {

    enum Commands { exit, give, tgm, take};

    private string command = "";
    private string[] args = null;

    private bool shown = false;

    private bool height;
    private bool width;

    private string consoleLog;
    private string consoleLine;

	// Use this for initialization
	void Start (){

    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            shown = !shown;
        }

        if(shown && Input.GetKeyDown(KeyCode.Return) && command != "")
        {
            //Process the command and reset the commands and args
            consoleLog += "\n";
            consoleLog += consoleLine;

            string[] proc = consoleLine.Split(' ');

            command = proc[0];

            for(int i = 1; i < proc.Length; i++)
            {
                args[i - 1] = proc[i];
            }

            SendCommand(command, args);
            command = "";
            if(args != null)
            {
                args = null;
            }
        }
	}

    void SendCommand(string command, string[] args)
    {

        Commands c = (Commands)Enum.Parse(typeof(Commands), command);

        switch (c)
        {
            case Commands.exit:
            {
                break;
            }
            case Commands.give:
            {
                break;
            }
            case Commands.take:
            {
                break;
            }
            case Commands.tgm:
            {
                break;
            }
            default:
            {
                break;
            }
        }
    }

}
