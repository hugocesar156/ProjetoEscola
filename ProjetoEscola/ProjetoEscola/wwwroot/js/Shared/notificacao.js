$(document).ready(function () {
    let tipo = $('#tipo-notificacao').val();
    let titulo = $('#titulo-notificacao');
    let notificacao = $('#div-notificacao');
    
    switch (tipo) {
        case 'Sucesso':
            titulo.html('Sucesso.');
            notificacao.addClass('alert-success');
            break;

        case 'Falha':
            titulo.html('Falha.');
            notificacao.addClass('alert-danger');
            break;
    }

    setTimeout(function () {
        $('#fechar-notificacao').click();
    }, 10000);
})