var geral = [];

geral.ConverterDecimal = function () {

    $(".numeral").focusout(function () {

        var valor = numeral($(this).val()).format('0,0.00');
        $(this).val(valor);

    });

};

geral.ConverterValorDecimalDuasCasas = function (controle) {

    var valor = numeral($(controle).val()).format('0,0.00');
    $(controle).val(valor);

};


geral.ConverterLabelValorDecimalDuasCasas = function (controle) {

    var valor = numeral($(controle).text()).format('0,0.00');
    $(controle).text(valor);

};

$(function () {

    numeral.language('pt-br', {
        delimiters: {
            thousands: '.',
            decimal: ','
        },
        abbreviations: {
            thousand: 'mil',
            million: 'milhões',
            billion: 'b',
            trillion: 't'
        },
        ordinal: function(number) {
            return 'º';
        },
        currency: {
            symbol: 'R$'
        }
    });

    numeral.language('pt-br');

    geral.ConverterDecimal();
    
    if ($("#pessoaFisica").is(":checked"))
        $("#Documento").mask("999.999.999-99");

    if ($("#pessoaJuridica").is(":checked"))
        $("#Documento").mask("99.999.999/9999-99");


    $("input[name='pessoa']").click(function () {
        if ($(this).val() == "F")
            $("#Documento").mask("999.999.999-99");
        else
            $("#Documento").mask("99.999.999/9999-99");
    });


    $(".datepicker").datepicker({
        currentText: 'Hoje',
        monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho',
        'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun',
        'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
    });

    geral.ModalExluir = function(titulo, idExcluir, nomeExcluir) {
        
        var id = idExcluir;
        var nome = nomeExcluir;

        $('#deleteModalLabel').text(titulo);
        $('#deleteModal .modal-body input[type=hidden]').val(id);
        $('#deleteModal .modal-body span').text(nome);
        $('#deleteModal').modal('show');

    };

    geral.ModalConfirmarExluisao = function () {

        $('#deleteModalLabel').text('');
        
        $('#' + $('#deleteModal .modal-body input[type=hidden]').val()).remove();

        $('#deleteModal .modal-body span').text('');
    };

    geral.Redirect = function(url) {

        window.location = url;

    };

    geral.preloader = {
        show: function() {
            $('div[class="navbar-header"]').show();
            $('div[class="navbar-header"]').show();
        },
        hide: function() {
            $('div[class="navbar-header"]').hide();
            $('div[class="navbar-header"]').hide();
        }
    };

    //$(document).bind("ajaxSend", function () {

    //    geral.preloader.hide();
    //}).bind("ajaxComplete", function () {

    //    geral.preloader.show();

    //});

});