var geral = [];

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

    $(".numeral").focusout(function() {
        
        var valor = numeral($(this).val()).format('0,0.00');
        $(this).val(valor);

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

});