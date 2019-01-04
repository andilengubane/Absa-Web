$(function () {
	$.ajax({
		type: "POST",
		url: "/Home/GetDeshbordStatus",
		cache: false,
		success: function (data) {

			var SF = Math.round((data.StrategicFitYes / data.NumberOfApps * 100),2);
			var DR = Math.round((data.DisasterRecoveryYes / data.NumberOfApps * 100),2);
			var backUpsData = Math.round((data.BackUpDataYes / data.NumberOfApps * 100),2);
			var backUpConfig = Math.round((data.BackUpConfigurationYes / data.NumberOfApps * 100),2);

			var highAv =  Math.round((data.HighAvailabilityYes / data.NumberOfApps * 100),2);
			var SPOF =  Math.round((data.SPOFYes / data.NumberOfApps * 100),2);
			var HDC =  Math.round((data.HighestDataClassificationYes / data.NumberOfApps * 100),2);
			var DRR =  Math.round((data.DataRetentionRequirementYes / data.NumberOfApps * 100),2);

			var OM =  Math.round((data.OperationalMonitoringYes / data.NumberOfApps * 100),2);
			var SM =  Math.round((data.SecurityMonitoringYes / data.NumberOfApps * 100),2);
			var IOLA =  Math.round((data.InternalOLAYes / data.NumberOfApps * 100),2);
			var ESLA =  Math.round((data.ExternalSLAYes / data.NumberOfApps * 100),2);

			var AD =  Math.round((data.ArchitectureDocumentationYes / data.NumberOfApps * 100),2);
			var OD =  Math.round((data.OparationsDocumentationYes / data.NumberOfApps * 100),2);
			var ITAD =  Math.round((data.IntegratedToADYes / data.NumberOfApps * 100),2);
			var JMLP =  Math.round((data.JMLProcessYes / data.NumberOfApps * 100),2);

			var RProcess =  Math.round((data.RecertificationProcessYes / data.NumberOfApps * 100),2);
			var PAM =  Math.round((data.PrivilegedAccessManagementYes / data.NumberOfApps * 100),2);
			var OSPL =  Math.round((data.OSPatchingLevelYes / data.NumberOfApps * 100),2);
			var APL =  Math.round((data.ApplicationPatchingLevelYes / data.NumberOfApps * 100),2);

			var MPL =  Math.round((data.MiddlewarePatchingLevelYes / data.NumberOfApps * 100),2);
			var SA =  Math.round((data.SupportedApplicationYes / data.NumberOfApps * 100),2);
			var SOS =  Math.round((data.SupportedOperationSystemYes / data.NumberOfApps * 100),2);
			var SJ =  Math.round((data.SupportedJavaYes / data.NumberOfApps * 100),2);

			var SML =  Math.round((data.SupportedMiddlewareYes / data.NumberOfApps * 100),2);
			var SDB =  Math.round((data.SupportedDatabaseYes / data.NumberOfApps * 100),2);
			var OV =  Math.round((data.OpenVulnerabilitiesYes / data.NumberOfApps * 100),2);

			var strategicFitData = document.getElementById('SF');
			tacho(strategicFitData, {
				"title": SF + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var disasterRecoverData = document.getElementById('DR');
			tacho(disasterRecoverData, {
				"title": DR + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var backUpData = document.getElementById('backUpsData');
			tacho(backUpData, {
				"title":  backUpsData + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var backUpConfiguration = document.getElementById('backUpConfig');
			tacho(backUpConfiguration, {
				"title":  backUpConfig + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});

			var highAvailability = document.getElementById('highAv');
			tacho(highAvailability, {
				"title":  highAv + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var SinglePointOfFailure = document.getElementById('SPOF');
			tacho(SinglePointOfFailure, {
				"title": SPOF + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var HighestDataClassification = document.getElementById('HDC');
			tacho(HighestDataClassification, {
				"title": HDC + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var DataRetentionRequirement = document.getElementById('DRR');
			tacho(DataRetentionRequirement, {
				"title": DRR + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});


			var OperationalMonitoring = document.getElementById('OM');
			tacho(OperationalMonitoring, {
				"title": OM + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var SecurityMonitoring = document.getElementById('SM');
			tacho(SecurityMonitoring, {
				"title": SM + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var InternalOLA = document.getElementById('IOLA');
			tacho(InternalOLA, {
				"title": IOLA + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var ExternalSLA = document.getElementById('ESLA');
			tacho(ExternalSLA, {
				"title": ESLA + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});

			var ArchictetureDocumentation = document.getElementById('AD');
			tacho(ArchictetureDocumentation, {
				"title": AD + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var OperationalDocumentation = document.getElementById('OD');
			tacho(OperationalDocumentation, {
				"title": OD + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var IntegratedToAD = document.getElementById('ITAD');
			tacho(IntegratedToAD, {
				"title": ITAD + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var JMLProcess = document.getElementById('JMLP');
			tacho(JMLProcess, {
				"title": JMLP + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});

			var RecertificationProcess = document.getElementById('RProcess');
			tacho(RecertificationProcess, {
				"title": RProcess + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var PrivilegedAccessManagement = document.getElementById('PAM');
			tacho(PrivilegedAccessManagement, {
				"title": PAM + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var OSPatchingLevel = document.getElementById('OSPL');
			tacho(OSPatchingLevel, {
				"title": OSPL + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var ApplicationPatchingLevel = document.getElementById('APL');
			tacho(ApplicationPatchingLevel, {
				"title": APL + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});

			var MiddlewarePatchingLevel = document.getElementById('MPL');
			tacho(MiddlewarePatchingLevel, {
				"title": MPL + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var SupportedApplication = document.getElementById('SA');
			tacho(SupportedApplication, {
				"title": SA + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var SupportedOS = document.getElementById('SOS');
			tacho(SupportedOS, {
				"title": SOS + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var SupportedJava = document.getElementById('SJ');
			tacho(SupportedJava, {
				"title": SJ + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});

			var SupportedMiddleware = document.getElementById('SML');
			tacho(SupportedMiddleware, {
				"title": SML + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var SupportedDatabase = document.getElementById('SDB');
			tacho(SupportedDatabase, {
				"title": SDB + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var OpenVulnerabilities = document.getElementById('OV');
			tacho(OpenVulnerabilities, {
				"title": OV + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});

			strategicFitData.setAttribute('data-val', SF);
			disasterRecoverData.setAttribute('data-val', DR);
			backUpData.setAttribute('data-val', backUpsData);
			backUpConfiguration.setAttribute('data-val', backUpConfig);

			highAvailability.setAttribute('data-val', highAv); 
			SinglePointOfFailure.setAttribute('data-val', SPOF);
			HighestDataClassification.setAttribute('data-val', HDC); 
			DataRetentionRequirement.setAttribute('data-val', DRR);

			OperationalMonitoring.setAttribute('data-val', OM);
			SecurityMonitoring.setAttribute('data-val', SM); 
			InternalOLA.setAttribute('data-val', IOLA); 
			ExternalSLA.setAttribute('data-val', ESLA);

			ArchictetureDocumentation.setAttribute('data-val', AD);
			OperationalDocumentation.setAttribute('data-val', OD); 
			IntegratedToAD.setAttribute('data-val', ITAD); 
			JMLProcess.setAttribute('data-val', JMLP);

			RecertificationProcess.setAttribute('data-val', RProcess);
			PrivilegedAccessManagement.setAttribute('data-val', PAM);
			OSPatchingLevel.setAttribute('data-val', OSPL);
			ApplicationPatchingLevel.setAttribute('data-val', APL); 

			MiddlewarePatchingLevel.setAttribute('data-val', MPL); 
			SupportedApplication.setAttribute('data-val', SA);
			SupportedOS.setAttribute('data-val', SOS); 
			SupportedJava.setAttribute('data-val', SJ);

			SupportedMiddleware.setAttribute('data-val', SML); 
			SupportedDatabase.setAttribute('data-val', SDB); 
			OpenVulnerabilities.setAttribute('data-val', OV);
		}
	});
});