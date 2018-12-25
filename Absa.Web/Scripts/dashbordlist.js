//$(function () {
function getStrategicFit() {
	$("#dialogStrategic").dialog({
		autoOpen: false,
		modal: true,
		title: "Strategic Fit Report",
		width: 800,
		height: 550
	});
	$("#dashBordlist .strategicfit").click(function () {
		debugger
		$.ajax({
			type: "POST",
			url: "/DashBord/StrategicFit",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (response) {
				$('#dialogStrategic').html(response);
				$('#dialogStrategic').dialog('open');
			},
			failure: function (response) {
				alert(response.responseText);
			},
			error: function (response) {
				alert(response.responseText);
			}
		});
	});
}
//});