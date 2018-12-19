$(function () {
	$("#strategicFit").dialog({
		autoOpen: false,
		modal: true,
		title: "Strategic Fit Report",
		width: 800,
		height: 550
	});
	$("#dashBordmodel .ViewReport").click(function () {
		$.ajax({
			type: "POST",
			url: "/DashBord/StrategicFit",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (response) {
				$('#strategicFit').html(response);
				$('#strategicFit').dialog('open');
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
	$("#disaterRecover").dialog({
		autoOpen: false,
		modal: true,
		title: "Disaster Recover",
		width: 800,
		height: 550
	});
	$("#disaterRecover .disaterRecover").click(function () {
		debugger
		$.ajax({
			type: "POST",
			url: "/Home/Report",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (response) {
				$('#disaterRecover').html(response);
				$('#disaterRecover').dialog('open');
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