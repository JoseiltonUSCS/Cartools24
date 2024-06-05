$(document).ready(function () {
    var diasSelecionados = {};

    $('#calendar').datepicker({
        dateFormat: 'dd/mm/yy',
        beforeShowDay: function (date) {
            var stringDate = $.datepicker.formatDate('dd/mm/yy', date);
            if (diasSelecionados[stringDate]) {
                return [true, 'selected-day'];
            } else {
                return [true, ''];
            }
        },
        onSelect: function (dateText, inst) {
            if (Object.keys(diasSelecionados).length >= 20) {
                alert('Você só pode selecionar até 20 datas.');
                return;
            }

            if (!diasSelecionados[dateText]) {
                diasSelecionados[dateText] = [];
            }
            updateDiasSelecionados();
            $(this).datepicker('refresh');

            $('#btnSelecionarHoras').prop('disabled', Object.keys(diasSelecionados).length === 0);
            atualizarBotaoSalvar(); // Atualiza o estado do botão
        }
    });

    $('#btnSelecionarHoras').click(function () {
        $('#modalBody').empty();
        Object.keys(diasSelecionados).forEach(function (data) {
            var divData = $('<div></div>').text(data + ':');
            var adicionarHora = $('<button class="btn btn-adicionar-hora">+</button>');
            adicionarHora.click(function () {
                adicionarHoraParaData(data, $(this).parent());
            });
            divData.append(adicionarHora);
            $('#modalBody').append(divData);

            diasSelecionados[data].forEach(function (hora) {
                adicionarHoraParaData(data, $('#modalBody').find('div:contains("' + data + '")'));
                $('#modalBody').find('input[type="time"]').last().val(hora);
            });
        });
        $('#modalHoras').modal('show');
    });

    $('#btnConfirmarHoras').click(function () {
        updateDiasSelecionados();
        $('#modalHoras').modal('hide');
    });

    $('#btnSalvarDisponibilidade').click(function () {
        updateDiasSelecionados();
        $('#modalSucesso').modal('show');
    });

    $('#modalHoras .modal-header .close, #btnCancelarHoras').click(function () {
        $('#modalHoras').modal('hide');
    });

    $('#modalHoras').on('hidden.bs.modal', function () {
        updateDiasSelecionados();
    });

    // Fechar o modal ao clicar no "x" do modal de sucesso
    $('#modalSucesso .close').click(function () {
        $('#modalSucesso').modal('hide');
    });

    // Redirecionar ao clicar em "OK" do modal de sucesso
    $('#btnSucessoOK').click(function () {
        window.location.href = 'https://localhost:7283/Parceiro/ParceiroDefinirDisponibilidade';
    });

    // Função para habilitar/desabilitar o botão "Salvar Disponibilidade"
    function atualizarBotaoSalvar() {
        var temSelecao = Object.keys(diasSelecionados).length > 0 &&
            Object.values(diasSelecionados).some(horas => horas.length > 0);
        $('#btnSalvarDisponibilidade').prop('disabled', !temSelecao);
    }

    function updateDiasSelecionados() {
        $('#diasSelecionados').empty();

        Object.keys(diasSelecionados).forEach(function (data, index) {
            var horarios = diasSelecionados[data];
            var divData = $('<div></div>').addClass('data-selecionada').text(data);

            var removerData = $('<button class="remover-data">X</button>');
            removerData.click(function () {
                delete diasSelecionados[data];
                updateDiasSelecionados();
                atualizarBotaoSalvar(); // Atualiza o estado do botão
            });
            divData.append(removerData);

            horarios.forEach(function (hora) {
                var divHora = $('<div class="hora-selecionada"></div>').text(hora);
                divData.append(divHora);
            });

            $('#diasSelecionados').append(divData);
        });
    }


    function adicionarHoraParaData(data, container) {
        var inputHora = $('<input type="time" class="form-control">');
        var divHora = $('<div class="hora-selecionada"></div>');
        var inputHoraContainer = $('<div></div>').append(inputHora);
        var removerHora = $('<button class="remover-hora">Remover</button>');
        removerHora.click(function () {
            var hora = inputHora.val();
            $(this).parent().remove();
            if (diasSelecionados[data]) {
                var index = diasSelecionados[data].indexOf(hora);
                if (index !== -1) {
                    diasSelecionados[data].splice(index, 1);
                }
            }
            atualizarBotaoSalvar(); // Atualiza o estado do botão
        });
        divHora.append(inputHoraContainer).append(removerHora);
        container.after(divHora);

        inputHora.change(function () {
            var hora = $(this).val();
            if (!diasSelecionados[data]) {
                diasSelecionados[data] = [];
            }
            var index = diasSelecionados[data].indexOf(hora);
            if (index === -1 && hora !== "") {
                diasSelecionados[data].push(hora);
            }
            atualizarBotaoSalvar(); // Atualiza o estado do botão
        });
    }

});