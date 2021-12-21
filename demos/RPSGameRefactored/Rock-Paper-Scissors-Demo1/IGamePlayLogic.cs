namespace Rock_Paper_Scissors_Demo1
{
    public interface IGamePlayLogic
    {
        Choice ValidateUserChoice(string choice);
        Choice GetComputerChoice();
        Player PlayRound(Choice p1Choice, Choice P2Choice);
        Player WinnerYet();

    }
}