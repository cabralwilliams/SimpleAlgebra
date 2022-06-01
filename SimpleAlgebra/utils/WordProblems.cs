namespace SimpleAlgebra.utils
{
    public static class WordProblems
    {
        public static string LinearStandard(int count1, int count2, int multiple1, int multiple2, int situationSelector, bool targetFirst = true)
        {
            string output1, output2;

            switch (situationSelector)
            {
                case 0:
                    output1 = $"At a certain fast food restaurant, burgers sell for ${multiple1}, and chicken sandwiches sell for ${multiple2}.  If on a given day, a total of {count1 + count2} burgers and sandwiches were sold, and if these menu options account for ${count1 * multiple1 + count2 * multiple2} in sales, then how many ";
                    if(targetFirst)
                    {
                        output2 = "burgers were sold?";
                    }
                    else
                    {
                        output2 = "chicken sandwiches were sold?";
                    }
                    break;
                case 1:
                    output1 = $"An analysis of programming on a given television station found that each interval of television programming lasted {multiple1} minutes and that each interval of commercial breaks lasted {multiple2} minutes.  If during this analysis, a total of {count1 + count2} intervals were observed, and the analysis lasted {multiple1 * count1 + multiple2 * count2} minutes, then how many ";
                    if (targetFirst)
                    {
                        output2 = "television programming intervals were observed?";
                    }
                    else
                    {
                        output2 = "commercial break intervals were observed?";
                    }
                    break;
                case 2:
                    output1 = $"At a charity banquet, only tables of {multiple2} people and {multiple1} people are used.  If there are a total of {count1 + count2} completely full tables in the hall for the banquet, and a total of {multiple1 * count1 + multiple2 * count2} people attend, then how many ";
                    if(targetFirst)
                    {
                        output2 = $"{multiple1}-person tables were used?";
                    }
                    else
                    {
                        output2 = $"{multiple2}-person tables were used?";
                    }
                    break;
                case 3:
                    output1 = $"In a certain game, a team scored a total of {multiple1 * count1 + multiple2 * count2} points on {count1 + count2} scoring plays.  If all of the team's scoring plays were worth either {multiple1} points or {multiple2} points, then how many ";
                    if (targetFirst)
                    {
                        output2 = $"{multiple1}-point scoring plays did the team have?";
                    }
                    else
                    {
                        output2 = $"{multiple2}-point scoring plays did the team have?";
                    }
                    break;
                default:
                    output1 = $"At a certain fast food restaurant, burgers sell for ${multiple1}, and chicken sandwiches sell for ${multiple2}.  If on a given day, a total of {count1 + count2} burgers and sandwiches were sold, and if these menu options account for ${count1 * multiple1 + count2 * multiple2} in sales, then how many ";
                    if (targetFirst)
                    {
                        output2 = "burgers were sold?";
                    }
                    else
                    {
                        output2 = "chicken sandwiches were sold?";
                    }
                    break;
            }
            return output1 + output2;
        }

        public static string LinearStandard2(int count1, int count2, int multiple1, int multiple2, int situationSelector, bool targetFirst = true)
        {
            string output1, output2;
            switch (situationSelector)
            {
                case 0:
                    output1 = $"At a certain fast food restaurant, burgers sell for ${multiple1}, and chicken sandwiches sell for ${multiple2}.  If on a given day, a total of {count1 + count2} burgers and sandwiches were sold, and if these menu options account for ${count1 * multiple1 + count2 * multiple2} in sales, then how much was spent on ";
                    if (targetFirst)
                    {
                        output2 = "burger purchases?";
                    }
                    else
                    {
                        output2 = "chicken sandwich purchases?";
                    }
                    break;
                case 1:
                    output1 = $"An analysis of programming on a given television station found that each interval of television programming lasted {multiple1} minutes and that each interval of commercial breaks lasted {multiple2} minutes.  If during this analysis, a total of {count1 + count2} intervals were observed, and the analysis lasted {multiple1 * count1 + multiple2 * count2} minutes, then how many total minutes did the ";
                    if (targetFirst)
                    {
                        output2 = "television programming intervals last?";
                    }
                    else
                    {
                        output2 = "commercial break intervals last?";
                    }
                    break;
                case 2:
                    output1 = $"At a charity banquet, only tables of {multiple2} people and {multiple1} people are used.  If there are a total of {count1 + count2} completely full tables in the hall for the banquet, and a total of {multiple1 * count1 + multiple2 * count2} people attend, then how many total people sat at ";
                    if (targetFirst)
                    {
                        output2 = $"{multiple1}-person tables?";
                    }
                    else
                    {
                        output2 = $"{multiple2}-person tables?";
                    }
                    break;
                case 3:
                    output1 = $"In a certain game, a team scored a total of {multiple1 * count1 + multiple2 * count2} points on {count1 + count2} scoring plays.  If all of the team's scoring plays were worth either {multiple1} points or {multiple2} points, then how many total points were scored on ";
                    if (targetFirst)
                    {
                        output2 = $"{multiple1}-point scoring plays by the team?";
                    }
                    else
                    {
                        output2 = $"{multiple2}-point scoring plays by the team?";
                    }
                    break;
                default:
                    output1 = $"At a certain fast food restaurant, burgers sell for ${multiple1}, and chicken sandwiches sell for ${multiple2}.  If on a given day, a total of {count1 + count2} burgers and sandwiches were sold, and if these menu options account for ${count1 * multiple1 + count2 * multiple2} in sales, then how much was spent on ";
                    if (targetFirst)
                    {
                        output2 = "burgers purchases?";
                    }
                    else
                    {
                        output2 = "chicken sandwiches purchases?";
                    }
                    break;
            }
            return output1 + output2;
        }
        public static string LinearStandard3(int count1, int count2, int multiple1, int multiple2, int situationSelector, bool targetFirst = true)
        {
            string output1, output2;
            //Stores the totals for comparison
            int total1 = count1 * multiple1;
            int total2 = count2 * multiple2;
            switch (situationSelector)
            {
                case 0:
                    output1 = $"At a certain fast food restaurant, burgers sell for ${multiple1}, and chicken sandwiches sell for ${multiple2}.  If on a given day, a total of {count1 + count2} burgers and sandwiches were sold, and if these menu options account for ${count1 * multiple1 + count2 * multiple2} in sales, then how much ";
                    if (targetFirst)
                    {
                        if(total1 > total2)
                        {
                            output2 = "more did the combined burgers cost than did the combined chicken sandwiches cost?";
                        }
                        else
                        {
                            output2 = "less did the combined burgers cost than did the combined chicken sandwiches cost?";
                        }
                    }
                    else
                    {
                        if(total1 > total2)
                        {
                            output2 = "less did the combined chicken sandwiches cost than did the combined burgers cost?";
                        }
                        else
                        {
                            output2 = "more did the combined chicken sandwiches cost than did the combined burgers cost?";
                        }
                    }
                    break;
                case 1:
                    output1 = $"An analysis of programming on a given television station found that each interval of television programming lasted {multiple1} minutes and that each interval of commercial breaks lasted {multiple2} minutes.  If during this analysis, a total of {count1 + count2} intervals were observed, and the analysis lasted {multiple1 * count1 + multiple2 * count2} minutes, then how many ";
                    if (targetFirst)
                    {
                        if(total1 > total2)
                        {
                            output2 = "more total minutes consisted of television programming than consisted of commercial breaks?";
                        }
                        else
                        {
                            output2 = "fewer total minutes consisted of television programming than consisted of commercial breaks?";
                        }
                    }
                    else
                    {
                        if (total1 > total2)
                        {
                            output2 = "fewer total minutes consisted of commercial breaks than consisted of television programming?";
                        }
                        else
                        {
                            output2 = "more total minutes consisted of commercial breaks than consisted of television programming?";
                        }
                    }
                    break;
                case 2:
                    output1 = $"At a charity banquet, only tables of {multiple2} people and {multiple1} people are used.  If there are a total of {count1 + count2} completely full tables in the hall for the banquet, and a total of {multiple1 * count1 + multiple2 * count2} people attend, then how many ";
                    if (targetFirst)
                    {
                        if (total1 > total2)
                        {
                            output2 = $"more total people sat at {multiple1}-person tables than sat at {multiple2}-person tables?";
                        }
                        else
                        {
                            output2 = $"fewer total people sat at {multiple1}-person tables than sat at {multiple2}-person tables?";
                        }
                    }
                    else
                    {
                        if (total1 > total2)
                        {
                            output2 = $"fewer total people sat at {multiple2}-person tables than sat at {multiple1}-person tables?";
                        }
                        else
                        {
                            output2 = $"more total people sat at {multiple2}-person tables than sat at {multiple1}-person tables?";
                        }
                    }
                    break;
                case 3:
                    output1 = $"In a certain game, a team scored a total of {multiple1 * count1 + multiple2 * count2} points on {count1 + count2} scoring plays.  If all of the team's scoring plays were worth either {multiple1} points or {multiple2} points, then how many ";
                    if (targetFirst)
                    {
                        if (total1 > total2)
                        {
                            output2 = $"more total points were scored with {multiple1}-point plays than were scored with {multiple2}-point plays?";
                        }
                        else
                        {
                            output2 = $"fewer total points were scored with {multiple1}-point plays than were scored with {multiple2}-point plays?";
                        }
                    }
                    else
                    {
                        if (total1 > total2)
                        {
                            output2 = $"fewer total points were scored with {multiple2}-point plays than were scored with {multiple1}-point plays?";
                        }
                        else
                        {
                            output2 = $"more total points were scored with {multiple2}-point plays than were scored with {multiple1}-point plays?";
                        }
                    }
                    break;
                default:
                    output1 = $"At a certain fast food restaurant, burgers sell for ${multiple1}, and chicken sandwiches sell for ${multiple2}.  If on a given day, a total of {count1 + count2} burgers and sandwiches were sold, and if these menu options account for ${count1 * multiple1 + count2 * multiple2} in sales, then how much ";
                    if (targetFirst)
                    {
                        if (total1 > total2)
                        {
                            output2 = "more did the combined burgers cost than did the combined chicken sandwiches cost?";
                        }
                        else
                        {
                            output2 = "less did the combined burgers cost than did the combined chicken sandwiches cost?";
                        }
                    }
                    else
                    {
                        if (total1 > total2)
                        {
                            output2 = "less did the combined chicken sandwiches cost than did the combined burgers cost?";
                        }
                        else
                        {
                            output2 = "more did the combined chicken sandwiches cost than did the combined burgers cost?";
                        }
                    }
                    break;
            }
            return output1 + output2;
        }

    }
}
