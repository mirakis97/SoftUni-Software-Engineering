namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations.ToList().AsReadOnly();

        public void Add(IDecoration model) => this.decorations.Add(model);

        public IDecoration FindByType(string type) => this.Models.FirstOrDefault(d => d.GetType().Name == type);

        public bool Remove(IDecoration model) => this.decorations.Remove(model);
    }
}
