if (!Cnm){ var Cnm = {}; }

Cnm.LoginForm = (function(){
	function LoginForm(element){
		var s = this;
		s.Form = $(element);
		s.Type = s.Form.find('[name="Type"]');
		s.Init();
	}

	var p = LoginForm.prototype;

	p.Init = function(){
		var s = this;
		s.BindEvents().ShowType();
		s.Form.css('visibility', 'visible');
	};

	p.BindEvents = function(){
		var s = this, LoginForm = s;

		s.Form.find('h2').bind('click', function(){
			LoginForm.Form.find('h2').removeClass('selected');
			LoginForm.Type.attr('value', $(this).addClass('selected').data('type'));
			LoginForm.ShowType();
		});

		return s;
	};

	p.ShowType = function (type) {
		var s = this, Type = type || s.Type.attr('value');

		$('.login-form')
			.find('.fieldblock').hide().end()
			.find('h2').removeClass('selected');
		$('.' + Type)
			.find('.fieldblock').show().end()
			.find('h2').addClass('selected');

		return s;
	};

	p.GetParameterByName = function(name)
	{
	    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
	    var regexS = "[\\?&]" + name + "=([^&#]*)";
	    var regex = new RegExp(regexS);
	    var results = regex.exec(window.location.search);
	    if(results == null)
	        return "";
	    else
	        return decodeURIComponent(results[1].replace(/\+/g, " "));
	}

	return LoginForm;
})();

(function($) {
	$.fn.LoginForm = function(){
		return this.each(function(){
			var element = $(this);
			if (element.data('LoginForm')) return;

			var LoginForm = new Cnm.LoginForm(this);

			var type = LoginForm.GetParameterByName('type');
			if (type) {
			    $('h2').hide();
			    LoginForm.ShowType(type);
			}

			element.data('LoginForm', LoginForm);
		});
	}
})(jQuery);

Cnm.Bootstrap.Add('LoginForm', function(){
	$('.LoginForm').LoginForm();
});
