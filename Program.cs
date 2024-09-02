﻿using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        Dictionary<string, List<Exibition>> exibitions = Exibitions.ToObject();
        Dictionary<string, List<Group>> groups = Groups.ToObject();

        List<TeamScore> groupPhase = new List<TeamScore>();
        GroupBoard.Create(groupPhase, exibitions);

        GroupPhase.Play(groups, exibitions, groupPhase);

        GroupBoard.Print(groupPhase);


    }
}