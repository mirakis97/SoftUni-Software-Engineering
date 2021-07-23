namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Data : IRepository
    {
        private PriorityQueue<IEntity> queue;
        private Dictionary<int, IEntity> dictonary;

        private Dictionary<int, List<IEntity>> parents;
        public Data()
        {
            queue = new PriorityQueue<IEntity>();
            dictonary = new Dictionary<int, IEntity>();
            parents = new Dictionary<int, List<IEntity>>();
        }
        public Data(PriorityQueue<IEntity> queue, Dictionary<int, IEntity> dictionary, Dictionary<int, List<IEntity>> parents)
        {
            this.queue = queue;
            this.dictonary = dictonary;
            this.parents = parents;
        }
        public int Size => queue.Size;

        public void Add(IEntity entity)
        {
            queue.Add(entity);
            dictonary.Add(entity.Id, entity);
            if (entity.ParentId != null)
            {
                if (!parents.ContainsKey((int)entity.ParentId))
                {
                    parents.Add((int)entity.ParentId, new List<IEntity>());
                }
                parents[(int)entity.ParentId].Add(entity);
            }
        }

        public IRepository Copy()
        {
            return new Data(queue, dictonary, parents);
        }

        public IEntity DequeueMostRecent()
        {
            if (queue.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
            var element = queue.Dequeue();
            dictonary.Remove(element.Id);
            return element;
        }

        public List<IEntity> GetAll()
        {
            return queue.ToList;
        }

        public List<IEntity> GetAllByType(string type)
        {
            if (!(type == "User" || type == "StoreClient" || type == "Invoice"))
            {
                throw new InvalidOperationException($"Invalid type: " + type);
            }
            return queue.ToList.Where(e => e.GetType().Name == type).ToList();
        }

        public IEntity GetById(int id)
        {
            if (!dictonary.ContainsKey(id))
            {
                return null;
            }
            return dictonary[id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            if (!parents.ContainsKey(parentId))
            {
                return new List<IEntity>();
            }
            return parents[parentId];
        }

        public IEntity PeekMostRecent()
        {
            if (queue.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
            return queue.Peek();
        }
    }
}
