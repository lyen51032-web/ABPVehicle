(function () {
	$(function () {
		var _personService = abp.services.app.person;
		var _$modal = $('#PersonCreateModal');
		var _$form = _$modal.find('form');

		_$form.validate({
			rules: {
				Name: "required",
			}
		});

		// 新增人員
		_$form.find('button[type="submit"]').click(function (e) {
			e.preventDefault();

			// 進行驗證
			if (!_$form.valid()) {
				return;
			}

			// 取得物件
			var person = _$form.serializeFormToObject();

			// call service, add person
			abp.ui.setBusy(_$modal);
			_personService.addPerson(person).done(function (result) {
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

		// 刪除人員
		$('.delete-person').click(function () {
			var personId = $(this).attr("data-person-id");
			var personName = $(this).attr('data-person-name');

			deletePerson(personId, personName);
		});

		/**
		* 重新整理人員清單
		*/
		function refreshPersonList() {
			location.reload(true);
		}

		/**
	    * 刪除人員
		* @param personId 人員 ID
		* @param personName 人員姓名
		*/
		function deletePerson(personId, personName) {
			debugger;	
			abp.message.confirm(null,
				"確定要刪除 '" + personName + "'嗎?",
				function (isConfirmed) {
					if (isConfirmed) {
						_personService.deletePerson(personId).done(function (result) {
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
	});
})();