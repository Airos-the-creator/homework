using System;
using System.Linq;
using Newtonsoft.Json;
using SimonsVoss.CodingCase.Logic;
using SimonsVoss.CodingCase.Logic.Model;

namespace SimonsVoss.CodingCase.Data
{
    public class DataRepository : IDataRepository
    {
        public IQueryable<Building> Buildings { get; set; } = new List<Building>().AsQueryable();
        public IQueryable<Lock> Locks { get; set; } = new List<Lock>().AsQueryable();
        public IQueryable<Medium> Media { get; set; } = new List<Medium>().AsQueryable();
        public IQueryable<Group> Groups { get; set; } = new List<Group>().AsQueryable();

        private ILookup<Guid, Building> buildingsLookup;
        private ILookup<Guid, Lock> locksLookup;
        private ILookup<Guid, Medium> mediaLookup;
        private ILookup<Guid, Group> groupsLookup;

        public IQueryable<QueryableEntity> QueryableEntities => (Buildings as IQueryable<QueryableEntity>)
            .Union(Locks as IQueryable<QueryableEntity>)
            .Union(Media as IQueryable<QueryableEntity>)
            .Union(Groups as IQueryable<QueryableEntity>);

        public DataRepository()
        {
        }

        public void Initialize()
        {
            InitializeLookups();

            SetNavigationProperties();
        }

        private void SetNavigationProperties()
        {
            foreach (var lockEntity in Locks)
            {
                lockEntity.BuildingOfLock = buildingsLookup[lockEntity.BuildingId].First();
            }

            foreach (var medium in Media)
            {
                medium.GroupOfMedium = groupsLookup[medium.GroupId].First();
            }
        }

        private void InitializeLookups()
        {
            this.buildingsLookup = Buildings.ToLookup(b => b.Id);
            this.groupsLookup = Groups.ToLookup(g => g.Id);
            this.locksLookup = Locks.ToLookup(l => l.Id);
            this.mediaLookup = Media.ToLookup(m => m.Id);
        }

        public QueryableEntity? GetById(Guid id)
        {
            QueryableEntity? result = buildingsLookup[id].FirstOrDefault();
            if (result != null)
            {
                return result;
            }

            result = groupsLookup[id].FirstOrDefault();
            if (result != null)
            {
                return result;
            }

            result = locksLookup[id].FirstOrDefault();
            if (result != null)
            {
                return result;
            }

            result = mediaLookup[id].FirstOrDefault();
            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}

