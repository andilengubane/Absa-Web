﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Absa.DateAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AbsaDBEntities : DbContext
    {
        public AbsaDBEntities()
            : base("name=AbsaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<BusinessUnitAudit> BusinessUnitAudits { get; set; }
        public virtual DbSet<DataLookUp> DataLookUps { get; set; }
        public virtual DbSet<LookUpName> LookUpNames { get; set; }
        public virtual DbSet<ResilienceTrack> ResilienceTracks { get; set; }
        public virtual DbSet<ResilienceTrackAudit> ResilienceTrackAudits { get; set; }
        public virtual DbSet<RolesPermission> RolesPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersAudit> UsersAudits { get; set; }
    
        public virtual ObjectResult<GetResilienceTrackList_Result> GetResilienceTrackList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetResilienceTrackList_Result>("GetResilienceTrackList");
        }
    
        public virtual ObjectResult<GetResilienceTrackListById_Result> GetResilienceTrackListById(Nullable<int> resilienceTrackID)
        {
            var resilienceTrackIDParameter = resilienceTrackID.HasValue ?
                new ObjectParameter("ResilienceTrackID", resilienceTrackID) :
                new ObjectParameter("ResilienceTrackID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetResilienceTrackListById_Result>("GetResilienceTrackListById", resilienceTrackIDParameter);
        }
    
        public virtual ObjectResult<GetUsersList_Result> GetUsersList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUsersList_Result>("GetUsersList");
        }
    
        public virtual ObjectResult<string> GetBusinessUnitByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetBusinessUnitByUserId", userIdParameter);
        }
    }
}
