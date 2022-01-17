$(document).ready(function () {
    $('.cep').mask('00000-000');
    $('.cpf').mask('000.000.000-00');
    $('.num-2').mask('00');
    $('.num-4').mask('0000');
    $('.telefone').mask('00 000000000');

    $('.select-2').each(function () {
        ConfigurarSeletor($(this))
    })
})

function BuscarEndereco(cep) {
    cep = cep.replace('-', '');

    if (cep.length === 8) {
        $.getJSON(`https://viacep.com.br/ws/${cep}/json/?callback=?`, function (endereco) {
            if (!('erro' in endereco)) {
                $('#logradouro').val(endereco.logradouro);
                $('#bairro').val(endereco.bairro);
                $('#cidade').val(endereco.localidade);
                $('#numero').val('');

                $('#uf').attr('data-value', endereco.uf);
                $('#uf').val(endereco.uf);
                ConfigurarSeletor($('#uf'));
            }
        });
    }
}

function ConfigurarSeletor(elemento) {
    elemento.select2({
        placeholder: elemento.attr('data-title'),
        matcher: function (params, data) {
            $('.select2-search__field').addClass('form-control');
            $('.select2-search__field').attr('placeholder', 'Buscar');

            if ($.trim(params.term) === '')
                return data;

            params.term = params.term.toLowerCase();
            let modifiedData = $.extend({}, data, true);

            if (data.text.toLowerCase().includes(params.term))
                return modifiedData;

            return null;
        },
        language: {
            noResults: function () {
                return "";
            }
        }
    });
   
    if (elemento.attr('data-value') == '')
        elemento.select2('val', '-1');
}