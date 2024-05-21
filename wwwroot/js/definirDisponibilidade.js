var diasSelecionados = {};

$(document).ready(function () {
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

            diasSelecionados[dateText] = [];
            updateDiasSelecionados();
            $(this).datepicker('refresh');
        }
    });

    $('#btnSelecionarHoras').click(function () {
        console.log('Clicou no botão de salvar');
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

    $('#btnSalvarHoras').click(function () {

        Object.keys(diasSelecionados).forEach(function (data) {
            var disponibilidade = {
                Data: data,
                HorasDisponibilidade: diasSelecionados[data]
            };
            console.log("Passando pela disponibilidade ==> ", disponibilidade)
            console.log('Enviando requisição AJAX...');
            $.ajax({
                url: 'DefinirDisponibilidade',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(disponibilidade),
                success: function (response) {
                    console.log('Disponibilidade e horas definidas com sucesso', response);
                    if (response.success) {
                    } else {
                        console.error('Erro ao definir disponibilidade e horas');
                    }
                },
                error: function () {
                    console.log('Erro na requisição AJAX');
                    console.error('Erro ao enviar dados para o servidor');
                }
            });
        });

        // Exibir modal de sucesso
        $('#modalHoras').modal('hide');
        $('#modalSucesso').modal('show');

        // Fechar o modal e limpar os dias selecionados
        $('#modalHoras').modal('hide');
        diasSelecionados = {};
        $('#calendar').find('.selected-day').removeClass('selected-day');
        $('#column1').empty();
        $('#column2').empty();
        $('#btnSelecionarHoras').prop('disabled', Object.keys(diasSelecionados).length === 0);
    });

    // Fechar o modal de sucesso ao clicar no botão "OK"
    $('#btnSucessoOK').click(function () {
        $('#modalSucesso').modal('hide');
    });

    // Fechar o modal de erro ao clicar no botão "OK"
    $('#btnErroOK').click(function () {
        $('#modalErro').modal('hide');
    });

    // Fechar o modal ao clicar no botão "X"
    $('#modalHoras .modal-header .close').click(function () {
        $('#modalHoras').modal('hide');
    });

    $('#modalSucesso .modal-header .close').click(function () {
        $('#modalSucesso').modal('hide');
    });

    $('#modalErro .modal-header .close').click(function () {
        $('#modalErro').modal('hide');
    });

    // Fechar o modal de horas ao clicar no botão "Cancelar"
    $('#btnCancelarHoras').click(function () {
        $('#modalHoras').modal('hide');
    });
});

function updateDiasSelecionados() {
    $('#column1').empty();
    $('#column2').empty();

    var colunaAtual = 1;
    Object.keys(diasSelecionados).forEach(function (data, index) {
        var horarios = diasSelecionados[data];
        var column = colunaAtual === 1 ? $('#column1') : $('#column2');
        var item = $('<div class="data-item"></div>');
        var texto = $('<span>' + data + ': ' + horarios.join(', ') + '</span>');
        var remover = $('<button class="remover-dia">X</button>');
        remover.click(function () {
            delete diasSelecionados[data];
            updateDiasSelecionados();
        });
        item.append(texto);
        item.append(remover);
        column.append(item);

        if (colunaAtual === 1 && Object.keys(diasSelecionados).indexOf(data) === 9) {
            colunaAtual = 2;
        }
    });

    // Habilitar o botão se pelo menos uma data estiver selecionada
    $('#btnSelecionarHoras').prop('disabled', Object.keys(diasSelecionados).length === 0);
}

function adicionarHoraParaData(data, container) {
    var inputHora = $('<input type="time" class="form-control">');
    var divHora = $('<div class="hora-selecionada"></div>');
    var inputHoraContainer = $('<div></div>').append(inputHora);
    var removerHora = $('<button class="remover-hora">Remover</button>');
    removerHora.click(function () {
        $(this).parent().remove();
        var hora = inputHora.val();
        var index = diasSelecionados[data].indexOf(hora);
        if (index !== -1) {
            diasSelecionados[data].splice(index, 1);
        }
    });
    divHora.append(inputHoraContainer).append(removerHora);
    container.after(divHora);

    // Adicionar a hora à lista de horas de disponibilidade
    inputHora.change(function () {
        var hora = $(this).val();
        var index = diasSelecionados[data].indexOf(hora);
        if (index === -1) {
            diasSelecionados[data].push(hora);
        }
    });
}

