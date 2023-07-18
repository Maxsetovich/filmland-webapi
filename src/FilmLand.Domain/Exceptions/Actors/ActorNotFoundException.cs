namespace FilmLand.Domain.Exceptions.Actors;

public class ActorNotFoundException : NotFoundException
{
    public ActorNotFoundException()
    {
        this.TitleMessage = "Actor not found!";
    }
}
