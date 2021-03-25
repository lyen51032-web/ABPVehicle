(function ($) {
	var _vehicleService = abp.services.app.vehicle;
	var _$modal = $('#VehicleListModel');
	var _$form = $('form[name=VehicleEditForm]');

	function save() {
		if (!_$form.valid()) {
			return;
		}

		var role = _$form.serializeFormToObject();
		console.log("error")
		abp.ui.setBusy(_$form);
		_vehicleService.editVehicle(role).done(function () {
			_$modal.modal('hide');
			location.reload(true);
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	}

	_$form.closest('div.modal-content').find(".save-button").click(function (e) {
		e.preventDefault();
		save();
	});

	_$form.find('input').on('keypress', function (e) {
		if (e.which === 13) {
			e.preventDefault();
			save();
		}
	});
})(jQuery);