using System;

namespace CleanAPI.Core.Entities
{
    public abstract class AuditableEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        //public virtual void Deactivate()
        //{
        //    IsActive = false;
        //}
        //public virtual void Activate()
        //{
        //    IsActive = true;
        //}
        //public virtual void CreateEntity()
        //{
        //    CreatedOn = DateTime.Now;
        //}
        //public virtual void CreateEntity(string createdBy)
        //{
        //    CreatedBy = createdBy;
        //    CreatedOn = DateTime.Now;
        //}
        //public virtual void UpdateEntity(string updateBy)
        //{
        //    UpdatedBy = updateBy;
        //    UpdatedOn = DateTime.Now;
        //}
    }
}
