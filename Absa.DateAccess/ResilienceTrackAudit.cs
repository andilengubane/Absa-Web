//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ResilienceTrackAudit
    {
        public int ResilienceTrackAuditID { get; set; }
        public Nullable<int> ResilienceTrackID { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public string NameOnSnow { get; set; }
        public string HeadOfTechnology { get; set; }
        public string ApplicatioOwner { get; set; }
        public string ServiceManager { get; set; }
        public Nullable<long> Tiering { get; set; }
        public string StrategicFit { get; set; }
        public string DisasterRecovery { get; set; }
        public string BackUpData { get; set; }
        public string BackUpConfiguration { get; set; }
        public string HighAvailability { get; set; }
        public string SPOF { get; set; }
        public string SecurityMonitoring { get; set; }
        public string InternalOLA { get; set; }
        public string ExternalSLA { get; set; }
        public string ArchitetureDocumentation { get; set; }
        public string OparationsDocumentation { get; set; }
        public string HighestDataClassification { get; set; }
        public string DataRetentionRequirement { get; set; }
        public string IntegratedToAD { get; set; }
        public string JMLProcess { get; set; }
        public string RecertificationProcess { get; set; }
        public string PrivilegedAccessManagement { get; set; }
        public string OSPatchingLevel { get; set; }
        public string ApplicationPatchingLevel { get; set; }
        public string MiddlewarePatchingLevel { get; set; }
        public string SupportedApplication { get; set; }
        public string SupportedOperationSystem { get; set; }
        public string SupportedJava { get; set; }
        public string SupportedMiddleware { get; set; }
        public string SupportedDatabase { get; set; }
        public string OpenVulnerabilities { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string OperationalMonitoring { get; set; }
    
        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}
