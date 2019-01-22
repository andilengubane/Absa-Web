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
        public virtual DbSet<DataLookUp> DataLookUps { get; set; }
        public virtual DbSet<LookUpName> LookUpNames { get; set; }
        public virtual DbSet<ResilienceTrack> ResilienceTracks { get; set; }
        public virtual DbSet<ResilinceApplication> ResilinceApplications { get; set; }
        public virtual DbSet<RolesPermission> RolesPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int AddUser(string firstName, string lastName, string emailAddress, string userName, string contactNumber, Nullable<bool> isActive, Nullable<int> rolesPermissionsID, Nullable<int> businessUnitId, string password)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("ContactNumber", contactNumber) :
                new ObjectParameter("ContactNumber", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var rolesPermissionsIDParameter = rolesPermissionsID.HasValue ?
                new ObjectParameter("RolesPermissionsID", rolesPermissionsID) :
                new ObjectParameter("RolesPermissionsID", typeof(int));
    
            var businessUnitIdParameter = businessUnitId.HasValue ?
                new ObjectParameter("BusinessUnitId", businessUnitId) :
                new ObjectParameter("BusinessUnitId", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", firstNameParameter, lastNameParameter, emailAddressParameter, userNameParameter, contactNumberParameter, isActiveParameter, rolesPermissionsIDParameter, businessUnitIdParameter, passwordParameter);
        }
    
        public virtual ObjectResult<GetAllUsersList_Result> GetAllUsersList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUsersList_Result>("GetAllUsersList");
        }
    
        public virtual ObjectResult<GetApplicationByResilienceID_Result> GetApplicationByResilienceID(Nullable<int> resilinceId)
        {
            var resilinceIdParameter = resilinceId.HasValue ?
                new ObjectParameter("ResilinceId", resilinceId) :
                new ObjectParameter("ResilinceId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetApplicationByResilienceID_Result>("GetApplicationByResilienceID", resilinceIdParameter);
        }
    
        public virtual ObjectResult<GetApplicationToDecline_Result> GetApplicationToDecline(Nullable<int> resilinceId)
        {
            var resilinceIdParameter = resilinceId.HasValue ?
                new ObjectParameter("ResilinceId", resilinceId) :
                new ObjectParameter("ResilinceId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetApplicationToDecline_Result>("GetApplicationToDecline", resilinceIdParameter);
        }
    
        public virtual ObjectResult<GetAppStatus_Result> GetAppStatus(Nullable<int> businessUnitId)
        {
            var businessUnitIdParameter = businessUnitId.HasValue ?
                new ObjectParameter("BusinessUnitId", businessUnitId) :
                new ObjectParameter("BusinessUnitId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAppStatus_Result>("GetAppStatus", businessUnitIdParameter);
        }
    
        public virtual ObjectResult<string> GetBusinessUnitByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetBusinessUnitByUserId", userIdParameter);
        }
    
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
    
        public virtual ObjectResult<GetUserById_Result> GetUserById(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserById_Result>("GetUserById", userIdParameter);
        }
    
        public virtual int UpdateUser(Nullable<int> userId, string firstName, string lastName, string emailAddress, string userName, string contactNumber, Nullable<bool> isActive, Nullable<int> rolesPermissionsID, Nullable<int> businessUnitId, string password)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("ContactNumber", contactNumber) :
                new ObjectParameter("ContactNumber", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var rolesPermissionsIDParameter = rolesPermissionsID.HasValue ?
                new ObjectParameter("RolesPermissionsID", rolesPermissionsID) :
                new ObjectParameter("RolesPermissionsID", typeof(int));
    
            var businessUnitIdParameter = businessUnitId.HasValue ?
                new ObjectParameter("BusinessUnitId", businessUnitId) :
                new ObjectParameter("BusinessUnitId", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUser", userIdParameter, firstNameParameter, lastNameParameter, emailAddressParameter, userNameParameter, contactNumberParameter, isActiveParameter, rolesPermissionsIDParameter, businessUnitIdParameter, passwordParameter);
        }
    
        public virtual ObjectResult<GetStatus_Result> GetStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStatus_Result>("GetStatus");
        }
    
        public virtual ObjectResult<GetBusinessUnit_Result> GetBusinessUnit()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBusinessUnit_Result>("GetBusinessUnit");
        }
    }
}
