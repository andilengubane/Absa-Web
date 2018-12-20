$(function () {
	$.ajax({
		type: "POST",
		//url: "/Home/GetAppStatusOverRall",
		cache: false,
		success: function (result) {

			var data = (result);
			//var json = JSON.parse(data);
			//jsonsData = json.issues;
			//console.log(jsonsData);
			var strategicFit = 5;
			var disasterRecover = 10;
			var backUpsData = 15;
			var backUpConfig = 20;

			var highAv = 25
			var SPOF = 30;
			var HDC = 35;
			var DRR = 40;

			var OM = 45;
			var SM = 50;
			var IOLA = 55;
			var ESLA = 60;

			var AD = 65;
			var OD = 70;
			var ITAD = 75;
			var JMLP = 80;

			var RProcess = 85;
			var PAM = 90;
			var OSPL = 95;
			var APL = 100;

			var MPL = 6;
			var SA = 12;
			var SOS = 18;
			var SJ = 24;

			var SML = 32;
			var SDB = 38;
			var OV = 46;
			//for (var i = 0; i < jsonsData.length; i++) {
			//	if ((jsonsData[i].fields.customfield_12807.value) === "Sev 1") {
			//		serv1++;
			//	} else if ((jsonsData[i].fields.customfield_12807.value) === "Sev 2") {
			//		serv2++;
			//	} else if ((jsonsData[i].fields.customfield_12807.value) === "Sev 3 med") {
			//		serv3M++;
			//	} else if ((jsonsData[i].fields.customfield_12807.value) === "Sev 3 low") {
			//		serv3L++;
			//	} else if ((jsonsData[i].fields.customfield_12807.value) === "Sev 3 High") {
			//		serv3H++;
			//	} else if ((jsonsData[i].fields.customfield_12807.value) === "Sev 4") {
			//		serv4++;
			//	}
			//}

			var strategicFitData = document.getElementById('strategicFit');
			tacho(strategicFitData, {
				"title":  strategicFit + "%",
				"max": 100,
				"markInterval": 20,
				"bigMarkInterval": 10,
				"redLinePoint": 0.85,
				"autoScale": true
			});
			var disasterRecoverData = document.getElementById('disasterRecover');
			tacho(disasterRecoverData, {
				"title": disasterRecover + "%",
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
		

			strategicFitData.setAttribute('data-val', strategicFit);
			disasterRecoverData.setAttribute('data-val', disasterRecover);
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

			// var demoInput = document.getElementById('demoInput');
			//var elements = document.getElementById("myValues");
			// elements.value =  serv3H;  
			// elements=elements.val(serv3L);
			//  var elements =  document.getElementById("serv3M");
			// elements.innerHTML =  serv3M;
			//   var elements =  document.getElementById("serv3H");
			// elements.innerHTML =  serv3H;
			// var elements =  document.getElementById("serv1");
			// elements.innerHTML =  serv1;
			//    var gaugeChart = AmCharts.makeChart( "chartdiv", {
			//   "type": "gauge",
			//   "theme": "light",
			//   "axes": [ {
			//     "axisThickness": 1,
			//     "axisAlpha": 0.2,
			//     "tickAlpha": 0.2,
			//     "valueInterval": 20,
			//     "bands": [ {
			//       "color": "#84b761",
			//       "endValue": 90,
			//       "startValue": 0
			//     }, {
			//       "color": "#fdd400",
			//       "endValue": 130,
			//       "startValue": 90
			//     }, {
			//       "color": "#cc4748",
			//       "endValue": 220,
			//       "innerRadius": "95%",
			//       "startValue": 130
			//     } ],
			//     "bottomText": "0 km/h",
			//     "bottomTextYOffset": -20,
			//     "endValue": 220
			//   } ],
			//   "arrows": [ {} ],
			//   "export": {
			//     "enabled": true
			//   }
			// } );

			// setInterval( randomValue, 2000 );

			// set random value
			// function randomValue() {
			//   var value = serv3H;
			//   if ( gaugeChart ) {
			//     if ( gaugeChart.arrows ) {
			//       if ( gaugeChart.arrows[ 0 ] ) {
			//         if ( gaugeChart.arrows[ 0 ].setValue ) {
			//           gaugeChart.arrows[ 0 ].setValue( value );
			//           gaugeChart.axes[ 0 ].setBottomText( value + " MIM's " );
			//         }
			//       }
			//     }
			//   }
			// }
		}
	});
});