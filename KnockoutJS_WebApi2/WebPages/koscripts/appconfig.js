/*
* Script para configurações globais da aplicação. 
* Inserir em todas as páginas!
*/

// Configura o formatador de número/moedas para PT-BR
numeral.language('pt-br');

// Configura animação Ajax Loading 
$(document).ajaxSend(function () {
    // Espera 500ms antes de exibir o Ajax Loading
    setTimeout(function () {
        if ($.active > 0) {
            // TODO: fazer teste de navegador, se IE10+ ou outro browser, usar animação CSS3, senão usar svg
            $(document.body).waitMe({ effect: 'img', source: '../Content/ajax.svg' })
        }
    }, 500);
});

// Fecha Ajax Loading ao completar qualquer requisicao ajax
$(document).ajaxComplete(function () {
    if ($.active <= 1) {
        $(document.body).waitMe('hide');
    }
});

$(document).ajaxError(function () {
    $(document.body).waitMe('hide');
    alert("Erro!");
    // TODO tratar erros e exibir em Modal Box
});