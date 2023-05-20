using Domain.Interfaces;

namespace Domain.Common
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public virtual T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        //public BaseEntity(T _id) {
        //    Id = _id;
        //}
    }
}
