
      $(function () {
        	$("#dialogStrategicFit").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Strategic Fit",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550,
        		close: function () {
        			window.location.reload(true);
        		}
        	});
        	$("#stategicFit .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/StrategicFit",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogStrategicFit').html(response);
        				$('#dialogStrategicFit').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogDisasterRecovery").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Disaster Recovery",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550,
				close: function () {
        			window.location.reload(true);
        		}

        	});
        	$('#dialog').dialog("refresh");
        	$("#disasterRecovery .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/DisasterRecovery",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogDisasterRecovery').html(response);
        				$('#dialogDisasterRecovery').dialog('open');
        				
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}

        		});
        	});
        });

        $(function () {
        	$("#dialogBackUpData").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "BackUp - Data",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#backUpData .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/BackUpData",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogBackUpData').html(response);
        				$('#dialogBackUpData').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogBackUpConfiguration").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "BackUp - Configuration",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#backUpConfiguration .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/BackUpConfiguration",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogBackUpConfiguration').html(response);
        				$('#dialogBackUpConfiguration').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogHighAvailability").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "High Availability",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#highAvailability .ViewReport").click(function () {
        		debugger
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/HighAvailability",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogHighAvailability').html(response);
        				$('#dialogHighAvailability').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogSinglePointOfFailure").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Single Point Of Failure",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#sPOF .ViewReport").click(function () {
        		debugger
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SinglePointOfFailure",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSinglePointOfFailure').html(response);
        				$('#dialogSinglePointOfFailure').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogHighestDataClassification").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Highest Data Classification",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#highestDataClassification .ViewReport").click(function () {
        		debugger
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/HighestDataClassification",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogHighestDataClassification').html(response);
        				$('#dialogHighestDataClassification').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogDataRetentionRequirement").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Data Retention Requirement",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#dataRetentionRequirement .ViewReport").click(function () {
        		debugger
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/DataRetentionRequirement",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogDataRetentionRequirement').html(response);
        				$('#dialogDataRetentionRequirement').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogOperationalMonitoring").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Operational Monitoring",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#operationalMonitoring .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/OperationalMonitoring",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogOperationalMonitoring').html(response);
        				$('#dialogOperationalMonitoring').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogSecurityMonitoring").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Security Monitoring",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#securityMonitoring .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SecurityMonitoring",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSecurityMonitoring').html(response);
        				$('#dialogSecurityMonitoring').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogInternalOLA").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Internal OLA",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#internalOLA .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/InternalOLA",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogInternalOLA').html(response);
        				$('#dialogInternalOLA').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogExternalSLA").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "External SLA",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#externalSLA .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/ExternalSLA",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogExternalSLA').html(response);
        				$('#dialogExternalSLA').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });


        $(function () {
        	$("#dialogArchictetureDocumentation").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Archicteture Documentation",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#archictetureDocumentation .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/ArchictetureDocumentation",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogArchictetureDocumentation').html(response);
        				$('#dialogArchictetureDocumentation').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogOperationalDocumentation").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Operational Documentation",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#operationalDocumentation .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/OperationalDocumentation",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogOperationalDocumentation').html(response);
        				$('#dialogOperationalDocumentation').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogIntegratedtoAD").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Integrated to AD",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#integratedtoAD .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/IntegratedtoAD",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogIntegratedtoAD').html(response);
        				$('#dialogIntegratedtoAD').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogJMLProcess").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "JML Process",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#jmlProcess .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/JMLProcess",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogJMLProcess').html(response);
        				$('#dialogJMLProcess').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogRecertificationProcess").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "RecertificationProcess",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#recertificationProcess .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/RecertificationProcess",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogRecertificationProcess').html(response);
        				$('#dialogRecertificationProcess').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogPrivilegedAccessManagement").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Privileged Access Management",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#privilegedAccessManagement .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/PrivilegedAccessManagement",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogPrivilegedAccessManagement').html(response);
        				$('#dialogPrivilegedAccessManagement').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogOSPatchingLevel").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "OS Patching Level",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#osPatchingLevel .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/OSPatchingLevel",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogOSPatchingLevel').html(response);
        				$('#dialogOSPatchingLevel').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogApplicationPatchingLevel").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Application Patching Level",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#applicationPatchingLevel .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/ApplicationPatchingLevel",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogApplicationPatchingLevel').html(response);
        				$('#dialogApplicationPatchingLevel').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogMiddlewarePatchingLevel").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Middleware Patching Level",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#middlewarePatchingLevel .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/MiddlewarePatchingLevel",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogMiddlewarePatchingLevel').html(response);
        				$('#dialogMiddlewarePatchingLevel').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogSupportedApplication").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Supported Application",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#supportedApplication .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SupportedApplication",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSupportedApplication').html(response);
        				$('#dialogSupportedApplication').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });


        $(function () {
        	$("#dialogSupportedOS").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Supported OS",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#supportedOS .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SupportedOperationSystem",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSupportedOS').html(response);
        				$('#dialogSupportedOS').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogSupportedJava").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Supported Java",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#supportedJava .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SupportedJava",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSupportedJava').html(response);
        				$('#dialogSupportedJava').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogSupportedMiddleware").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Supported Middleware",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#supportedMiddleware .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SupportedMiddleware",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSupportedMiddleware').html(response);
        				$('#dialogSupportedMiddleware').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogSupportedDatabase").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Supported Database",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#supportedDatabase .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/SupportedDatabase",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogSupportedDatabase').html(response);
        				$('#dialogSupportedDatabase').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });

        $(function () {
        	$("#dialogOpenVulnerabilities").dialog({
        		autoOpen: false,
        		modal: true,
        		title: "Open Vulnerabilities",
        		dialogClass: 'titleColor',
        		width: 700,
        		height: 550
        	});
        	$("#openVulnerabilities .ViewReport").click(function () {
        		$.ajax({
        			type: "POST",
        			url: "/DashBord/OpenVulnerabilities",
        			contentType: "application/json; charset=utf-8",
        			dataType: "html",
        			success: function (response) {
        				$('#dialogOpenVulnerabilities').html(response);
        				$('#dialogOpenVulnerabilities').dialog('open');
        			},
        			failure: function (response) {
        				alert(response.responseText);
        			},
        			error: function (response) {
        				alert(response.responseText);
        			}
        		});
        	});
        });