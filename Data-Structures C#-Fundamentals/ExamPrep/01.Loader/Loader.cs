namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;
        public Loader()
        {
            entities = new List<IEntity>();
        }
        public int EntitiesCount => entities.Count;

        public void Add(IEntity entity)
        {
            entities.Add(entity);
        }

        public void Clear()
        {
            entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return entities.Contains(entity);
        }

        public IEntity Extract(int id)
        {
            IEntity entity = FindById(id);
            if (entity != null)
            {
                 entities.Remove(entity);
            }

            return entity;
        }

        public IEntity Find(IEntity entity)
        {
            return FindByEntity(entity);
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(entities);
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public void RemoveSold()
        {
            List<IEntity> withoutSold = new List<IEntity>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status != BaseEntityStatus.Sold)
                {
                    withoutSold.Add(entities[i]);
                }
            }
            entities =  withoutSold;
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int firstEntitiyIndex = entities.IndexOf(oldEntity);

            CheckValidIndex(firstEntitiyIndex, "Entity not found");

            entities[firstEntitiyIndex] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            List<IEntity> inBount = new List<IEntity>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status >= lowerBound && entities[i].Status <= upperBound)
                {
                    inBount.Add(entities[i]);
                }
            }
            return inBount;
        }

        public void Swap(IEntity first, IEntity second)
        {
            int firstEntitiyIndex = entities.IndexOf(first);
            int secondEntitiyIndex = entities.IndexOf(second);

            CheckValidIndex(firstEntitiyIndex, "Entity not found");
            CheckValidIndex(secondEntitiyIndex, "Entity not found");

            IEntity temp = entities[firstEntitiyIndex];
            entities[firstEntitiyIndex] = entities[secondEntitiyIndex];
            entities[secondEntitiyIndex] = temp;
        }

        public IEntity[] ToArray()
        {
            return entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status == oldStatus)
                {
                    entities[i].Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }
        private IEntity FindById(int id)
        {

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Id == id)
                {
                    return entities[i];
                }
            }

            return null;
        }
        private IEntity FindByEntity(IEntity entity)
        {
            int index = entities.IndexOf(entity);
            if (index >= 0)
            {
                return entities[index];
            }

            return null;
        }
        private void CheckValidIndex(int index, string message)
        {
            if (index < 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
