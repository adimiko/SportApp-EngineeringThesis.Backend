namespace Application.Commands.CompletedWorkout
{
    public class CreateCompletedSet : ICommand
    {
        public int Order {get; set;}
        public int Reps {get; set;}
        public float Weight {get; set;}
    }
}