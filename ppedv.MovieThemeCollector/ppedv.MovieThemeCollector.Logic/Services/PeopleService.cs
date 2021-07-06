using ppedv.MovieThemeCollector.Contracts;
using ppedv.MovieThemeCollector.Contracts.Exceptions;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using ppedv.MovieThemeCollector.Contracts.Interfaces.Services;

namespace ppedv.MovieThemeCollector.Logic.Services
{
    public class PeopleService : IPeopleService
    {
        public IUnitOfWork UnitOfWork { get; }

        public PeopleService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void DeletePerson(Person personToDelete)
        {
            if (personToDelete.AsActor.Count != 0)
                throw new DeletePersonException(personToDelete, "The Person is an Actor of one or more Movies");
            if (personToDelete.AsDirector.Count != 0)
                throw new DeletePersonException(personToDelete, "The Person is an Director of one or more Movies");

            personToDelete.Debut = null;
            UnitOfWork.GetRepo<Person>().Delete(personToDelete);
            UnitOfWork.Save();
        }
    }
}
