$(function () {
	var submitAutoCompleteForm = function (event, ui) {
		var $input = $(this);
		$input.val(ui.item.label);

		var $form = $input.parents("form:first");
		$form.submit();
	}
	var ajaxFormSubmit = function () {
		var $form = $(this);

		var options = {
			url: $form.attr("action"),		//controller and action to go to when submit action is performed
			type: $form.attr("method"),		//Type of request
			data: $form.serialize(),		//data from the form
		};

		$.ajax(options).done(function (data) {		//data returned fromthe server
			var $target = $($form.attr("data-projectX-target"));
			$target.replaceWith(data);
		});
		return false;		//to prevent browser from doing its default action and navigating away to server.
	};
	var createAutoComplete = function () {
		var $input = $(this);

		var options = {
			source: $input.attr("data-projectX-autoComplete"),
			select: submitAutoCompleteForm
		};
		$input.autocomplete(options);
	}
	var getAsyncPage = function () {
		var $a = $(this)

		var options = {
			url: $a.attr("href"),		//controller and action to go to when submit action is performed
			type: "get"		//Type of request
		};

		$.ajax(options).done(function (data) {		//data returned fromthe server
			var target = $a.parents("div.pagedList").attr("data-projectX-target");
			$(target).replaceWith(data);
		});
		return false;		//to prevent browser from doing its default action and navigating away to server.
	};
	$("form[data-projectX-ajax='true']").submit(ajaxFormSubmit);	//async get request
	$("input[data-projectX-autoComplete]").each(createAutoComplete); //AutoCompete form with autoSubmission on clicking one
	$(".main-content").on("click", ".pagedList a", getAsyncPage);
});

