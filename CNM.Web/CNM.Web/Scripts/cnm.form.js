if (!Cnm){ var Cnm = {}; }

Cnm.Form = (function(){
	function Form(element){
		var s = this;
		s.Form = $(element);
		s.Button = s.Form.find('[type="submit"]');
		s.Init();
	}

	var p = Form.prototype;

	p.Init = function(){
		var s = this;
	};

	p.Enable = function(){
		var s = this;
		s.Form.unbind('submit.search');
		s.Button.removeAttr('disabled');
	};
	
	p.Disable = function(){
		var s = this;
		s.Form.bind('submit.search', function(e){
			e.preventDefault();
			e.stopPropagation();
		});
		s.Button.attr('disabled', 'disabled');
	};

	return Form;
})();

(function($) {
	$.fn.Form = function(){
		return this.each(function(){
			var element = $(this);
			if (element.data('Form')) return;
			var Form = new Cnm.Form(this);
			element.data('Form', Form);
		});
	}
})(jQuery);

Cnm.Bootstrap.Add('Form', function(){
	$('form').Form();
});
