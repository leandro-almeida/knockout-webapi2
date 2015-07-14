/*
        * Parametro: objeto javascript simples com os atributos da subconta:
        *    var subconta = {
        *        id: <id>,
        *        numeroSubconta: "<nrSubconta>",
        *        numeroProcesso: "<nrProcesso>",
        *        titular: "<nomeTitular>",
        *        dataAbertura: "<data>",
        *        saldo: <valorSaldo>
        *    };
        */
function Subconta(pSubconta) {
    var self = this;
    self.id = ko.observable(pSubconta.id);
    self.numeroSubconta = ko.observable(pSubconta.numeroSubconta);
    self.numeroProcesso = ko.observable(pSubconta.numeroProcesso);
    self.titular = ko.observable(pSubconta.titular);
    self.dataAbertura = ko.observable(pSubconta.dataAbertura);
    self.saldo = ko.observable(pSubconta.saldo);

    self.dataFormatada = ko.computed(function () {
        return new Date(self.dataAbertura()).toLocaleString();
    });

    self.saldoFormatado = ko.computed(function () {
        return numeral(self.saldo()).format('$0,0.00');
    });
}

function Movimentacao(pMovimentacao) {
    var self = this;

    self.numeroSequencial = ko.observable(pMovimentacao.numeroSequencial);
    self.numeroSubconta = ko.observable(pMovimentacao.numeroSubconta);
    self.codigoMovimentacao = ko.observable(pMovimentacao.codigoMovimentacao);
    self.descricao = ko.observable(pMovimentacao.descricao);
    self.data = ko.observable(pMovimentacao.data);
    self.valor = ko.observable(pMovimentacao.valor);
    self.usuario = ko.observable(pMovimentacao.usuario);
    self.complemento = ko.observable(pMovimentacao.complemento);

    self.dataFormatada = ko.computed(function () {
        return new Date(self.data()).toLocaleString();
    });

    self.valorFormatado = ko.computed(function () {
        return numeral(self.valor()).format('$0,0.00');
    });
}

/*
* Objeto que representa o View-Model desta tela.
*/
function SubcontaViewModel() {
    var self = this;

    // campos de pesquisa
    self.pSubconta = ko.observable('');
    self.pProcesso = ko.observable('');
    self.pTitular = ko.observable('');
    self.boolExibirPainelResultado = ko.observable(false);
    self.subcontaSelecionada = ko.observable('');

    // lista de objetos retornados do servidor
    self.listaSubcontas = ko.observableArray([]);
    self.listaMovimentacoes = ko.observableArray([]);

    // pesquisa subcontas no SubcontasController
    self.GetSubcontas = function (objForm) {

        var p1 = (self.pSubconta().length == 0 ? "''" : self.pSubconta()) + '/';
        var p2 = (self.pProcesso().length == 0 ? "''" : self.pProcesso()) + '/';
        var p3 = (self.pTitular().length == 0 ? "''" : self.pTitular());

        // realiza chamada ajax
        // TODO: mudar url do browser com os parametros de pesquisa (Sammy plugin?)
        console.log('/api/Subconta/' + p1 + p2 + p3);
        //location.hash = p1 + p2 + p3;

        $.ajax('/api/Subconta/' + p1 + p2 + p3,
            {
                method: 'GET',
                dataType: "json",
                data: {},
                beforeSend: function () {
                    self.boolExibirPainelResultado(false);
                    self.subcontaSelecionada('');
                    self.listaSubcontas([]);
                },

                success: function (data) {

                    console.log(data);

                    var mappedData = ko.utils.arrayMap(data, function (item) {
                        return new Subconta(item);
                    });

                    //self.listaSubcontas.push.apply(self.listaSubcontas, mappedData);
                    self.listaSubcontas(mappedData);
                    //self.subcontaSelecionada('');
                },

                complete: function () {
                    self.boolExibirPainelResultado(true);
                    // esconder ajax loading
                }
            });
    };

    self.GetMovimentacoesSubconta = function (obj) {
        console.log("Subconta:", obj.numeroSubconta());
        console.log('/api/Movimentacao/' + obj.numeroSubconta());
        // Obtem lista de movimentações da subconta
        $.ajax('/api/Movimentacao/' + obj.numeroSubconta(),
            {
                method: 'GET',
                dataType: "json",
                data: {},
                beforeSend: function () {
                    // Limpa ultima subconta selecionada e lista de movimentações, se houver
                    self.subcontaSelecionada('');
                    self.listaMovimentacoes([]);
                },

                success: function (data) {
                    console.log(data);

                    var mappedData = ko.utils.arrayMap(data, function (item) {
                        return new Movimentacao(item);
                    });

                    self.listaMovimentacoes(mappedData);
                },

                complete: function () {
                    self.boolExibirPainelResultado(true);
                    self.subcontaSelecionada(obj.numeroSubconta());

                    $('html, body').animate({
                        scrollTop: $("#divMovimentacoes").offset().top
                    }, 2000);
                }
            });
    };

    self.LimparCampos = function () {
        self.pSubconta('');
        self.pProcesso('');
        self.pTitular('');
        self.subcontaSelecionada('');
        self.listaSubcontas([]);
        self.listaMovimentacoes([]);
        self.boolExibirPainelResultado(false);
    };

    // Função auxiliar para informar se deve habilitar botao pesquisar
    self.isExibirBotaoPesquisar = function () {
        return (self.pSubconta() || self.pProcesso() || self.pTitular());
    };

    self.isExibirPainelResultado = function () {
        return self.boolExibirPainelResultado();
    };

    self.isExibirPainelMovimentacao = function () {
        return (self.subcontaSelecionada().length > 0);
    };
}

$(document).ready(function () {
    ko.applyBindings(new SubcontaViewModel());
});