(function () {
	$(function () {
		var _vehicleService = abp.services.app.vehicle;
		var _$modal = $('#VehicleCreateModal');
		var _$form = _$modal.find('form');

		//_$form.validate({
		//	rules: {
		//		Name: "required",
		//	}
		//});

		// 新增車輛
		_$form.find('button[type="submit"]').click(function (e) {
			e.preventDefault();

			// 進行驗證
			if (!_$form.valid()) {
				return;
			}
			debugger
			// 取得物件
			var vehicle = _$form.serializeFormToObject();
			console.log(vehicle)
			console.log(_vehicleService)
			// call service, add person
			abp.ui.setBusy(_$modal);
			_vehicleService.addVehicle(vehicle).done(function (result) {
				
				if (result.isSuccess) {
					abp.message.success(result.message, result.title).then(function () {
						_$modal.modal('hide');
						location.reload(true);
					});
				}
				else {
					abp.message.error(result.message, result.title).then(function () {
					});
				}
			}).always(function () {
				abp.ui.clearBusy(_$modal);
			});
		});

		$('#RefreshButton').click(function () {
			refreshPersonList();
		});

		// 刪除車輛
		$('.delete-vehicle').click(function () {
			var vehicleId = $(this).attr("data-vehicle-id");
			deleteVehicle(vehicleId);
		});

		$('.edit-vehicle').click(function (e) {
			var vehicleId = $(this).attr("data-vehicle-id");

			e.preventDefault();
			abp.ajax({
				url: abp.appPath + 'Vehicle/EditvehicleModal?vehicleId=' + vehicleId,
				type: 'POST',
				dataType: 'html',
				success: function (content) {
					debugger;
					console.log(content);
					$('#VehicleEditModal div.modal-content').html(content);
				},
				error: function (e) { }
			});
		});

		/**
		* 重新整理車輛清單
		*/
		function refreshPersonList() {
			location.reload(true);
		}

		/**
	    * 刪除車輛
		* @param vehicleId 車輛 ID
		*/
		function deleteVehicle(vehicleId) {
			abp.message.confirm(null,
				"確定要刪除嗎?",
				function (isConfirmed) {
					if (isConfirmed) {
						_vehicleService.deleteVehicle(vehicleId).done(function (result) {
							if (result.isSuccess) {
								abp.message.success(result.message, result.title).then(function () {
									refreshPersonList();
								});
							}
							else {
								abp.message.error(result.message, result.title).then(function () {
								});
							}
						});
					}
				}
			);
		}

		_vehicleService.getRegisterPerson().done(function (data) {
			data = $.map(data, function (item, a) {
				return "<option value=" + item.id + ">" + item.name + "</option>";
			});
			$("#ddlPerson").append(data.join("")).selectpicker('refresh').selectpicker('render');
		});



		_vehicleService.getVehicleType().done(function (data) {
			data = $.map(data, function (item, a) {
				return "<option value=" + item.key + ">" + item.value + "</option>";
			});
			$("#ddlVehicleType").append(data.join("")).selectpicker('refresh').selectpicker('render');
		});

		
	});
})();