function copyFormData(jFormFrom, jFormTo) {
    var jFieldsFrom = jFormFrom.find('input');
    var jFieldsTo = jFormTo.find('input');
    jFieldsFrom.each(function () {
        var jFieldTo = jFieldsTo.filter('input[name=' + $(this).attr('name') + ']');

        if ($(this).is(':checkbox')) {
            if ($(this).is(':checked')) {
                jFieldTo.attr('checked', true);
            } else {
                jFieldTo.removeAttr('checked');
            }
        } else {
            jFieldTo.val($(this).val());
        }
    });
}

$(function () {

    $('#main-tabs, #user-tabs').tabs();

    $('button, #login-info a').button();

    $('table.clickable tbody tr').click(function () {
        $(this).siblings().removeClass('active');
        $(this).addClass('active');
    });

    var jDialog = $('#dialog-form');
    var jProfileForm = $('#profile-form');
    var jUpdateProfileForm = $('#update-profile-form');

    jDialog.dialog({
        autoOpen: false,
        height: 420,
        width: 410,
        modal: true,
        buttons: {
            Ok: function () {
                jUpdateProfileForm.submit();
            },
            Cancel: function () {
                $(this).dialog('close');
            }
        },
        close: function () {
            jUpdateProfileForm.find('input').removeClass('error');
            jUpdateProfileForm.find('label.error').hide();
        }
    });

    $('#profile-update').click(function () {
        copyFormData($('#profile-form'), jUpdateProfileForm);
        jDialog.dialog('open');
        return false;
    });

    jUpdateProfileForm.validate({
        submitHandler: function (form) {
            copyFormData($(form), jProfileForm);
            jDialog.dialog('close');
        }
    });
});

(function () {
    var root = this;

    define3rdPartyModules();
    loadPluginsAndBoot();

    function define3rdPartyModules() {
        // These are already loaded via bundles. 
        // We define them and put them in the root object.
        debugger;
        define('jquery', [], function () { return root.jQuery; });
        define('ko', [], function () { return root.ko; });
        define('amplify', [], function () { return root.amplify; });
        define('infuser', [], function () { return root.infuser; });
        define('moment', [], function () { return root.moment; });
        define('sammy', [], function () { return root.Sammy; });
        define('toastr', [], function () { return root.toastr; });
        define('underscore', [], function () { return root._; });
    }

    function loadPluginsAndBoot() {
        // Plugins must be loaded after jQuery and Knockout, 
        // since they depend on them.
        requirejs([
                'ko.bindingHandlers',
                'ko.debug.helpers'
        ], boot);
    }

    function boot() {
        require(['bootstrapper'], function (bs) { bs.run(); });
    }
})();